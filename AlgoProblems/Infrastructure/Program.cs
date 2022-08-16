using Infrastructure.Configurations;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure
{
    //public static class DatabaseMigrationService
    //{
    //    public static IServiceCollection AddDatabaseMigration(this IServiceCollection services, string connectionString)
    //    {
    //        services.AddFluentMigratorCore()
    //                .ConfigureRunner(config => config
    //                .AddSqlServer() // For MSSQL
    //                .WithGlobalConnectionString(connectionString)
    //                .ScanIn(typeof(DatabaseMigrationService).Assembly).For.Migrations())
    //                .AddLogging(config => config.AddFluentMigratorConsole());

    //        return services;
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            var connectionStrings = "pdata.db"; // @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pdata;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";//"Server =(localdb)\\MSSQLLocalDB;Database=Pdata;Persist Security Info=False;Connection Timeout=30;";
            INHibernateHelper nhibernateHelper = new NHibernateHelper(connectionStrings);
            //IRepository<Person> repository = new Repository<Person>(nhibernateHelper);

            var unitOfWork = new UnitOfWork(nhibernateHelper);


            var person = new Person
            {
                FirstName = "Adams",
                LastName = "Ken",
                Email = "adams.ken@kkl.com"
            };

            unitOfWork.PersonRepository.Create(person);
            unitOfWork.CommitAsync();

            //repository.Create(person);
            //repository.CommitAsync();

            Console.WriteLine("Save to db");
            //using (var scope = nhibernateHelper.OpenSession())
            //{
            //    repository.Create(person);
            //    repository.CommitAsync();

            //    Console.WriteLine("Save to db");
            //}

            //var result = repository.GetById(person.Id);

        }
    }
}
