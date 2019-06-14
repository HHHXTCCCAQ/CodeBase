using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 通过任务开启线程 {
    class Program {
        static void ThreadMethod() {
            Console.WriteLine("任务开始");
            Thread.Sleep(2000);
            Console.WriteLine("任务结束");

        }

        static void Main(string[] args) {

            //通过任务开启线程的方法
            //通过Task开启
            //Task t =new Task(ThreadMethod);//传递一个需要线程执行的方法
            //t.Start();


            //通过TaskFactory开启
            TaskFactory tf = new TaskFactory();
            Task t = tf.StartNew(ThreadMethod);
            Console.WriteLine("Main");
            Console.ReadKey();
        }
    }
}
