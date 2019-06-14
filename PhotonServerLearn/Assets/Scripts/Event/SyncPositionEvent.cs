using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common;
using Common.Tools;
using System.IO;
using System.Xml.Serialization;
//love you into disease, but no medicine can.
//Created By xxx
public class SyncPositionEvent : BaseEvent
{
    private Player player;
    public override void Start()
    {
        base.Start();
        player=GetComponent<Player>();
    }
    public override void OnEvent(EventData eventData)
    {
        string playerDataListString = (string)DictTool.GetValue<byte, object>(eventData.Parameters, (byte)ParameterCode.PlayerDataList);
        using (StringReader reader = new StringReader(playerDataListString))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PlayerData>));
            List<PlayerData> playerDatas = (List<PlayerData>)serializer.Deserialize(reader);
            player.OnSyncPositionEvent(playerDatas);
        }
    }

}
