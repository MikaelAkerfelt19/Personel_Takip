using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class UserTwoFactor
{
    public int UserId { get; set; }

    public byte[]? Totpsecret { get; set; }

    public virtual User User { get; set; } = null!;
}
