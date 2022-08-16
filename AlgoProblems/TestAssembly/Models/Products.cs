using System;
using System.Collections.Generic;
using System.Text;

namespace TestAssembly.Models
{
    public class Products : IEntity
    {
        public virtual Guid Id { get ; set ; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Customers Customers { get; set; }
    }
}
