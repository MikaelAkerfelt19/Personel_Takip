using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class LateNotificationLog
{
    public long Id { get; set; }

    public int PersonelId { get; set; }

    public DateOnly WorkDate { get; set; }

    public long? AtamaId { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public virtual ShiftAssignment? Atama { get; set; }

    public virtual Personel Personel { get; set; } = null!;
}
