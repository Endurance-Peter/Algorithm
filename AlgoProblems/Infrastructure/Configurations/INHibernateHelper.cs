using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
        ISessionFactory SessionFactory { get; }
    }

}
