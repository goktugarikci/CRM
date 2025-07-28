using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class DemirbasAtamaGecmisi
{
    public int AtamaId { get; set; }

    public int SirketId { get; set; }

    public int DemirbasId { get; set; }

    public int PersonelId { get; set; }

    public DateTime VerilisTarihi { get; set; }

    public int? VerenKullaniciId { get; set; }

    public string? VerilisNotu { get; set; }

    public DateTime? GeriAlinmaTarihi { get; set; }

    public int? AlanKullaniciId { get; set; }

    public string? GeriAlinmaNotu { get; set; }
}
