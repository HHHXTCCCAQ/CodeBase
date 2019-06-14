using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common;
using Common.Tools;
using System.Xml.Serialization;
using System.IO;
//love you into disease, but no medicine can.
//Created By xxx
public class SyncPlayerRequest : Request
{
    private Player player;
    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }
    public override void DefaultRequest()
    {
        PhotonEngine.Peer.OpCustom((byte)OpCode, null, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {

        string usernamelistString = (string)DictTool.GetValue<byte, object>(operationResponse.Parameters, (byte)ParameterCode.UsernameList);

        using (StringReader reader = new StringReader(usernamelistString))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            List<string> usernameList = (List<string>)serializer.Deserialize(reader);
            player.OnSyncPlayerResponse(usernameList);
        }


    }
}
