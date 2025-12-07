using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class Personel
{
    public int PersonelId { get; set; }

    public string PersonelAd { get; set; } = null!;

    public string PersonelSoyad { get; set; } = null!;

    public DateOnly IseGirisTarihi { get; set; }

    public DateOnly? IstenCikisTarihi { get; set; }

    public bool Durum { get; set; }

    public string Email { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Tc { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public int DepartmanId { get; set; }

    public int SozlesmeId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Avan> Avans { get; set; } = new List<Avan>();

    public virtual Departman Departman { get; set; } = null!;

    public virtual ICollection<EarlyExitRequest> EarlyExitRequests { get; set; } = new List<EarlyExitRequest>();

    public virtual ICollection<ExternalMisson> ExternalMissons { get; set; } = new List<ExternalMisson>();

    public virtual ICollection<LateNotificationLog> LateNotificationLogs { get; set; } = new List<LateNotificationLog>();

    public virtual ICollection<LocationLog> LocationLogs { get; set; } = new List<LocationLog>();

    public virtual ICollection<OvertimeRequest> OvertimeRequests { get; set; } = new List<OvertimeRequest>();

    public virtual ICollection<Prim> Prims { get; set; } = new List<Prim>();

    public virtual ICollection<RollCall> RollCalls { get; set; } = new List<RollCall>();

    public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();

    public virtual Contract Sozlesme { get; set; } = null!;

    public virtual ICollection<TrackingSession> TrackingSessions { get; set; } = new List<TrackingSession>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WorkHour> WorkHours { get; set; } = new List<WorkHour>();
}
