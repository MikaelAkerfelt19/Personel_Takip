using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class Prim
{
    public long Id { get; set; }

    public int PersonelId { get; set; }

    public DateOnly Tarih { get; set; }

    public decimal Tutar { get; set; }

    public byte Tur { get; set; }

    public string? Kaynak { get; set; }

    public string? Aciklama { get; set; }

    public byte OnayDurumu { get; set; }

    public int? OnaylayanUserId { get; set; }

    public DateTime CreatedUtc { get; set; }

    public virtual User? OnaylayanUser { get; set; }

    public virtual Personel Personel { get; set; } = null!;
}
