using Microsoft.AspNetCore.Builder;
using System;
using TestAssembly.Configurations;
using TestAssembly.Models;
using TestAssembly.UnitOfWorks;
using TestAssembly.Migrations;

namespace TestAssembly
{
    class Program
    {
        //public static IApplicationBuilder ApplicationBuilder { get; set; }
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var service = DataBaseRunner.CreateMigrations(connectionString);
            DataBaseRunner.RunMigrate(service);
            INHibernateHelper nHibernate = new NHibernateHelper(connectionString);
            IUnitOfWork unitOfWork = new UnitOfWork(nHibernate);

            var product = new Products
            {
                Description = "Milk contains rich vitamins",
                Name = "Milk"
            };
            var customer = new Customers
            {
                FirstName = "Harry",
                LastName = "Kain",
                Email = "harry@gmail.com"
            };
            customer.AddProduct(product);

            unitOfWork.CustomerRepository.Add(customer);
            unitOfWork.CommitToDatabase();

            Console.WriteLine("Save to database!");
        }
    }
}
