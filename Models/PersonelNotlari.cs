using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class PersonelNotlari
{
    public int NotId { get; set; }

    public int PersonelId { get; set; }

    public int SirketId { get; set; }

    public int? EkleyenKullaniciId { get; set; }

    public string NotMetni { get; set; } = null!;

    public DateTime? Tarih { get; set; }

    public virtual Kullanicilar? EkleyenKullanici { get; set; }

    public virtual Personeller Personel { get; set; } = null!;

    public virtual Sirketler Sirket { get; set; } = null!;
}
