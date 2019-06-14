using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        delegate int NumberChanger(int n);
        static  int num =10;
        static void Main(string[] args)
        {
            //System.Delegate
            NumberChanger nc1 = new NumberChanger(AddNum);
            nc1(10);//委托调用静态方法
            Console.WriteLine(" Value of num:{0}", num);


            //委托调用实例化方法

            MyClass mc = new MyClass();
            NumberChanger nc2 = new NumberChanger(mc.AddNum);

            Console.WriteLine(" Value of num:{0}", nc2(20));

            Console.ReadLine();

        }
        
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
    }
   class MyClass
   {
       private int num = 10;
       public  int AddNum(int p)
       {
           num += p;
           return num;
       }
   }
}
