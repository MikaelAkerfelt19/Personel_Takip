using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class Departman
{
    public int DepartmanId { get; set; }

    public string Ad { get; set; } = null!;

    public bool Aktif { get; set; }

    public virtual ICollection<Overtime> Overtimes { get; set; } = new List<Overtime>();

    public virtual ICollection<Personel> Personels { get; set; } = new List<Personel>();
}
