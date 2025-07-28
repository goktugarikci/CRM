using CRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Kullanicilar> _userManager;
        private readonly RoleManager<Roller> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<Kullanicilar> userManager, RoleManager<Roller> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        // POST: api/account/register
        // Bu endpoint'in PUBLIC olmasi gerekir, o yuzden [Authorize] etiketi yok.
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var userExists = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new { Status = "Error", Message = "Bu email adresi zaten mevcut!" });
            }

            Kullanicilar user = new()
            {
                Email = registerDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerDto.Email,
                AdSoyad = registerDto.AdSoyad,
                SirketID = registerDto.SirketID,
                AktifMi = true
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                // Identity'den gelen gercek hata mesajlarini donduruyoruz.
                return BadRequest(new { Status = "Error", Message = "Kullanici olusturulamadi.", Errors = result.Errors });
            }

            return Ok(new { Status = "Success", Message = "Kullanici basariyla olusturuldu!" });
        }

        // POST: api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                // --- KULLANICININ ROLLERİNİ ALMA ---
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Kullanici ID'si
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("sirketId", user.SirketID.ToString()) // Token'a sirket ID'sini ekliyoruz
                };

                // --- EN ÖNEMLİ KISIM ---
                // Kullanicinin sahip oldugu tum rolleri token'a ekliyoruz.
                // [Authorize(Roles="...")] mekanizmasinin calismasi icin bu zorunludur.
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                // -------------------------

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized(new { Message = "E-posta veya şifre hatalı." });
        }
    }
}
