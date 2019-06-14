using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;
using System.Collections.Generic;
using System.IO;
using Common;
using MyGameServer.Handler;
using MyGameServer.Threads;
namespace MyGameServer
{
    //所有的server 端  主类都继承ApplicationBase
    class MyGameServer : ApplicationBase
    {
        public  static readonly ILogger log = LogManager.GetCurrentClassLogger();
        public static MyGameServer Instance {
            get;
            private set;
        }
        public Dictionary<OperationCode, BaseHandler> handlerDict = new Dictionary<OperationCode, BaseHandler>();
        public List<ClientPeer> clientPeers = new List<ClientPeer>();//可以访问所有客户端的peer
        //当一个客户端请求链接的
        private SyncPositionThread positionThread = new SyncPositionThread();
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {

            log.Info("一个客户端链接了");
            ClientPeer peer = new ClientPeer(initRequest);
            clientPeers.Add(peer);
            return peer;
        }

        //初始化
        protected override void Setup()
        {
            Instance = this;
            //日志的初始化
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "bin_Win64","log");
            FileInfo configfileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if (configfileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                XmlConfigurator.ConfigureAndWatch(configfileInfo);//让log4net插件读取配置文件
            }
            log.Info("SetUp  comm......");
            InitHandler();
            positionThread.Run();
        }
        public void InitHandler() {
            LoginHander loginHander = new LoginHander();
            handlerDict.Add(loginHander.opCode, loginHander);
            DefaultHandler defaultHandler = new DefaultHandler();
            handlerDict.Add(defaultHandler.opCode, defaultHandler);
            RegisterHandler registerHandler = new RegisterHandler();
            handlerDict.Add(registerHandler.opCode, registerHandler);
            SyncPositionHandler syncPositionHandler = new SyncPositionHandler();
            handlerDict.Add(syncPositionHandler.opCode, syncPositionHandler);
            SyncPlayerHandler syncPlayerHandler = new SyncPlayerHandler();
            handlerDict.Add(syncPlayerHandler.opCode, syncPlayerHandler);
        }


        //关闭
        protected override void TearDown()
        {
            positionThread.Stop();
            log.Info("服务器关闭了");
        }
    }
}
