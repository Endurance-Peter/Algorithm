using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInfrastructure.Models
{
    public class Products : IEntity
    {
        public virtual Guid Id { get ; set ; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Customers Customers { get; set; }
    }
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateCustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<ProductDto> ProductDtos { get; set; }
    }
}
