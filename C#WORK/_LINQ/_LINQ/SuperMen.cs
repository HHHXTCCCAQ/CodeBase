using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LINQ
{
    class SuperMen
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string MenPai { get; set; }
        public string Kongfu { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, age: {2}, MenPai: {3}, Kongfu: {4}, Level: {5}", ID, Name, age, MenPai, Kongfu, Level);
        }
    }
}
