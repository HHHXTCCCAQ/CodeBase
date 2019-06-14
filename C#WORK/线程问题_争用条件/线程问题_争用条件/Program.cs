using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程问题_争用条件 {
    class Program {

        //很多线程访问一个变量的时候回出现冲突

        static void ChangeState(object o)
        {
            MythreadObject m= o as MythreadObject;
            while (true)
            {
                lock (m)//向系统申请是否可以锁定M对象
                        //如果m对象没有被锁定，那么可以，如果m对象被锁定，那么这个语句会暂停，直到申请到m对象
                {
                    m.ChangeState();//同一个时刻，只有一个线程在执行这个方法
                }//释放对m的锁定
                
            }
        }
        static void Main(string[] args) {
            MythreadObject m=new MythreadObject();
            Thread t =new Thread(ChangeState);
            t.Start(m);
            new Thread(ChangeState).Start(m);
            Console.ReadKey();
        }
    }
}
