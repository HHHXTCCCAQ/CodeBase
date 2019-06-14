using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IORead
{
    class Program
    {
        private const string FILE_NAME = "Test.txt";
        static void Main(string[] args)
        {
            //判断文件是否存在
            if (!File.Exists(FILE_NAME))
            {
                Console.WriteLine("{0}不存在", FILE_NAME);
                Console.ReadLine();
                return;
            }

            /////方法一
            //FileStream fs =new FileStream (FILE_NAME,FileMode.Open,FileAccess.Read);
            //BinaryReader r = new BinaryReader(fs);
            //for(int i=0;i<11;i++)
            //{
            //    Console.WriteLine(r.ReadString());
            //}
            //r.Close();
            //fs.Close();
            //Console.ReadLine();

            ///方法二
            ///
            List<string> str = new List<string>();
            using(StreamReader sr = File.OpenText(FILE_NAME))
            {
                string input;
                while ((input = sr.ReadLine()) != null)
                
                {
                    //Console.WriteLine(input);
                    str.Add(input);
                }
              // for(int i=0;i<)
                foreach(List<>)
                sr.Close();
            }
            Console.ReadLine();
        }
    }
}
