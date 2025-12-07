using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class ShiftBreak
{
    public int MolaId { get; set; }

    public int VardiyaId { get; set; }

    public int BaslangicDakika { get; set; }

    public int SureDakika { get; set; }

    public virtual Shift Vardiya { get; set; } = null!;
}
