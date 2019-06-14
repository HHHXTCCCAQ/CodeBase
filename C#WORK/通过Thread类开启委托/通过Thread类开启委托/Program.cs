using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 通过Thread类开启委托 {
    class Program {
        //给Thread 传递参数必须使用object类型
        static void DownLoadFile(object fileName) {
            //Thread.CurrentThread.ManagedThreadId  获得当前线程的ID
            Console.WriteLine("开始下载:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成"+fileName);
        }

        static void Main(string[] args) {

            #region 如何开启线程
            //Thread  t =new Thread(DownLoadFile);//创建出来Thread对象，这个线程并没有启动
            //t.Start();//开始执行线程
            //Console.WriteLine("Main");

            //修改成Lambda 表达式
            //Thread t = new Thread(() => {
            //    Console.WriteLine("开始下载:" + Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(2000);
            //    Console.WriteLine("下载完成");
            //});
            //t.Start(); 
            #endregion

            #region 给线程传递参数的方法
            //给线程传递参数
            //方法一
            //
            //
            //Thread t = new Thread(DownLoadFile);//创建出来Thread对象，这个线程并没有启动
            //t.Start("xxx.avi");//开始执行线程
            //Console.WriteLine("Main");
            //Console.ReadKey();


            //方法二
            //单独创建一个Thread 类
            MyThread my = new MyThread("xxx.avi", "http://www.xxx.bbs");
            Thread t = new Thread(my.DownFile);//构造一个Thread对象的时候，可以传递一个静态方法也可以，传递一个对象的普通方法
            t.Start();
            Console.ReadKey();
            #endregion
        }
    }
}
