using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线程问题_争用条件 {
    class MythreadObject {
        private int State = 5;

        public void ChangeState() {
            State++;
            if (State == 5) {
                Console.WriteLine("state=5");
            }
            State = 5;
        }
    }
}
