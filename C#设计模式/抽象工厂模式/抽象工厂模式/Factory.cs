using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
namespace 抽象工厂模式 {
    class Factory : abstractFactory {
        //道路
        public class  Road:abstractFactory.Road {
            public override void Test()
            {
                Console.WriteLine("Road");
                Console.ReadKey();
            }
        }
        //房屋
        public class Building :abstractFactory.Building{

        }
        //地道
        public class Tunnel:abstractFactory.Tunnel {

        }
        //丛林
        public class Jungle:abstractFactory.Jungle {

        }

        public class FacilitiesFactory:abstractFactory.FacilitiesFactory {
            public override abstractFactory.Road CreateRoad() {    
                return new Road();
            }

            public override abstractFactory.Building CreateBuilding()
            {
                return  new Building();
            }

            public override abstractFactory.Tunnel CreateTunnel()
            {
                return new Tunnel();
            }

            public override abstractFactory.Jungle CreateJungle()
            {
                return new Jungle();
            }
        }

    }
}
