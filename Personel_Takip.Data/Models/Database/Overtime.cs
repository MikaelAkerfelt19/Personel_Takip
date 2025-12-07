using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class Overtime
{
    public long OvertimeId { get; set; }

    public DateOnly Tarih { get; set; }

    public int? DepartmanId { get; set; }

    public string? Aciklama { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedUtc { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual Departman? Departman { get; set; }

    public virtual ICollection<OvertimeRequest> OvertimeRequests { get; set; } = new List<OvertimeRequest>();
}
