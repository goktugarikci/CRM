using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Demirbaslar
{
    public int DemirbasId { get; set; }

    public int SirketId { get; set; }

    public string DemirbasKodu { get; set; } = null!;

    public string DemirbasAdi { get; set; } = null!;

    public string? Kategori { get; set; }

    public string? Model { get; set; }

    public string? SeriNo { get; set; }

    public DateOnly? AlinmaTarihi { get; set; }

    public string? MevcutDurum { get; set; }

    public virtual Sirketler Sirket { get; set; } = null!;
}
