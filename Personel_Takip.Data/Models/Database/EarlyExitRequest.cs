using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class EarlyExitRequest
{
    public long RequestId { get; set; }

    public int PersonelId { get; set; }

    public long AtamaId { get; set; }

    public DateOnly WorkDate { get; set; }

    public string? Reason { get; set; }

    public byte Status { get; set; }

    public DateTime RequestedUtc { get; set; }

    public DateTime? DecisionUtc { get; set; }

    public int? DeciderUserId { get; set; }

    public virtual ShiftAssignment Atama { get; set; } = null!;

    public virtual User? DeciderUser { get; set; }

    public virtual Personel Personel { get; set; } = null!;
}
