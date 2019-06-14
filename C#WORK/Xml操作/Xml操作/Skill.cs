using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml操作 {
    /// <summary>
    /// 技能类
    /// </summary>
    class Skill {
        public int ID
        {
            get; set; }
        public string Name { get; set; }
        public string Lang { get; set; }
        public float Damage { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Lang: {2}, Damage: {3}", ID, Name, Lang, Damage);
        }
    }
}
