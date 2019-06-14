using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Cat
    {
        private string name;
        private string color;
        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }
        /// <summary>
        /// 猫的状态发生改变（被观察者的状态发生改变）
        /// </summary>
        //public void CatComing(Mouse mouse1,Mouse mouse2)
        //{
        //    Console.WriteLine(color+"颜色的"+name+"猫来了,喵喵喵~");
        //    mouse1.RanAway();
        //    mouse2.RanAway();
        //}
        public void CatComing()
        {
            Console.WriteLine(color + "颜色的" + name + "猫来了,喵喵喵~");
            if (Catcome != null)
            {
                Catcome();
            }
        }
        //public Action Catcome;//声明一个委托
        public event Action Catcome;//声明一个事件   事件只能在类的内部调用 ，不能在外部调用
    }
}
