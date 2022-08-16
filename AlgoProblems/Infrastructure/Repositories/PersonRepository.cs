using Infrastructure.Configurations;
using Infrastructure.Models;
using NHibernate;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(INHibernateHelper nHibernateHelper) : base(nHibernateHelper) { }
        public PersonRepository(ISession session) : base(session) { }
    }
}
