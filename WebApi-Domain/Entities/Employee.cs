using System.ComponentModel.DataAnnotations;

namespace WebApi_Domain.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Position { get; set; }

        [Required]
        public Guid CompanyId { get; set; }
    }
}
