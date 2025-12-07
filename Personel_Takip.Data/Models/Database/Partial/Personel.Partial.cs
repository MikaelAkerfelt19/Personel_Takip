namespace Personel_Takip.Data.Models.Database;

public partial class Personel
{
    public string AdSoyad => $"{PersonelAd} {PersonelSoyad}";
}
