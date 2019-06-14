using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json操作 {
    class Player
    {
        public string name { get; set; }
        public int level{ get; set; }
        public int age{ get; set; }
        public List<Skill> skillList { get; set; }

        public override string ToString()
        {
            return string.Format("name: {0}, level: {1}, age: {2}, skillList: {3}", name, level, age, skillList);
        }
    }
}
