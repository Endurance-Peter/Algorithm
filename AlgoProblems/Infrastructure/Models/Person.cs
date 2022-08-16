using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class Person : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
    }

    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
