using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Dapper.DTOs;
using WebApi_Domain.Entities;

namespace WebApi_Domain.IRepository
{
    public interface ICompanyRepository
    {
        Task CreateCompanyAsync(CreateCompanyDTO createCompany);

        Task<IEnumerable<Company>> GetAllCompaniesAsync();

        Task<Company> GetCompanyByIdAsync(Guid companyId); 

        Task UpdateCompanyAsync(UpdateCompanyDTO updateCompany, Guid id);

        Task DeleteCompanyAsync(Guid companyId);
    }
}
