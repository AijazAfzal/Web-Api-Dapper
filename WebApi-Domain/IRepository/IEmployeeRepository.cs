using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Dapper.DTOs;
using WebApi_Domain.Entities;

namespace WebApi_Domain.IRepository
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(AddEmployeeDTO addEmployee);

        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);

        Task<IEnumerable<Employee>> GetEmployeesByCompanyNameAsync(string companyName);

        Task UpdateEmployeeAsync(UpdateEmployeeDTO updateCompany, Guid id);

        Task DeleteEmployeeAsync(Guid employeeId);
    }
}
