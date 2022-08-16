using Infrastructure.Models;
using System;

namespace Infrastructure.Repositories
{
    public interface IRepository<T> where T : IEntity//: IDisposable where T: IEntity
    {
        void Create(T model);
        void Update(T model);
        void Delete(Guid id);
        T GetById(Guid id);
        //void CommitAsync();
    }
}
