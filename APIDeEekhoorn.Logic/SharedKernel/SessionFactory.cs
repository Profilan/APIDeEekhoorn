using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDeEekhoorn.Logic.SharedKernel
{
    public class SessionFactory
    {
        private static ISessionFactory _factory;

        private static void Init()
        {
            Configuration config = new Configuration();
            config.Configure();

            _factory = config.BuildSessionFactory();
        }

        public static ISessionFactory GetSessionFactory()
        {
            if (_factory == null)
            {
                Init();
            }

            return _factory;
        }

        public static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }
    }
}
