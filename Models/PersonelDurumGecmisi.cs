using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class PersonelDurumGecmisi
{
    public int DurumGecmisId { get; set; }

    public int PersonelId { get; set; }

    public int SirketId { get; set; }

    public string Durum { get; set; } = null!;

    public DateOnly Tarih { get; set; }

    public string? Aciklama { get; set; }

    public int? IslemYapanKullaniciId { get; set; }

    public virtual Kullanicilar? IslemYapanKullanici { get; set; }

    public virtual Personeller Personel { get; set; } = null!;

    public virtual Sirketler Sirket { get; set; } = null!;
}
