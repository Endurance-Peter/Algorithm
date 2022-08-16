using FluentNHibernate.Mapping;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("Persons");
            Id(x => x.Id).GeneratedBy.GuidComb().Unique();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
        }
    }
}
