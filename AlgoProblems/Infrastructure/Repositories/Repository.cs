using Infrastructure.Configurations;
using Infrastructure.Models;
using NHibernate;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T: IEntity
    {
        private ISession _session;
        private readonly ITransaction _transaction;

        public Repository(INHibernateHelper nHibernateHelper)
        {
            _session = nHibernateHelper.OpenSession();
            _transaction = _session.BeginTransaction();
        }
        public Repository(ISession session)
        {
            _session = session;
        }

        //public async void CommitAsync()
        //{
        //    try
        //    {
        //        if (_transaction.IsActive) await _transaction.CommitAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (_transaction.IsActive)  _transaction.Rollback();
        //    }
        //}

        public void Create(T model)
        {
            _session.SaveOrUpdate(model);
        }

        public void Delete(Guid id)
        {
            var model = _session.Query<T>().FirstOrDefault(x => x.Id == id);
            _session.Delete(model);
        }

        //public void Dispose()
        //{
        //    _session.Close();
        //    _session = null;
        //}
        //public void Rollback()
        //{
        //    try
        //    {
        //        if (_transaction.IsActive) _transaction.Rollback();
        //    }
        //    finally 
        //    {
        //        _session.Dispose();
        //    }
        //}
        public T GetById(Guid id)
        {
            return _session.Query<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Update(T model)
        {
            _session.Update(model);
        }
    }
}
