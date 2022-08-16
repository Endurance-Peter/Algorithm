using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Configurations
{
    public class NHibernateHelper : INHibernateHelper
    {
        private ISessionFactory _sessionFactory;

        public NHibernateHelper(string connectionStrings)
        {
            if(_sessionFactory == null && connectionStrings != null)
            {
                //_sessionFactory = BegingSession(connectionStrings);
                _sessionFactory = BegingSqliteSession(connectionStrings);
            }
        }
        public ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory;
            }
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        private ISessionFactory BegingSession(string connectionString)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(PersonMap).Assembly))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
                //.ExposeConfiguration(cfg =>
                //    {
                //        cfg.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "5000");
                //    }
                //);

            return configuration.BuildSessionFactory();
        }
        private ISessionFactory BegingSqliteSession(string filename)
        {
            var configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(filename))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(PersonMap).Assembly))
                .ExposeConfiguration(cfg =>
                {
                    if (File.Exists(filename)) File.Delete(filename);
                    new SchemaUpdate(cfg).Execute(false, true);
                    //cfg.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "5000");

                });

            //.ExposeConfiguration(cfg =>
            //    {
            //        cfg.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "5000");
            //    }
            //);

            return configuration.BuildSessionFactory();
        }
    }
}
