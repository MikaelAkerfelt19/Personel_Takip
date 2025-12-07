using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class UserTwoFactorCode
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public byte[] CodeHash { get; set; } = null!;

    public DateTime ExpiresUtc { get; set; }

    public bool Used { get; set; }

    public DateTime CreatedUtc { get; set; }

    public virtual User User { get; set; } = null!;
}
