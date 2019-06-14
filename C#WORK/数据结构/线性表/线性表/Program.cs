using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线性表 {
    class Program {
        static void Main(string[] args) {
            //使用BCL中的List线性表
            //List<string> strList =new List<string>();
            //strList.Add("hxt");
            //strList .Add("ai");
            //strList.Add("caq");
            //Console.WriteLine(strList[0]);//通过索引器访问元素
            //strList.Remove("ai");
            //Console.WriteLine(strList.Count);
            //strList.Clear();
            //Console.WriteLine(strList.Count);
            //Console.ReadKey();


            //使用自己的顺序表
            //#region 自己的顺序表
            //SeqList<string> seqList = new SeqList<string>();
            //seqList.Add("hxt");
            //seqList.Add("ai");
            //seqList.Add("caq");
            //Console.WriteLine(seqList.GetEle(0));
            //Console.WriteLine(seqList[0]);
            //seqList.Insert("ai77", 1);
            //for (int i = 0; i < seqList.GetLength(); i++) {
            //    Console.WriteLine(seqList[i] + "  ");

            //}
            //Console.WriteLine();
            //seqList.Delete(0);
            //for (int i = 0; i < seqList.GetLength(); i++) {
            //    Console.WriteLine(seqList[i] + "  ");

            //}
            //seqList.Claer();
            //Console.WriteLine();
            //Console.WriteLine(seqList.GetLength());
            //Console.ReadKey();
            //#endregion


            #region 自己的单链表

            LinkList<string> seqList = new LinkList<string>();


            seqList.Add("hxt");
            seqList.Add("ai");
            seqList.Add("caq");

            Console.WriteLine(seqList.GetEle(0));
            Console.WriteLine(seqList[0]);
            seqList.Insert("ai77", 1);
            for (int i = 0; i < seqList.GetLength(); i++) {

                Console.WriteLine(seqList[i] + "  ");

            }
            Console.WriteLine();
            seqList.Delete(0);
            for (int i = 0; i < seqList.GetLength(); i++) {
                Console.WriteLine(seqList[i] + "  ");

            }
            seqList.Claer();
            Console.WriteLine();
            Console.WriteLine(seqList.GetLength());
            Console.ReadKey(); 
            #endregion
     

        }
    }
}
