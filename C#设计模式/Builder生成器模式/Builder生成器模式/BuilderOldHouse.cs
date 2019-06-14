using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
namespace Builder生成器模式 {
    class BuilderOldHouse : Builder {
        public override void BulidDoor() {
          
        }
        public override void BulidWindows() {
          
        }
        public override void BulidWall()
        {

        }
        public override void BulidFloor()
        {
        }

        public override House GetHouse() {
            Console.WriteLine("123");
            Console.ReadKey();
            return new OldHouse();
            
        }
    }

    public class OldHouse : House {

    }
}
