using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class TrackingSession
{
    public long SessionId { get; set; }

    public int PersonelId { get; set; }

    public DateOnly WorkDate { get; set; }

    public long? AtamaId { get; set; }

    public byte Reason { get; set; }

    public DateTime StartedUtc { get; set; }

    public DateTime? EndedUtc { get; set; }

    public bool IsActive { get; set; }

    public byte? EndReason { get; set; }

    public virtual ShiftAssignment? Atama { get; set; }

    public virtual Personel Personel { get; set; } = null!;

    public virtual ICollection<TrackingPoint> TrackingPoints { get; set; } = new List<TrackingPoint>();
}
