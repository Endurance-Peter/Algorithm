using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Text;
using DatabaseInfrastructure.Mappings;

namespace DatabaseInfrastructure.Configurations
{
    public class NHibernateHelper : INHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        public NHibernateHelper(string connectionStrings)
        {
            if (_sessionFactory == null && !string.IsNullOrEmpty(connectionStrings))
            {
                _sessionFactory = Begin_ConfigurationSql(connectionStrings);
            }
        }

        private ISessionFactory Begin_ConfigurationSql(string connectionStrings)
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionStrings))
                           .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(CustomerMap).Assembly))
                           .ExposeConfiguration(cfg =>
                           {
                               new SchemaUpdate(cfg).Execute(false, true);
                               //cfg.SetProperty(NHibernate)
                           }).BuildSessionFactory();
        }

        public ISessionFactory SessionFactory { get => _sessionFactory; }
        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
