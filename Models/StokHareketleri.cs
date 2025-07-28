using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class StokHareketleri
{
    public int StokHareketId { get; set; }

    public int SirketId { get; set; }

    public int StokKartiId { get; set; }

    public int? FaturaKalemId { get; set; }

    public int? SiparisKalemId { get; set; }

    public string HareketTipi { get; set; } = null!;

    public decimal Miktar { get; set; }

    public decimal BirimFiyat { get; set; }

    public DateTime? Tarih { get; set; }

    public string? Aciklama { get; set; }

    public virtual FaturaKalemleri? FaturaKalem { get; set; }

    public virtual SiparisKalemleri? SiparisKalem { get; set; }

    public virtual Sirketler Sirket { get; set; } = null!;

    public virtual StokKartlari StokKarti { get; set; } = null!;
}
