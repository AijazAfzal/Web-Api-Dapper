using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _dapperContext;
        public EmployeeRepository(DapperContext dapperContext)
        {
                _dapperContext = dapperContext; 
        }
        public async Task AddEmployeeAsync(AddEmployeeDTO addEmployee)
        {
            string sqlQuery = "INSERT into Employees (Id,Name,Age,Position,CompanyId) values (@Id, @Name, @Age, @Position, @CompanyId)";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Guid.NewGuid(), DbType.Guid);
            parameters.Add("Name", addEmployee.Name, DbType.String);
            parameters.Add("Age", addEmployee.Age, DbType.Int32);
            parameters.Add("Position",addEmployee.Position,DbType.String);
            parameters.Add("CompanyId",addEmployee.CompanyId,DbType.Guid); 
            using (var connection = _dapperContext.CreateConnection())
            {
                var r = await connection.ExecuteAsync(sqlQuery, parameters);
                Console.Write(r);
            }
        }

        public async Task DeleteEmployeeAsync(Guid employeeId)
        {
            string query = "DELETE FROM Employees WHERE Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = employeeId });
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            string sqlQuery = "SELECT * FROM Employees";
            using (var connection = _dapperContext.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(sqlQuery);
                return employees.ToList();
            }

        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            string sqlQuery = "SELECT * FROM Employees WHERE Id = @Id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var employee = await connection.QuerySingleAsync<Employee>(sqlQuery, new { Id = employeeId });
                return employee; 
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByCompanyNameAsync(string companyName)
        {
            string sqlQuery = @"SELECT e.*, c.Name as CompanyName FROM Employees as e INNER JOIN Companies as c ON e.CompanyId = c.Id WHERE c.Name = @companyName";

            using (var connection = _dapperContext.CreateConnection())
            {
                IEnumerable<Employee> employees = await connection.QueryAsync<Employee>(sqlQuery, new { CompanyName = companyName });
                return employees;
            }
        }


        public async Task UpdateEmployeeAsync(UpdateEmployeeDTO updateCompany, Guid id)
        {
            string sqlQuery = "UPDATE Employees SET Name = @Name, Age = @Age, Position = @Position WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Name", updateCompany.Name, DbType.String);
            parameters.Add("Age", updateCompany.Age, DbType.Int32);
            parameters.Add("Position", updateCompany.Position, DbType.String);
            parameters.Add("Id", id, DbType.Guid);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
