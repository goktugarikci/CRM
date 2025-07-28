using CRM.Core;
using CRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data
{
    public static class DataSeeder
    {
        public static async Task SeedRolesAndSuperAdminAsync(UserManager<Kullanicilar> userManager, RoleManager<Roller> roleManager, CRMAppDbContext context)
        {
            // Veritabaninin olusturuldugundan ve migration'larin uygulandigindan emin ol.
            await context.Database.MigrateAsync();

            Console.WriteLine("Veri tohumlama basladi...");

            // 1. "Sistem Yönetimi" sirketini olustur
            if (!await context.Sirketlers.AnyAsync(s => s.SirketAdi == Constants.Sirket.SistemSirketiAdi))
            {
                var sistemSirketi = new Sirketler
                {
                    SirketAdi = Constants.Sirket.SistemSirketiAdi,
                    KayitTarihi = DateTime.UtcNow
                };
                await context.Sirketlers.AddAsync(sistemSirketi);
                await context.SaveChangesAsync();
                Console.WriteLine("'Sistem Yonetimi' sirketi olusturuldu.");
            }
            var systemCompany = await context.Sirketlers.SingleAsync(s => s.SirketAdi == Constants.Sirket.SistemSirketiAdi);

            // 2. Temel rolleri olustur
            var roles = new List<string>
            {
                Constants.Roles.SuperAdmin,
                Constants.Roles.CEO,
                Constants.Roles.GenelMudur,
                Constants.Roles.MuhasebeMuduru,
                Constants.Roles.Muhasebe,
                Constants.Roles.DepoMuduru,
                Constants.Roles.InsanKaynaklari
            };

            int rolDerecesiCounter = 0;
            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new Roller
                    {
                        Name = roleName,
                        SirketId = systemCompany.SirketId, // Tum temel roller sistem sirketine aittir
                        RolDerecesi = rolDerecesiCounter++ // Rol derecelerini sirayla ata
                    });
                    Console.WriteLine($"'{roleName}' rolu olusturuldu.");
                }
            }

            // 3. Super Admin kullanicisini olustur
            var superAdminEmail = "superadmin@crm.com";
            if (await userManager.FindByEmailAsync(superAdminEmail) == null)
            {
                var superAdmin = new Kullanicilar
                {
                    UserName = superAdminEmail,
                    Email = superAdminEmail,
                    AdSoyad = "Sistem Yöneticisi",
                    SirketID = systemCompany.SirketId,
                    EmailConfirmed = true,
                    AktifMi = true
                };

                // ÖNEMLİ: Sifre "Pa$$w0rd123!"
                var result = await userManager.CreateAsync(superAdmin, "Pa$$w0rd123!");

                if (result.Succeeded)
                {
                    Console.WriteLine("'Super Admin' kullanicisi olusturuldu.");
                    // Super Admin kullanicisini SuperAdmin roluyle iliskilendir
                    await userManager.AddToRoleAsync(superAdmin, Constants.Roles.SuperAdmin);
                    Console.WriteLine("'Super Admin' kullanicisi 'SuperAdmin' rolune atandi.");
                }
                else
                {
                    Console.WriteLine("'Super Admin' kullanicisi olusturulamadi. Hatalar:");
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"- {error.Description}");
                    }
                }
            }
            Console.WriteLine("Veri tohumlama tamamlandi.");
        }
    }
}
