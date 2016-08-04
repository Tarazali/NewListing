using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace NewListing.Models.NHibernate
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            //var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\Configuration\hibernate.cfg.xml");
            //configuration.Configure(configurationPath);
            //var userConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\Mapping\Users.hbm.xml");
            //configuration.AddFile(userConfigurationFile);
            //var taskConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\Mapping\Tasks.hbm.xml");
            //configuration.AddFile(taskConfigurationFile);
            configuration.Configure(HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\Configuration\hibernate.cfg.xml"));
            configuration.AddAssembly("NewListing");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}