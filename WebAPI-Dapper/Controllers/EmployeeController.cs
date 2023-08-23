using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Dapper.DTOs;
using WebApi_Domain.Entities;
using WebApi_Domain.IRepository;
using WebApi_Infrastructure.Repository;

namespace WebAPI_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger; 
        private readonly IEmployeeRepository _employeeRepository; 
        public EmployeeController(ILogger<EmployeeController> logger
            , IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetAllEmployeesAsync")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await _employeeRepository.GetAllEmployeesAsync();
                return Ok(new
                {
                    Sucess = true,
                    Message = "All Employees retrieved sucessfully",
                    employees

                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetEmployeeByIdAsync")] 
        public async Task<IActionResult> GetEmployeeByIdAsync(Guid employeeId)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId); 
                return Ok(new
                {
                    Sucess = true,
                    Message = $"Employee with Id{employee.Id} retrieved sucessfully",
                    employee

                }
                    );

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetEmployeeesByCompanyNameAsync")]
        public async Task<IActionResult> GetEmployeeesByCompanyNameAsync(string CompanyName)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeesByCompanyNameAsync(CompanyName); 
                return Ok(new
                {
                    Sucess = true,
                    Message = $"Employee of {CompanyName} company retrieved sucessfully",
                    employees
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpPost("AddEmployeeAsync")]
        public async Task<IActionResult> AddEmployeeAsync(AddEmployeeDTO addEmployeeDTO)
        {
            try
            {
                await _employeeRepository.AddEmployeeAsync(addEmployeeDTO); 
                return Ok(new
                {
                    Success = true,
                    Message = $"Employee added sucessfully"

                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteEmployeeAsync")]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid employeeID)
        {
            try
            {
                await _employeeRepository.DeleteEmployeeAsync(employeeID); 
                return Ok(new
                {
                    Success = true,
                    Message = $"Employee deleted sucessfully"

                });


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateEmployeeAsync")] 

        public async Task<IActionResult> UpdateEmployeeAsync(UpdateEmployeeDTO updateEmployeeDTO, Guid employeeId)
        {
            try
            {
                await _employeeRepository.UpdateEmployeeAsync(updateEmployeeDTO, employeeId); 
                return Ok(new
                {
                    Success = true,
                    Message = $"Employee details updated sucessfully" 

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
