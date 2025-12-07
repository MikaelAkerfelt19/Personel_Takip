using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Personel_Takip.Data.Models.Database;

public partial class PersonelContext : DbContext
{
    public PersonelContext()
    {
    }

    public PersonelContext(DbContextOptions<PersonelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avan> Avans { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Departman> Departmen { get; set; }

    public virtual DbSet<EarlyExitRequest> EarlyExitRequests { get; set; }

    public virtual DbSet<ExternalMisson> ExternalMissons { get; set; }

    public virtual DbSet<LateNotificationLog> LateNotificationLogs { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationLog> LocationLogs { get; set; }

    public virtual DbSet<Overtime> Overtimes { get; set; }

    public virtual DbSet<OvertimeRequest> OvertimeRequests { get; set; }

    public virtual DbSet<Personel> Personels { get; set; }

    public virtual DbSet<Prim> Prims { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RollCall> RollCalls { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftAssignment> ShiftAssignments { get; set; }

    public virtual DbSet<ShiftBreak> ShiftBreaks { get; set; }

    public virtual DbSet<TrackingPoint> TrackingPoints { get; set; }

    public virtual DbSet<TrackingSession> TrackingSessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDevice> UserDevices { get; set; }

    public virtual DbSet<UserTwoFactor> UserTwoFactors { get; set; }

    public virtual DbSet<UserTwoFactorCode> UserTwoFactorCodes { get; set; }

    public virtual DbSet<VwGunlukVardiyaOzet> VwGunlukVardiyaOzets { get; set; }

    public virtual DbSet<VwPersonelDetay> VwPersonelDetays { get; set; }

    public virtual DbSet<WorkHour> WorkHours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:PersonelConnection");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avan>(entity =>
        {
            entity.HasKey(e => e.AvansId).HasName("PK__AvansTal__60CB1686184A6E05");

            entity.HasIndex(e => new { e.PersonelId, e.Durum }, "IX_AvansTalep_Personel");

            entity.Property(e => e.AvansId).HasColumnName("AvansID");
            entity.Property(e => e.Aciklama).HasMaxLength(300);
            entity.Property(e => e.CreatedUtc).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.OnaylayanUserId).HasColumnName("OnaylayanUserID");
            entity.Property(e => e.ParaBirimi)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength();
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.TalepEdenUserId).HasColumnName("TalepEdenUserID");
            entity.Property(e => e.TalepTutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OnaylayanUser).WithMany(p => p.AvanOnaylayanUsers)
                .HasForeignKey(d => d.OnaylayanUserId)
                .HasConstraintName("FK__AvansTale__Onayl__3A4CA8FD");

            entity.HasOne(d => d.Personel).WithMany(p => p.Avans)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AvansTale__Perso__3864608B");

            entity.HasOne(d => d.TalepEdenUser).WithMany(p => p.AvanTalepEdenUsers)
                .HasForeignKey(d => d.TalepEdenUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AvansTale__Talep__395884C4");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.SozlesmeId).HasName("PK__Sozlesme__00002899226D530B");

            entity.ToTable("Contract");

            entity.Property(e => e.SozlesmeId).HasColumnName("SozlesmeID");
        });

        modelBuilder.Entity<Departman>(entity =>
        {
            entity.HasKey(e => e.DepartmanId).HasName("PK__Departma__3A231236076262D5");

            entity.ToTable("Departman");

            entity.HasIndex(e => e.Ad, "UQ__Departma__3214AD00213396E9").IsUnique();

            entity.Property(e => e.DepartmanId).HasColumnName("DepartmanID");
            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Aktif).HasDefaultValue(true);
        });

        modelBuilder.Entity<EarlyExitRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__EarlyExi__33A8519AE4248939");

            entity.ToTable("EarlyExitRequest");

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "UX_EER_Pending")
                .IsUnique()
                .HasFilter("([Status]=(0))");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
            entity.Property(e => e.DeciderUserId).HasColumnName("DeciderUserID");
            entity.Property(e => e.DecisionUtc).HasPrecision(0);
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.RequestedUtc)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Atama).WithMany(p => p.EarlyExitRequests)
                .HasForeignKey(d => d.AtamaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EER_Atama");

            entity.HasOne(d => d.DeciderUser).WithMany(p => p.EarlyExitRequests)
                .HasForeignKey(d => d.DeciderUserId)
                .HasConstraintName("FK_EER_User");

            entity.HasOne(d => d.Personel).WithMany(p => p.EarlyExitRequests)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EER_Personel");
        });

        modelBuilder.Entity<ExternalMisson>(entity =>
        {
            entity.HasKey(e => e.GorevId).HasName("PK__HariciGo__2BC59949976DEC59");

            entity.ToTable("ExternalMisson");

            entity.HasIndex(e => new { e.PersonelId, e.BaslangicUtc }, "IX_HariciGorev_Personel_Time");

            entity.Property(e => e.GorevId).HasColumnName("GorevID");
            entity.Property(e => e.Aciklama).HasMaxLength(300);
            entity.Property(e => e.LokasyonAdi).HasMaxLength(120);
            entity.Property(e => e.OnaylayanUserId).HasColumnName("OnaylayanUserID");
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.TalepEdenUserId).HasColumnName("TalepEdenUserID");

            entity.HasOne(d => d.OnaylayanUser).WithMany(p => p.ExternalMissonOnaylayanUsers)
                .HasForeignKey(d => d.OnaylayanUserId)
                .HasConstraintName("FK__HariciGor__Onayl__1CBC4616");

            entity.HasOne(d => d.Personel).WithMany(p => p.ExternalMissons)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HariciGor__Perso__1AD3FDA4");

            entity.HasOne(d => d.TalepEdenUser).WithMany(p => p.ExternalMissonTalepEdenUsers)
                .HasForeignKey(d => d.TalepEdenUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HariciGor__Talep__1BC821DD");
        });

        modelBuilder.Entity<LateNotificationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LateNoti__3214EC0780ECAA29");

            entity.ToTable("LateNotificationLog");

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "UX_LateNotif_Personel_WorkDate").IsUnique();

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "UX_LateNotificationLog_Personel_WorkDate").IsUnique();

            entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
            entity.Property(e => e.CreatedAtUtc)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");

            entity.HasOne(d => d.Atama).WithMany(p => p.LateNotificationLogs)
                .HasForeignKey(d => d.AtamaId)
                .HasConstraintName("FK__LateNotif__Atama__10566F31");

            entity.HasOne(d => d.Personel).WithMany(p => p.LateNotificationLogs)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LateNotif__Perso__0F624AF8");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LokasyonId).HasName("PK__IsyeriLo__553543C210DC8CCE");

            entity.ToTable("Location");

            entity.Property(e => e.LokasyonId).HasColumnName("LokasyonID");
            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Aktif).HasDefaultValue(true);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
        });

        modelBuilder.Entity<LocationLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__KonumLog__5E5499A8DC924787");

            entity.ToTable("LocationLog");

            entity.HasIndex(e => new { e.PersonelId, e.EventTimeUtc }, "IX_KonumLog_Personel_Time");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
            entity.Property(e => e.CreatedUtc)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.EventTimeUtc).HasPrecision(0);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");

            entity.HasOne(d => d.Atama).WithMany(p => p.LocationLogs)
                .HasForeignKey(d => d.AtamaId)
                .HasConstraintName("FK__KonumLog__AtamaI__151B244E");

            entity.HasOne(d => d.Personel).WithMany(p => p.LocationLogs)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KonumLog__Person__14270015");
        });

        modelBuilder.Entity<Overtime>(entity =>
        {
            entity.HasKey(e => e.OvertimeId).HasName("PK__MesaiGun__3214EC0799D50853");

            entity.ToTable("Overtime");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedUtc).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DepartmanId).HasColumnName("DepartmanID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Overtimes)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MesaiGunD__Creat__2A164134");

            entity.HasOne(d => d.Departman).WithMany(p => p.Overtimes)
                .HasForeignKey(d => d.DepartmanId)
                .HasConstraintName("FK__MesaiGunD__Depar__29221CFB");
        });

        modelBuilder.Entity<OvertimeRequest>(entity =>
        {
            entity.HasKey(e => e.TalepId).HasName("PK__MesaiTal__AF651643314FABDC");

            entity.ToTable("OvertimeRequest");

            entity.HasIndex(e => new { e.PersonelId, e.Tarih }, "IX_MesaiTalep_Personel_Tarih");

            entity.Property(e => e.TalepId).HasColumnName("TalepID");
            entity.Property(e => e.Aciklama).HasMaxLength(300);
            entity.Property(e => e.CreatedUtc).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.OnaylayanUserId).HasColumnName("OnaylayanUserID");
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.TalepEdenUserId).HasColumnName("TalepEdenUserID");

            entity.HasOne(d => d.OnaylayanUser).WithMany(p => p.OvertimeRequestOnaylayanUsers)
                .HasForeignKey(d => d.OnaylayanUserId)
                .HasConstraintName("FK__MesaiTale__Onayl__25518C17");

            entity.HasOne(d => d.Overtime).WithMany(p => p.OvertimeRequests)
                .HasForeignKey(d => d.OvertimeId)
                .HasConstraintName("FK_OvertimeRequest_Overtime");

            entity.HasOne(d => d.Personel).WithMany(p => p.OvertimeRequests)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MesaiTale__Perso__236943A5");

            entity.HasOne(d => d.TalepEdenUser).WithMany(p => p.OvertimeRequestTalepEdenUsers)
                .HasForeignKey(d => d.TalepEdenUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MesaiTale__Talep__245D67DE");
        });

        modelBuilder.Entity<Personel>(entity =>
        {
            entity.HasKey(e => e.PersonelId).HasName("PK__Personel__0F0C57513F06E225");

            entity.ToTable("Personel", tb => tb.HasTrigger("trg_Personel_GuvenliSilme"));

            entity.HasIndex(e => new { e.PersonelAd, e.PersonelSoyad }, "IX_Personel_AdSoyad");

            entity.HasIndex(e => e.UserId, "UQ__Personel__1788CCADF0FB3443").IsUnique();

            entity.HasIndex(e => e.Tc, "UQ__Personel__3214E409176A3F4C").IsUnique();

            entity.HasIndex(e => e.Telefon, "UQ__Personel__92EB4169A59B91E7").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Personel__A9D105345CA95FB4").IsUnique();

            entity.HasIndex(e => e.Email, "UX_Personel_Email").IsUnique();

            entity.HasIndex(e => e.Tc, "UX_Personel_TC").IsUnique();

            entity.HasIndex(e => e.Telefon, "UX_Personel_Telefon").IsUnique();

            entity.HasIndex(e => e.UserId, "UX_Personel_UserID").IsUnique();

            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.Adres).HasMaxLength(200);
            entity.Property(e => e.DepartmanId).HasColumnName("DepartmanID");
            entity.Property(e => e.Durum).HasDefaultValue(true);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.PersonelAd)
                .HasMaxLength(50)
                .HasColumnName("Personel_Ad");
            entity.Property(e => e.PersonelSoyad)
                .HasMaxLength(50)
                .HasColumnName("Personel_Soyad");
            entity.Property(e => e.SozlesmeId).HasColumnName("SozlesmeID");
            entity.Property(e => e.Tc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TC");
            entity.Property(e => e.Telefon).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Departman).WithMany(p => p.Personels)
                .HasForeignKey(d => d.DepartmanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personel__Depart__71D1E811");

            entity.HasOne(d => d.Sozlesme).WithMany(p => p.Personels)
                .HasForeignKey(d => d.SozlesmeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personel__Sozles__72C60C4A");

            entity.HasOne(d => d.User).WithOne(p => p.Personel)
                .HasForeignKey<Personel>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personel__UserID__73BA3083");
        });

        modelBuilder.Entity<Prim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrimKesi__3214EC076C5A8EB9");

            entity.ToTable("Prim");

            entity.HasIndex(e => new { e.PersonelId, e.Tarih }, "IX_PrimKesinti_Personel_Tarih");

            entity.Property(e => e.Aciklama).HasMaxLength(300);
            entity.Property(e => e.CreatedUtc).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Kaynak).HasMaxLength(50);
            entity.Property(e => e.OnaylayanUserId).HasColumnName("OnaylayanUserID");
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.Tutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OnaylayanUser).WithMany(p => p.Prims)
                .HasForeignKey(d => d.OnaylayanUserId)
                .HasConstraintName("FK__PrimKesin__Onayl__30C33EC3");

            entity.HasOne(d => d.Personel).WithMany(p => p.Prims)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrimKesin__Perso__2FCF1A8A");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC079F710118");

            entity.ToTable("RefreshToken");

            entity.HasIndex(e => e.Token, "UQ__RefreshT__1EB4F817BA6FC3B7").IsUnique();

            entity.Property(e => e.Token).HasMaxLength(200);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RefreshTo__UserI__7D0E9093");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A30C7C997");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ__Role__737584F68613D11A").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Name).HasMaxLength(32);
        });

        modelBuilder.Entity<RollCall>(entity =>
        {
            entity.HasKey(e => e.OlayId).HasName("PK__YoklamaO__F7A439A71150EDB5");

            entity.ToTable("RollCall");

            entity.HasIndex(e => new { e.PersonelId, e.EventTimeUtc }, "IX_YoklamaOlay_Personel_Time");

            entity.Property(e => e.OlayId).HasColumnName("OlayID");
            entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
            entity.Property(e => e.CreatedAtUtc)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.EventTimeUtc).HasPrecision(0);
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.Source).HasMaxLength(30);

            entity.HasOne(d => d.Atama).WithMany(p => p.RollCalls)
                .HasForeignKey(d => d.AtamaId)
                .HasConstraintName("FK__YoklamaOl__Atama__0B91BA14");

            entity.HasOne(d => d.Personel).WithMany(p => p.RollCalls)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__YoklamaOl__Perso__0A9D95DB");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.VardiyaId).HasName("PK__VardiyaT__65D888E442844091");

            entity.ToTable("Shift");

            entity.HasIndex(e => e.Ad, "UQ__VardiyaT__3214AD0010EF9D20").IsUnique();

            entity.Property(e => e.VardiyaId).HasColumnName("VardiyaID");
            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Aktif).HasDefaultValue(true);
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.VarsayilanGraceDakika).HasDefaultValue(5);
        });

        modelBuilder.Entity<ShiftAssignment>(entity =>
        {
            entity.HasKey(e => e.AtamaId).HasName("PK__VardiyaA__00DE786B15DF7F26");

            entity.ToTable("ShiftAssignment");

            entity.HasIndex(e => e.WorkDate, "IX_ShiftAssignment_Rapor");

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "IX_VardiyaAtama_Personel_Date");

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "IX_VardiyaAtama_Personel_WorkDate");

            entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
            entity.Property(e => e.LokasyonId).HasColumnName("LokasyonID");
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.ShiftEndLocal).HasPrecision(0);
            entity.Property(e => e.ShiftStartLocal).HasPrecision(0);
            entity.Property(e => e.VardiyaId).HasColumnName("VardiyaID");

            entity.HasOne(d => d.Lokasyon).WithMany(p => p.ShiftAssignments)
                .HasForeignKey(d => d.LokasyonId)
                .HasConstraintName("FK__VardiyaAt__Lokas__06CD04F7");

            entity.HasOne(d => d.Personel).WithMany(p => p.ShiftAssignments)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VardiyaAt__Perso__04E4BC85");

            entity.HasOne(d => d.Vardiya).WithMany(p => p.ShiftAssignments)
                .HasForeignKey(d => d.VardiyaId)
                .HasConstraintName("FK__VardiyaAt__Vardi__05D8E0BE");
        });

        modelBuilder.Entity<ShiftBreak>(entity =>
        {
            entity.HasKey(e => e.MolaId).HasName("PK__VardiyaM__90E40886D8B56FBE");

            entity.ToTable("ShiftBreak");

            entity.HasIndex(e => e.VardiyaId, "IX_VardiyaMolaTanimi_Vardiya");

            entity.Property(e => e.MolaId).HasColumnName("MolaID");
            entity.Property(e => e.VardiyaId).HasColumnName("VardiyaID");

            entity.HasOne(d => d.Vardiya).WithMany(p => p.ShiftBreaks)
                .HasForeignKey(d => d.VardiyaId)
                .HasConstraintName("FK__VardiyaMo__Vardi__01142BA1");
        });

        modelBuilder.Entity<TrackingPoint>(entity =>
        {
            entity.HasKey(e => e.PointId).HasName("PK__Tracking__40A9778186201A91");

            entity.ToTable("TrackingPoint");

            entity.HasIndex(e => new { e.SessionId, e.EventTimeUtc }, "IX_TrackingPoint_Session_Time");

            entity.Property(e => e.PointId).HasColumnName("PointID");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.SpeedMps).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.Session).WithMany(p => p.TrackingPoints)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__TrackingP__Sessi__56E8E7AB");
        });

        modelBuilder.Entity<TrackingSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Tracking__C9F49270C4DBA16A");

            entity.ToTable("TrackingSession");

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "UX_TrackSession_UniqDay").IsUnique();

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "UX_TrackingSession_Active_PerDay")
                .IsUnique()
                .HasFilter("([IsActive]=(1))");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.Reason).HasDefaultValue((byte)1);
            entity.Property(e => e.StartedUtc).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Atama).WithMany(p => p.TrackingSessions)
                .HasForeignKey(d => d.AtamaId)
                .HasConstraintName("FK__TrackingS__Atama__531856C7");

            entity.HasOne(d => d.Personel).WithMany(p => p.TrackingSessions)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TrackingS__Perso__5224328E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC3BF9BB49");

            entity.ToTable("User");

            entity.HasIndex(e => e.KullaniciAdi, "UQ__User__5BAE6A7562BD3BFB").IsUnique();

            entity.HasIndex(e => e.Telefon, "UQ__User__92EB41697124B6CF").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D1053413142C19").IsUnique();

            entity.HasIndex(e => e.Email, "UX_User_Email").IsUnique();

            entity.HasIndex(e => e.KullaniciAdi, "UX_User_UserName").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.KullaniciAdi).HasMaxLength(50);
            entity.Property(e => e.OlusturulmaUtc).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.SifreHash).HasMaxLength(64);
            entity.Property(e => e.SifreSalt).HasMaxLength(16);
            entity.Property(e => e.Telefon).HasMaxLength(20);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRole__RoleID__793DFFAF"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRole__UserID__7849DB76"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF27604F890F7B91");
                        j.ToTable("UserRole");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                    });
        });

        modelBuilder.Entity<UserDevice>(entity =>
        {
            entity.HasKey(e => e.CihazId).HasName("PK__UserCiha__B560B4876AEB2578");

            entity.ToTable("UserDevice");

            entity.HasIndex(e => new { e.UserId, e.DeviceUid }, "UQ__UserCiha__C539BBB092C092AD").IsUnique();

            entity.Property(e => e.CihazId).HasColumnName("CihazID");
            entity.Property(e => e.DeviceUid).HasMaxLength(128);
            entity.Property(e => e.KayitUtc).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.OnaylayanUserId).HasColumnName("OnaylayanUserID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.OnaylayanUser).WithMany(p => p.UserDeviceOnaylayanUsers)
                .HasForeignKey(d => d.OnaylayanUserId)
                .HasConstraintName("FK__UserCihaz__Onayl__66603565");

            entity.HasOne(d => d.User).WithMany(p => p.UserDeviceUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserCihaz__UserI__656C112C");
        });

        modelBuilder.Entity<UserTwoFactor>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserTwoF__1788CCACE20ACB5E");

            entity.ToTable("UserTwoFactor");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Totpsecret)
                .HasMaxLength(64)
                .HasColumnName("TOTPSecret");

            entity.HasOne(d => d.User).WithOne(p => p.UserTwoFactor)
                .HasForeignKey<UserTwoFactor>(d => d.UserId)
                .HasConstraintName("FK__UserTwoFa__UserI__5AEE82B9");
        });

        modelBuilder.Entity<UserTwoFactorCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserTwoF__3214EC0757AFF338");

            entity.ToTable("UserTwoFactorCode");

            entity.HasIndex(e => new { e.UserId, e.Used, e.ExpiresUtc }, "IX_UserTwoFactorCode_User_Active");

            entity.Property(e => e.CodeHash).HasMaxLength(32);
            entity.Property(e => e.CreatedUtc).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserTwoFactorCodes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserTwoFa__UserI__5FB337D6");
        });

        modelBuilder.Entity<VwGunlukVardiyaOzet>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GunlukVardiyaOzet");

            entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
            entity.Property(e => e.LokasyonAdi).HasMaxLength(100);
            entity.Property(e => e.PersonelAd)
                .HasMaxLength(50)
                .HasColumnName("Personel_Ad");
            entity.Property(e => e.PersonelSoyad)
                .HasMaxLength(50)
                .HasColumnName("Personel_Soyad");
            entity.Property(e => e.ShiftEndLocal).HasPrecision(0);
            entity.Property(e => e.ShiftStartLocal).HasPrecision(0);
            entity.Property(e => e.VardiyaAdi).HasMaxLength(100);
        });

        modelBuilder.Entity<VwPersonelDetay>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PersonelDetay");

            entity.Property(e => e.DepartmanAdi).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.KullaniciAdi).HasMaxLength(50);
            entity.Property(e => e.PersonelAd)
                .HasMaxLength(50)
                .HasColumnName("Personel_Ad");
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.PersonelSoyad)
                .HasMaxLength(50)
                .HasColumnName("Personel_Soyad");
            entity.Property(e => e.RolAdi).HasMaxLength(32);
            entity.Property(e => e.Tc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TC");
            entity.Property(e => e.Telefon).HasMaxLength(20);
        });

        modelBuilder.Entity<WorkHour>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__WorkSess__C9F492707FB872F7");

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "IX_WorkSession_Personel_Date");

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "UX_WorkSession_Active_PerDay")
                .IsUnique()
                .HasFilter("([IsActive]=(1))");

            entity.HasIndex(e => new { e.PersonelId, e.WorkDate }, "UX_WorkSession_UniqDay").IsUnique();

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.AtamaId).HasColumnName("AtamaID");
            entity.Property(e => e.CreatedUtc)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.EndSource).HasMaxLength(20);
            entity.Property(e => e.EndUtc).HasPrecision(0);
            entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
            entity.Property(e => e.StartSource).HasMaxLength(20);
            entity.Property(e => e.StartUtc).HasPrecision(0);

            entity.HasOne(d => d.Atama).WithMany(p => p.WorkHours)
                .HasForeignKey(d => d.AtamaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSession_Atama");

            entity.HasOne(d => d.Personel).WithMany(p => p.WorkHours)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSession_Personel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
