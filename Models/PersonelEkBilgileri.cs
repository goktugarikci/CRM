using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class PersonelEkBilgileri
{
    public int EkBilgiId { get; set; }

    public int PersonelId { get; set; }

    public int SirketId { get; set; }

    public string? Telefon { get; set; }

    public string? Adres { get; set; }

    public string? AcilDurumKontakAdi { get; set; }

    public string? AcilDurumKontakTelefonu { get; set; }

    public virtual Personeller Personel { get; set; } = null!;

    public virtual Sirketler Sirket { get; set; } = null!;
}
