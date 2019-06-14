using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new IndexedNames();
            names [0]="wq";
            names[1] = "Hello";
            names[2] = "Hello1";
            names[3] = "Hello2";
            names[4] = "Hello3";
            names[5] = "Hello4";
            names[6] = "Hello5";
            names[7] = "Hello6";
            names[8] = "Hello7";
            names[9] = "Hello8";
            // names[10] = "Hello9";
            //names[11] = "Hello10";
            //names[12] = "Hello11";
            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine(names["Hello"]);
            Console.WriteLine(names["Hello5"]);
            Console.WriteLine(names["Hello0"]);
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 建立类似数组的操作方式
    /// </summary>
    class IndexedNames
    {
        private string[] nameList = new string[10];
        public IndexedNames()
        {
            for (int i = 0; i < nameList.Length; i++)
            {
                nameList[i] = "N/A";
            }


        }
        /// <summary>
        /// 索引器的语法
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get { 
              string tmp;
              if (index >= 0 && index <= nameList.Length - 1)
              {
                  tmp = nameList[index];
              }
              else
              {
                  tmp = "";

              }
              return tmp;
            }
            set
            {
                if (index >= 0 && index <= nameList.Length - 1)
                {
                    nameList[index] = value;
                }
            }
        }


        /// <summary>
        ///索引器重载
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int this[string name]
        {
            get {
                int index = 0;
                while(index<nameList.Length)
                {
                    if(nameList [index]==name){
                          return index;
                    }
                  index ++;
                }
                return -1;
            }
            
        }


        //给接口 添加索引器
       
    }

     public interface IsomeInterface
        {
            int this[int index]
            {
                get;
                set;
            }
        }
    class IndexedClass:IsomeInterface
    {
        private int[] arr = new int[100];
        public int this[int index]
        {
            get {
                return arr[index];
            }
            set {
                arr[index] = value;
            }
        }
    }
}
