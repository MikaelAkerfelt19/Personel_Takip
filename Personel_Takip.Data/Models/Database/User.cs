using System;
using System.Collections.Generic;

namespace Personel_Takip.Data.Models.Database;

public partial class User
{
    public int UserId { get; set; }

    public string KullaniciAdi { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefon { get; set; }

    public byte[] SifreHash { get; set; } = null!;

    public byte[] SifreSalt { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime OlusturulmaUtc { get; set; }

    public DateTime? SonGirisUtc { get; set; }

    public virtual ICollection<Avan> AvanOnaylayanUsers { get; set; } = new List<Avan>();

    public virtual ICollection<Avan> AvanTalepEdenUsers { get; set; } = new List<Avan>();

    public virtual ICollection<EarlyExitRequest> EarlyExitRequests { get; set; } = new List<EarlyExitRequest>();

    public virtual ICollection<ExternalMisson> ExternalMissonOnaylayanUsers { get; set; } = new List<ExternalMisson>();

    public virtual ICollection<ExternalMisson> ExternalMissonTalepEdenUsers { get; set; } = new List<ExternalMisson>();

    public virtual ICollection<OvertimeRequest> OvertimeRequestOnaylayanUsers { get; set; } = new List<OvertimeRequest>();

    public virtual ICollection<OvertimeRequest> OvertimeRequestTalepEdenUsers { get; set; } = new List<OvertimeRequest>();

    public virtual ICollection<Overtime> Overtimes { get; set; } = new List<Overtime>();

    public virtual Personel? Personel { get; set; }

    public virtual ICollection<Prim> Prims { get; set; } = new List<Prim>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<UserDevice> UserDeviceOnaylayanUsers { get; set; } = new List<UserDevice>();

    public virtual ICollection<UserDevice> UserDeviceUsers { get; set; } = new List<UserDevice>();

    public virtual UserTwoFactor? UserTwoFactor { get; set; }

    public virtual ICollection<UserTwoFactorCode> UserTwoFactorCodes { get; set; } = new List<UserTwoFactorCode>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
