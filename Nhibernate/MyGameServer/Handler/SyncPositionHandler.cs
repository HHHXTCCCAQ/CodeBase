using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using Common;
using Common.Tools;
namespace MyGameServer.Handler
{
    class SyncPositionHandler : BaseHandler

    {
        public SyncPositionHandler()
        {
            opCode = OperationCode.SyncPostion;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            peer. x = (float)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.X);
            peer. y = (float)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Y);
            peer. z = (float)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Z);
            
            //MyGameServer.log.Info(x+ "..." +y + "..." +  z);
        }
    }
}
