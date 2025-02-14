﻿using System.Collections;
using System.Collections.Generic;
using Common;
using ExitGames.Client.Photon;
using UnityEngine;
//love you into disease, but no medicine can.
//Created By xxx
public class RegisterRequest : Request
{
    [HideInInspector]
    public string username;
    [HideInInspector]
    public string password;
    private RegisterPanel registerPanel;

    public override void Start()
    {
        base.Start();
        registerPanel = GetComponent<RegisterPanel>();
    }
    public override void DefaultRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.Username, username);
        data.Add((byte)ParameterCode.Password, password);
        PhotonEngine.Peer.OpCustom((byte)OpCode, data, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
        registerPanel.OnRegisterResponse(returnCode);
    }
}
