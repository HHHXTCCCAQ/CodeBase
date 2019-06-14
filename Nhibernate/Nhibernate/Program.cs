using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NhibernateTest.Model;
using NhibernateTest.Manager;
namespace NhibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var configuration = new Configuration();
            //configuration.Configure(); //解析nhibernate.cfg.xml
            //configuration.AddAssembly("NhibernateTest");//解析 映射文件


            //ISessionFactory sessionFactory = null;
            //ISession session = null;
            //ITransaction transaction = null;
            //try
            //{
            //    sessionFactory = configuration.BuildSessionFactory();
            //    session = sessionFactory.OpenSession();//打开一个跟数据库的对话


            //    //事物

            //    transaction = session.BeginTransaction();
            //    User user1 = new User() { Username = "ht3", Password = "123456" };
            //    User user2 = new User() { Username = "ht2", Password = "123456" };
            //    session.Save(user1);
            //    session.Save(user2);
            //    transaction.Commit();
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e);
            //}
            //finally
            //{

            //    if (transaction != null)
            //    {
            //        transaction.Dispose();
            //    }
            //    if (session != null)
            //    {
            //        session.Close();
            //    }
            //    if (sessionFactory != null)
            //    {
            //        sessionFactory.Close();
            //    }
            //}

            //User user = new User() {Id=10, Username = "hac1", Password = "5201222" };
            IUserManager userManager = new UserManager();
            Console.WriteLine( userManager.GetByUsername("hac1").Password);
            Console.ReadKey();
        }
    }
}
