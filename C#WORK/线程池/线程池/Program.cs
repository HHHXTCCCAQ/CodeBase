﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池 {
    class Program {
        static void ThreadMethod(object state)
        {
            Console.WriteLine("线程开始"+Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("线程结束");
            
        }
        static void Main(string[] args)
        {
            //通过线程池开启线程
            ThreadPool.QueueUserWorkItem(ThreadMethod);//开启一个工作线程
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            ThreadPool.QueueUserWorkItem(ThreadMethod);
            Console.ReadKey();
        }
    }
}
