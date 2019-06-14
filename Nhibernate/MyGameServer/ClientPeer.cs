using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using Common.Tools;
using Common;
using MyGameServer.Handler;
namespace MyGameServer
{
    public class ClientPeer : Photon.SocketServer.ClientPeer
    {
        public float x, y, z;
        public string username;
        public ClientPeer(InitRequest initRequest) : base(initRequest)
        {
            
        } 
        //断开链接的后续工作
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            MyGameServer.Instance.clientPeers.Remove(this);
        }
        //处理客户端的请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            BaseHandler handler = DictTool.GetValue<OperationCode, BaseHandler>(MyGameServer.Instance.handlerDict,(OperationCode)operationRequest.OperationCode);
            if (handler!=null)
            {
                handler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            else
            {
                BaseHandler defaultHandler = DictTool.GetValue<OperationCode, BaseHandler>(MyGameServer.Instance.handlerDict, OperationCode.Default);
                defaultHandler.OnOperationRequest(operationRequest, sendParameters, this);
            }
        }
    }
}
