// Models/RegisterDto.cs

using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!; // null olamaz

        [Required]
        public string Password { get; set; } = null!; // null olamaz

        [Required]
        public string AdSoyad { get; set; } = null!; // null olamaz

        [Required]
        public int SirketID { get; set; }
    }
}