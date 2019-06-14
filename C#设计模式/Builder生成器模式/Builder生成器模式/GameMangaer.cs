using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


//Wait for me, I don't want to let you down
//love you into disease, but no medicine can.
//Created By HeXiaoTao
namespace Builder生成器模式 {
    class GameMangaer {
        public static House CreatHouse(Builder builder) {
            builder.BulidDoor();
            builder.BulidWall();
            builder.BulidWall();
            builder.BulidFloor();
            return builder.GetHouse();
        }
    }
}
