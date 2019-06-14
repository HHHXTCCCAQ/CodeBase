using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
namespace 单例模式 {
    /// <summary>
    /// 单线程
    /// </summary>
    class Singleton {
        private static Singleton instance;
        private Singleton() { }

        public static Singleton Instance {
            get {
                if (instance == null) {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
    /// <summary>
    /// 多线程单例模式
    /// </summary>
    class Singleton1 {
        private static volatile Singleton1 instance;
        private static object lockHelper = new object();
        private Singleton1() { }

        public static Singleton1 Instance {
            get {
                if (instance == null) {
                    lock (lockHelper) {
                        if (instance == null) {
                            instance = new Singleton1();
                        }
                    }

                }
                return instance;
            }
        }
    }
}
