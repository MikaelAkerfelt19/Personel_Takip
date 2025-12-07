using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class ExternalMisson
{
    public long GorevId { get; set; }

    public int PersonelId { get; set; }

    public DateTime BaslangicUtc { get; set; }

    public DateTime BitisUtc { get; set; }

    public string? Aciklama { get; set; }

    public string? LokasyonAdi { get; set; }

    public byte OnayDurumu { get; set; }

    public int TalepEdenUserId { get; set; }

    public int? OnaylayanUserId { get; set; }

    public virtual User? OnaylayanUser { get; set; }

    public virtual Personel Personel { get; set; } = null!;

    public virtual User TalepEdenUser { get; set; } = null!;
}
