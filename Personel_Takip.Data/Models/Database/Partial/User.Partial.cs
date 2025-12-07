namespace Personel_Takip.Data.Models.Database;

public partial class User
{
    public bool HasPersonelKaydi => Personel is not null;
}
