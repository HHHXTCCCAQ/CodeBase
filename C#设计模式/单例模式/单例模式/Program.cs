using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式 {
    class Program {
        static void Main(string[] args) {

            Singleton t1=Singleton.Instance;
            Singleton t2=Singleton.Instance;
            Console.WriteLine(t1==t2);
            Console.ReadKey();
        }
    }
}
