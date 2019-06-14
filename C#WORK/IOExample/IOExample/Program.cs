using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOExample
{
    class Program
    {
        static void Main(string[] args)
        {
           // File.Exists(@"C:\HelloIO\IO.txt");//函数的作用 ：在上面的路径是否存在这个文件
           // Directory.Exists(@"c:\");//文件夹是否存在

            string path = "."; //当前路径
            if (args.Length > 0)
            {
               // Console.WriteLine("{0,-12:NO}{1,-20:g} {2}");
               
                if (Directory.Exists(args[0]))
                {
                    path = args[0];
                }
                else 
                {
                Console.WriteLine("{0} not found ; using current directory:",args[0]);
                }
             
            }
            DirectoryInfo dir = new DirectoryInfo(path);//可以实例化的 文件夹 提供实例化之后的方法
            foreach (FileInfo f in dir.GetFiles("*.exe"))
            {
                string name = f.Name;
                long size = f.Length;
                DateTime Creattime = f.CreationTime;

                Console.WriteLine("{0,-12:N0} {1,-20:g} {2}", size, Creattime, name);
            }
               
            Console.ReadLine();
        }
    }
}
