using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PRJRepository.Models;

public partial class TcemrProdContext : DbContext
{
    public TcemrProdContext()
    {
    }

    public TcemrProdContext(DbContextOptions<TcemrProdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentPayment> AppointmentPayments { get; set; }

    public virtual DbSet<AvailableSlot> AvailableSlots { get; set; }

    public virtual DbSet<BillingSetting> BillingSettings { get; set; }

    public virtual DbSet<CalenderSetting> CalenderSettings { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CheckAvaliability> CheckAvaliabilities { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientForm> ClientForms { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<ClinicLocation> ClinicLocations { get; set; }

    public virtual DbSet<Clinician> Clinicians { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<EditClient> EditClients { get; set; }

    public virtual DbSet<EditClientBilling> EditClientBillings { get; set; }

    public virtual DbSet<EditClientContact> EditClientContacts { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<InsurranceSetting> InsurranceSettings { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceSetting> ServiceSettings { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<TcUser> TcUsers { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=67.225.177.73;User Id=thequatumz-db-admin;Password=@dmin123;Database=TCEMR_Prod;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Address1)
                .HasMaxLength(200)
                .HasColumnName("Address");
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.ZipCode).HasMaxLength(50);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.ClientName).HasMaxLength(200);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Date).HasColumnType("date");
        });

        modelBuilder.Entity<AppointmentPayment>(entity =>
        {
            entity.ToTable("AppointmentPayment");

            entity.Property(e => e.AppointmentDate).HasColumnType("date");
            entity.Property(e => e.Billed).HasColumnType("money");
            entity.Property(e => e.ClientName).HasMaxLength(200);
            entity.Property(e => e.ClientOwes).HasColumnType("money");
            entity.Property(e => e.Cptcode).HasColumnName("CPTCode");
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.InsurancePaid).HasColumnType("money");
            entity.Property(e => e.WriteOff).HasColumnType("money");
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

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK_CreditAndDebitCard");

            entity.ToTable("Card");

            entity.Property(e => e.CardType).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.DateExpire).HasColumnType("date");
        });

        modelBuilder.Entity<CheckAvaliability>(entity =>
        {
            entity.HasKey(e => e.CheckAvailabilityId);

            entity.ToTable("CheckAvaliability");

            entity.Property(e => e.SelectDate).HasColumnType("date");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC074481970D");

            entity.ToTable("City");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK_TCUser");

            entity.ToTable("Client");

            entity.Property(e => e.BillResponsibleClient).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.Email1).HasMaxLength(200);
            entity.Property(e => e.Email2).HasMaxLength(200);
            entity.Property(e => e.EmailType1).HasMaxLength(50);
            entity.Property(e => e.EmailType2).HasMaxLength(50);
            entity.Property(e => e.FirstName1).HasMaxLength(200);
            entity.Property(e => e.FirstName2).HasMaxLength(200);
            entity.Property(e => e.LastName1).HasMaxLength(200);
            entity.Property(e => e.LastName2).HasMaxLength(200);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Location2).HasMaxLength(50);
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PhoneType1).HasMaxLength(50);
            entity.Property(e => e.PhoneType2).HasMaxLength(50);
            entity.Property(e => e.PrimaryClinicianName).HasMaxLength(200);
            entity.Property(e => e.PrimaryClinicianName2).HasMaxLength(200);
            entity.Property(e => e.Relationship).HasMaxLength(50);
            entity.Property(e => e.RemainderType1).HasMaxLength(50);
            entity.Property(e => e.RemainderType2).HasMaxLength(50);
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
            entity.Property(e => e.ContactEmail).HasMaxLength(200);
            entity.Property(e => e.ContactName).HasMaxLength(200);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.ExpirationDate).HasColumnType("date");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.LongFacilityName).HasMaxLength(200);
            entity.Property(e => e.Npi).HasColumnName("NPI");
            entity.Property(e => e.OtherAddress).HasMaxLength(200);
            entity.Property(e => e.OtherZipCode).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ShortFacilityName).HasMaxLength(200);
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

        modelBuilder.Entity<Clinician>(entity =>
        {
            entity.ToTable("Clinician");

            entity.Property(e => e.ClinicianName).HasMaxLength(200);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countrie__3214EC076234D417");

            entity.ToTable("Country");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ShortName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EditClient>(entity =>
        {
            entity.ToTable("EditClient");

            entity.Property(e => e.ClientEmail).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.GenderIdentity).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.LocationType).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(200);
            entity.Property(e => e.ModifiedDate).HasColumnType("date");
            entity.Property(e => e.NameToGoBy).HasMaxLength(200);
            entity.Property(e => e.Suffix).HasMaxLength(200);
        });

        modelBuilder.Entity<EditClientBilling>(entity =>
        {
            entity.HasKey(e => e.BillingId);

            entity.ToTable("EditClientBilling");

            entity.Property(e => e.EmailNotification).HasMaxLength(50);
            entity.Property(e => e.PaymentPay).HasMaxLength(50);
        });

        modelBuilder.Entity<EditClientContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("EditClientContact");

            entity.Property(e => e.ContactFirstName).HasMaxLength(200);
            entity.Property(e => e.ContactLastName).HasMaxLength(200);
            entity.Property(e => e.ContactMiddleName).HasMaxLength(200);
            entity.Property(e => e.ContactNameGoBy)
                .HasMaxLength(200)
                .HasColumnName("ContactNameGoBY");
            entity.Property(e => e.ContactSuffix).HasMaxLength(200);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Notes).HasMaxLength(500);
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.ToTable("Email");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.EmailAddress).HasMaxLength(200);
            entity.Property(e => e.EmailType).HasMaxLength(50);
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.ToTable("Insurance");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Copay).HasColumnType("money");
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Deductible).HasColumnType("money");
            entity.Property(e => e.EmployerOrSchool).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.InsurancePayerFax).HasMaxLength(20);
            entity.Property(e => e.InsurancePayerPhone).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.MiddleName).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.SendPayment).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);
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

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.LocationType).HasMaxLength(50);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("Login");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.LoginDate).HasColumnType("date");
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("Message");

            entity.Property(e => e.CreactionDate).HasColumnType("date");
            entity.Property(e => e.Message1).HasColumnName("Message");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrgId);

            entity.ToTable("Organization");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.OrgAddress).HasMaxLength(200);
            entity.Property(e => e.OrgDescription).HasMaxLength(200);
            entity.Property(e => e.OrgLogo).HasMaxLength(200);
            entity.Property(e => e.OrgName).HasMaxLength(200);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.ToTable("Phone");

            entity.Property(e => e.PhoneId).ValueGeneratedNever();
            entity.Property(e => e.CreactionDate).HasColumnType("date");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PhoneType).HasMaxLength(50);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.Modifier1).HasMaxLength(50);
            entity.Property(e => e.Modifier2).HasMaxLength(50);
            entity.Property(e => e.Modifier3).HasMaxLength(50);
            entity.Property(e => e.Modifier4).HasMaxLength(50);
            entity.Property(e => e.RatePerUnit).HasColumnType("money");
            entity.Property(e => e.ServiceName).HasMaxLength(200);
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

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__States__3214EC07B36DC5F9");

            entity.ToTable("State");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TcUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User");

            entity.ToTable("TcUser");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.AddressType).HasMaxLength(50);
            entity.Property(e => e.Caqhid).HasColumnName("CAQHId");
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
            entity.Property(e => e.Npi).HasColumnName("NPI");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PrimaryWorkLocation).HasMaxLength(50);
            entity.Property(e => e.School).HasMaxLength(200);
            entity.Property(e => e.UploadFilePath)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.UserName).HasMaxLength(200);
            entity.Property(e => e.ZipCode).HasMaxLength(50);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("UserRole");

            entity.Property(e => e.Title).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
