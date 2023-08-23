using System.ComponentModel.DataAnnotations;

namespace WebAPI_Dapper.DTOs
{
    public class AddEmployeeDTO
    {
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Position { get; set; }

        [Required]
        public Guid CompanyId { get; set; }
    }
}
