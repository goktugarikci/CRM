using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class FinansalHareketler
{
    public int HareketId { get; set; }

    public int SirketId { get; set; }

    public int? CariHesapId { get; set; }

    public int? FaturaId { get; set; }

    public decimal Tutar { get; set; }

    public string HareketTipi { get; set; } = null!;

    public string? Aciklama { get; set; }

    public DateOnly Tarih { get; set; }

    public virtual CariHesaplar? CariHesap { get; set; }

    public virtual Faturalar? Fatura { get; set; }

    public virtual Sirketler Sirket { get; set; } = null!;
}
