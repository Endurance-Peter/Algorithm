using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInfrastructure.Migrations.MigrationScripts
{
    [Migration(202208151552)]
    public class Product_Table : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("Customers_Id").AsGuid().NotNullable().ForeignKey("FK_Customers_Products_Id", "Customers", "Id");
        }
    }
}
