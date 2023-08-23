using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Entities;

namespace WebApi_Infrastructure.Migrations
{
    public class Seed_202125100002 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Companies");
            Delete.FromTable("Employees");
        }

        public override void Up()
        {
            List<Guid> ids = new List<Guid> { };
            List<String> companynames = new List<String> { "tcs", "amd", "ariqt", "lti" };
            List<String> employeenames = new List<String> { "Mike", "Olumide", "Precious", "Marv" };
            List<String> position = new List<String> { "jr dev", "sr dev", "cto", "ceo" };
            List<int> ages = new List<int> { 24,26,28,29 };
            List<String> Address = new List<String> { "A", "B", "C", "D"};
            List<String> Country = new List<String> { "E", "F", "G", "H" };
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                String coname = companynames[rnd.Next(companynames.Count)];
                String address = Address[rnd.Next(Address.Count)];
                String country = Country[rnd.Next(Country.Count)];
                Guid id = Guid.NewGuid();
                ids.Add(id);
                Insert.IntoTable("Companies")
                    .Row(new Company
                    {
                        Name = coname,
                        Address=address,
                        Country=country,
                        Id=id
                        
                    });

                for (int j = 0; j < 4; j++)
                {
                    Insert.IntoTable("Employees")
                        .Row(new Employee
                        {
                            Name = employeenames[rnd.Next(employeenames.Count)],
                            Age= ages[rnd.Next(ages.Count)],
                            Position= position[rnd.Next(position.Count)],
                            CompanyId=id,
                            Id=Guid.NewGuid()
                            


                        });
                }
            }
        }
    }
    }

