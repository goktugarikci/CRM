using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Sirketler
{
    public int SirketId { get; set; }

    public string SirketAdi { get; set; } = null!;

    public string? VergiNo { get; set; }

    public string? Adres { get; set; }

    public string? Telefon { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public virtual ICollection<CariHesaplar> CariHesaplars { get; set; } = new List<CariHesaplar>();

    public virtual ICollection<Demirbaslar> Demirbaslars { get; set; } = new List<Demirbaslar>();

    public virtual ICollection<FaturaKalemleri> FaturaKalemleris { get; set; } = new List<FaturaKalemleri>();

    public virtual ICollection<Faturalar> Faturalars { get; set; } = new List<Faturalar>();

    public virtual ICollection<FinansalHareketler> FinansalHareketlers { get; set; } = new List<FinansalHareketler>();

    public virtual ICollection<Kullanicilar> Kullanicilars { get; set; } = new List<Kullanicilar>();

    public virtual ICollection<PersonelDurumGecmisi> PersonelDurumGecmisis { get; set; } = new List<PersonelDurumGecmisi>();

    public virtual ICollection<PersonelEkBilgileri> PersonelEkBilgileris { get; set; } = new List<PersonelEkBilgileri>();

    public virtual ICollection<PersonelMaasBilgileri> PersonelMaasBilgileris { get; set; } = new List<PersonelMaasBilgileri>();

    public virtual ICollection<PersonelNotlari> PersonelNotlaris { get; set; } = new List<PersonelNotlari>();

    public virtual ICollection<Personeller> Personellers { get; set; } = new List<Personeller>();

    public virtual ICollection<Roller> Rollers { get; set; } = new List<Roller>();

    public virtual ICollection<SiparisKalemleri> SiparisKalemleris { get; set; } = new List<SiparisKalemleri>();

    public virtual ICollection<Siparisler> Siparislers { get; set; } = new List<Siparisler>();

    public virtual ICollection<StokHareketleri> StokHareketleris { get; set; } = new List<StokHareketleri>();

    public virtual ICollection<StokKartlari> StokKartlaris { get; set; } = new List<StokKartlari>();
}
