﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using DatabaseInfrastructure.Models;

namespace DatabaseInfrastructure.Mappings
{
    public class ProductMap : ClassMap<Products>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.Id).GeneratedBy.GuidComb().Unique();
            Map(x => x.Name);
            Map(x => x.Description);
            References(x => x.Customers);
        }
    }
}
