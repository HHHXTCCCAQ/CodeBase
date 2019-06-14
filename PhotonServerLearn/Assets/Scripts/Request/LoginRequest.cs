using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common;
//love you into disease, but no medicine can.
//Created By xxx
public class LoginRequest : Request
{
    [HideInInspector]
    public string Username;
    [HideInInspector]
    public string Password;

    private LoginPanel loginPanel;
    public  override void Start()
    {
        base.Start();
        loginPanel = GetComponent<LoginPanel>();
    }
    public override void DefaultRequest()
    {      
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.Username, Username);
        data.Add((byte)ParameterCode.Password, Password);
        PhotonEngine.Peer.OpCustom((byte)OpCode,data,true); 
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
        if (returnCode==ReturnCode.Success)
        {
            PhotonEngine.username = Username;
        }
        //Debug.Log(operationResponse.ReturnCode);
        loginPanel.OnLogainResponse(returnCode);
    }
}
