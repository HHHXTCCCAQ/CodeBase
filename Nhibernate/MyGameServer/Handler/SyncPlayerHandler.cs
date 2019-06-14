using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using Common;
using System.Xml.Serialization;
using System.IO;
namespace MyGameServer.Handler
{
    class SyncPlayerHandler : BaseHandler
    {
        public SyncPlayerHandler()
        {
            opCode = OperationCode.SyncPlayer;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            //取得在线玩家用户名
            List<string> usernameList = new List<string>();
            foreach (ClientPeer itemPeer in MyGameServer.Instance.clientPeers)
            {
                if (string.IsNullOrEmpty(itemPeer.username) == false && itemPeer != peer)
                {
                    usernameList.Add(itemPeer.username);
                }

            }
            StringWriter sw = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            serializer.Serialize(sw, usernameList);
            sw.Close();
            string usernameListString = sw.ToString();
            
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add((byte)ParameterCode.UsernameList, usernameListString);
            OperationResponse operationResponse = new OperationResponse(operationRequest.OperationCode);
            operationResponse.Parameters = data;
            peer.SendOperationResponse(operationResponse, sendParameters);

            //告诉其他客户端 有新的客户端加入
            foreach (ClientPeer itemPeer in MyGameServer.Instance.clientPeers)
            {
                if (string.IsNullOrEmpty(itemPeer.username) == false && itemPeer != peer)
                {
                    EventData ed = new EventData((byte)EventCode.NewPlayer);
                    Dictionary<byte, object> eventdata = new Dictionary<byte, object>();
                    eventdata.Add((byte)ParameterCode.Username, peer.username);
                    ed.Parameters = eventdata;
                    itemPeer.SendEvent(ed, sendParameters);
                }
            }
        }
    }
}
