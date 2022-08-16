using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInfrastructure.Migrations
{
    public static class DataBaseRunner
    {
        public static IServiceProvider CreateMigration(this IServiceCollection service, string connectionString)
        {
            return service.AddFluentMigratorCore()
                                          .ConfigureRunner(x => x.AddSqlServer2016()
                                                                 .WithGlobalConnectionString(connectionString).ScanIn(typeof(DataBaseRunner).Assembly).For.Migrations())
                                          .BuildServiceProvider();
        }

        public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
        { 
            using(var scope= app.ApplicationServices.CreateScope())
            {
                var migrationRunner = scope.ServiceProvider.GetService<IMigrationRunner>();
                migrationRunner.MigrateUp();
            }
            
            return app;
        }
    }
}
