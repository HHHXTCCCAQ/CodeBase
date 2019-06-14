using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 反射和特性
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Type对象
            //每一个类对应一个type对象，这个type对象储存了这个类 有哪些方法跟那些数据 那些成员
            MyClass my = new MyClass();//一个类的数据 是存储在对象中的，但是type对象只存储类的成员
            Type type = my.GetType();//通过对象获取这个对象所属类的type对象
            Console.Write(type.Name);//获取类的名字
            Console.WriteLine(type.Namespace);
            Console.WriteLine(type.Assembly);//返回程序集
            FieldInfo[] array = type.GetFields();//只能获得public字段
            foreach (FieldInfo info in array)
            {
                Console.Write(info.Name + "  ");

            }
            PropertyInfo[] array2 = type.GetProperties();
            foreach (PropertyInfo info in array2)
            {
                Console.Write(info.Name + "  ");
            }
            MethodInfo[] array3 = type.GetMethods();//获取类的方法
            foreach (MethodInfo info in array3)
            {
                Console.Write(info.Name + "  ");
            }
            //通过type对象能获得它对应类的所有成员（public）

            MyClass my1 = new MyClass();
            Assembly assem = my1.GetType().Assembly;//通过类的type 对象获取它所在的程序集Assembly
            Console.WriteLine(assem.FullName);
            Type[] type1 = assem.GetTypes();
            foreach (Type infoType in type1)
            {
                Console.WriteLine(infoType);
            }
            Console.ReadKey(); 

            #endregion

        }
    }
}
