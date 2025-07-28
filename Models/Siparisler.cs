using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Siparisler
{
    public int SiparisId { get; set; }

    public int SirketId { get; set; }

    public int CariHesapId { get; set; }

    public string SiparisNo { get; set; } = null!;

    public string SiparisTipi { get; set; } = null!;

    public DateOnly Tarih { get; set; }

    public DateOnly? TeslimTarihi { get; set; }

    public string? Durum { get; set; }

    public virtual CariHesaplar CariHesap { get; set; } = null!;

    public virtual ICollection<Faturalar> Faturalars { get; set; } = new List<Faturalar>();

    public virtual ICollection<SiparisKalemleri> SiparisKalemleris { get; set; } = new List<SiparisKalemleri>();

    public virtual Sirketler Sirket { get; set; } = null!;
}
