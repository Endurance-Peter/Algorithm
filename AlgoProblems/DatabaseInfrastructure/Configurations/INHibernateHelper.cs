using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInfrastructure.Configurations
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}
