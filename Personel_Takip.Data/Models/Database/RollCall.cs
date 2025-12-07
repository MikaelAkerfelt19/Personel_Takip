using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class RollCall
{
    public long OlayId { get; set; }

    public int PersonelId { get; set; }

    public long? AtamaId { get; set; }

    public byte EventType { get; set; }

    public DateTime EventTimeUtc { get; set; }

    public string Source { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual ShiftAssignment? Atama { get; set; }

    public virtual Personel Personel { get; set; } = null!;
}
