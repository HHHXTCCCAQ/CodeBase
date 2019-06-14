using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOWrite
{
    class Program
    {
        private const string FILE_NAME = "Test.txt";
        static void Main(string[] args)
        {
        //    if (File.Exists(FILE_NAME))
        //    {
        //        Console.WriteLine("{0}存在", FILE_NAME);
        //        Console.ReadLine();
        //        return;
        //    }
        //    //新建文件
            //FileStream fs = new FileStream(FILE_NAME, FileMode.Create);
            //BinaryWriter w = new BinaryWriter(fs);
            //for (int i = 0; i < 11; i++)
            //{
            //    w.Write("a");
            //}
            //w.Close();
            //fs.Close();
            //


            
            using(StreamWriter h =File .AppendText("Test.txt")) //变量 只在using 下面使用  用完会销毁  文件读写  数据库连接  尽量使用 using 写法
            {
                Log("11111111111", h);
                Log("htlovecq", h);
                h.Close();

            }


        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="LogMessage"> 文件内容</param>
        /// <param name="w">文件在的地方</param>
        public static void Log(string LogMessage,TextWriter w )
        {
            w.Write("\r\nLog Entry");
            w.Write(":{0}", LogMessage);
            w.Flush();

        }
    }
}
