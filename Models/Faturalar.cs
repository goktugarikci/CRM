using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Faturalar
{
    public int FaturaId { get; set; }

    public int SirketId { get; set; }

    public int CariHesapId { get; set; }

    public int? SiparisId { get; set; }

    public string FaturaNo { get; set; } = null!;

    public string FaturaTipi { get; set; } = null!;

    public DateOnly Tarih { get; set; }

    public DateOnly? VadeTarihi { get; set; }

    public decimal AraToplam { get; set; }

    public decimal? KdvTutari { get; set; }

    public decimal GenelToplam { get; set; }

    public string? Durum { get; set; }

    public virtual CariHesaplar CariHesap { get; set; } = null!;

    public virtual ICollection<FaturaKalemleri> FaturaKalemleris { get; set; } = new List<FaturaKalemleri>();

    public virtual ICollection<FinansalHareketler> FinansalHareketlers { get; set; } = new List<FinansalHareketler>();

    public virtual Siparisler? Siparis { get; set; }

    public virtual Sirketler Sirket { get; set; } = null!;
}
