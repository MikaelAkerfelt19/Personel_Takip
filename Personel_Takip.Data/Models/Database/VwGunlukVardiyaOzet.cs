using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class VwGunlukVardiyaOzet
{
    public long AtamaId { get; set; }

    public DateOnly WorkDate { get; set; }

    public string PersonelAd { get; set; } = null!;

    public string PersonelSoyad { get; set; } = null!;

    public string VardiyaAdi { get; set; } = null!;

    public string? LokasyonAdi { get; set; }

    public DateTime ShiftStartLocal { get; set; }

    public DateTime ShiftEndLocal { get; set; }

    public int GecKaldiMi { get; set; }

    public int SuAnAktifMi { get; set; }
}
