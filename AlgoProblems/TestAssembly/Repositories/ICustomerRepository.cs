using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssembly.Models;

namespace TestAssembly.Repositories
{
    public interface ICustomerRepository : IRepositroy<Customers>
    {

    }

    public class CustomerRepository : Repository<Customers>, ICustomerRepository
    {
        public CustomerRepository(ISession session) : base (session)
        {

        }
    }

    public interface IRepositroy <T> where T: IEntity
    {
        void Add(T model);
        void Update(T model);
        void Delete(Guid id);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
    }

    public class Repository<T> : IRepositroy<T> where T : IEntity
    {
        private readonly ISession _session;
        public Repository(ISession session)
        {
            _session = session;
        }
        public void Add(T model)
        {
            _session.Save(model);
        }

        public void Delete(Guid id)
        {
            var model = _session.Query<T>().FirstOrDefault(x => x.Id == id);
            _session.Delete(model);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            var models = _session.Query<T>().AsEnumerable<T>();

            return Task.FromResult(models);
        }

        public Task<T> GetById(Guid id)
        {
            var model = _session.Query<T>().FirstOrDefault(x => x.Id == id);

            return Task.FromResult(model);
        }

        public void Update(T model)
        {
            _session.SaveOrUpdate(model);
        }
    }
}
