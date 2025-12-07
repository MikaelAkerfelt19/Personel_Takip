using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class Location
{
    public int LokasyonId { get; set; }

    public string Ad { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int RadiusM { get; set; }

    public bool Aktif { get; set; }

    public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();
}
