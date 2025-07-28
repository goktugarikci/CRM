using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Ajanda
{
    public int AjandaId { get; set; }

    public string Departman { get; set; } = null!;

    public string NotBaslik { get; set; } = null!;

    public string? NotIcerik { get; set; }

    public DateOnly OlusturulmaTarihi { get; set; }

    public DateOnly? HatirlatmaTarihi { get; set; }

    public string? HatirlatmaGunu { get; set; }

    public bool? Tamamlandi { get; set; }

    public int? OlusturanKullaniciId { get; set; }

    public virtual Kullanicilar? OlusturanKullanici { get; set; }
}
