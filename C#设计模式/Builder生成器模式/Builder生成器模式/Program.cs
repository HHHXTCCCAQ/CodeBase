using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder生成器模式 {
    class Program {
        static void Main(string[] args)
        {
            GameMangaer.CreatHouse(new BuilderOldHouse());
        }
    }
}
