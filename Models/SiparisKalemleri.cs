using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class SiparisKalemleri
{
    public int SiparisKalemId { get; set; }

    public int SiparisId { get; set; }

    public int SirketId { get; set; }

    public int? StokKartiId { get; set; }

    public string Aciklama { get; set; } = null!;

    public decimal Miktar { get; set; }

    public decimal BirimFiyat { get; set; }

    public decimal ToplamFiyat { get; set; }

    public virtual Siparisler Siparis { get; set; } = null!;

    public virtual Sirketler Sirket { get; set; } = null!;

    public virtual ICollection<StokHareketleri> StokHareketleris { get; set; } = new List<StokHareketleri>();

    public virtual StokKartlari? StokKarti { get; set; }
}
