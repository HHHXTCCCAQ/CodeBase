using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socket_TCP协议 {
    class Program {
        static void Main(string[] args) {
            //1. 创建socket
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 2.绑定ip跟端口号  绑定本机ip：192.168.1.88
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 1, 88 });
            EndPoint point = new IPEndPoint(ipAddress, 7788);//ipendpoint 是对ip+端口做了一层封装的类
            tcpServer.Bind(point);//向操作系统申请一个可用的ip跟端口用来做通讯
            //3.开始监听 ，等待客户端连接
            tcpServer.Listen(100);//参数是最大连接数
            Console.WriteLine("开始监听");
            Socket clientSocket = tcpServer.Accept();//暂停当前线程，直到有一个客户端连接过来，之后进行下面的代码
            Console.WriteLine("连接到一个客户端");
            
            //使用返回的Socket跟客户端通讯
            string message = "hello caq";
            byte[] data = Encoding.UTF8.GetBytes(message);//对字符串做编码，的到一个字符串的字节数组
            clientSocket.Send(data);
            Console.WriteLine("向客户的发送数据");
            byte[] data2 = new byte[1024];//创建一个字节数组用来接收客户端发送过来了的数据
            int length = clientSocket.Receive(data2);
            string message2 = Encoding.UTF8.GetString(data2, 0, length);
            Console.WriteLine("接收到从客户端发送的消息"+message2);
            Console.ReadKey();
        }
    }
}
