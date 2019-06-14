#define IsTest //定义宏
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 反射的特性
{
    //通过制定属性的名字，给属性赋值，这种事命名参数
    [MyTest("简单的特性类", ID = 100)]//当我们使用特性的时候，后面的Attribute不需要写
    class Program
    {
        [Obsolete("这个方法过时了，使用NewMethod代替")]//用来表示这个方法被弃用
        private static void OldMethod()
        {
            Console.WriteLine("OldMethod");
        }

        static void NewMethod()
        {

        }
        [Conditional("IsTest")]//如果调用要定义宏
        static void Test1()
        {
            Console.WriteLine("Test1");
        }
        static void Test2()
        {
            Console.WriteLine("Test2");
        }
        [DebuggerStepThrough]//可以跳过的debuger的单步调试，当确定方法没错误的时候可以使用
        static void PrintOut(string str, [CallerFilePath] string fileName = "", [CallerLineNumber] int LineNumber = 0,
            [CallerMemberName] string MethodName = "")
        {
            Console.WriteLine(str);
            Console.WriteLine(fileName);
            Console.WriteLine(LineNumber);
            Console.WriteLine(MethodName);
        }

        static void Main(string[] args)
        {
            //OldMethod();
            //Test1();
            //Test2();
            //Test1();
            // PrintOut("123");
            Type type = typeof(Program);//通过typeof+类名也可以获取type 对象
            object[] obj = type.GetCustomAttributes(false);
            MyTestAttribute Mytest = obj[0] as MyTestAttribute;
            Console.WriteLine(Mytest.Description);
            Console.WriteLine(Mytest.ID);
            Console.ReadKey();
        }
    }
}
