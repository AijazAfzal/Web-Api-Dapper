using System.ComponentModel.DataAnnotations;

namespace WebAPI_Dapper.DTOs
{
    public class CreateCompanyDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
