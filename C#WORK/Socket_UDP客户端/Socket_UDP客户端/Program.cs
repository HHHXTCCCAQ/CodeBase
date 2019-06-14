﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socket_UDP客户端 {
    class Program {
        static void Main(string[] args) {
            //创建Socket
            Socket udpClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //发送数据
            while (true)
            {
                EndPoint serverPoint = new IPEndPoint(IPAddress.Parse("192.168.1.101"), 7788);
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.SendTo(data, serverPoint);
            }
           
            udpClient.Close();
            Console.ReadKey();
        }
    }

}
