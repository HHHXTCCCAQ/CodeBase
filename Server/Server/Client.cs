using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{/// <summary>
 /// 用来跟客户端通信
 /// </summary>
    class Client
    {
        private Socket ClientSocket;
        private Thread t;
        private byte[] dataBytes = new byte[1024];//数据容器


        public Client(Socket s)
        {
            ClientSocket = s;
            //启动一个线程 处理客户端的数据接收
            t = new Thread(ReceiveMessage);
            t.Start();
        }

        private void ReceiveMessage()
        {
            //一直接收客户端的数据
            while (true)
            {
                //在接受数据之前判断一下socket连接是否断开
                if (ClientSocket.Poll(10, SelectMode.SelectRead))
                {

                    break;//跳出循环 终止线程
                }
                int length = ClientSocket.Receive(dataBytes);
                string message = Encoding.UTF8.GetString(dataBytes, 0, length);
                //TODO：接收到数据的时候 把这个数据分发到客户端
                //广播这个消息
                Program.BroadcastMessage(message);
                Console.WriteLine("收到了消息" + message);

            }
        }

        public void SendMessage(string message)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(message);
            ClientSocket.Send(dataBytes);
        }

        public bool Connected
        {
            get { return ClientSocket.Connected; }
        }
    }
}
