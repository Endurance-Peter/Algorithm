using System;
using System.Collections.Generic;
using System.Text;

namespace TestAssembly.Models
{
    public class Customers : IEntity
    {
        public virtual void AddProduct(Products product)
        {
            _products.Add(product);
        }
        public virtual  Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual IEnumerable<Products> Products => _products;
        private readonly ISet<Products> _products = new HashSet<Products>();
    }

    public interface IEntity
    {
        Guid Id { get; set; }
    }

    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
