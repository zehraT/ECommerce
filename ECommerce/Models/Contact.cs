using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Message { get; set; }
    }
}