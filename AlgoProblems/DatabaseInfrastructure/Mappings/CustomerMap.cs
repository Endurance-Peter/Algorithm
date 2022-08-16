using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using DatabaseInfrastructure.Models;

namespace DatabaseInfrastructure.Mappings
{
    public class CustomerMap : ClassMap<Customers>
    {
        public CustomerMap()
        {
            Table("Customers");
            Id(x => x.Id).GeneratedBy.GuidComb().Unique();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            HasMany(x => x.Products).Cascade.All().Inverse();
        }
    }
}
