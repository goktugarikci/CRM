using CRM.Core;
using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Constants.Roles.SuperAdmin)] // Yetkilendirme artik tum controller icin gecerli.
    public class AdminController : ControllerBase
    {
        private readonly CRMAppDbContext _context;
        private readonly UserManager<Kullanicilar> _userManager;
        private readonly RoleManager<Roller> _roleManager;

        public AdminController(
            CRMAppDbContext context,
            UserManager<Kullanicilar> userManager,
            RoleManager<Roller> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // POST: api/admin/sirketolustur
        [HttpPost("sirketolustur")]
        public async Task<IActionResult> SirketOlustur([FromBody] SirketOlusturDto sirketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _context.Sirketlers.AnyAsync(s => s.SirketAdi == sirketDto.SirketAdi))
            {
                return Conflict("Bu isimde bir şirket zaten mevcut.");
            }

            var yeniSirket = new Sirketler
            {
                SirketAdi = sirketDto.SirketAdi,
                VergiNo = sirketDto.VergiNo,
                Adres = sirketDto.Adres,
                Telefon = sirketDto.Telefon,
                KayitTarihi = DateTime.UtcNow
            };

            _context.Sirketlers.Add(yeniSirket);
            await _context.SaveChangesAsync();

            return Ok(yeniSirket);
        }

        // POST: api/admin/kullaniciolustur
        [HttpPost("kullaniciolustur")]
        public async Task<IActionResult> KullaniciOlustur([FromBody] KullaniciOlusturDto kullaniciDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sirket = await _context.Sirketlers.FindAsync(kullaniciDto.SirketID);
            if (sirket == null)
            {
                return NotFound("Kullanıcı atanmak istenen şirket bulunamadı.");
            }

            if (sirket.SirketId == 1) // Sistem Yönetimi sirketinin ID'si her zaman 1 olacak.
            {
                return BadRequest("Sistem Yönetimi şirketine bu şekilde yeni kullanıcı atanamaz.");
            }

            var rol = await _roleManager.FindByNameAsync(kullaniciDto.RolAdi);
            if (rol == null)
            {
                return NotFound($"'{kullaniciDto.RolAdi}' adında bir rol bulunamadı.");
            }

            if (rol.Name == Constants.Roles.SuperAdmin)
            {
                return BadRequest("SuperAdmin rolü bu endpoint ile atanamaz.");
            }

            if (await _userManager.FindByEmailAsync(kullaniciDto.Email) != null)
            {
                return Conflict("Bu e-posta adresi zaten kullanılıyor.");
            }

            var yeniKullanici = new Kullanicilar
            {
                UserName = kullaniciDto.Email,
                Email = kullaniciDto.Email,
                AdSoyad = kullaniciDto.AdSoyad,
                SirketID = kullaniciDto.SirketID,
                AktifMi = true
            };

            var result = await _userManager.CreateAsync(yeniKullanici, kullaniciDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { Status = "Hata", Message = "Kullanıcı oluşturulamadı.", Errors = result.Errors });
            }

            await _userManager.AddToRoleAsync(yeniKullanici, kullaniciDto.RolAdi);

            return Ok(new { message = $"'{yeniKullanici.AdSoyad}' adlı kullanıcı başarıyla oluşturuldu ve '{rol.Name}' rolüne atandı." });
        }
    }
}
