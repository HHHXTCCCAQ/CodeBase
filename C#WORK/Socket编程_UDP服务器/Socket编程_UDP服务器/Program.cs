using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket编程_UDP服务器 {
    
    class Program
    {
        private static Socket udpSocket;
        static void Main(string[] args) {
            //1.创建Socket
             udpSocket=new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            //2.绑定ip和端口号
            udpSocket.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.101"),7788));
            //3.接收数据
           new Thread(ReceiveMessage){IsBackground = true}.Start();
           // udpSocket.Close();
            Console.ReadKey();
        }

        static void ReceiveMessage()
        {
            while (true) {
                byte[] data = new byte[1024];
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                int length = udpSocket.ReceiveFrom(data, ref remoteEndPoint);//这个方法会把从那个IP和端口号接收的数据（数据来源）放到第二个参数上
                string message = Encoding.UTF8.GetString(data, 0, length);
                Console.WriteLine("从IP" + (remoteEndPoint as IPEndPoint).Address.ToString() + ":" + (remoteEndPoint as IPEndPoint).Port + "接收了数据：" + message);
                
            }
            
        }
    }
}
