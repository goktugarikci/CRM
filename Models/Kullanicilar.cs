// --- Dosya: Models/Kullanicilar.cs ---
// Bu, Identity ile uyumlu, en sade ve doğru Kullanicilar sinifidir.
// Lutfen projenizdeki dosyayi bu icerikle tamamen degistirin.

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Kullanicilar : IdentityUser<int>
    {
        [Required]
        [StringLength(150)]
        public string AdSoyad { get; set; } = null!;

        [Required]
        public int SirketID { get; set; }

        public bool AktifMi { get; set; } = true;

        // DIKKAT: ASP.NET Core Identity ile cakismaya neden olan
        // 'public virtual Sirketler Sirket { get; set; }' gibi
        // tum iliskisel ozellikler (navigation properties) buradan kaldirilmistir.
    }
}