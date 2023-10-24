using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PRJRepository.Models;

public partial class TcdatabaseContext : DbContext
{
    public TcdatabaseContext()
    {
    }

    public TcdatabaseContext(DbContextOptions<TcdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AvailableSlot> AvailableSlots { get; set; }

    public virtual DbSet<BillingSetting> BillingSettings { get; set; }

    public virtual DbSet<CalenderSetting> CalenderSettings { get; set; }

    public virtual DbSet<CheckAvaliability> CheckAvaliabilities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientForm> ClientForms { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<ClinicLocation> ClinicLocations { get; set; }

    public virtual DbSet<InsurranceSetting> InsurranceSettings { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<ServiceSetting> ServiceSettings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-018QP73\\SQLEXPRESS;Database=TCDatabase;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.ClientName).HasMaxLength(200);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Date).HasColumnType("date");
        });

        modelBuilder.Entity<AvailableSlot>(entity =>
        {
            entity.HasKey(e => e.AppointmntSlotId);

            entity.ToTable("AvailableSlot");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.SlotDate).HasColumnType("date");
            entity.Property(e => e.Time).HasPrecision(2);
        });

        modelBuilder.Entity<BillingSetting>(entity =>
        {
            entity.HasKey(e => e.BillingId);

            entity.ToTable("BillingSetting");

            entity.Property(e => e.BillingCurrency).HasColumnType("money");
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.OrgNpi).HasColumnName("OrgNPI");
        });

        modelBuilder.Entity<CalenderSetting>(entity =>
        {
            entity.HasKey(e => e.CalenderId);

            entity.ToTable("CalenderSetting");

            entity.Property(e => e.CreationDate).HasColumnType("date");
        });

        modelBuilder.Entity<CheckAvaliability>(entity =>
        {
            entity.HasKey(e => e.CheckAvailabilityId);

            entity.ToTable("CheckAvaliability");

            entity.Property(e => e.SelectDate).HasColumnType("date");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK_TCUser");

            entity.ToTable("Client");

            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.Email1).HasMaxLength(200);
            entity.Property(e => e.Email2).HasMaxLength(200);
            entity.Property(e => e.FirstName1).HasMaxLength(200);
            entity.Property(e => e.FirstName2).HasMaxLength(200);
            entity.Property(e => e.LastName1).HasMaxLength(200);
            entity.Property(e => e.LastName2).HasMaxLength(200);
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.Relationship).HasMaxLength(50);
        });

        modelBuilder.Entity<ClientForm>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("ClientForm");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.FormJson)
                .IsUnicode(false)
                .HasColumnName("FormJSON");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.ToTable("Clinic");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BillingAddress).HasMaxLength(200);
            entity.Property(e => e.CityName).HasMaxLength(200);
            entity.Property(e => e.ContactEmail).HasMaxLength(200);
            entity.Property(e => e.ContactName).HasMaxLength(200);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.ExpirationDate).HasColumnType("date");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.LongFacultyName).HasMaxLength(200);
            entity.Property(e => e.Npi).HasColumnName("NPI");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ShortFacultyName).HasMaxLength(200);
            entity.Property(e => e.StateName).HasMaxLength(200);
            entity.Property(e => e.ZipCode).HasMaxLength(50);
        });

        modelBuilder.Entity<ClinicLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId);

            entity.ToTable("ClinicLocation");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BillingAddress).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.ExpirationDate).HasColumnType("date");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.IndividualOffice).HasMaxLength(50);
            entity.Property(e => e.LongName).HasMaxLength(200);
            entity.Property(e => e.Npi).HasColumnName("NPI");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ShortName).HasMaxLength(200);
            entity.Property(e => e.ZipCode).HasMaxLength(20);
        });

        modelBuilder.Entity<InsurranceSetting>(entity =>
        {
            entity.HasKey(e => e.InsurranceId);

            entity.ToTable("InsurranceSetting");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Npi).HasColumnName("NPI");
            entity.Property(e => e.PracticeName).HasMaxLength(200);
            entity.Property(e => e.Street).HasMaxLength(200);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiveId);

            entity.ToTable("Invoice");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.InvoiceType).HasMaxLength(50);
        });

        modelBuilder.Entity<License>(entity =>
        {
            entity.ToTable("License");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.LicenseExpirationDate).HasColumnType("date");
            entity.Property(e => e.LicenseState).HasMaxLength(200);
            entity.Property(e => e.LicenseType).HasMaxLength(20);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrgId);

            entity.ToTable("Organization");

            entity.Property(e => e.OrgAddress).HasMaxLength(200);
            entity.Property(e => e.OrgDescription).HasMaxLength(200);
            entity.Property(e => e.OrgName).HasMaxLength(200);
        });

        modelBuilder.Entity<ServiceSetting>(entity =>
        {
            entity.HasKey(e => e.ServiceId);

            entity.ToTable("ServiceSetting");

            entity.Property(e => e.Cptcode).HasColumnName("CPTCode");
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.ServiceDescription).HasMaxLength(300);
            entity.Property(e => e.ServiceName).HasMaxLength(200);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.AddressType).HasMaxLength(50);
            entity.Property(e => e.Caqhid).HasColumnName("CAQHId");
            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.DefaultModifier).HasMaxLength(200);
            entity.Property(e => e.DegreeReceived).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Malpractice).HasMaxLength(50);
            entity.Property(e => e.MalpracticeExpDate).HasColumnType("date");
            entity.Property(e => e.ModifiedDate).HasColumnType("date");
            entity.Property(e => e.Modifier1).HasMaxLength(200);
            entity.Property(e => e.Modifier2).HasMaxLength(200);
            entity.Property(e => e.Modifier3).HasMaxLength(200);
            entity.Property(e => e.Month).HasMaxLength(50);
            entity.Property(e => e.Npi).HasColumnName("NPI");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PrimaryWorkLocation).HasMaxLength(50);
            entity.Property(e => e.School).HasMaxLength(200);
            entity.Property(e => e.StateName).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UploadFilePath)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.UserName).HasMaxLength(200);
            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
