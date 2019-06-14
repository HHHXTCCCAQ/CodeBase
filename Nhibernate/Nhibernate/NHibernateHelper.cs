using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace NhibernateTest
{
    class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory==null)
                {
                    var configuration = new Configuration();
                    configuration.Configure(); //解析nhibernate.cfg.xml  //注意xml的名称必须为nhibernate.cfg.xml
                    configuration.AddAssembly("NhibernateTest");//解析 映射文件 参数为程序集
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }


        public static  ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
