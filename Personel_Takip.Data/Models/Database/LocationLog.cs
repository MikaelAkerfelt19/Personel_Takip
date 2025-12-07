using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class LocationLog
{
    public long LogId { get; set; }

    public int PersonelId { get; set; }

    public long? AtamaId { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public byte Reason { get; set; }

    public DateTime EventTimeUtc { get; set; }

    public DateTime CreatedUtc { get; set; }

    public virtual ShiftAssignment? Atama { get; set; }

    public virtual Personel Personel { get; set; } = null!;
}
