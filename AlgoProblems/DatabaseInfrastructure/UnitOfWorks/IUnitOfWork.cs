using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using DatabaseInfrastructure.Configurations;
using DatabaseInfrastructure.Repositories;

namespace DatabaseInfrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; set; }
        void CommitToDatabase();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction transaction;
        private ISession session;
        public UnitOfWork(INHibernateHelper nHibernateHelper)
        {
            session = nHibernateHelper.OpenSession();
            transaction = session.BeginTransaction();
            CreateRepositories(session);
        }
        private void CreateRepositories(ISession session)
        {
            CustomerRepository = new CustomerRepository(session);
        }

        public void CommitToDatabase()
        {
            try
            {
                if (transaction.IsActive) transaction.Commit();
            }
            catch (Exception)
            {

                if (transaction.IsActive) transaction.Rollback();
            }
        }

        public void Rollback()
        {
            try
            {
                if (transaction.IsActive) transaction.Rollback();
            }
            finally
            {
                transaction.Rollback();
            }

        }

        public void Dispose()
        {
            session.Close();
            session = null;
        }

        public ICustomerRepository CustomerRepository { get ; set ; }
    }
}
