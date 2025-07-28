using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Personeller
{
    public int PersonelId { get; set; }

    public int SirketId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string? TckimlikNo { get; set; }

    public DateOnly? IseGirisTarihi { get; set; }

    public string? Pozisyon { get; set; }

    public string? Departman { get; set; }

    public bool? AktifMi { get; set; }

    public virtual ICollection<PersonelDurumGecmisi> PersonelDurumGecmisis { get; set; } = new List<PersonelDurumGecmisi>();

    public virtual ICollection<PersonelEkBilgileri> PersonelEkBilgileris { get; set; } = new List<PersonelEkBilgileri>();

    public virtual ICollection<PersonelMaasBilgileri> PersonelMaasBilgileris { get; set; } = new List<PersonelMaasBilgileri>();

    public virtual ICollection<PersonelNotlari> PersonelNotlaris { get; set; } = new List<PersonelNotlari>();

    public virtual Sirketler Sirket { get; set; } = null!;
}
