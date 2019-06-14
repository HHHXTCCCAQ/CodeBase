using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
namespace Builder生成器模式 {
    public abstract class Builder
    {
        public abstract void BulidDoor();
        public abstract void BulidWindows();
        public abstract void BulidWall();
        public abstract void BulidFloor();
        public abstract House GetHouse();
    }

    public abstract class House
    {
        
    }
}
