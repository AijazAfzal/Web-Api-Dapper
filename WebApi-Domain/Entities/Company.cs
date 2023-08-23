using System.ComponentModel.DataAnnotations;

namespace WebApi_Domain.Entities
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
