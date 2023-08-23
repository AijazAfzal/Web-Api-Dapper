using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Dapper.DTOs;
using WebApi_Domain.Entities;
using WebApi_Domain.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ILogger<CompanyController> logger 
                               , ICompanyRepository companyRepository)
        {
            _logger = logger;
            _companyRepository = companyRepository; 
        }

        [HttpGet("GetAllCompaniesAsync")] 
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
            try 
            {
                var companies = await _companyRepository.GetAllCompaniesAsync();
                return Ok(new {
                    Success = true,
                    Message = "All Companies retrieved sucessfully",
                    companies
                }); 
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCompanyByIdAsync")]
        public async Task<IActionResult> GetCompanyByIdAsync(Guid Id)
        {
            try 
            {
                var company = await _companyRepository.GetCompanyByIdAsync(Id); 
                return Ok(new
                {
                    Success = true,
                    Message = $"Company with Id {company.Id} retrieved sucessfully",
                    company
                });

            }

            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpPost("CreateCompanyAsync")]
        public async Task<IActionResult> CreateCompanyAsync(CreateCompanyDTO createCompanyDTO)
        {
            try 
            {
                await _companyRepository.CreateCompanyAsync(createCompanyDTO);
                return Ok(new 
                {
                    Success = true,
                    Message = $"Company added sucessfully"
                  
                });

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpDelete("DeleteCompanyAsync")] 
        public async Task<IActionResult> DeleteCompanyAsync(Guid companyID)
        {
            try
            {
                await _companyRepository.DeleteCompanyAsync(companyID); 
                return Ok(new  
                {
                    Success = true,
                    Message = $"Company deleted sucessfully"

                });


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpPut("UpdateCompanyAsync")]  

        public async Task<IActionResult> UpdateCompanyAsync(UpdateCompanyDTO updateCompanyDTO,Guid companyId)
        {
            try
            {
                await _companyRepository.UpdateCompanyAsync(updateCompanyDTO, companyId);
                return Ok(new
                {
                    Success = true,
                    Message = $"Company details updated sucessfully"

                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message); 
            }
        }
    }
}
