using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
namespace 抽象工厂模式 {
    //抽象工厂
    class abstractFactory {
        //道路
        public abstract class Road {
            public virtual void Test() {

            }
        }
        //房屋
        public abstract class Building {

        }
        //地道 
        public abstract class Tunnel {

        }
        //丛林
        public abstract class Jungle {

        }

        public abstract class FacilitiesFactory {
            public abstract Road CreateRoad();
            public abstract Building CreateBuilding();
            public abstract Tunnel CreateTunnel();
            public abstract Jungle CreateJungle();
        }


    }
}
