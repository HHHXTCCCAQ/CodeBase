using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
namespace 抽象工厂模式 {
    /// <summary>
    /// 客户程序
    /// </summary>
    class GameManager {
        private abstractFactory.FacilitiesFactory facilitiesFactory;
        public GameManager(abstractFactory.FacilitiesFactory facilitiesFactory) {
            this.facilitiesFactory = facilitiesFactory;
        }
        public void BulidGameFacilties() {
            abstractFactory.Road road = facilitiesFactory.CreateRoad();
            road.Test();
            abstractFactory.Building building = facilitiesFactory.CreateBuilding();
        }
    }
}
