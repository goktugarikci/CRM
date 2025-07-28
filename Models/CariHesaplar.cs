using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class CariHesaplar
{
    public int CariHesapId { get; set; }

    public int SirketId { get; set; }

    public string CariKodu { get; set; } = null!;

    public string Unvan { get; set; } = null!;

    public string CariTipi { get; set; } = null!;

    public string? VergiDairesi { get; set; }

    public string? VergiNo { get; set; }

    public decimal? Bakiye { get; set; }

    public virtual ICollection<Faturalar> Faturalars { get; set; } = new List<Faturalar>();

    public virtual ICollection<FinansalHareketler> FinansalHareketlers { get; set; } = new List<FinansalHareketler>();

    public virtual ICollection<Siparisler> Siparislers { get; set; } = new List<Siparisler>();

    public virtual Sirketler Sirket { get; set; } = null!;
}
