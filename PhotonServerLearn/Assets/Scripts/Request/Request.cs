using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using ExitGames.Client.Photon;
//love you into disease, but no medicine can.
//Created By xxx
public abstract class Request : MonoBehaviour
{
    public OperationCode OpCode;
    public abstract void DefaultRequest();
    public abstract void OnOperationResponse(OperationResponse operationResponse);

    public virtual void Start()
    {
        PhotonEngine._instance.AddRequest(this);
    }
    private void OnDestroy()
    {
        PhotonEngine._instance.RemoveRequest(this);
    }
}
