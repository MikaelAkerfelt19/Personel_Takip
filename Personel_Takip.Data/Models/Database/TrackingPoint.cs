using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class TrackingPoint
{
    public long PointId { get; set; }

    public long SessionId { get; set; }

    public DateTime EventTimeUtc { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int? AccuracyM { get; set; }

    public decimal? SpeedMps { get; set; }

    public bool IsInsideFence { get; set; }

    public virtual TrackingSession Session { get; set; } = null!;
}
