using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Dapper.DTOs;
using WebApi_Domain.Entities;
using WebApi_Domain.IRepository;
using WebApi_Infrastructure.ApplicationDbContext;

namespace WebApi_Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _dapperContext;
        public CompanyRepository(DapperContext dapperContext)
        {
                _dapperContext = dapperContext; 
        }
        public async Task CreateCompanyAsync(CreateCompanyDTO createCompany)
        {
            string sqlquery = "INSERT into Companies(Id,Name,Address,Country) values(@Id,@Name,@Address,@Country)";
            var parametres = new DynamicParameters();
            parametres.Add("Name", createCompany.Name,DbType.String);
            parametres.Add("Id",Guid.NewGuid(),DbType.Guid);
            parametres.Add("Address",createCompany.Address,DbType.String);
            parametres.Add("Country",createCompany.Country,DbType.String);
            using (var connection=_dapperContext.CreateConnection())
            {
                var r=await connection.ExecuteAsync(sqlquery,parametres);
                Console.Write(r); //for displaying no of rows affected
            }

        }

        public async Task DeleteCompanyAsync(Guid companyId)
        {
            string sqlquery = "DELETE FROM Companies where Id = @ID";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sqlquery, new { Id = companyId });
            }


        } 

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            string sqlQuery = "SELECT * FROM Companies";
            using (var connection = _dapperContext.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(sqlQuery);
                return companies.ToList();
            }
        }

        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            string sqlQuery = "SELECT * FROM Companies WHERE Id = @Id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var company = await connection.QuerySingleAsync<Company>(sqlQuery, new { Id = companyId });
                return company;
            }
        }

        public async Task UpdateCompanyAsync(UpdateCompanyDTO updateCompany,Guid id)
        {
            string sqlQuery = "UPDATE Companies SET Name = @Name, Address = @Address, Country = @Country WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Name", updateCompany.Name, DbType.String);
            parameters.Add("Address", updateCompany.Address, DbType.String);
            parameters.Add("Country", updateCompany.Country, DbType.String);
            parameters.Add("Id", id, DbType.Guid);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
