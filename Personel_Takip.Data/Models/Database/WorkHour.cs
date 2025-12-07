using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class WorkHour
{
    public long SessionId { get; set; }

    public int PersonelId { get; set; }

    public long AtamaId { get; set; }

    public DateOnly WorkDate { get; set; }

    public DateTime? StartUtc { get; set; }

    public DateTime? EndUtc { get; set; }

    public string? StartSource { get; set; }

    public string? EndSource { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedUtc { get; set; }

    public virtual ShiftAssignment Atama { get; set; } = null!;

    public virtual Personel Personel { get; set; } = null!;
}
