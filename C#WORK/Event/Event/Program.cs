using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var e = new Num(10);
            e.SetValue(100);
            e.ChangeNum += new Num.NumMainHandler(Num.EventFired);
            e.SetValue(20);
            Console.ReadLine();
        }
    }
    class Num {

        private int value;
        public delegate void NumMainHandler();
        public event NumMainHandler ChangeNum;

        public Num(int n)
        {
            SetValue(n);
      }
        public static void EventFired()
        {
            Console.WriteLine("Binded Event fired");
        }
        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("Event fired");
            }
        }
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }
}
