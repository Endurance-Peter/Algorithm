using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAssembly.Migrations
{
    public static class DataBaseRunner
    {
        //public static IServiceProvider CreateMigration(this IServiceCollection service, string connectionString)
        //{
        //    return service.AddFluentMigratorCore()
        //                                  .ConfigureRunner(x => x.AddSqlServer2016()
        //                                                         .WithGlobalConnectionString(connectionString).ScanIn(typeof(DataBaseRunner).Assembly).For.Migrations())
        //                                  .BuildServiceProvider();
        //}

        //public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
        //{ 
        //    using(var scope= app.ApplicationServices.CreateScope())
        //    {
        //        var migrationRunner = scope.ServiceProvider.GetService<IMigrationRunner>();
        //        migrationRunner.MigrateUp();
        //    }
            
        //    return app;
        //}


        public static IServiceProvider CreateMigrations(string connectionStrings)
        {
            return new ServiceCollection().AddFluentMigratorCore()
                                          .ConfigureRunner(x => x.AddSqlServer2016().WithGlobalConnectionString(connectionStrings).ScanIn(typeof(DataBaseRunner).Assembly).For.Migrations())
                                          .BuildServiceProvider();
        }
        public static void RunMigrate(IServiceProvider service)
        {
            //var service = (IServiceProvider)Activator.CreateInstance(typeof(IServiceProvider));
            using(var scope = service.CreateScope())
            {
                var run = scope.ServiceProvider.GetService<IMigrationRunner>();
                run.MigrateUp();
            }
        }
        //public static IServiceProvider ServiceProvider { get; set; }
    }


}
