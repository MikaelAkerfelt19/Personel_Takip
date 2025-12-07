using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class Shift
{
    public int VardiyaId { get; set; }

    public string Ad { get; set; } = null!;

    public int VarsayilanGraceDakika { get; set; }

    public bool Aktif { get; set; }

    public int? PersonelId { get; set; }

    public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();

    public virtual ICollection<ShiftBreak> ShiftBreaks { get; set; } = new List<ShiftBreak>();
}
