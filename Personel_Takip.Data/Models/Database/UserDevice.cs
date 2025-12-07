using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class UserDevice
{
    public long CihazId { get; set; }

    public int UserId { get; set; }

    public string DeviceUid { get; set; } = null!;

    public byte Platform { get; set; }

    public byte IzinDurumu { get; set; }

    public int? OnaylayanUserId { get; set; }

    public DateTime? OnayUtc { get; set; }

    public DateTime KayitUtc { get; set; }

    public virtual User? OnaylayanUser { get; set; }

    public virtual User User { get; set; } = null!;
}
