using System.ComponentModel.DataAnnotations;

namespace WebAPI_Dapper.DTOs
{
    public class UpdateEmployeeDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
