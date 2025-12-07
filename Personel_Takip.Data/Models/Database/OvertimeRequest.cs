using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class OvertimeRequest
{
    public long TalepId { get; set; }

    public int PersonelId { get; set; }

    public DateOnly Tarih { get; set; }

    public int SureDakika { get; set; }

    public string? Aciklama { get; set; }

    public byte Durum { get; set; }

    public int TalepEdenUserId { get; set; }

    public int? OnaylayanUserId { get; set; }

    public DateTime CreatedUtc { get; set; }

    public DateTime? DecisionUtc { get; set; }

    public long? OvertimeId { get; set; }

    public virtual User? OnaylayanUser { get; set; }

    public virtual Overtime? Overtime { get; set; }

    public virtual Personel Personel { get; set; } = null!;

    public virtual User TalepEdenUser { get; set; } = null!;
}
