using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class SirketOlusturDto
    {
        [Required(ErrorMessage = "Şirket adı zorunludur.")]
        [StringLength(255)]
        public string SirketAdi { get; set; } = null!;

        [StringLength(20)]
        public string? VergiNo { get; set; }

        public string? Adres { get; set; }

        [StringLength(20)]
        public string? Telefon { get; set; }
    }
}
