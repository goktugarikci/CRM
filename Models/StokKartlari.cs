using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class StokKartlari
{
    public int StokKartiId { get; set; }

    public int SirketId { get; set; }

    public string StokKodu { get; set; } = null!;

    public string StokAdi { get; set; } = null!;

    public string? Birim { get; set; }

    public decimal? MevcutMiktar { get; set; }

    public virtual ICollection<FaturaKalemleri> FaturaKalemleris { get; set; } = new List<FaturaKalemleri>();

    public virtual ICollection<SiparisKalemleri> SiparisKalemleris { get; set; } = new List<SiparisKalemleri>();

    public virtual Sirketler Sirket { get; set; } = null!;

    public virtual ICollection<StokHareketleri> StokHareketleris { get; set; } = new List<StokHareketleri>();
}
