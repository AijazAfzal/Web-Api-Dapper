using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Infrastructure.Migrations
{
    [Migration(202125100001)] 
    public class Initial_202125100001 : Migration 
    {
        public override void Down()
        {
            Delete.FromTable("Companies");
            Delete.FromTable("Employees");
        }

        public override void Up()
        {
            Create.Table("Companies")
                 .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                 .WithColumn("Name").AsString(50).NotNullable()
                 .WithColumn("Address").AsString(50).NotNullable()
                 .WithColumn("Country").AsString(50).NotNullable();

            Create.Table("Employees")
                 .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                 .WithColumn("Name").AsString(50).NotNullable()
                 .WithColumn("Age").AsInt32().NotNullable()
                 .WithColumn("Position").AsString(50).NotNullable()
                 .WithColumn("CompanyId").AsGuid().NotNullable().ForeignKey("Companies", "Id");
        }
    }
}

