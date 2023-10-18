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

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<ClinicLocation> ClinicLocations { get; set; }

    public virtual DbSet<Form1> Form1s { get; set; }

    public virtual DbSet<Form10> Form10s { get; set; }

    public virtual DbSet<Form11> Form11s { get; set; }

    public virtual DbSet<Form12> Form12s { get; set; }

    public virtual DbSet<Form13> Form13s { get; set; }

    public virtual DbSet<Form14> Form14s { get; set; }

    public virtual DbSet<Form15> Form15s { get; set; }

    public virtual DbSet<Form16> Form16s { get; set; }

    public virtual DbSet<Form17> Form17s { get; set; }

    public virtual DbSet<Form18> Form18s { get; set; }

    public virtual DbSet<Form19> Form19s { get; set; }

    public virtual DbSet<Form2> Form2s { get; set; }

    public virtual DbSet<Form20> Form20s { get; set; }

    public virtual DbSet<Form3> Form3s { get; set; }

    public virtual DbSet<Form4> Form4s { get; set; }

    public virtual DbSet<Form5> Form5s { get; set; }

    public virtual DbSet<Form6> Form6s { get; set; }

    public virtual DbSet<Form7> Form7s { get; set; }

    public virtual DbSet<Form8> Form8s { get; set; }

    public virtual DbSet<Form9> Form9s { get; set; }

    public virtual DbSet<InsurranceSetting> InsurranceSettings { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<ServiceSetting> ServiceSettings { get; set; }

    public virtual DbSet<Tcuser> Tcusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-018QP73\\SQLEXPRESS;Database=TCDatabase;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Duration)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.Client).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_TCUser");
        });

        modelBuilder.Entity<AvailableSlot>(entity =>
        {
            entity.HasKey(e => e.AppointmntSlotId);

            entity.ToTable("AvailableSlot");

            entity.Property(e => e.Duration).HasPrecision(2);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.SlotDate).HasColumnType("date");
            entity.Property(e => e.Time).HasPrecision(2);
        });

        modelBuilder.Entity<BillingSetting>(entity =>
        {
            entity.HasKey(e => e.BillingId);

            entity.ToTable("BillingSetting");

            entity.Property(e => e.BillingCurrency).HasColumnType("money");
            entity.Property(e => e.OrgNpi).HasColumnName("OrgNPI");
        });

        modelBuilder.Entity<CalenderSetting>(entity =>
        {
            entity.HasKey(e => e.CalenderId);

            entity.ToTable("CalenderSetting");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.ToTable("Clinic");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BillingAddress).HasMaxLength(200);
            entity.Property(e => e.ContactEmail).HasMaxLength(200);
            entity.Property(e => e.ContactName).HasMaxLength(200);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.ExpirationDate).HasColumnType("date");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.LongFacultyName).HasMaxLength(200);
            entity.Property(e => e.Npi).HasColumnName("NPI");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ShortFacultyName).HasMaxLength(200);
            entity.Property(e => e.ZipCode).HasMaxLength(50);

            entity.HasOne(d => d.Org).WithMany(p => p.Clinics)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK_Clinic_Organization");
        });

        modelBuilder.Entity<ClinicLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId);

            entity.ToTable("ClinicLocation");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BillingAddress).HasMaxLength(50);
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

        modelBuilder.Entity<Form1>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_1");

            entity.Property(e => e.F11).HasColumnName("F1_1");
            entity.Property(e => e.F110).HasColumnName("F1_10");
            entity.Property(e => e.F12).HasColumnName("F1_2");
            entity.Property(e => e.F13).HasColumnName("F1_3");
            entity.Property(e => e.F14).HasColumnName("F1_4");
            entity.Property(e => e.F15).HasColumnName("F1_5");
            entity.Property(e => e.F16).HasColumnName("F1_6");
            entity.Property(e => e.F17).HasColumnName("F1_7");
            entity.Property(e => e.F18).HasColumnName("F1_8");
            entity.Property(e => e.F19).HasColumnName("F1_9");
            entity.Property(e => e.TotalYes).HasColumnName("TotalYES");
        });

        modelBuilder.Entity<Form10>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_10");

            entity.Property(e => e.F81op1)
                .HasMaxLength(50)
                .HasColumnName("F8_1Op1");
            entity.Property(e => e.F81op2)
                .HasMaxLength(50)
                .HasColumnName("F8_1Op2");
            entity.Property(e => e.F81req)
                .HasMaxLength(50)
                .HasColumnName("F8_1Req");
            entity.Property(e => e.F82op1)
                .HasMaxLength(50)
                .HasColumnName("F8_2Op1");
            entity.Property(e => e.F82op2)
                .HasMaxLength(50)
                .HasColumnName("F8_2Op2");
            entity.Property(e => e.F82req)
                .HasMaxLength(50)
                .HasColumnName("F8_2Req");
            entity.Property(e => e.F83NameOp)
                .HasMaxLength(200)
                .HasColumnName("F8_3_NameOp");
            entity.Property(e => e.F83NameReq)
                .HasMaxLength(200)
                .HasColumnName("F8_3_NameReq");
            entity.Property(e => e.F83PlaceOp)
                .HasMaxLength(50)
                .HasColumnName("F8_3_PlaceOp");
            entity.Property(e => e.F83PlaceReq)
                .HasMaxLength(50)
                .HasColumnName("F8_3_PlaceReq");
            entity.Property(e => e.F84NameOp1)
                .HasMaxLength(200)
                .HasColumnName("F8_4_NameOp1");
            entity.Property(e => e.F84NameOp2)
                .HasMaxLength(200)
                .HasColumnName("F8_4_NameOp2");
            entity.Property(e => e.F84NameReq)
                .HasMaxLength(200)
                .HasColumnName("F8_4_NameReq");
            entity.Property(e => e.F85Address)
                .HasMaxLength(200)
                .HasColumnName("F8_5_Address");
            entity.Property(e => e.F85Name)
                .HasMaxLength(200)
                .HasColumnName("F8_5_Name");
            entity.Property(e => e.F85Phone)
                .HasMaxLength(200)
                .HasColumnName("F8_5_Phone");
            entity.Property(e => e.F86Future)
                .HasMaxLength(200)
                .HasColumnName("F8_6_Future");
            entity.Property(e => e.F86Op1)
                .HasMaxLength(200)
                .HasColumnName("F8_6_Op1");
            entity.Property(e => e.F86Op2)
                .HasMaxLength(200)
                .HasColumnName("F8_6_Op2");
            entity.Property(e => e.F86Req)
                .HasMaxLength(200)
                .HasColumnName("F8_6_Req");
            entity.Property(e => e.F86WorthLiving)
                .HasMaxLength(200)
                .HasColumnName("F8_6_WorthLiving");
        });

        modelBuilder.Entity<Form11>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_11");

            entity.Property(e => e.F111).HasColumnName("F11_1");
            entity.Property(e => e.F1110).HasColumnName("F11_10");
            entity.Property(e => e.F1111).HasColumnName("F11_11");
            entity.Property(e => e.F1112).HasColumnName("F11_12");
            entity.Property(e => e.F1113).HasColumnName("F11_13");
            entity.Property(e => e.F1114).HasColumnName("F11_14");
            entity.Property(e => e.F1115).HasColumnName("F11_15");
            entity.Property(e => e.F1116).HasColumnName("F11_16");
            entity.Property(e => e.F1117).HasColumnName("F11_17");
            entity.Property(e => e.F1118).HasColumnName("F11_18");
            entity.Property(e => e.F1119).HasColumnName("F11_19");
            entity.Property(e => e.F112).HasColumnName("F11_2");
            entity.Property(e => e.F1120).HasColumnName("F11_20");
            entity.Property(e => e.F113).HasColumnName("F11_3");
            entity.Property(e => e.F114).HasColumnName("F11_4");
            entity.Property(e => e.F115).HasColumnName("F11_5");
            entity.Property(e => e.F116).HasColumnName("F11_6");
            entity.Property(e => e.F117).HasColumnName("F11_7");
            entity.Property(e => e.F118).HasColumnName("F11_8");
            entity.Property(e => e.F119).HasColumnName("F11_9");
        });

        modelBuilder.Entity<Form12>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_12");

            entity.Property(e => e.F121)
                .HasMaxLength(50)
                .HasColumnName("F12_1");
            entity.Property(e => e.F1210).HasColumnName("F12_10");
            entity.Property(e => e.F122)
                .HasMaxLength(50)
                .HasColumnName("F12_2");
            entity.Property(e => e.F123)
                .HasMaxLength(50)
                .HasColumnName("F12_3");
            entity.Property(e => e.F124)
                .HasMaxLength(50)
                .HasColumnName("F12_4");
            entity.Property(e => e.F125)
                .HasMaxLength(50)
                .HasColumnName("F12_5");
            entity.Property(e => e.F126)
                .HasMaxLength(50)
                .HasColumnName("F12_6");
            entity.Property(e => e.F127)
                .HasMaxLength(50)
                .HasColumnName("F12_7");
            entity.Property(e => e.F128)
                .HasMaxLength(50)
                .HasColumnName("F12_8");
            entity.Property(e => e.F129)
                .HasMaxLength(50)
                .HasColumnName("F12_9");
        });

        modelBuilder.Entity<Form13>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_13");

            entity.Property(e => e.F131).HasColumnName("F13_1");
            entity.Property(e => e.F132).HasColumnName("F13_2");
            entity.Property(e => e.F133).HasColumnName("F13_3");
            entity.Property(e => e.F134).HasColumnName("F13_4");
            entity.Property(e => e.F135).HasColumnName("F13_5");
            entity.Property(e => e.F136).HasColumnName("F13_6");
            entity.Property(e => e.F137).HasColumnName("F13_7");
            entity.Property(e => e.F138).HasColumnName("F13_8");
        });

        modelBuilder.Entity<Form14>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_14");

            entity.Property(e => e.F14Email)
                .HasMaxLength(200)
                .HasColumnName("F14_Email");
            entity.Property(e => e.F14IsAttendenceReasons).HasColumnName("F14_IsAttendenceReasons");
            entity.Property(e => e.F14IsCaseReview).HasColumnName("F14_IsCaseReview");
            entity.Property(e => e.F14IsContinuing).HasColumnName("F14_IsContinuing");
            entity.Property(e => e.F14IsDetermining).HasColumnName("F14_IsDetermining");
            entity.Property(e => e.F14IsEducationalRecord).HasColumnName("F14_IsEducationalRecord");
            entity.Property(e => e.F14IsFinancialInformation).HasColumnName("F14_IsFinancialInformation");
            entity.Property(e => e.F14IsMedicalHealth).HasColumnName("F14_IsMedicalHealth");
            entity.Property(e => e.F14IsMedicalHistory).HasColumnName("F14_IsMedicalHistory");
            entity.Property(e => e.F14IsOthers1).HasColumnName("F14_IsOthers1");
            entity.Property(e => e.F14IsOthers2).HasColumnName("F14_IsOthers2");
            entity.Property(e => e.F14IsPlanning).HasColumnName("F14_IsPlanning");
            entity.Property(e => e.F14IsProgressNotes).HasColumnName("F14_IsProgressNotes");
            entity.Property(e => e.F14IsReceive).HasColumnName("F14_IsReceive");
            entity.Property(e => e.F14IsScheduling).HasColumnName("F14_IsScheduling");
            entity.Property(e => e.F14IsSend).HasColumnName("F14_IsSend");
            entity.Property(e => e.F14IsSocialHistory).HasColumnName("F14_IsSocialHistory");
            entity.Property(e => e.F14IsUpdatingFiles).HasColumnName("F14_IsUpdatingFiles");
            entity.Property(e => e.F14Name)
                .HasMaxLength(200)
                .HasColumnName("F14_Name");
            entity.Property(e => e.F14Phone)
                .HasMaxLength(200)
                .HasColumnName("F14_Phone");
            entity.Property(e => e.F14Relationship).HasColumnName("F14_Relationship");
            entity.Property(e => e.F14ToFrom)
                .HasMaxLength(200)
                .HasColumnName("F14_To_From");
        });

        modelBuilder.Entity<Form15>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_15");

            entity.Property(e => e.F151)
                .HasMaxLength(500)
                .HasColumnName("F15_1");
            entity.Property(e => e.F1510)
                .HasMaxLength(500)
                .HasColumnName("F15_10");
            entity.Property(e => e.F152)
                .HasMaxLength(500)
                .HasColumnName("F15_2");
            entity.Property(e => e.F153)
                .HasMaxLength(500)
                .HasColumnName("F15_3");
            entity.Property(e => e.F154)
                .HasMaxLength(500)
                .HasColumnName("F15_4");
            entity.Property(e => e.F155)
                .HasMaxLength(500)
                .HasColumnName("F15_5");
            entity.Property(e => e.F156)
                .HasMaxLength(500)
                .HasColumnName("F15_6");
            entity.Property(e => e.F157)
                .HasMaxLength(500)
                .HasColumnName("F15_7");
            entity.Property(e => e.F158)
                .HasMaxLength(500)
                .HasColumnName("F15_8");
            entity.Property(e => e.F159)
                .HasMaxLength(500)
                .HasColumnName("F15_9");
        });

        modelBuilder.Entity<Form16>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK_From_15");

            entity.ToTable("Form_16");

            entity.Property(e => e.Form1510).HasColumnName("Form15_10");
            entity.Property(e => e.Form1511).HasColumnName("Form15_11");
            entity.Property(e => e.Form1512).HasColumnName("Form15_12");
            entity.Property(e => e.Form1513).HasColumnName("Form15_13");
            entity.Property(e => e.Form1514).HasColumnName("Form15_14");
            entity.Property(e => e.Form1515).HasColumnName("Form15_15");
            entity.Property(e => e.Form1516)
                .HasMaxLength(500)
                .HasColumnName("Form15_16");
            entity.Property(e => e.Form1517)
                .HasMaxLength(500)
                .HasColumnName("Form15_17");
            entity.Property(e => e.Form1518)
                .HasMaxLength(500)
                .HasColumnName("Form15_18");
            entity.Property(e => e.Form1519)
                .HasMaxLength(500)
                .HasColumnName("Form15_19");
            entity.Property(e => e.Form152)
                .HasMaxLength(500)
                .HasColumnName("Form15_2");
            entity.Property(e => e.Form1520)
                .HasMaxLength(500)
                .HasColumnName("Form15_20");
            entity.Property(e => e.Form1521)
                .HasMaxLength(500)
                .HasColumnName("Form15_21");
            entity.Property(e => e.Form1522)
                .HasMaxLength(500)
                .HasColumnName("Form15_22");
            entity.Property(e => e.Form1523)
                .HasMaxLength(500)
                .HasColumnName("Form15_23");
            entity.Property(e => e.Form1524)
                .HasMaxLength(500)
                .HasColumnName("Form15_24");
            entity.Property(e => e.Form1525)
                .HasMaxLength(500)
                .HasColumnName("Form15_25");
            entity.Property(e => e.Form1526)
                .HasMaxLength(500)
                .HasColumnName("Form15_26");
            entity.Property(e => e.Form1527)
                .HasMaxLength(500)
                .HasColumnName("Form15_27");
            entity.Property(e => e.Form1528)
                .HasMaxLength(500)
                .HasColumnName("Form15_28");
            entity.Property(e => e.Form1529)
                .HasMaxLength(500)
                .HasColumnName("Form15_29");
            entity.Property(e => e.Form153)
                .HasMaxLength(500)
                .HasColumnName("Form15_3");
            entity.Property(e => e.Form1530)
                .HasMaxLength(500)
                .HasColumnName("Form15_30");
            entity.Property(e => e.Form1531)
                .HasMaxLength(500)
                .HasColumnName("Form15_31");
            entity.Property(e => e.Form1532).HasColumnName("Form15_32");
            entity.Property(e => e.Form1533).HasColumnName("Form15_33");
            entity.Property(e => e.Form1534)
                .HasMaxLength(500)
                .HasColumnName("Form15_34");
            entity.Property(e => e.Form1535)
                .HasMaxLength(500)
                .HasColumnName("Form15_35");
            entity.Property(e => e.Form1536)
                .HasMaxLength(500)
                .HasColumnName("Form15_36");
            entity.Property(e => e.Form1537)
                .HasMaxLength(500)
                .HasColumnName("Form15_37");
            entity.Property(e => e.Form1538)
                .HasMaxLength(500)
                .HasColumnName("Form15_38");
            entity.Property(e => e.Form1539)
                .HasMaxLength(500)
                .HasColumnName("Form15_39");
            entity.Property(e => e.Form154)
                .HasMaxLength(500)
                .HasColumnName("Form15_4");
            entity.Property(e => e.Form1540)
                .HasMaxLength(500)
                .HasColumnName("Form15_40");
            entity.Property(e => e.Form1541)
                .HasMaxLength(500)
                .HasColumnName("Form15_41");
            entity.Property(e => e.Form1542)
                .HasMaxLength(500)
                .HasColumnName("Form15_42");
            entity.Property(e => e.Form1543)
                .HasMaxLength(500)
                .HasColumnName("Form15_43");
            entity.Property(e => e.Form1544)
                .HasMaxLength(500)
                .HasColumnName("Form15_44");
            entity.Property(e => e.Form1545)
                .HasMaxLength(500)
                .HasColumnName("Form15_45");
            entity.Property(e => e.Form1546)
                .HasMaxLength(500)
                .HasColumnName("Form15_46");
            entity.Property(e => e.Form1547)
                .HasMaxLength(500)
                .HasColumnName("Form15_47");
            entity.Property(e => e.Form155)
                .HasMaxLength(500)
                .HasColumnName("Form15_5");
            entity.Property(e => e.Form156)
                .HasMaxLength(500)
                .HasColumnName("Form15_6");
            entity.Property(e => e.Form157)
                .HasMaxLength(500)
                .HasColumnName("Form15_7");
            entity.Property(e => e.Form158)
                .HasMaxLength(500)
                .HasColumnName("Form15_8");
            entity.Property(e => e.Form159).HasColumnName("Form15_9");
            entity.Property(e => e.Form15IsAnginaOrChestPain).HasColumnName("Form15_IsAnginaOrChestPain");
            entity.Property(e => e.Form15IsAnxiety).HasColumnName("Form15_IsAnxiety");
            entity.Property(e => e.Form15IsArthritis).HasColumnName("Form15_IsArthritis");
            entity.Property(e => e.Form15IsAsthma).HasColumnName("Form15_IsAsthma");
            entity.Property(e => e.Form15IsBoneOrJointProblem).HasColumnName("Form15_IsBoneOrJointProblem");
            entity.Property(e => e.Form15IsCancer).HasColumnName("Form15_IsCancer");
            entity.Property(e => e.Form15IsChronicFatigue).HasColumnName("Form15_IsChronicFatigue");
            entity.Property(e => e.Form15IsChronicPain).HasColumnName("Form15_IsChronicPain");
            entity.Property(e => e.Form15IsDecreasedAppetite).HasColumnName("Form15_IsDecreasedAppetite");
            entity.Property(e => e.Form15IsDepressedMood).HasColumnName("Form15_IsDepressedMood");
            entity.Property(e => e.Form15IsDiabetes).HasColumnName("Form15_IsDiabetes");
            entity.Property(e => e.Form15IsDifficultySleeping).HasColumnName("Form15_IsDifficultySleeping");
            entity.Property(e => e.Form15IsDizziness).HasColumnName("Form15_IsDizziness");
            entity.Property(e => e.Form15IsExcessiveSleep).HasColumnName("Form15_IsExcessiveSleep");
            entity.Property(e => e.Form15IsFear).HasColumnName("Form15_IsFear");
            entity.Property(e => e.Form15IsFibromyalgia).HasColumnName("Form15_IsFibromyalgia");
            entity.Property(e => e.Form15IsGastritisOrEsophagitis).HasColumnName("Form15_IsGastritisOrEsophagitis");
            entity.Property(e => e.Form15IsHeadInjury).HasColumnName("Form15_IsHeadInjury");
            entity.Property(e => e.Form15IsHeadache).HasColumnName("Form15_IsHeadache");
            entity.Property(e => e.Form15IsHeartAttact).HasColumnName("Form15_IsHeartAttact");
            entity.Property(e => e.Form15IsHeartValveProblems).HasColumnName("Form15_IsHeartValveProblems");
            entity.Property(e => e.Form15IsHepatitis).HasColumnName("Form15_IsHepatitis");
            entity.Property(e => e.Form15IsHighBloodPressure).HasColumnName("Form15_IsHighBloodPressure");
            entity.Property(e => e.Form15IsHivAids).HasColumnName("Form15_IsHiv/Aids");
            entity.Property(e => e.Form15IsHopelessness).HasColumnName("Form15_IsHopelessness");
            entity.Property(e => e.Form15IsHormone).HasColumnName("Form15_IsHormone");
            entity.Property(e => e.Form15IsIrritableBowel).HasColumnName("Form15_IsIrritableBowel");
            entity.Property(e => e.Form15IsIsolationForm).HasColumnName("Form15_IsIsolationForm");
            entity.Property(e => e.Form15IsKidneyRelatedIssues).HasColumnName("Form15_IsKidneyRelatedIssues");
            entity.Property(e => e.Form15IsLossofConsciousmess).HasColumnName("Form15_IsLossofConsciousmess");
            entity.Property(e => e.Form15IsLowEnergy).HasColumnName("Form15_IsLowEnergy");
            entity.Property(e => e.Form15IsLowMotivation).HasColumnName("Form15_IsLowMotivation");
            entity.Property(e => e.Form15IsLowSeltEsteem).HasColumnName("Form15_IsLowSeltEsteem");
            entity.Property(e => e.Form15IsNumbnessTingling).HasColumnName("Form15_IsNumbness&Tingling");
            entity.Property(e => e.Form15IsOther1).HasColumnName("Form15_IsOther1");
            entity.Property(e => e.Form15IsOther2).HasColumnName("Form15_IsOther2");
            entity.Property(e => e.Form15IsPanic).HasColumnName("Form15_IsPanic");
            entity.Property(e => e.Form15IsSeizures).HasColumnName("Form15_IsSeizures");
            entity.Property(e => e.Form15IsShortnessOfBreath).HasColumnName("Form15_IsShortnessOfBreath");
            entity.Property(e => e.Form15IsTearful).HasColumnName("Form15_IsTearful");
            entity.Property(e => e.Form15IsThyroidIssues).HasColumnName("Form15_IsThyroidIssues");
            entity.Property(e => e.Form15IsTractProblems).HasColumnName("Form15_IsTractProblems");
            entity.Property(e => e.Form15IsTroublrConcentrating).HasColumnName("Form15_IsTroublrConcentrating");
            entity.Property(e => e.Form15Isfaitness).HasColumnName("Form15_Isfaitness");
            entity.Property(e => e.Form15Scale).HasColumnName("Form15_Scale");
            entity.Property(e => e.Form161)
                .HasMaxLength(500)
                .HasColumnName("Form16_1");
            entity.Property(e => e.Form16IsIncreasedAppetite).HasColumnName("Form16_IsIncreasedAppetite");
        });

        modelBuilder.Entity<Form17>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_17");

            entity.Property(e => e.Form171)
                .HasMaxLength(500)
                .HasColumnName("Form17_1");
            entity.Property(e => e.Form1710)
                .HasMaxLength(500)
                .HasColumnName("Form17_10");
            entity.Property(e => e.Form1711)
                .HasMaxLength(500)
                .HasColumnName("Form17_11");
            entity.Property(e => e.Form1712)
                .HasMaxLength(500)
                .HasColumnName("Form17_12");
            entity.Property(e => e.Form1713)
                .HasMaxLength(500)
                .HasColumnName("Form17_13");
            entity.Property(e => e.Form1714)
                .HasMaxLength(500)
                .HasColumnName("Form17_14");
            entity.Property(e => e.Form1715)
                .HasMaxLength(500)
                .HasColumnName("Form17_15");
            entity.Property(e => e.Form1716)
                .HasMaxLength(500)
                .HasColumnName("Form17_16");
            entity.Property(e => e.Form1717)
                .HasMaxLength(500)
                .HasColumnName("Form17_17");
            entity.Property(e => e.Form1718)
                .HasMaxLength(500)
                .HasColumnName("Form17_18");
            entity.Property(e => e.Form1719)
                .HasMaxLength(500)
                .HasColumnName("Form17_19");
            entity.Property(e => e.Form172)
                .HasMaxLength(500)
                .HasColumnName("Form17_2");
            entity.Property(e => e.Form1720)
                .HasMaxLength(500)
                .HasColumnName("Form17_20");
            entity.Property(e => e.Form1721)
                .HasMaxLength(500)
                .HasColumnName("Form17_21");
            entity.Property(e => e.Form1722)
                .HasMaxLength(500)
                .HasColumnName("Form17_22");
            entity.Property(e => e.Form1723)
                .HasMaxLength(500)
                .HasColumnName("Form17_23");
            entity.Property(e => e.Form1724)
                .HasMaxLength(500)
                .HasColumnName("Form17_24");
            entity.Property(e => e.Form1725)
                .HasMaxLength(500)
                .HasColumnName("Form17_25");
            entity.Property(e => e.Form1726)
                .HasMaxLength(500)
                .HasColumnName("Form17_26");
            entity.Property(e => e.Form1727)
                .HasMaxLength(500)
                .HasColumnName("Form17_27");
            entity.Property(e => e.Form1728)
                .HasMaxLength(500)
                .HasColumnName("Form17_28");
            entity.Property(e => e.Form1729)
                .HasMaxLength(500)
                .HasColumnName("Form17_29");
            entity.Property(e => e.Form173)
                .HasMaxLength(500)
                .HasColumnName("Form17_3");
            entity.Property(e => e.Form1730)
                .HasMaxLength(500)
                .HasColumnName("Form17_30");
            entity.Property(e => e.Form1731)
                .HasMaxLength(500)
                .HasColumnName("Form17_31");
            entity.Property(e => e.Form1732)
                .HasMaxLength(500)
                .HasColumnName("Form17_32");
            entity.Property(e => e.Form1733)
                .HasMaxLength(500)
                .HasColumnName("Form17_33");
            entity.Property(e => e.Form1734)
                .HasMaxLength(500)
                .HasColumnName("Form17_34");
            entity.Property(e => e.Form1735)
                .HasMaxLength(500)
                .HasColumnName("Form17_35");
            entity.Property(e => e.Form1736)
                .HasMaxLength(500)
                .HasColumnName("Form17_36");
            entity.Property(e => e.Form1737)
                .HasMaxLength(500)
                .HasColumnName("Form17_37");
            entity.Property(e => e.Form1738)
                .HasMaxLength(500)
                .HasColumnName("Form17_38");
            entity.Property(e => e.Form1739)
                .HasMaxLength(500)
                .HasColumnName("Form17_39");
            entity.Property(e => e.Form174)
                .HasMaxLength(500)
                .HasColumnName("Form17_4");
            entity.Property(e => e.Form1740)
                .HasMaxLength(500)
                .HasColumnName("Form17_40");
            entity.Property(e => e.Form1741)
                .HasMaxLength(500)
                .HasColumnName("Form17_41");
            entity.Property(e => e.Form1742)
                .HasMaxLength(500)
                .HasColumnName("Form17_42");
            entity.Property(e => e.Form1743)
                .HasMaxLength(500)
                .HasColumnName("Form17_43");
            entity.Property(e => e.Form1744)
                .HasMaxLength(500)
                .HasColumnName("Form17_44");
            entity.Property(e => e.Form1745)
                .HasMaxLength(500)
                .HasColumnName("Form17_45");
            entity.Property(e => e.Form1746)
                .HasMaxLength(500)
                .HasColumnName("Form17_46");
            entity.Property(e => e.Form175)
                .HasMaxLength(500)
                .HasColumnName("Form17_5");
            entity.Property(e => e.Form176)
                .HasMaxLength(500)
                .HasColumnName("Form17_6");
            entity.Property(e => e.Form177)
                .HasMaxLength(500)
                .HasColumnName("Form17_7");
            entity.Property(e => e.Form178)
                .HasMaxLength(500)
                .HasColumnName("Form17_8");
            entity.Property(e => e.Form179)
                .HasMaxLength(500)
                .HasColumnName("Form17_9");
        });

        modelBuilder.Entity<Form18>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_18");

            entity.Property(e => e.Form181)
                .HasMaxLength(500)
                .HasColumnName("Form18_1");
            entity.Property(e => e.Form1810).HasColumnName("Form18_10");
            entity.Property(e => e.Form1811).HasColumnName("Form18_11");
            entity.Property(e => e.Form1812).HasColumnName("Form18_12");
            entity.Property(e => e.Form1813).HasColumnName("Form18_13");
            entity.Property(e => e.Form1814).HasColumnName("Form18_14");
            entity.Property(e => e.Form1815).HasColumnName("Form18_15");
            entity.Property(e => e.Form1816)
                .HasMaxLength(500)
                .HasColumnName("Form18_16");
            entity.Property(e => e.Form1817)
                .HasMaxLength(500)
                .HasColumnName("Form18_17");
            entity.Property(e => e.Form1818)
                .HasMaxLength(500)
                .HasColumnName("Form18_18");
            entity.Property(e => e.Form1819)
                .HasMaxLength(500)
                .HasColumnName("Form18_19");
            entity.Property(e => e.Form182)
                .HasMaxLength(500)
                .HasColumnName("Form18_2");
            entity.Property(e => e.Form1820)
                .HasMaxLength(500)
                .HasColumnName("Form18_20");
            entity.Property(e => e.Form1821)
                .HasMaxLength(500)
                .HasColumnName("Form18_21");
            entity.Property(e => e.Form1822).HasColumnName("Form18_22");
            entity.Property(e => e.Form1823).HasColumnName("Form18_23");
            entity.Property(e => e.Form1824)
                .HasMaxLength(500)
                .HasColumnName("Form18_24");
            entity.Property(e => e.Form1825)
                .HasMaxLength(500)
                .HasColumnName("Form18_25");
            entity.Property(e => e.Form1826)
                .HasMaxLength(500)
                .HasColumnName("Form18_26");
            entity.Property(e => e.Form1827)
                .HasMaxLength(500)
                .HasColumnName("Form18_27");
            entity.Property(e => e.Form1828)
                .HasMaxLength(500)
                .HasColumnName("Form18_28");
            entity.Property(e => e.Form1829)
                .HasMaxLength(500)
                .HasColumnName("Form18_29");
            entity.Property(e => e.Form183)
                .HasMaxLength(500)
                .HasColumnName("Form18_3");
            entity.Property(e => e.Form1830)
                .HasMaxLength(500)
                .HasColumnName("Form18_30");
            entity.Property(e => e.Form1831)
                .HasMaxLength(500)
                .HasColumnName("Form18_31");
            entity.Property(e => e.Form1832)
                .HasMaxLength(500)
                .HasColumnName("Form18_32");
            entity.Property(e => e.Form1833)
                .HasMaxLength(500)
                .HasColumnName("Form18_33");
            entity.Property(e => e.Form1834)
                .HasMaxLength(500)
                .HasColumnName("Form18_34");
            entity.Property(e => e.Form1835)
                .HasMaxLength(500)
                .HasColumnName("Form18_35");
            entity.Property(e => e.Form1836)
                .HasMaxLength(500)
                .HasColumnName("Form18_36");
            entity.Property(e => e.Form1837)
                .HasMaxLength(500)
                .HasColumnName("Form18_37");
            entity.Property(e => e.Form1838)
                .HasMaxLength(500)
                .HasColumnName("Form18_38");
            entity.Property(e => e.Form1839).HasColumnName("Form18_39");
            entity.Property(e => e.Form184)
                .HasMaxLength(500)
                .HasColumnName("Form18_4");
            entity.Property(e => e.Form1840).HasColumnName("Form18_40");
            entity.Property(e => e.Form1841).HasColumnName("Form18_41");
            entity.Property(e => e.Form1842).HasColumnName("Form18_42");
            entity.Property(e => e.Form1843).HasColumnName("Form18_43");
            entity.Property(e => e.Form1844).HasColumnName("Form18_44");
            entity.Property(e => e.Form1845)
                .HasMaxLength(500)
                .HasColumnName("Form18_45");
            entity.Property(e => e.Form1846)
                .HasMaxLength(500)
                .HasColumnName("Form18_46");
            entity.Property(e => e.Form1847)
                .HasMaxLength(500)
                .HasColumnName("Form18_47");
            entity.Property(e => e.Form185)
                .HasMaxLength(500)
                .HasColumnName("Form18_5");
            entity.Property(e => e.Form186)
                .HasMaxLength(500)
                .HasColumnName("Form18_6");
            entity.Property(e => e.Form187)
                .HasMaxLength(500)
                .HasColumnName("Form18_7");
            entity.Property(e => e.Form188)
                .HasMaxLength(500)
                .HasColumnName("Form18_8");
            entity.Property(e => e.Form189).HasColumnName("Form18_9");
            entity.Property(e => e.Form18IsAnxiety).HasColumnName("Form18_IsAnxiety");
            entity.Property(e => e.Form18IsArthritis).HasColumnName("Form18_IsArthritis");
            entity.Property(e => e.Form18IsAsthma).HasColumnName("Form18_IsAsthma");
            entity.Property(e => e.Form18IsBone).HasColumnName("Form18_IsBone");
            entity.Property(e => e.Form18IsCancer).HasColumnName("Form18_IsCancer");
            entity.Property(e => e.Form18IsChestPain).HasColumnName("Form18_IsChestPain");
            entity.Property(e => e.Form18IsChronicFatigue).HasColumnName("Form18_IsChronicFatigue");
            entity.Property(e => e.Form18IsChronicPain).HasColumnName("Form18_IsChronicPain");
            entity.Property(e => e.Form18IsDating).HasColumnName("Form18_IsDating");
            entity.Property(e => e.Form18IsDecreasedAppetite).HasColumnName("Form18_IsDecreasedAppetite");
            entity.Property(e => e.Form18IsDepressedMood).HasColumnName("Form18_IsDepressedMood");
            entity.Property(e => e.Form18IsDiabetes).HasColumnName("Form18_IsDiabetes");
            entity.Property(e => e.Form18IsDifficultySleeping).HasColumnName("Form18_IsDifficultySleeping");
            entity.Property(e => e.Form18IsDivorced).HasColumnName("Form18_IsDivorced");
            entity.Property(e => e.Form18IsDizziness).HasColumnName("Form18_IsDizziness");
            entity.Property(e => e.Form18IsExcessiveSleep).HasColumnName("Form18_IsExcessiveSleep");
            entity.Property(e => e.Form18IsFaintness).HasColumnName("Form18_IsFaintness");
            entity.Property(e => e.Form18IsFatigue).HasColumnName("Form18_IsFatigue");
            entity.Property(e => e.Form18IsFear).HasColumnName("Form18_IsFear");
            entity.Property(e => e.Form18IsFibromyalgia).HasColumnName("Form18_IsFibromyalgia");
            entity.Property(e => e.Form18IsGastritis).HasColumnName("Form18_IsGastritis");
            entity.Property(e => e.Form18IsHeadInjury).HasColumnName("Form18_IsHeadInjury");
            entity.Property(e => e.Form18IsHeadache).HasColumnName("Form18_IsHeadache");
            entity.Property(e => e.Form18IsHeartAttact).HasColumnName("Form18_IsHeartAttact");
            entity.Property(e => e.Form18IsHeartValveProblems).HasColumnName("Form18_IsHeartValveProblems");
            entity.Property(e => e.Form18IsHepatitis).HasColumnName("Form18_IsHepatitis");
            entity.Property(e => e.Form18IsHighBloodPressure).HasColumnName("Form18_IsHighBloodPressure");
            entity.Property(e => e.Form18IsHivAids).HasColumnName("Form18_IsHiv/Aids");
            entity.Property(e => e.Form18IsHopelessness).HasColumnName("Form18_IsHopelessness");
            entity.Property(e => e.Form18IsHormone).HasColumnName("Form18_IsHormone");
            entity.Property(e => e.Form18IsIncreasedAppetite).HasColumnName("Form18_IsIncreasedAppetite");
            entity.Property(e => e.Form18IsIrritableBowel).HasColumnName("Form18_IsIrritableBowel");
            entity.Property(e => e.Form18IsIsolationFrom).HasColumnName("Form18_IsIsolationFrom");
            entity.Property(e => e.Form18IsKidneyRelatedIssues).HasColumnName("Form18_IsKidneyRelatedIssues");
            entity.Property(e => e.Form18IsLivingApart).HasColumnName("Form18_IsLivingApart");
            entity.Property(e => e.Form18IsLivingTogether).HasColumnName("Form18_IsLivingTogether");
            entity.Property(e => e.Form18IsLossOfConsciousness).HasColumnName("Form18_IsLossOfConsciousness");
            entity.Property(e => e.Form18IsLowMotivation).HasColumnName("Form18_IsLowMotivation");
            entity.Property(e => e.Form18IsLowSelfEsteem).HasColumnName("Form18_IsLowSelfEsteem");
            entity.Property(e => e.Form18IsMarried).HasColumnName("Form18_IsMarried");
            entity.Property(e => e.Form18IsNumbness).HasColumnName("Form18_IsNumbness");
            entity.Property(e => e.Form18IsOther1).HasColumnName("Form18_IsOther1");
            entity.Property(e => e.Form18IsOther2).HasColumnName("Form18_IsOther2");
            entity.Property(e => e.Form18IsPanic).HasColumnName("Form18_IsPanic");
            entity.Property(e => e.Form18IsSeizures).HasColumnName("Form18_IsSeizures");
            entity.Property(e => e.Form18IsSeparated).HasColumnName("Form18_IsSeparated");
            entity.Property(e => e.Form18IsShortness).HasColumnName("Form18_IsShortness");
            entity.Property(e => e.Form18IsTearful).HasColumnName("Form18_IsTearful");
            entity.Property(e => e.Form18IsThyroidIssues).HasColumnName("Form18_IsThyroidIssues");
            entity.Property(e => e.Form18IsTroubleConcentrating).HasColumnName("Form18_IsTroubleConcentrating");
            entity.Property(e => e.Form18IsUniaryTractProblems).HasColumnName("Form18_IsUniaryTractProblems");
            entity.Property(e => e.Form18Scale1).HasColumnName("Form18_Scale1");
            entity.Property(e => e.Form18Scale2).HasColumnName("Form18_Scale2");
            entity.Property(e => e.Form18Scale3).HasColumnName("Form18_Scale3");
            entity.Property(e => e.Form18Scale4).HasColumnName("Form18_Scale4");
            entity.Property(e => e.Form18Scale5).HasColumnName("Form18_Scale5");
        });

        modelBuilder.Entity<Form19>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_19");

            entity.Property(e => e.F191)
                .HasMaxLength(500)
                .HasColumnName("F19_1");
            entity.Property(e => e.F1910)
                .HasMaxLength(500)
                .HasColumnName("F19_10");
            entity.Property(e => e.F1911)
                .HasMaxLength(500)
                .HasColumnName("F19_11");
            entity.Property(e => e.F1912)
                .HasMaxLength(500)
                .HasColumnName("F19_12");
            entity.Property(e => e.F1913)
                .HasMaxLength(500)
                .HasColumnName("F19_13");
            entity.Property(e => e.F1914)
                .HasMaxLength(500)
                .HasColumnName("F19_14");
            entity.Property(e => e.F1915).HasColumnName("F19_15");
            entity.Property(e => e.F1916).HasColumnName("F19_16");
            entity.Property(e => e.F1917)
                .HasMaxLength(500)
                .HasColumnName("F19_17");
            entity.Property(e => e.F1918)
                .HasMaxLength(500)
                .HasColumnName("F19_18");
            entity.Property(e => e.F1919)
                .HasMaxLength(500)
                .HasColumnName("F19_19");
            entity.Property(e => e.F192)
                .HasMaxLength(500)
                .HasColumnName("F19_2");
            entity.Property(e => e.F1920)
                .HasMaxLength(500)
                .HasColumnName("F19_20");
            entity.Property(e => e.F1921)
                .HasMaxLength(500)
                .HasColumnName("F19_21");
            entity.Property(e => e.F1922)
                .HasMaxLength(500)
                .HasColumnName("F19_22");
            entity.Property(e => e.F1923)
                .HasMaxLength(500)
                .HasColumnName("F19_23");
            entity.Property(e => e.F1924)
                .HasMaxLength(500)
                .HasColumnName("F19_24");
            entity.Property(e => e.F1925)
                .HasMaxLength(500)
                .HasColumnName("F19_25");
            entity.Property(e => e.F1926).HasColumnName("F19_26");
            entity.Property(e => e.F1927).HasColumnName("F19_27");
            entity.Property(e => e.F1928)
                .HasMaxLength(500)
                .HasColumnName("F19_28");
            entity.Property(e => e.F1929).HasColumnName("F19_29");
            entity.Property(e => e.F193)
                .HasMaxLength(500)
                .HasColumnName("F19_3");
            entity.Property(e => e.F1930).HasColumnName("F19_30");
            entity.Property(e => e.F1931).HasColumnName("F19_31");
            entity.Property(e => e.F1932).HasColumnName("F19_32");
            entity.Property(e => e.F1933).HasColumnName("F19_33");
            entity.Property(e => e.F1934).HasColumnName("F19_34");
            entity.Property(e => e.F1935)
                .HasMaxLength(500)
                .HasColumnName("F19_35");
            entity.Property(e => e.F1936).HasColumnName("F19_36");
            entity.Property(e => e.F1937).HasColumnName("F19_37");
            entity.Property(e => e.F1938)
                .HasMaxLength(500)
                .HasColumnName("F19_38");
            entity.Property(e => e.F1939)
                .HasMaxLength(500)
                .HasColumnName("F19_39");
            entity.Property(e => e.F194)
                .HasMaxLength(500)
                .HasColumnName("F19_4");
            entity.Property(e => e.F195).HasColumnName("F19_5");
            entity.Property(e => e.F196).HasColumnName("F19_6");
            entity.Property(e => e.F197).HasColumnName("F19_7");
            entity.Property(e => e.F198).HasColumnName("F19_8");
            entity.Property(e => e.F199)
                .HasMaxLength(500)
                .HasColumnName("F19_9");
            entity.Property(e => e.F19IsAnxiety).HasColumnName("F19_IsAnxiety");
            entity.Property(e => e.F19IsDating).HasColumnName("F19_IsDating");
            entity.Property(e => e.F19IsDecreasedAppetite).HasColumnName("F19_IsDecreasedAppetite");
            entity.Property(e => e.F19IsDepressedMood).HasColumnName("F19_IsDepressedMood");
            entity.Property(e => e.F19IsDifficultySleeping).HasColumnName("F19_IsDifficultySleeping");
            entity.Property(e => e.F19IsDivorced).HasColumnName("F19_IsDivorced");
            entity.Property(e => e.F19IsExcessiveSleep).HasColumnName("F19_IsExcessiveSleep");
            entity.Property(e => e.F19IsFatigue).HasColumnName("F19_IsFatigue");
            entity.Property(e => e.F19IsFear).HasColumnName("F19_IsFear");
            entity.Property(e => e.F19IsHopelessness).HasColumnName("F19_IsHopelessness");
            entity.Property(e => e.F19IsIncreasedAppetite).HasColumnName("F19_IsIncreasedAppetite");
            entity.Property(e => e.F19IsIsolationFromOthers).HasColumnName("F19_IsIsolationFromOthers");
            entity.Property(e => e.F19IsLivingApart).HasColumnName("F19_IsLivingApart");
            entity.Property(e => e.F19IsLivingTogether).HasColumnName("F19_IsLivingTogether");
            entity.Property(e => e.F19IsLowMotivation).HasColumnName("F19_IsLowMotivation");
            entity.Property(e => e.F19IsLowSelfEsteem).HasColumnName("F19_IsLowSelfEsteem");
            entity.Property(e => e.F19IsMarried).HasColumnName("F19_IsMarried");
            entity.Property(e => e.F19IsOther1).HasColumnName("F19_IsOther1");
            entity.Property(e => e.F19IsPanic).HasColumnName("F19_IsPanic");
            entity.Property(e => e.F19IsSeparated).HasColumnName("F19_IsSeparated");
            entity.Property(e => e.F19IsTearful).HasColumnName("F19_IsTearful");
            entity.Property(e => e.F19IsTroubleConcentrating).HasColumnName("F19_IsTroubleConcentrating");
        });

        modelBuilder.Entity<Form2>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_2");

            entity.Property(e => e.F21).HasColumnName("F2_1");
            entity.Property(e => e.F210).HasColumnName("F2_10");
            entity.Property(e => e.F211).HasColumnName("F2_11");
            entity.Property(e => e.F212).HasColumnName("F2_12");
            entity.Property(e => e.F213).HasColumnName("F2_13");
            entity.Property(e => e.F214).HasColumnName("F2_14");
            entity.Property(e => e.F215).HasColumnName("F2_15");
            entity.Property(e => e.F216).HasColumnName("F2_16");
            entity.Property(e => e.F217).HasColumnName("F2_17");
            entity.Property(e => e.F218).HasColumnName("F2_18");
            entity.Property(e => e.F22).HasColumnName("F2_2");
            entity.Property(e => e.F23).HasColumnName("F2_3");
            entity.Property(e => e.F24).HasColumnName("F2_4");
            entity.Property(e => e.F25).HasColumnName("F2_5");
            entity.Property(e => e.F26).HasColumnName("F2_6");
            entity.Property(e => e.F27).HasColumnName("F2_7");
            entity.Property(e => e.F28).HasColumnName("F2_8");
            entity.Property(e => e.F29).HasColumnName("F2_9");
        });

        modelBuilder.Entity<Form20>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_20");

            entity.Property(e => e.F201)
                .HasMaxLength(500)
                .HasColumnName("F20_1");
            entity.Property(e => e.F2010).HasColumnName("F20_10");
            entity.Property(e => e.F2011)
                .HasMaxLength(500)
                .HasColumnName("F20_11");
            entity.Property(e => e.F2012)
                .HasMaxLength(500)
                .HasColumnName("F20_12");
            entity.Property(e => e.F2013)
                .HasMaxLength(500)
                .HasColumnName("F20_13");
            entity.Property(e => e.F2014)
                .HasMaxLength(500)
                .HasColumnName("F20_14");
            entity.Property(e => e.F2015).HasColumnName("F20_15");
            entity.Property(e => e.F2016).HasColumnName("F20_16");
            entity.Property(e => e.F2017).HasColumnName("F20_17");
            entity.Property(e => e.F2017Yes)
                .HasMaxLength(500)
                .HasColumnName("F20_17_Yes");
            entity.Property(e => e.F2018).HasColumnName("F20_18");
            entity.Property(e => e.F2019).HasColumnName("F20_19");
            entity.Property(e => e.F202)
                .HasMaxLength(500)
                .HasColumnName("F20_2");
            entity.Property(e => e.F2020).HasColumnName("F20_20");
            entity.Property(e => e.F2021).HasColumnName("F20_21");
            entity.Property(e => e.F2022).HasColumnName("F20_22");
            entity.Property(e => e.F2023)
                .HasMaxLength(500)
                .HasColumnName("F20_23");
            entity.Property(e => e.F2024).HasColumnName("F20_24");
            entity.Property(e => e.F2025)
                .HasMaxLength(500)
                .HasColumnName("F20_25");
            entity.Property(e => e.F2026)
                .HasMaxLength(500)
                .HasColumnName("F20_26");
            entity.Property(e => e.F2027).HasColumnName("F20_27");
            entity.Property(e => e.F2028).HasColumnName("F20_28");
            entity.Property(e => e.F2029).HasColumnName("F20_29");
            entity.Property(e => e.F203)
                .HasMaxLength(500)
                .HasColumnName("F20_3");
            entity.Property(e => e.F2030)
                .HasMaxLength(500)
                .HasColumnName("F20_30");
            entity.Property(e => e.F2031)
                .HasMaxLength(500)
                .HasColumnName("F20_31");
            entity.Property(e => e.F2032).HasColumnName("F20_32");
            entity.Property(e => e.F2033)
                .HasMaxLength(500)
                .HasColumnName("F20_33");
            entity.Property(e => e.F2034)
                .HasMaxLength(500)
                .HasColumnName("F20_34");
            entity.Property(e => e.F2035)
                .HasMaxLength(500)
                .HasColumnName("F20_35");
            entity.Property(e => e.F204)
                .HasMaxLength(500)
                .HasColumnName("F20_4");
            entity.Property(e => e.F205)
                .HasMaxLength(500)
                .HasColumnName("F20_5");
            entity.Property(e => e.F206)
                .HasMaxLength(500)
                .HasColumnName("F20_6");
            entity.Property(e => e.F207)
                .HasMaxLength(500)
                .HasColumnName("F20_7");
            entity.Property(e => e.F208)
                .HasMaxLength(500)
                .HasColumnName("F20_8");
            entity.Property(e => e.F209)
                .HasMaxLength(500)
                .HasColumnName("F20_9");
            entity.Property(e => e.F20IsAlcoholCarving).HasColumnName("F20_IsAlcoholCarving");
            entity.Property(e => e.F20IsAlcoholism).HasColumnName("F20_IsAlcoholism");
            entity.Property(e => e.F20IsAngerIssues).HasColumnName("F20_IsAngerIssues");
            entity.Property(e => e.F20IsAnxiety).HasColumnName("F20_IsAnxiety");
            entity.Property(e => e.F20IsAnxietyOrPanicAttacts).HasColumnName("F20_IsAnxietyOrPanicAttacts");
            entity.Property(e => e.F20IsAnxity).HasColumnName("F20_IsAnxity");
            entity.Property(e => e.F20IsAppetiteChanges).HasColumnName("F20_IsAppetiteChanges");
            entity.Property(e => e.F20IsAttemptedSuicide).HasColumnName("F20_IsAttemptedSuicide");
            entity.Property(e => e.F20IsAvoidPlaces).HasColumnName("F20_IsAvoidPlaces");
            entity.Property(e => e.F20IsBipolarDisorder).HasColumnName("F20_IsBipolarDisorder");
            entity.Property(e => e.F20IsConcentrationProblems).HasColumnName("F20_IsConcentrationProblems");
            entity.Property(e => e.F20IsConfusion).HasColumnName("F20_IsConfusion");
            entity.Property(e => e.F20IsConstantSuspicion).HasColumnName("F20_IsConstantSuspicion");
            entity.Property(e => e.F20IsCryingFrequently).HasColumnName("F20_IsCryingFrequently");
            entity.Property(e => e.F20IsDecreasedPleasure).HasColumnName("F20_IsDecreasedPleasure");
            entity.Property(e => e.F20IsDepression).HasColumnName("F20_IsDepression");
            entity.Property(e => e.F20IsDifficultyGettingSleep).HasColumnName("F20_IsDifficultyGettingSleep");
            entity.Property(e => e.F20IsDifficultyStayingAsleep).HasColumnName("F20_IsDifficultyStayingAsleep");
            entity.Property(e => e.F20IsDizziness).HasColumnName("F20_IsDizziness");
            entity.Property(e => e.F20IsDrugCraving).HasColumnName("F20_IsDrugCraving");
            entity.Property(e => e.F20IsEatingDisorders).HasColumnName("F20_IsEatingDisorders");
            entity.Property(e => e.F20IsEatingProblems).HasColumnName("F20_IsEatingProblems");
            entity.Property(e => e.F20IsElatedMood).HasColumnName("F20_IsElatedMood");
            entity.Property(e => e.F20IsEmotional).HasColumnName("F20_IsEmotional");
            entity.Property(e => e.F20IsExcessEnergy).HasColumnName("F20_IsExcessEnergy");
            entity.Property(e => e.F20IsExcessiveAnger).HasColumnName("F20_IsExcessiveAnger");
            entity.Property(e => e.F20IsExcessiveSpending).HasColumnName("F20_IsExcessiveSpending");
            entity.Property(e => e.F20IsFamilyConflict).HasColumnName("F20_IsFamilyConflict");
            entity.Property(e => e.F20IsFear).HasColumnName("F20_IsFear");
            entity.Property(e => e.F20IsFeelThatOthersAreAgaintYou).HasColumnName("F20_IsFeelThatOthersAreAgaintYou");
            entity.Property(e => e.F20IsFeelingHopeless).HasColumnName("F20_IsFeelingHopeless");
            entity.Property(e => e.F20IsFeelingIsolated).HasColumnName("F20_IsFeelingIsolated");
            entity.Property(e => e.F20IsFeelingTheNeedToDo).HasColumnName("F20_IsFeelingTheNeedToDo");
            entity.Property(e => e.F20IsFeelingWired).HasColumnName("F20_IsFeelingWired");
            entity.Property(e => e.F20IsFeelingWorthless).HasColumnName("F20_IsFeelingWorthless");
            entity.Property(e => e.F20IsFrequentNightmares).HasColumnName("F20_IsFrequentNightmares");
            entity.Property(e => e.F20IsFrequentWorring).HasColumnName("F20_IsFrequentWorring");
            entity.Property(e => e.F20IsFriends).HasColumnName("F20_IsFriends");
            entity.Property(e => e.F20IsGrandioseThoughts).HasColumnName("F20_IsGrandioseThoughts");
            entity.Property(e => e.F20IsHeadaches).HasColumnName("F20_IsHeadaches");
            entity.Property(e => e.F20IsHearingVoices).HasColumnName("F20_IsHearingVoices");
            entity.Property(e => e.F20IsHyperactivity).HasColumnName("F20_IsHyperactivity");
            entity.Property(e => e.F20IsImpulsiveBehaviour).HasColumnName("F20_IsIMpulsiveBehaviour");
            entity.Property(e => e.F20IsLearningChallenges).HasColumnName("F20_IsLearningChallenges");
            entity.Property(e => e.F20IsLegal).HasColumnName("F20_IsLegal");
            entity.Property(e => e.F20IsLessNeedForSleep).HasColumnName("F20_IsLessNeedForSleep");
            entity.Property(e => e.F20IsLossOfAppetite).HasColumnName("F20_IsLossOfAppetite");
            entity.Property(e => e.F20IsLowEnergy).HasColumnName("F20_IsLowEnergy");
            entity.Property(e => e.F20IsMoodSwings).HasColumnName("F20_IsMoodSwings");
            entity.Property(e => e.F20IsObsessive).HasColumnName("F20_IsObsessive");
            entity.Property(e => e.F20IsOther).HasColumnName("F20_IsOther");
            entity.Property(e => e.F20IsPain).HasColumnName("F20_IsPain");
            entity.Property(e => e.F20IsPanicAttacts).HasColumnName("F20_IsPanicAttacts");
            entity.Property(e => e.F20IsParents).HasColumnName("F20_IsParents");
            entity.Property(e => e.F20IsPhysicalAbuse).HasColumnName("F20_IsPhysicalAbuse");
            entity.Property(e => e.F20IsRacingThoughts).HasColumnName("F20_IsRacingThoughts");
            entity.Property(e => e.F20IsRelationshipProblems).HasColumnName("F20_IsRelationshipProblems");
            entity.Property(e => e.F20IsRestlessness).HasColumnName("F20_IsRestlessness");
            entity.Property(e => e.F20IsSeeingThings).HasColumnName("F20_IsSeeingThings");
            entity.Property(e => e.F20IsSexualAbuse).HasColumnName("F20_IsSexualAbuse");
            entity.Property(e => e.F20IsSexualProblems).HasColumnName("F20_IsSexualProblems");
            entity.Property(e => e.F20IsStrangeExperience).HasColumnName("F20_IsStrangeExperience");
            entity.Property(e => e.F20IsSubstanceUse).HasColumnName("F20_IsSubstanceUse");
            entity.Property(e => e.F20IsSuicidalPlans).HasColumnName("F20_IsSuicidalPlans");
            entity.Property(e => e.F20IsSuicidalThought).HasColumnName("F20_IsSuicidalThought");
            entity.Property(e => e.F20IsSuicidalThoughts).HasColumnName("F20_IsSuicidalThoughts");
            entity.Property(e => e.F20IsSuideAttempts).HasColumnName("F20_IsSuideAttempts");
            entity.Property(e => e.F20IsThoughtsOfPhysicallyHarmingSomeone).HasColumnName("F20_IsThoughtsOfPhysicallyHarmingSomeone");
            entity.Property(e => e.F20IsThoughtsOfSomeonePhysicallyHarmingYou).HasColumnName("F20_IsThoughtsOfSomeonePhysicallyHarmingYou");
            entity.Property(e => e.F20IsTrauma).HasColumnName("F20_IsTrauma");
            entity.Property(e => e.F20IsTroubleEatingFood).HasColumnName("F20_IsTroubleEatingFood");
            entity.Property(e => e.F20IsUnableToHaveFun).HasColumnName("F20_IsUnableToHaveFun");
            entity.Property(e => e.F20IsUnusualThoughts).HasColumnName("F20_IsUnusualThoughts");
            entity.Property(e => e.F20IsUnwantedThoughts).HasColumnName("F20_IsUnwantedThoughts");
            entity.Property(e => e.F20IsVoilent).HasColumnName("F20_IsVoilent");
            entity.Property(e => e.F20IsWeightGain).HasColumnName("F20_IsWeightGain");
            entity.Property(e => e.F20IsWeightLoss).HasColumnName("F20_IsWeightLoss");
        });

        modelBuilder.Entity<Form3>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_3");

            entity.Property(e => e.F31).HasColumnName("F3_1");
            entity.Property(e => e.F310).HasColumnName("F3_10");
            entity.Property(e => e.F32).HasColumnName("F3_2");
            entity.Property(e => e.F33).HasColumnName("F3_3");
            entity.Property(e => e.F34).HasColumnName("F3_4");
            entity.Property(e => e.F35).HasColumnName("F3_5");
            entity.Property(e => e.F36).HasColumnName("F3_6");
            entity.Property(e => e.F37).HasColumnName("F3_7");
            entity.Property(e => e.F38).HasColumnName("F3_8");
            entity.Property(e => e.F39).HasColumnName("F3_9");
        });

        modelBuilder.Entity<Form4>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_4");

            entity.Property(e => e.F41).HasColumnName("F4_1");
            entity.Property(e => e.F410).HasColumnName("F4_10");
            entity.Property(e => e.F411).HasColumnName("F4_11");
            entity.Property(e => e.F42).HasColumnName("F4_2");
            entity.Property(e => e.F43).HasColumnName("F4_3");
            entity.Property(e => e.F44).HasColumnName("F4_4");
            entity.Property(e => e.F45).HasColumnName("F4_5");
            entity.Property(e => e.F46).HasColumnName("F4_6");
            entity.Property(e => e.F47).HasColumnName("F4_7");
            entity.Property(e => e.F48).HasColumnName("F4_8");
            entity.Property(e => e.F49).HasColumnName("F4_9");
        });

        modelBuilder.Entity<Form5>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_5");

            entity.Property(e => e.F51)
                .HasMaxLength(200)
                .HasColumnName("F5_1");
            entity.Property(e => e.F510)
                .HasMaxLength(500)
                .HasColumnName("F5_10");
            entity.Property(e => e.F511)
                .HasMaxLength(500)
                .HasColumnName("F5_11");
            entity.Property(e => e.F512)
                .HasMaxLength(500)
                .HasColumnName("F5_12");
            entity.Property(e => e.F513)
                .HasMaxLength(500)
                .HasColumnName("F5_13");
            entity.Property(e => e.F514).HasColumnName("F5_14");
            entity.Property(e => e.F515).HasColumnName("F5_15");
            entity.Property(e => e.F516).HasColumnName("F5_16");
            entity.Property(e => e.F517).HasColumnName("F5_17");
            entity.Property(e => e.F518).HasColumnName("F5_18");
            entity.Property(e => e.F519).HasColumnName("F5_19");
            entity.Property(e => e.F52)
                .HasMaxLength(200)
                .HasColumnName("F5_2");
            entity.Property(e => e.F520).HasColumnName("F5_20");
            entity.Property(e => e.F521).HasColumnName("F5_21");
            entity.Property(e => e.F522)
                .HasMaxLength(500)
                .HasColumnName("F5_22");
            entity.Property(e => e.F53).HasColumnName("F5_3");
            entity.Property(e => e.F54)
                .HasMaxLength(500)
                .HasColumnName("F5_4");
            entity.Property(e => e.F55)
                .HasMaxLength(500)
                .HasColumnName("F5_5");
            entity.Property(e => e.F56)
                .HasMaxLength(500)
                .HasColumnName("F5_6");
            entity.Property(e => e.F57).HasColumnName("F5_7");
            entity.Property(e => e.F58)
                .HasMaxLength(500)
                .HasColumnName("F5_8");
            entity.Property(e => e.F59)
                .HasMaxLength(500)
                .HasColumnName("F5_9");
            entity.Property(e => e.F5IsDating).HasColumnName("F5_IsDating");
            entity.Property(e => e.F5IsDivorced).HasColumnName("F5_IsDivorced");
            entity.Property(e => e.F5IsLittleConcern).HasColumnName("F5_IsLittleConcern");
            entity.Property(e => e.F5IsLivingApart).HasColumnName("F5_IsLivingApart");
            entity.Property(e => e.F5IsLivingTogether).HasColumnName("F5_IsLivingTogether");
            entity.Property(e => e.F5IsMarried).HasColumnName("F5_IsMarried");
            entity.Property(e => e.F5IsModerateConcern).HasColumnName("F5_IsModerateConcern");
            entity.Property(e => e.F5IsNoConcern).HasColumnName("F5_IsNoConcern");
            entity.Property(e => e.F5IsSeparated).HasColumnName("F5_IsSeparated");
            entity.Property(e => e.F5IsSeriousConcern).HasColumnName("F5_IsSeriousConcern");
            entity.Property(e => e.F5IsVerySeriousConcern).HasColumnName("F5_IsVerySeriousConcern");
            entity.Property(e => e.F5Scale).HasColumnName("F5_Scale");
            entity.Property(e => e.F5Scale2).HasColumnName("F5_Scale2");
            entity.Property(e => e.F5Scale3).HasColumnName("F5_Scale3");
            entity.Property(e => e.F5Scale4).HasColumnName("F5_Scale4");
            entity.Property(e => e.F5Scale5).HasColumnName("F5_Scale5");
        });

        modelBuilder.Entity<Form6>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_6");

            entity.Property(e => e.FormId).ValueGeneratedNever();
            entity.Property(e => e.F61)
                .HasMaxLength(500)
                .HasColumnName("F6_1");
            entity.Property(e => e.F62)
                .HasMaxLength(200)
                .HasColumnName("F6_2");
            entity.Property(e => e.F63)
                .HasColumnType("date")
                .HasColumnName("F6_3");
            entity.Property(e => e.F6IsConcent).HasColumnName("F6_IsConcent");
        });

        modelBuilder.Entity<Form7>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_7");

            entity.Property(e => e.F71)
                .HasMaxLength(100)
                .HasColumnName("F7_1");
            entity.Property(e => e.F72)
                .HasMaxLength(100)
                .HasColumnName("F7_2");
            entity.Property(e => e.F73)
                .HasMaxLength(100)
                .HasColumnName("F7_3");
            entity.Property(e => e.F74)
                .HasMaxLength(100)
                .HasColumnName("F7_4");
            entity.Property(e => e.F75)
                .HasMaxLength(100)
                .HasColumnName("F7_5");
            entity.Property(e => e.F76)
                .HasMaxLength(100)
                .HasColumnName("F7_6");
            entity.Property(e => e.F77)
                .HasMaxLength(100)
                .HasColumnName("F7_7");
            entity.Property(e => e.F78).HasColumnName("F7_8");
        });

        modelBuilder.Entity<Form8>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_8");

            entity.Property(e => e.F81).HasColumnName("F8_1");
            entity.Property(e => e.F810).HasColumnName("F8_10");
            entity.Property(e => e.F811).HasColumnName("F8_11");
            entity.Property(e => e.F812).HasColumnName("F8_12");
            entity.Property(e => e.F813).HasColumnName("F8_13");
            entity.Property(e => e.F814).HasColumnName("F8_14");
            entity.Property(e => e.F815).HasColumnName("F8_15");
            entity.Property(e => e.F816).HasColumnName("F8_16");
            entity.Property(e => e.F817).HasColumnName("F8_17");
            entity.Property(e => e.F818).HasColumnName("F8_18");
            entity.Property(e => e.F82).HasColumnName("F8_2");
            entity.Property(e => e.F83).HasColumnName("F8_3");
            entity.Property(e => e.F84).HasColumnName("F8_4");
            entity.Property(e => e.F85).HasColumnName("F8_5");
            entity.Property(e => e.F86).HasColumnName("F8_6");
            entity.Property(e => e.F87).HasColumnName("F8_7");
            entity.Property(e => e.F88).HasColumnName("F8_8");
            entity.Property(e => e.F89).HasColumnName("F8_9");
        });

        modelBuilder.Entity<Form9>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("Form_9");
        });

        modelBuilder.Entity<InsurranceSetting>(entity =>
        {
            entity.HasKey(e => e.InsurranceId);

            entity.ToTable("InsurranceSetting");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Npi).HasColumnName("NPI");
            entity.Property(e => e.PracticeName).HasMaxLength(200);
            entity.Property(e => e.Street).HasMaxLength(200);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiveId);

            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceType).HasMaxLength(50);
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
            entity.Property(e => e.ServiceDescription).HasMaxLength(300);
            entity.Property(e => e.ServiceName).HasMaxLength(200);
        });

        modelBuilder.Entity<Tcuser>(entity =>
        {
            entity.HasKey(e => e.ClientId);

            entity.ToTable("TCUser");

            entity.Property(e => e.BilingType).HasMaxLength(50);
            entity.Property(e => e.BillResponsible)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ClientType).HasMaxLength(20);
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
