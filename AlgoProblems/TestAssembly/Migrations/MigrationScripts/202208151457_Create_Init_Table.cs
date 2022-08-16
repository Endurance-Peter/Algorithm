using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInfrastructure.Migrations.MigrationScripts
{
    [Migration(202208151457)]
    public class Create_Init_Table : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Customers")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable();
        }
    }
}
