using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Roller : IdentityRole<int>
    {
        [Required]
        public int SirketId { get; set; }

        [Required]
        public int RolDerecesi { get; set; } = 99;

        // DIKKAT: ASP.NET Core Identity ile cakismaya neden olan
        // 'public virtual Sirketler Sirket { get; set; }' ve
        // 'public virtual ICollection<Kullanicilar> Kullanicilar { get; set; }' gibi
        // tum iliskisel ozellikler (navigation properties) buradan kaldirilmistir.
    }
}