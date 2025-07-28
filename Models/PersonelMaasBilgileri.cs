using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class PersonelMaasBilgileri
{
    public int MaasId { get; set; }

    public int PersonelId { get; set; }

    public int SirketId { get; set; }

    public decimal MaasTutar { get; set; }

    public string? OdemePeriyodu { get; set; }

    public string? BankaHesapNo { get; set; }

    public DateOnly BaslangicTarihi { get; set; }

    public virtual Personeller Personel { get; set; } = null!;

    public virtual Sirketler Sirket { get; set; } = null!;
}
