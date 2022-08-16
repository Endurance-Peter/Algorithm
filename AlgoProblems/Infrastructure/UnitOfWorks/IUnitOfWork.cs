using Infrastructure.Configurations;
using Infrastructure.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        PersonRepository PersonRepository { get; set; }
        void CommitAsync();
        void Roleback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITransaction _transasction;
        private ISession session;
        public UnitOfWork(INHibernateHelper nHibernateHelper)
        {
            session = nHibernateHelper.OpenSession();
            _transasction = session.BeginTransaction();

            CreateRepositories(session);
        }

        private void CreateRepositories(ISession session)
        {
            PersonRepository = new PersonRepository(session);
        }

        public PersonRepository PersonRepository { get; set; }

        public void CommitAsync()
        {
            try
            {
                if (_transasction.IsActive) _transasction.Commit();
            }
            catch (Exception ex)
            {
                if (_transasction.IsActive) _transasction.Rollback();

                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            session.Close();
            session = null;
        }

        public void Roleback()
        {
            try
            {
                if (_transasction.IsActive) _transasction.Rollback();
            }
            finally
            {
                session.Dispose();
            }
        }
    }
}
