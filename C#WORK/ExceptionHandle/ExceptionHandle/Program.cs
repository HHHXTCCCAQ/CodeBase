using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            try
            {
                int y = 100 / x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Anyway,we arrive here!");
            }
            //throw new NullReferenceException();
        }
            
    }
}
