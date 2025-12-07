using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class Contract
{
    public int SozlesmeId { get; set; }

    public DateOnly BaslangicTarihi { get; set; }

    public DateOnly? BitisTarihi { get; set; }

    public byte CalismaModu { get; set; }

    public virtual ICollection<Personel> Personels { get; set; } = new List<Personel>();
}
