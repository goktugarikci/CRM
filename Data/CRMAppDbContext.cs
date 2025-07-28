using CRM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data
{
    public partial class CRMAppDbContext : IdentityDbContext<Kullanicilar, Roller, int>
    {
        public CRMAppDbContext(DbContextOptions<CRMAppDbContext> options) : base(options) { }

        // --- EKSIK OLAN DbSet'ler EKLENDI ---
        public virtual DbSet<Ajanda> Ajanda { get; set; }
        public virtual DbSet<CariHesaplar> CariHesaplars { get; set; }
        public virtual DbSet<DemirbasAtamaGecmisi> DemirbasAtamaGecmisis { get; set; }
        public virtual DbSet<Demirbaslar> Demirbaslars { get; set; }
        public virtual DbSet<FaturaKalemleri> FaturaKalemleris { get; set; }
        public virtual DbSet<Faturalar> Faturalars { get; set; }
        public virtual DbSet<FinansalHareketler> FinansalHareketlers { get; set; }
        public virtual DbSet<PersonelDurumGecmisi> PersonelDurumGecmisis { get; set; }
        public virtual DbSet<PersonelEkBilgileri> PersonelEkBilgileris { get; set; }
        public virtual DbSet<PersonelMaasBilgileri> PersonelMaasBilgileris { get; set; } // EKLENDI
        public virtual DbSet<PersonelNotlari> PersonelNotlaris { get; set; }
        public virtual DbSet<Personeller> Personellers { get; set; }
        public virtual DbSet<SiparisKalemleri> SiparisKalemleris { get; set; }
        public virtual DbSet<Siparisler> Siparislers { get; set; }
        public virtual DbSet<Sirketler> Sirketlers { get; set; }
        public virtual DbSet<StokHareketleri> StokHareketleris { get; set; }
        public virtual DbSet<StokKartlari> StokKartlaris { get; set; } // EKLENDI

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Identity tablolarinin duzgun calismasi icin bu satir HER ZAMAN en basta olmali!
            base.OnModelCreating(modelBuilder);

            #region Scaffold Ile Gelen Yapilandirmalar
            // Scaffold tarafindan olusturulan orijinal yapilandirmalar.
            // Sadece 'Kullanicilar' ve 'Roller' icin olanlari sildik cunku Identity onlari yonetiyor.

            modelBuilder.Entity<Ajanda>(entity =>
            {
                entity.HasKey(e => e.AjandaId).HasName("PK__Ajanda__DCC2ABA52D80C9E0");

                entity.Property(e => e.AjandaId).HasColumnName("AjandaID");
                entity.Property(e => e.Departman).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.HatirlatmaGunu).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.NotBaslik).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.OlusturanKullaniciId).HasColumnName("OlusturanKullaniciID");
                entity.Property(e => e.Tamamlandi).HasDefaultValue(false);
            });

            modelBuilder.Entity<CariHesaplar>(entity =>
            {
                entity.HasKey(e => e.CariHesapId).HasName("PK__CariHesa__613698EB03E3BBE8");
                entity.ToTable("CariHesaplar");
                entity.HasIndex(e => new { e.SirketId, e.CariKodu }, "UQ__CariHesa__243A98D632F43645").IsUnique();
                entity.Property(e => e.CariHesapId).HasColumnName("CariHesapID");
                entity.Property(e => e.Bakiye).HasDefaultValue(0m).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CariKodu).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.CariTipi).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.Unvan).HasMaxLength(255);
                entity.Property(e => e.VergiDairesi).HasMaxLength(150);
                entity.Property(e => e.VergiNo).HasMaxLength(20).IsUnicode(false);
                entity.HasOne(d => d.Sirket).WithMany(p => p.CariHesaplars).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CariHesap__Sirke__078C1F06");
            });

            modelBuilder.Entity<DemirbasAtamaGecmisi>(entity =>
            {
                entity.HasKey(e => e.AtamaId).HasName("PK__Demirbas__00DE786B4EF94EB7");
                entity.ToTable("DemirbasAtamaGecmisi");
                entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
                entity.Property(e => e.AlanKullaniciId).HasColumnName("AlanKullaniciID");
                entity.Property(e => e.DemirbasId).HasColumnName("DemirbasID");
                entity.Property(e => e.GeriAlinmaTarihi).HasColumnType("datetime");
                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.VerenKullaniciId).HasColumnName("VerenKullaniciID");
                entity.Property(e => e.VerilisTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Demirbaslar>(entity =>
            {
                entity.HasKey(e => e.DemirbasId).HasName("PK__Demirbas__0AED0CA271325D69");
                entity.ToTable("Demirbaslar");
                entity.HasIndex(e => e.SeriNo, "UQ__Demirbas__1A24D142F6A8B3E4").IsUnique();
                entity.HasIndex(e => new { e.SirketId, e.DemirbasKodu }, "UQ__Demirbas__908542280D3788E4").IsUnique();
                entity.Property(e => e.DemirbasId).HasColumnName("DemirbasID");
                entity.Property(e => e.DemirbasAdi).HasMaxLength(255);
                entity.Property(e => e.DemirbasKodu).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Kategori).HasMaxLength(100);
                entity.Property(e => e.MevcutDurum).HasMaxLength(50).HasDefaultValue("Depoda");
                entity.Property(e => e.Model).HasMaxLength(150);
                entity.Property(e => e.SeriNo).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.HasOne(d => d.Sirket).WithMany(p => p.Demirbaslars).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Demirbasl__Sirke__43A1090D");
            });

            modelBuilder.Entity<FaturaKalemleri>(entity =>
            {
                entity.HasKey(e => e.FaturaKalemId).HasName("PK__FaturaKa__80EDE66AD521BDB7");
                entity.ToTable("FaturaKalemleri");
                entity.Property(e => e.FaturaKalemId).HasColumnName("FaturaKalemID");
                entity.Property(e => e.Aciklama).HasMaxLength(255);
                entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FaturaId).HasColumnName("FaturaID");
                entity.Property(e => e.KdvOrani).HasDefaultValue(18);
                entity.Property(e => e.Miktar).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.StokKartiId).HasColumnName("StokKartiID");
                entity.Property(e => e.ToplamFiyat).HasColumnType("decimal(18, 2)");
                entity.HasOne(d => d.Fatura).WithMany(p => p.FaturaKalemleris).HasForeignKey(d => d.FaturaId).HasConstraintName("FK__FaturaKal__Fatur__251C81ED");
                entity.HasOne(d => d.Sirket).WithMany(p => p.FaturaKalemleris).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__FaturaKal__Sirke__2610A626");
                entity.HasOne(d => d.StokKarti).WithMany(p => p.FaturaKalemleris).HasForeignKey(d => d.StokKartiId).HasConstraintName("fk_fatura_stok");
            });

            modelBuilder.Entity<Faturalar>(entity =>
            {
                entity.HasKey(e => e.FaturaId).HasName("PK__Faturala__84301C40B143F2AF");
                entity.ToTable("Faturalar");
                entity.HasIndex(e => new { e.SirketId, e.FaturaNo }, "UQ__Faturala__CD6D56F35F88FB29").IsUnique();
                entity.Property(e => e.FaturaId).HasColumnName("FaturaID");
                entity.Property(e => e.AraToplam).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CariHesapId).HasColumnName("CariHesapID");
                entity.Property(e => e.Durum).HasMaxLength(50).IsUnicode(false).HasDefaultValue("Beklemede");
                entity.Property(e => e.FaturaNo).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.FaturaTipi).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.GenelToplam).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.KdvTutari).HasDefaultValue(0m).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.HasOne(d => d.CariHesap).WithMany(p => p.Faturalars).HasForeignKey(d => d.CariHesapId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Faturalar__CariH__2057CCD0");
                entity.HasOne(d => d.Siparis).WithMany(p => p.Faturalars).HasForeignKey(d => d.SiparisId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("FK__Faturalar__Sipar__214BF109");
                entity.HasOne(d => d.Sirket).WithMany(p => p.Faturalars).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Faturalar__Sirke__1F63A897");
            });

            modelBuilder.Entity<FinansalHareketler>(entity =>
            {
                entity.HasKey(e => e.HareketId).HasName("PK__Finansal__50654B06E424F44B");
                entity.ToTable("FinansalHareketler");
                entity.Property(e => e.HareketId).HasColumnName("HareketID");
                entity.Property(e => e.CariHesapId).HasColumnName("CariHesapID");
                entity.Property(e => e.FaturaId).HasColumnName("FaturaID");
                entity.Property(e => e.HareketTipi).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.Tutar).HasColumnType("decimal(18, 2)");
                entity.HasOne(d => d.CariHesap).WithMany(p => p.FinansalHareketlers).HasForeignKey(d => d.CariHesapId).HasConstraintName("FK__FinansalH__CariH__0B5CAFEA");
                entity.HasOne(d => d.Fatura).WithMany(p => p.FinansalHareketlers).HasForeignKey(d => d.FaturaId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("fk_finans_fatura");
                entity.HasOne(d => d.Sirket).WithMany(p => p.FinansalHareketlers).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__FinansalH__Sirke__0A688BB1");
            });

            modelBuilder.Entity<PersonelDurumGecmisi>(entity =>
            {
                entity.HasKey(e => e.DurumGecmisId).HasName("PK__Personel__EDDDD12E24668969");
                entity.ToTable("PersonelDurumGecmisi");
                entity.Property(e => e.DurumGecmisId).HasColumnName("DurumGecmisID");
                entity.Property(e => e.Durum).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.IslemYapanKullaniciId).HasColumnName("IslemYapanKullaniciID");
                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.HasOne(d => d.Personel).WithMany(p => p.PersonelDurumGecmisis).HasForeignKey(d => d.PersonelId).HasConstraintName("FK__PersonelD__Perso__72910220");
                entity.HasOne(d => d.Sirket).WithMany(p => p.PersonelDurumGecmisis).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PersonelD__Sirke__73852659");
            });

            modelBuilder.Entity<PersonelEkBilgileri>(entity =>
            {
                entity.HasKey(e => e.EkBilgiId).HasName("PK__Personel__56BE018F99884029");
                entity.ToTable("PersonelEkBilgileri");
                entity.Property(e => e.EkBilgiId).HasColumnName("EkBilgiID");
                entity.Property(e => e.AcilDurumKontakAdi).HasMaxLength(150);
                entity.Property(e => e.AcilDurumKontakTelefonu).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.Telefon).HasMaxLength(20).IsUnicode(false);
                entity.HasOne(d => d.Personel).WithMany(p => p.PersonelEkBilgileris).HasForeignKey(d => d.PersonelId).HasConstraintName("FK__PersonelE__Perso__7C1A6C5A");
                entity.HasOne(d => d.Sirket).WithMany(p => p.PersonelEkBilgileris).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PersonelE__Sirke__7D0E9093");
            });

            modelBuilder.Entity<PersonelMaasBilgileri>(entity =>
            {
                entity.HasKey(e => e.MaasId).HasName("PK__Personel__22D00316EA900DE7");
                entity.ToTable("PersonelMaasBilgileri");
                entity.Property(e => e.MaasId).HasColumnName("MaasID");
                entity.Property(e => e.BankaHesapNo).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.MaasTutar).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.OdemePeriyodu).HasMaxLength(50).IsUnicode(false).HasDefaultValue("Aylık");
                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.HasOne(d => d.Personel).WithMany(p => p.PersonelMaasBilgileris).HasForeignKey(d => d.PersonelId).HasConstraintName("FK__PersonelM__Perso__7849DB76");
                entity.HasOne(d => d.Sirket).WithMany(p => p.PersonelMaasBilgileris).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PersonelM__Sirke__793DFFAF");
            });

            modelBuilder.Entity<PersonelNotlari>(entity =>
            {
                entity.HasKey(e => e.NotId).HasName("PK__Personel__4FB200AAFCCFBE90");
                entity.ToTable("PersonelNotlari");
                entity.Property(e => e.NotId).HasColumnName("NotID");
                entity.Property(e => e.EkleyenKullaniciId).HasColumnName("EkleyenKullaniciID");
                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.Tarih).HasColumnType("datetime");
                entity.HasOne(d => d.Personel).WithMany(p => p.PersonelNotlaris).HasForeignKey(d => d.PersonelId).HasConstraintName("FK__PersonelN__Perso__00DF2177");
                entity.HasOne(d => d.Sirket).WithMany(p => p.PersonelNotlaris).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PersonelN__Sirke__01D345B0");
            });

            modelBuilder.Entity<Personeller>(entity =>
            {
                entity.HasKey(e => e.PersonelId).HasName("PK__Personel__0F0C57517A080A22");
                entity.ToTable("Personeller");
                entity.HasIndex(e => e.TckimlikNo, "UQ__Personel__7E1935ED4D4F1021").IsUnique();
                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
                entity.Property(e => e.Ad).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.AktifMi).HasDefaultValue(true);
                entity.Property(e => e.Departman).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Pozisyon).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.Soyad).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.TckimlikNo).HasMaxLength(11).IsUnicode(false).HasColumnName("TCKimlikNo");
                entity.HasOne(d => d.Sirket).WithMany(p => p.Personellers).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Personell__Sirke__6FB49575");
            });

            modelBuilder.Entity<SiparisKalemleri>(entity =>
            {
                entity.HasKey(e => e.SiparisKalemId).HasName("PK__SiparisK__66721F4222BFDCD4");
                entity.ToTable("SiparisKalemleri");
                entity.Property(e => e.SiparisKalemId).HasColumnName("SiparisKalemID");
                entity.Property(e => e.Aciklama).HasMaxLength(255);
                entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Miktar).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.StokKartiId).HasColumnName("StokKartiID");
                entity.Property(e => e.ToplamFiyat).HasColumnType("decimal(18, 2)");
                entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisKalemleris).HasForeignKey(d => d.SiparisId).HasConstraintName("FK__SiparisKa__Sipar__13F1F5EB");
                entity.HasOne(d => d.Sirket).WithMany(p => p.SiparisKalemleris).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__SiparisKa__Sirke__14E61A24");
                entity.HasOne(d => d.StokKarti).WithMany(p => p.SiparisKalemleris).HasForeignKey(d => d.StokKartiId).HasConstraintName("fk_siparis_stok");
            });

            modelBuilder.Entity<Siparisler>(entity =>
            {
                entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__C3F03BDD6DC41C10");
                entity.ToTable("Siparisler");
                entity.HasIndex(e => new { e.SirketId, e.SiparisNo }, "UQ__Siparisl__5911603E61DF7F78").IsUnique();
                entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
                entity.Property(e => e.CariHesapId).HasColumnName("CariHesapID");
                entity.Property(e => e.Durum).HasMaxLength(50).IsUnicode(false).HasDefaultValue("Açık");
                entity.Property(e => e.SiparisNo).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.SiparisTipi).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.HasOne(d => d.CariHesap).WithMany(p => p.Siparislers).HasForeignKey(d => d.CariHesapId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Siparisle__CariH__11158940");
                entity.HasOne(d => d.Sirket).WithMany(p => p.Siparislers).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Siparisle__Sirke__10216507");
            });

            modelBuilder.Entity<Sirketler>(entity =>
            {
                entity.HasKey(e => e.SirketId).HasName("PK__Sirketle__E52E4AAEDE706344");
                entity.ToTable("Sirketler");
                entity.HasIndex(e => e.VergiNo, "UQ__Sirketle__3849AC29469978A2").IsUnique();
                entity.HasIndex(e => e.SirketAdi, "UQ__Sirketle__DBF43D50D8F3DB30").IsUnique();
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
                entity.Property(e => e.SirketAdi).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Telefon).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.VergiNo).HasMaxLength(20).IsUnicode(false);
            });

            modelBuilder.Entity<StokHareketleri>(entity =>
            {
                entity.HasKey(e => e.StokHareketId).HasName("PK__StokHare__8F9B28C0FCCE4B94");
                entity.ToTable("StokHareketleri");
                entity.Property(e => e.StokHareketId).HasColumnName("StokHareketID");
                entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FaturaKalemId).HasColumnName("FaturaKalemID");
                entity.Property(e => e.HareketTipi).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Miktar).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.SiparisKalemId).HasColumnName("SiparisKalemID");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.StokKartiId).HasColumnName("StokKartiID");
                entity.Property(e => e.Tarih).HasColumnType("datetime");
                entity.HasOne(d => d.FaturaKalem).WithMany(p => p.StokHareketleris).HasForeignKey(d => d.FaturaKalemId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("FK__StokHarek__Fatur__2BC97F7C");
                entity.HasOne(d => d.SiparisKalem).WithMany(p => p.StokHareketleris).HasForeignKey(d => d.SiparisKalemId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("FK__StokHarek__Sipar__2CBDA3B5");
                entity.HasOne(d => d.Sirket).WithMany(p => p.StokHareketleris).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StokHarek__Sirke__29E1370A");
                entity.HasOne(d => d.StokKarti).WithMany(p => p.StokHareketleris).HasForeignKey(d => d.StokKartiId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StokHarek__StokK__2AD55B43");
            });

            modelBuilder.Entity<StokKartlari>(entity =>
            {
                entity.HasKey(e => e.StokKartiId).HasName("PK__StokKart__03151E01ACE6C3BE");
                entity.ToTable("StokKartlari");
                entity.HasIndex(e => new { e.SirketId, e.StokKodu }, "UQ__StokKart__01A1F6E24D7971B0").IsUnique();
                entity.Property(e => e.StokKartiId).HasColumnName("StokKartiID");
                entity.Property(e => e.Birim).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.MevcutMiktar).HasDefaultValue(0m).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.SirketId).HasColumnName("SirketID");
                entity.Property(e => e.StokAdi).HasMaxLength(255);
                entity.Property(e => e.StokKodu).HasMaxLength(100).IsUnicode(false);
                entity.HasOne(d => d.Sirket).WithMany(p => p.StokKartlaris).HasForeignKey(d => d.SirketId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StokKartl__Sirke__19AACF41");
            });

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
