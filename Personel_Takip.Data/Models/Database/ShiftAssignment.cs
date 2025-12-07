using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class ShiftAssignment
{
    public long AtamaId { get; set; }

    public int PersonelId { get; set; }

    public int? VardiyaId { get; set; }

    public DateOnly WorkDate { get; set; }

    public DateTime ShiftStartLocal { get; set; }

    public DateTime ShiftEndLocal { get; set; }

    public int GraceMinutes { get; set; }

    public int? LokasyonId { get; set; }

    public bool EsnekMi { get; set; }

    public virtual ICollection<EarlyExitRequest> EarlyExitRequests { get; set; } = new List<EarlyExitRequest>();

    public virtual ICollection<LateNotificationLog> LateNotificationLogs { get; set; } = new List<LateNotificationLog>();

    public virtual ICollection<LocationLog> LocationLogs { get; set; } = new List<LocationLog>();

    public virtual Location? Lokasyon { get; set; }

    public virtual Personel Personel { get; set; } = null!;

    public virtual ICollection<RollCall> RollCalls { get; set; } = new List<RollCall>();

    public virtual ICollection<TrackingSession> TrackingSessions { get; set; } = new List<TrackingSession>();

    public virtual Shift? Vardiya { get; set; }

    public virtual ICollection<WorkHour> WorkHours { get; set; } = new List<WorkHour>();
}
