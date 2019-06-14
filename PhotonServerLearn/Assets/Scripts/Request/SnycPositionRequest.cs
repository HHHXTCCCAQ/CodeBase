using System.Collections;
using System.Collections.Generic;
using Common;
using ExitGames.Client.Photon;
using UnityEngine;
//love you into disease, but no medicine can.
//Created By xxx
public class SnycPositionRequest : Request
{
    [HideInInspector]
    public Vector3 position;
    public override void DefaultRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        //data.Add((byte)ParameterCode.Position, new Vector3Data() { x = position.x, y = position.y, z = position.z });
        data.Add((byte)ParameterCode.X, position.x);
        data.Add((byte)ParameterCode.Y, position.y);
        data.Add((byte)ParameterCode.Z, position.z);
        PhotonEngine.Peer.OpCustom((byte)OpCode, data, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }
}
