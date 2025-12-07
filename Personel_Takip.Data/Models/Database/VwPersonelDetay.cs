using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class VwPersonelDetay
{
    public int PersonelId { get; set; }

    public string PersonelAd { get; set; } = null!;

    public string PersonelSoyad { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Tc { get; set; } = null!;

    public bool PersonelAktifMi { get; set; }

    public string DepartmanAdi { get; set; } = null!;

    public DateOnly SozlesmeBaslangic { get; set; }

    public string KullaniciAdi { get; set; } = null!;

    public string? RolAdi { get; set; }
}
