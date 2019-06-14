using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json操作 {
    class Skill
    {
        public int id;
        public int damage;
        public string name;

        public override string ToString()
        {
            return string.Format("Id: {0}, Damage: {1}, Name: {2}", id, damage, name);
        }
    }

   
}
