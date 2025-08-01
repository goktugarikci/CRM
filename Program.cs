using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// --- Veritabanı ve Identity Servislerinin Eklenmesi ---
// 1. Veritabanı bağlantısını appsettings.json dosyasından okuyarak ekliyoruz.
builder.Services.AddDbContext<CRMAppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// 2. ASP.NET Core Identity sistemini ekliyoruz.
builder.Services.AddIdentity<Kullanicilar, Roller>(options =>
{
    // Gelistirme ortami icin sifre kurallarini basitlesitiyoruz.
    // Dilerseniz bu kurallari projenizin gereksinimlerine gore sıkılaştırabilirsiniz.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;
})
    .AddEntityFrameworkStores<CRMAppDbContext>()
    .AddDefaultTokenProviders();

// --- JWT (JSON Web Token) Ayarlarının Eklenmesi ---
// 3. Kimlik doğrulama mekanizması olarak JWT'yi yapılandırıyoruz.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false; // Gelistirme icin false
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["Jwt:Audience"],
        ValidIssuer = configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
    };
});


// 4. API Kontrolcülerini (Controller) ekliyoruz.
builder.Services.AddControllers();

// 5. Swagger (API Test Arayüzü) servislerini ekliyoruz.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header'ını 'Bearer {token}' formatında girin."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// --- Uygulama Hattının (Pipeline) Yapılandırılması ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ÖNEMLİ: UseAuthentication, UseAuthorization'dan ÖNCE gelmelidir.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


// --- Veri Tohumlama (Data Seeding) ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        await DataSeeder.SeedRolesAndSuperAdminAsync(services);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Veri tohumlama sirasinda bir hata olustu.");
    }
}
// ------------------------------------

app.Run();
