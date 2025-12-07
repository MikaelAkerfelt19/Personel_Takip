using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class Avan
{
    public long AvansId { get; set; }

    public int PersonelId { get; set; }

    public decimal TalepTutar { get; set; }

    public string ParaBirimi { get; set; } = null!;

    public byte Durum { get; set; }

    public string? Aciklama { get; set; }

    public int TalepEdenUserId { get; set; }

    public int? OnaylayanUserId { get; set; }

    public DateTime CreatedUtc { get; set; }

    public DateTime? DecisionUtc { get; set; }

    public virtual User? OnaylayanUser { get; set; }

    public virtual Personel Personel { get; set; } = null!;

    public virtual User TalepEdenUser { get; set; } = null!;
}
