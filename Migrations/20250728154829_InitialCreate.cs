using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemirbasAtamaGecmisi",
                columns: table => new
                {
                    AtamaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    DemirbasID = table.Column<int>(type: "int", nullable: false),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    VerilisTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    VerenKullaniciID = table.Column<int>(type: "int", nullable: true),
                    VerilisNotu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeriAlinmaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    AlanKullaniciID = table.Column<int>(type: "int", nullable: true),
                    GeriAlinmaNotu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Demirbas__00DE786B4EF94EB7", x => x.AtamaID);
                });

            migrationBuilder.CreateTable(
                name: "Sirketler",
                columns: table => new
                {
                    SirketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketAdi = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    VergiNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sirketle__E52E4AAEDE706344", x => x.SirketID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketId = table.Column<int>(type: "int", nullable: false),
                    RolDerecesi = table.Column<int>(type: "int", nullable: false),
                    SirketlerSirketId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_Sirketler_SirketlerSirketId",
                        column: x => x.SirketlerSirketId,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    SirketlerSirketId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Sirketler_SirketlerSirketId",
                        column: x => x.SirketlerSirketId,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "CariHesaplar",
                columns: table => new
                {
                    CariHesapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    CariKodu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CariTipi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    VergiNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Bakiye = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CariHesa__613698EB03E3BBE8", x => x.CariHesapID);
                    table.ForeignKey(
                        name: "FK__CariHesap__Sirke__078C1F06",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "Demirbaslar",
                columns: table => new
                {
                    DemirbasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    DemirbasKodu = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DemirbasAdi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeriNo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    AlinmaTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    MevcutDurum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Depoda")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Demirbas__0AED0CA271325D69", x => x.DemirbasID);
                    table.ForeignKey(
                        name: "FK__Demirbasl__Sirke__43A1090D",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TCKimlikNo = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    IseGirisTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    Pozisyon = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Departman = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personel__0F0C57517A080A22", x => x.PersonelID);
                    table.ForeignKey(
                        name: "FK__Personell__Sirke__6FB49575",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "StokKartlari",
                columns: table => new
                {
                    StokKartiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    StokKodu = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    StokAdi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Birim = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MevcutMiktar = table.Column<decimal>(type: "decimal(18,3)", nullable: true, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StokKart__03151E01ACE6C3BE", x => x.StokKartiID);
                    table.ForeignKey(
                        name: "FK__StokKartl__Sirke__19AACF41",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ajanda",
                columns: table => new
                {
                    AjandaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departman = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NotBaslik = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NotIcerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    HatirlatmaTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    HatirlatmaGunu = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Tamamlandi = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    OlusturanKullaniciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ajanda__DCC2ABA52D80C9E0", x => x.AjandaID);
                    table.ForeignKey(
                        name: "FK_Ajanda_AspNetUsers_OlusturanKullaniciID",
                        column: x => x.OlusturanKullaniciID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    CariHesapID = table.Column<int>(type: "int", nullable: false),
                    SiparisNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SiparisTipi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Tarih = table.Column<DateOnly>(type: "date", nullable: false),
                    TeslimTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    Durum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Açık")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Siparisl__C3F03BDD6DC41C10", x => x.SiparisID);
                    table.ForeignKey(
                        name: "FK__Siparisle__CariH__11158940",
                        column: x => x.CariHesapID,
                        principalTable: "CariHesaplar",
                        principalColumn: "CariHesapID");
                    table.ForeignKey(
                        name: "FK__Siparisle__Sirke__10216507",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "PersonelDurumGecmisi",
                columns: table => new
                {
                    DurumGecmisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Tarih = table.Column<DateOnly>(type: "date", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IslemYapanKullaniciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personel__EDDDD12E24668969", x => x.DurumGecmisID);
                    table.ForeignKey(
                        name: "FK_PersonelDurumGecmisi_AspNetUsers_IslemYapanKullaniciID",
                        column: x => x.IslemYapanKullaniciID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonelD__Perso__72910220",
                        column: x => x.PersonelID,
                        principalTable: "Personeller",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonelD__Sirke__73852659",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "PersonelEkBilgileri",
                columns: table => new
                {
                    EkBilgiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcilDurumKontakAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AcilDurumKontakTelefonu = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personel__56BE018F99884029", x => x.EkBilgiID);
                    table.ForeignKey(
                        name: "FK__PersonelE__Perso__7C1A6C5A",
                        column: x => x.PersonelID,
                        principalTable: "Personeller",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonelE__Sirke__7D0E9093",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "PersonelMaasBilgileri",
                columns: table => new
                {
                    MaasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    MaasTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemePeriyodu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Aylık"),
                    BankaHesapNo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BaslangicTarihi = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personel__22D00316EA900DE7", x => x.MaasID);
                    table.ForeignKey(
                        name: "FK__PersonelM__Perso__7849DB76",
                        column: x => x.PersonelID,
                        principalTable: "Personeller",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonelM__Sirke__793DFFAF",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "PersonelNotlari",
                columns: table => new
                {
                    NotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    EkleyenKullaniciID = table.Column<int>(type: "int", nullable: true),
                    NotMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personel__4FB200AAFCCFBE90", x => x.NotID);
                    table.ForeignKey(
                        name: "FK_PersonelNotlari_AspNetUsers_EkleyenKullaniciID",
                        column: x => x.EkleyenKullaniciID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PersonelN__Perso__00DF2177",
                        column: x => x.PersonelID,
                        principalTable: "Personeller",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PersonelN__Sirke__01D345B0",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "Faturalar",
                columns: table => new
                {
                    FaturaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    CariHesapID = table.Column<int>(type: "int", nullable: false),
                    SiparisID = table.Column<int>(type: "int", nullable: true),
                    FaturaNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FaturaTipi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Tarih = table.Column<DateOnly>(type: "date", nullable: false),
                    VadeTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    AraToplam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KdvTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    GenelToplam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Durum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Beklemede")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Faturala__84301C40B143F2AF", x => x.FaturaID);
                    table.ForeignKey(
                        name: "FK__Faturalar__CariH__2057CCD0",
                        column: x => x.CariHesapID,
                        principalTable: "CariHesaplar",
                        principalColumn: "CariHesapID");
                    table.ForeignKey(
                        name: "FK__Faturalar__Sipar__214BF109",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "SiparisID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Faturalar__Sirke__1F63A897",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                });

            migrationBuilder.CreateTable(
                name: "SiparisKalemleri",
                columns: table => new
                {
                    SiparisKalemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    StokKartiID = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SiparisK__66721F4222BFDCD4", x => x.SiparisKalemID);
                    table.ForeignKey(
                        name: "FK__SiparisKa__Sipar__13F1F5EB",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "SiparisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__SiparisKa__Sirke__14E61A24",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                    table.ForeignKey(
                        name: "fk_siparis_stok",
                        column: x => x.StokKartiID,
                        principalTable: "StokKartlari",
                        principalColumn: "StokKartiID");
                });

            migrationBuilder.CreateTable(
                name: "FaturaKalemleri",
                columns: table => new
                {
                    FaturaKalemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaID = table.Column<int>(type: "int", nullable: false),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    StokKartiID = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KdvOrani = table.Column<int>(type: "int", nullable: true, defaultValue: 18),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FaturaKa__80EDE66AD521BDB7", x => x.FaturaKalemID);
                    table.ForeignKey(
                        name: "FK__FaturaKal__Fatur__251C81ED",
                        column: x => x.FaturaID,
                        principalTable: "Faturalar",
                        principalColumn: "FaturaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FaturaKal__Sirke__2610A626",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                    table.ForeignKey(
                        name: "fk_fatura_stok",
                        column: x => x.StokKartiID,
                        principalTable: "StokKartlari",
                        principalColumn: "StokKartiID");
                });

            migrationBuilder.CreateTable(
                name: "FinansalHareketler",
                columns: table => new
                {
                    HareketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    CariHesapID = table.Column<int>(type: "int", nullable: true),
                    FaturaID = table.Column<int>(type: "int", nullable: true),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HareketTipi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Finansal__50654B06E424F44B", x => x.HareketID);
                    table.ForeignKey(
                        name: "FK__FinansalH__CariH__0B5CAFEA",
                        column: x => x.CariHesapID,
                        principalTable: "CariHesaplar",
                        principalColumn: "CariHesapID");
                    table.ForeignKey(
                        name: "FK__FinansalH__Sirke__0A688BB1",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                    table.ForeignKey(
                        name: "fk_finans_fatura",
                        column: x => x.FaturaID,
                        principalTable: "Faturalar",
                        principalColumn: "FaturaID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StokHareketleri",
                columns: table => new
                {
                    StokHareketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketID = table.Column<int>(type: "int", nullable: false),
                    StokKartiID = table.Column<int>(type: "int", nullable: false),
                    FaturaKalemID = table.Column<int>(type: "int", nullable: true),
                    SiparisKalemID = table.Column<int>(type: "int", nullable: true),
                    HareketTipi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StokHare__8F9B28C0FCCE4B94", x => x.StokHareketID);
                    table.ForeignKey(
                        name: "FK__StokHarek__Fatur__2BC97F7C",
                        column: x => x.FaturaKalemID,
                        principalTable: "FaturaKalemleri",
                        principalColumn: "FaturaKalemID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__StokHarek__Sipar__2CBDA3B5",
                        column: x => x.SiparisKalemID,
                        principalTable: "SiparisKalemleri",
                        principalColumn: "SiparisKalemID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__StokHarek__Sirke__29E1370A",
                        column: x => x.SirketID,
                        principalTable: "Sirketler",
                        principalColumn: "SirketID");
                    table.ForeignKey(
                        name: "FK__StokHarek__StokK__2AD55B43",
                        column: x => x.StokKartiID,
                        principalTable: "StokKartlari",
                        principalColumn: "StokKartiID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ajanda_OlusturanKullaniciID",
                table: "Ajanda",
                column: "OlusturanKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_SirketlerSirketId",
                table: "AspNetRoles",
                column: "SirketlerSirketId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SirketlerSirketId",
                table: "AspNetUsers",
                column: "SirketlerSirketId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__CariHesa__243A98D632F43645",
                table: "CariHesaplar",
                columns: new[] { "SirketID", "CariKodu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Demirbas__1A24D142F6A8B3E4",
                table: "Demirbaslar",
                column: "SeriNo",
                unique: true,
                filter: "[SeriNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Demirbas__908542280D3788E4",
                table: "Demirbaslar",
                columns: new[] { "SirketID", "DemirbasKodu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalemleri_FaturaID",
                table: "FaturaKalemleri",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalemleri_SirketID",
                table: "FaturaKalemleri",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalemleri_StokKartiID",
                table: "FaturaKalemleri",
                column: "StokKartiID");

            migrationBuilder.CreateIndex(
                name: "IX_Faturalar_CariHesapID",
                table: "Faturalar",
                column: "CariHesapID");

            migrationBuilder.CreateIndex(
                name: "IX_Faturalar_SiparisID",
                table: "Faturalar",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "UQ__Faturala__CD6D56F35F88FB29",
                table: "Faturalar",
                columns: new[] { "SirketID", "FaturaNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinansalHareketler_CariHesapID",
                table: "FinansalHareketler",
                column: "CariHesapID");

            migrationBuilder.CreateIndex(
                name: "IX_FinansalHareketler_FaturaID",
                table: "FinansalHareketler",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_FinansalHareketler_SirketID",
                table: "FinansalHareketler",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelDurumGecmisi_IslemYapanKullaniciID",
                table: "PersonelDurumGecmisi",
                column: "IslemYapanKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelDurumGecmisi_PersonelID",
                table: "PersonelDurumGecmisi",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelDurumGecmisi_SirketID",
                table: "PersonelDurumGecmisi",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelEkBilgileri_PersonelID",
                table: "PersonelEkBilgileri",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelEkBilgileri_SirketID",
                table: "PersonelEkBilgileri",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_SirketID",
                table: "Personeller",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "UQ__Personel__7E1935ED4D4F1021",
                table: "Personeller",
                column: "TCKimlikNo",
                unique: true,
                filter: "[TCKimlikNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMaasBilgileri_PersonelID",
                table: "PersonelMaasBilgileri",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMaasBilgileri_SirketID",
                table: "PersonelMaasBilgileri",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelNotlari_EkleyenKullaniciID",
                table: "PersonelNotlari",
                column: "EkleyenKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelNotlari_PersonelID",
                table: "PersonelNotlari",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelNotlari_SirketID",
                table: "PersonelNotlari",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisKalemleri_SiparisID",
                table: "SiparisKalemleri",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisKalemleri_SirketID",
                table: "SiparisKalemleri",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisKalemleri_StokKartiID",
                table: "SiparisKalemleri",
                column: "StokKartiID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_CariHesapID",
                table: "Siparisler",
                column: "CariHesapID");

            migrationBuilder.CreateIndex(
                name: "UQ__Siparisl__5911603E61DF7F78",
                table: "Siparisler",
                columns: new[] { "SirketID", "SiparisNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Sirketle__3849AC29469978A2",
                table: "Sirketler",
                column: "VergiNo",
                unique: true,
                filter: "[VergiNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Sirketle__DBF43D50D8F3DB30",
                table: "Sirketler",
                column: "SirketAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketleri_FaturaKalemID",
                table: "StokHareketleri",
                column: "FaturaKalemID");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketleri_SiparisKalemID",
                table: "StokHareketleri",
                column: "SiparisKalemID");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketleri_SirketID",
                table: "StokHareketleri",
                column: "SirketID");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketleri_StokKartiID",
                table: "StokHareketleri",
                column: "StokKartiID");

            migrationBuilder.CreateIndex(
                name: "UQ__StokKart__01A1F6E24D7971B0",
                table: "StokKartlari",
                columns: new[] { "SirketID", "StokKodu" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ajanda");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DemirbasAtamaGecmisi");

            migrationBuilder.DropTable(
                name: "Demirbaslar");

            migrationBuilder.DropTable(
                name: "FinansalHareketler");

            migrationBuilder.DropTable(
                name: "PersonelDurumGecmisi");

            migrationBuilder.DropTable(
                name: "PersonelEkBilgileri");

            migrationBuilder.DropTable(
                name: "PersonelMaasBilgileri");

            migrationBuilder.DropTable(
                name: "PersonelNotlari");

            migrationBuilder.DropTable(
                name: "StokHareketleri");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "FaturaKalemleri");

            migrationBuilder.DropTable(
                name: "SiparisKalemleri");

            migrationBuilder.DropTable(
                name: "Faturalar");

            migrationBuilder.DropTable(
                name: "StokKartlari");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "CariHesaplar");

            migrationBuilder.DropTable(
                name: "Sirketler");
        }
    }
}
