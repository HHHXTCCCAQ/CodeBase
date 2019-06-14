 using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //数组是引用类型，继承于Syetem.Array 固定长度 添加删除不方便
            #region  Array
            int[] numbers = new int[5];//一位数组
            string[,] names = new string[5, 4];//二维数组
            byte[][] scores = new byte[5][];//数组的数组,没一层的长度不固定

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = new byte[i + 3];
            }
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine("Length of row {0 } is {1}", i, scores[i].Length);
            }

            int[] number1 = new int[5] { 1, 2, 3, 4, 5 };
            int[] number2 = new int[] { 1, 2, 3, 4, 5 };
            int[] number3 = { 1, 2, 3, 4, 5 };

            int[][] numberss = { new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 } };
            foreach (int i in number2)
            {
                Console.WriteLine(i);
            }

            #endregion

            #region ArrayList
            //数组列表将所有的存储在里面的数据都当成为object类型
            //不安全
            ArrayList al = new ArrayList();
            al.Add(5);
            al.Add(100);
            al.Remove(100);
            al.Add("lovecq");
            Console.WriteLine(al[0]);
            //控制了数据类型，方便添加，安全高效
            List<int> intList = new List<int>();
            intList.Add(100);
            intList.AddRange(new int[] { 501, 502 });
            Console.WriteLine(intList.Contains(200));//是否包含200
            Console.WriteLine(intList.IndexOf(501));//501 在列表的位置
            intList.Insert(1, 100);
            //Console.WriteLine(al[0]); 
            #endregion

            //哈希表 类型没有规定 不安全
            Hashtable ht = new Hashtable();
            ht.Add("first", "HT");
            ht.Add("secornd", "CQ");
            Console.WriteLine(ht["secornd"]);

            //字典  规定类型 安全  线程不安全
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("first", "HT");
            dic.Add("secornd", "CQ");

            //需要线程安全 需要  用   ConcurrentDictionary
            Console.WriteLine(dic["first"]);
            //根据 key 值排序的List
            SortedList<int, int> sl = new SortedList<int, int>();

            Console.ReadLine();
        }
    }
}
