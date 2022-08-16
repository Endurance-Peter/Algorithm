using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAssembly.Configurations
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}
