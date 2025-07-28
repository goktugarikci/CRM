using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class KullaniciOlusturDto
    {
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        public string AdSoyad { get; set; } = null!;

        [Required(ErrorMessage = "Şirket ID'si zorunludur.")]
        public int SirketID { get; set; }

        [Required(ErrorMessage = "Rol adı zorunludur.")]
        public string RolAdi { get; set; } = null!; // Ornek: "CEO" veya "Genel Mudur"
    }
}
