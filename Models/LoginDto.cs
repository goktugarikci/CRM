using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!; // null olamaz

        [Required]
        public string Password { get; set; } = null!; // null olamaz
    }
}