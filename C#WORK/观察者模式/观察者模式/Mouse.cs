using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Mouse
    {
        private string color;
        private string name;
        
        public Mouse(string name, string color,Cat cat)
        {
            this.color = color;
            this.name = name;
            cat.Catcome += this.RanAway;//把自身的逃跑方法注册进入猫里面

        }
        public void RanAway()
        {
            Console.WriteLine(color+"颜色的老鼠"+name+"说：猫来了  ！！！赶快跑呀");
            
        }
    }
}
