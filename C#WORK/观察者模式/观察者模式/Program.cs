using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Program
    {


        static void Main(string[] args)
        {
            Cat cat = new Cat("加菲猫", "红");
            //  Mouse mouse1 = new Mouse("杰瑞", "白");
            // cat.Catcome += mouse1.RanAway;
            //  Mouse mouse2 = new Mouse("米奇", "黑");
            // cat.Catcome += mouse2.RanAway;

            Mouse mouse1 = new Mouse("杰瑞", "白", cat);
            Mouse mouse2 = new Mouse("米奇", "黑", cat);
            // cat.CatComing(mouse1 ,mouse2);  猫的状态发生改变
            cat.CatComing();
            Console.ReadKey();
        }
       
    }
}
