using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程 {
    class Program {
        //一般会为比较耗时的操作开启单独的线程去执行，比如下载操作
        static void Test(int i) {
            Console.WriteLine("test" + i);
        }

        static int Test1(int i) {
            Console.WriteLine("test" + i);
            Thread.Sleep(100);//休眠当前线程
            return 100;

        }

        static void Main(string[] args) {//在main线程中执行 一个线程里面语句的执行 是从上到下的
            //1 通过委托开启一个线程
            //没有返回值的委托
            //Action<int> a = Test;
            //a.BeginInvoke(100, null, null);//开启一个新的线程去执行a所引用的方法


            #region 检测线程状态的几个方法

            //方法一
            //Func<int, int> b = Test1;
            //IAsyncResult ar = b.BeginInvoke(100, null, null);
            //IAsyncResult可以取得当前线程的状态
            //可以认为线程是同时执行的（异步执行）
            //while (ar.IsCompleted == false) {//如果当前线程没有执行完毕
            //    Console.WriteLine("....");
            //}
            //int res =b.EndInvoke(ar);
            //Console.WriteLine(res);
            //Console.ReadKey();



            //方法二
            // 
            //
            //Func<int, int> b = Test1;
            //IAsyncResult ar = b.BeginInvoke(100, null, null);
            //bool isEnd=ar.AsyncWaitHandle.WaitOne(1000);//一千毫秒表示超时时间，如果等待1000毫秒，线程还没结束返回false 如果结束了则返回true
            //if (isEnd)
            //{
            //    int res = b.EndInvoke(ar);
            //    Console.WriteLine(res);
            //}
            //Console.ReadKey();


            //方法三 
            //通过回调 检测线程结束
            //BeginInvoke的后两个参数的解释：
            //倒数第二个：是一个委托类型的参数，表示回调函数（当线程结束的时候会调用这个委托指向的方法）
            //倒数第一个参数，用来给回调函数传递数据
            Func<int, int> b = Test1;
            //IAsyncResult ar = b.BeginInvoke(100, OnCallBack, b);

            //修改成Lambda表达式
            b.BeginInvoke(100, ar => {
                int res = b.EndInvoke(ar);
                Console.WriteLine(res + "在Lambda表达式中取得");
            }, null);
            Console.ReadKey(); 
            #endregion
        }

        static void OnCallBack(IAsyncResult ar) {
            Func<int, int> a = ar.AsyncState as Func<int, int>;
            int res = a.EndInvoke(ar);
            Console.WriteLine(res+"在回调函数中取得结果");
           // Console.WriteLine("子线程结束");
        }

        private static int Test1() {
            throw new NotImplementedException();
        }
    }
}
