﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Models;

public partial class WorkplandbContext : IdentityDbContext
{
    public WorkplandbContext()
    {
    }

    public WorkplandbContext(DbContextOptions<WorkplandbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminOfficerComment> AdminOfficerComments { get; set; }

    public virtual DbSet<Analytical> Analyticals { get; set; }

    public virtual DbSet<Commodity> Commodities { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<FieldOption> FieldOptions { get; set; }

    public virtual DbSet<FieldWork> FieldWorks { get; set; }

    public virtual DbSet<FiscalYear> FiscalYears { get; set; }

    public virtual DbSet<FiscalYearStatus> FiscalYearStatuses { get; set; }

    public virtual DbSet<Fund> Funds { get; set; }

    public virtual DbSet<FundType> FundTypes { get; set; }

    public virtual DbSet<GradAss> GradAsses { get; set; }

    public virtual DbSet<GradOption> GradOptions { get; set; }

    public virtual DbSet<Laboratory> Laboratories { get; set; }

    public virtual DbSet<Locationn> Locationns { get; set; }

    public virtual DbSet<OtherPersonel> OtherPersonels { get; set; }

    public virtual DbSet<Porganization> Porganizations { get; set; }

    public virtual DbSet<PrincipalLocation> PrincipalLocations { get; set; }

    public virtual DbSet<ProcessProjectWay> ProcessProjectWays { get; set; }

    public virtual DbSet<ProgramArea> ProgramAreas { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectAssent> ProjectAssents { get; set; }

    public virtual DbSet<ProjectNote> ProjectNotes { get; set; }

    public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Roster> Rosters { get; set; }

    public virtual DbSet<SciProject> SciProjects { get; set; }

    public virtual DbSet<SciRole> SciRoles { get; set; }

    public virtual DbSet<Substacion> Substacions { get; set; }

    public virtual DbSet<ThesisProject> ThesisProjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=workplandb; Trusted_Connection=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AdminOfficerComment>(entity =>
        {
            entity.HasKey(e => e.AdminOfficerCommentsId).HasName("PK__adminOff__83E2C4E3A74A6E2A");

            entity.ToTable("adminOfficerComments");

            entity.Property(e => e.AdminOfficerCommentsId).HasColumnName("adminOfficerCommentsID");
            entity.Property(e => e.AdComments).HasColumnType("text");
            entity.Property(e => e.FundsComments).HasColumnType("text");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectVigency)
                .HasColumnType("date")
                .HasColumnName("projectVigency");
            entity.Property(e => e.ReviewDate).HasColumnType("date");
            entity.Property(e => e.UserRole).HasColumnType("text");
            entity.Property(e => e.Username).HasColumnType("text");
            entity.Property(e => e.WorkplanQuantity).HasColumnType("text");

            entity.HasOne(d => d.Project).WithMany(p => p.AdminOfficerComments)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__adminOffi__Proje__3429BB53");
        });

        modelBuilder.Entity<Analytical>(entity =>
        {
            entity.HasKey(e => e.AnalyticalId).HasName("PK__Analytic__B1E78B77D97F9138");

            entity.ToTable("Analytical");

            entity.Property(e => e.AnalyticalId).HasColumnName("AnalyticalID");
            entity.Property(e => e.AnalysisRequired)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("analysisRequired");
            entity.Property(e => e.NumSamples)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numSamples");
            entity.Property(e => e.ProbableDate).HasColumnType("date");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Analyticals)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Analytica__Proje__2B0A656D");
        });

        modelBuilder.Entity<Commodity>(entity =>
        {
            entity.HasKey(e => e.CommId).HasName("PK__commodit__AF8CE2B9D73102EF");

            entity.ToTable("commodity");

            entity.Property(e => e.CommId).HasColumnName("CommID");
            entity.Property(e => e.CommName)
                .IsRequired()
                .HasMaxLength(210);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD83D4441F");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentCode)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.DepartmentName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.DepartmentOldId).HasColumnName("DepartmentOldID");
        });

        modelBuilder.Entity<FieldOption>(entity =>
        {
            entity.HasKey(e => e.FieldoptionId).HasName("PK__fieldOpt__07A1D99EA2DE5B4F");

            entity.ToTable("fieldOption");

            entity.Property(e => e.FieldoptionId).HasColumnName("fieldoptionId");
            entity.Property(e => e.OptionName).HasColumnType("text");
        });

        modelBuilder.Entity<FieldWork>(entity =>
        {
            entity.HasKey(e => e.FieldWorkId).HasName("PK__FieldWor__460E4F22C33E2AF1");

            entity.ToTable("FieldWork");

            entity.Property(e => e.FieldWorkId).HasColumnName("FieldWorkID");
            entity.Property(e => e.Area).IsUnicode(false);
            entity.Property(e => e.DateEnded)
                .HasColumnType("date")
                .HasColumnName("dateEnded");
            entity.Property(e => e.DateStarted)
                .HasColumnType("date")
                .HasColumnName("dateStarted");
            entity.Property(e => e.FieldoptionId).HasColumnName("fieldoptionId");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Wfieldwork)
                .HasColumnType("text")
                .HasColumnName("WFieldwork");

            entity.HasOne(d => d.Fieldoption).WithMany(p => p.FieldWorks)
                .HasForeignKey(d => d.FieldoptionId)
                .HasConstraintName("FK__FieldWork__field__54CB950F");

            entity.HasOne(d => d.Location).WithMany(p => p.FieldWorks)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FieldWork__Locat__68487DD7");

            entity.HasOne(d => d.Project).WithMany(p => p.FieldWorks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FieldWork__Proje__6754599E");
        });

        modelBuilder.Entity<FiscalYear>(entity =>
        {
            entity.HasKey(e => e.FiscalYearId).HasName("PK__fiscalYe__A4E4808FFED4D144");

            entity.ToTable("fiscalYear");

            entity.Property(e => e.FiscalYearId).HasColumnName("FiscalYearID");
            entity.Property(e => e.FiscalYearName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.FiscalYearNumber)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.FiscalYearStatusId).HasColumnName("FiscalYearStatusID");

            entity.HasOne(d => d.FiscalYearStatus).WithMany(p => p.FiscalYears)
                .HasForeignKey(d => d.FiscalYearStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fiscalYea__Fisca__5AEE82B9");
        });

        modelBuilder.Entity<FiscalYearStatus>(entity =>
        {
            entity.HasKey(e => e.FiscalYearStatusId).HasName("PK__FiscalYe__B9296B5B9DD4ADE8");

            entity.ToTable("FiscalYearStatus");

            entity.Property(e => e.FiscalYearStatusId)
                .ValueGeneratedNever()
                .HasColumnName("FiscalYearStatusID");
            entity.Property(e => e.FiscalYearStatusName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Fund>(entity =>
        {
            entity.HasKey(e => e.FundId).HasName("PK__funds__830DFC7A77D3E65F");

            entity.ToTable("funds");

            entity.Property(e => e.FundId).HasColumnName("FundID");
            entity.Property(e => e.Abroad).HasColumnType("money");
            entity.Property(e => e.Assistant).HasColumnType("money");
            entity.Property(e => e.Benefits).HasColumnType("money");
            entity.Property(e => e.Equipment).HasColumnType("money");
            entity.Property(e => e.IndirectCosts).HasColumnType("money");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Materials).HasColumnType("money");
            entity.Property(e => e.Others).HasColumnType("money");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Salaries).HasColumnType("money");
            entity.Property(e => e.Subcontracts).HasColumnType("money");
            entity.Property(e => e.TotalAmount).HasColumnType("money");
            entity.Property(e => e.Travel).HasColumnType("money");
            entity.Property(e => e.Ufisaccount)
                .HasMaxLength(50)
                .HasColumnName("UFISaccount");
            entity.Property(e => e.Wages).HasColumnType("money");

            entity.HasOne(d => d.Location).WithMany(p => p.Funds)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__funds__LocationI__6383C8BA");

            entity.HasOne(d => d.Project).WithMany(p => p.Funds)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__funds__ProjectID__6477ECF3");
        });

        modelBuilder.Entity<FundType>(entity =>
        {
            entity.HasKey(e => e.FundTypeId).HasName("PK__FundType__1CA29CB4FFE3D5BA");

            entity.ToTable("FundType");

            entity.Property(e => e.FundTypeId).HasColumnName("FundTypeID");
            entity.Property(e => e.FundTypeName).HasMaxLength(250);
        });

        modelBuilder.Entity<GradAss>(entity =>
        {
            entity.HasKey(e => e.Gaid).HasName("PK__gradAss__53B87C56576534AD");

            entity.ToTable("gradAss");

            entity.Property(e => e.Gaid).HasColumnName("GAID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Gname).HasMaxLength(255);
            entity.Property(e => e.GradoptionId).HasColumnName("gradoptionId");
            entity.Property(e => e.IsGraduated).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsUndergraduated).HasDefaultValueSql("((0))");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.StudentName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Thesis).HasColumnType("text");
            entity.Property(e => e.ThesisProjectId).HasColumnName("thesisProjectId");

            entity.HasOne(d => d.Gradoption).WithMany(p => p.GradAsses)
                .HasForeignKey(d => d.GradoptionId)
                .HasConstraintName("FK__gradAss__gradopt__589C25F3");

            entity.HasOne(d => d.Project).WithMany(p => p.GradAsses)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__gradAss__Project__5441852A");

            entity.HasOne(d => d.ThesisProject).WithMany(p => p.GradAsses)
                .HasForeignKey(d => d.ThesisProjectId)
                .HasConstraintName("FK__gradAss__thesisP__3FD07829");
        });

        modelBuilder.Entity<GradOption>(entity =>
        {
            entity.HasKey(e => e.GradoptionId).HasName("PK__gradOpti__C83A08D1B9826E3F");

            entity.ToTable("gradOption");

            entity.Property(e => e.GradoptionId).HasColumnName("gradoptionId");
            entity.Property(e => e.GradOptionName)
                .HasColumnType("text")
                .HasColumnName("gradOptionName");
        });

        modelBuilder.Entity<Laboratory>(entity =>
        {
            entity.HasKey(e => e.LabId).HasName("PK__laborato__EDBD773A43FC9BAF");

            entity.ToTable("laboratory");

            entity.Property(e => e.LabId).HasColumnName("LabID");
            entity.Property(e => e.Areq)
                .HasMaxLength(255)
                .HasColumnName("AReq");
            entity.Property(e => e.CentralLaboratory)
                .HasColumnType("text")
                .HasColumnName("centralLaboratory");
            entity.Property(e => e.Descriptions).HasColumnType("text");
            entity.Property(e => e.EstimatedTime).HasColumnType("text");
            entity.Property(e => e.FacilitiesNeeded).HasColumnType("text");
            entity.Property(e => e.NoSamples).HasMaxLength(70);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.SamplesDate).HasColumnType("datetime");
            entity.Property(e => e.TimeEstimated)
                .HasColumnType("date")
                .HasColumnName("timeEstimated");
            entity.Property(e => e.WorkPlanned).HasColumnType("text");

            entity.HasOne(d => d.Project).WithMany(p => p.Laboratories)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__laborator__Proje__49C3F6B7");
        });

        modelBuilder.Entity<Locationn>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA4779DCBB781");

            entity.ToTable("Locationn");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.FundsVar).HasMaxLength(10);
            entity.Property(e => e.LocationName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.LocationOldId).HasColumnName("LocationOldID");
        });

        modelBuilder.Entity<OtherPersonel>(entity =>
        {
            entity.HasKey(e => e.Opid).HasName("PK__OtherPer__AE2CBE1E1138560E");

            entity.ToTable("OtherPersonel");

            entity.Property(e => e.Opid).HasColumnName("OPID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PerTime).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PersonnelManAdded)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.RoleManAdded)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.RosterId).HasColumnName("RosterID");

            entity.HasOne(d => d.Location).WithMany(p => p.OtherPersonels)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__OtherPers__Locat__6C190EBB");

            entity.HasOne(d => d.Project).WithMany(p => p.OtherPersonels)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__OtherPers__Proje__6B24EA82");

            entity.HasOne(d => d.Roster).WithMany(p => p.OtherPersonels)
                .HasForeignKey(d => d.RosterId)
                .HasConstraintName("FK__OtherPers__Roste__6D0D32F4");
        });

        modelBuilder.Entity<Porganization>(entity =>
        {
            entity.HasKey(e => e.PorganizationId).HasName("PK__POrganiz__52E382BC29BC6268");

            entity.ToTable("POrganization");

            entity.Property(e => e.PorganizationId).HasColumnName("POrganizationID");
            entity.Property(e => e.PorganizationName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("POrganizationName");
        });

        modelBuilder.Entity<PrincipalLocation>(entity =>
        {
            entity.HasKey(e => e.PrincLocId).HasName("PK__principa__E67880F7556F770A");

            entity.ToTable("principalLocation");

            entity.Property(e => e.PrincLocId).HasColumnName("PrincLocID");
            entity.Property(e => e.PrincLocName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProcessProjectWay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("processProjectWay");

            entity.Property(e => e.ProcessProjectWayId).HasColumnName("ProcessProjectWayID");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__processPr__Proje__4D94879B");
        });

        modelBuilder.Entity<ProgramArea>(entity =>
        {
            entity.HasKey(e => e.ProgramAreaId).HasName("PK__ProgramA__FB5F0C9B6EAB4578");

            entity.ToTable("ProgramArea");

            entity.Property(e => e.ProgramAreaId).HasColumnName("ProgramAreaID");
            entity.Property(e => e.ProgramAreaName).HasMaxLength(200);
            entity.Property(e => e.ProgramAreaOldId).HasColumnName("ProgramAreaOldID");
            entity.Property(e => e.RosterProgragmaticCoordinatorId).HasColumnName("RosterProgragmaticCoordinatorID");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__projects__761ABED05384DF0D");

            entity.ToTable("projects");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Abroad).HasColumnType("text");
            entity.Property(e => e.Assistant).HasColumnType("text");
            entity.Property(e => e.Benefits).HasColumnType("text");
            entity.Property(e => e.CommId).HasColumnName("CommID");
            entity.Property(e => e.ContractNumber).HasColumnType("text");
            entity.Property(e => e.DateRegister).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Equipment).HasColumnType("text");
            entity.Property(e => e.Facilities).HasColumnType("text");
            entity.Property(e => e.FiscalYearId).HasColumnName("FiscalYearID");
            entity.Property(e => e.FundTypeId).HasColumnName("FundTypeID");
            entity.Property(e => e.Impact).HasColumnType("text");
            entity.Property(e => e.IndirectCosts).HasColumnType("text");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Materials).HasColumnType("text");
            entity.Property(e => e.ObjWorkPlan).HasColumnType("text");
            entity.Property(e => e.Objectives).HasColumnType("text");
            entity.Property(e => e.Objectives2).HasColumnType("text");
            entity.Property(e => e.Objectives3).HasColumnType("text");
            entity.Property(e => e.Objectives4).HasColumnType("text");
            entity.Property(e => e.Objectives5).HasColumnType("text");
            entity.Property(e => e.Objectives6).HasColumnType("text");
            entity.Property(e => e.Orcid)
                .HasColumnType("text")
                .HasColumnName("ORCID");
            entity.Property(e => e.Others).HasColumnType("text");
            entity.Property(e => e.PorganizationsId).HasColumnName("POrganizationsId");
            entity.Property(e => e.PresentOutlook).HasColumnType("text");
            entity.Property(e => e.ProcessProjectWayId).HasColumnName("ProcessProjectWayID");
            entity.Property(e => e.ProgramAreaId).HasColumnName("ProgramAreaID");
            entity.Property(e => e.ProjectNumber)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ProjectPi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ProjectPI");
            entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");
            entity.Property(e => e.ProjectTitle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ResultsAvailable).HasMaxLength(255);
            entity.Property(e => e.RosterId).HasColumnName("RosterID");
            entity.Property(e => e.Salaries).HasColumnType("text");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.SubStationId).HasColumnName("SubStationID");
            entity.Property(e => e.Subcontracts).HasColumnType("text");
            entity.Property(e => e.Substation).HasColumnType("text");
            entity.Property(e => e.TerminationDate).HasColumnType("datetime");
            entity.Property(e => e.Travel).HasColumnType("text");
            entity.Property(e => e.Wages).HasColumnType("text");
            entity.Property(e => e.Wfsid).HasColumnName("WFSID");
            entity.Property(e => e.Wfupdate)
                .HasColumnType("datetime")
                .HasColumnName("WFUpdate");
            entity.Property(e => e.WorkPlan2).HasColumnType("text");
            entity.Property(e => e.Workplan2Desc).HasColumnType("text");
            entity.Property(e => e.Wp1fieldWork)
                .HasColumnType("text")
                .HasColumnName("WP1FieldWork");
            entity.Property(e => e.Wp2id).HasColumnName("WP2ID");

            entity.HasOne(d => d.Comm).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CommId)
                .HasConstraintName("FK__projects__CommID__797309D9");

            entity.HasOne(d => d.Department).WithMany(p => p.Projects)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__projects__Depart__75A278F5");

            entity.HasOne(d => d.FiscalYear).WithMany(p => p.Projects)
                .HasForeignKey(d => d.FiscalYearId)
                .HasConstraintName("FK__projects__Fiscal__787EE5A0");

            entity.HasOne(d => d.FundType).WithMany(p => p.Projects)
                .HasForeignKey(d => d.FundTypeId)
                .HasConstraintName("FK__projects__FundTy__160F4887");

            entity.HasOne(d => d.Location).WithMany(p => p.Projects)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__projects__Locati__14270015");

            entity.HasOne(d => d.Porganizations).WithMany(p => p.Projects)
                .HasForeignKey(d => d.PorganizationsId)
                .HasConstraintName("FK__projects__POrgan__151B244E");

            entity.HasOne(d => d.ProgramArea).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProgramAreaId)
                .HasConstraintName("FK__projects__Progra__76969D2E");

            entity.HasOne(d => d.ProjectStatus).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectStatusId)
                .HasConstraintName("FK__projects__Projec__595B4002");

            entity.HasOne(d => d.Roster).WithMany(p => p.Projects)
                .HasForeignKey(d => d.RosterId)
                .HasConstraintName("FK__projects__Roster__3D2915A8");

            entity.HasOne(d => d.SubStation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.SubStationId)
                .HasConstraintName("FK__projects__SubSta__3C34F16F");
        });

        modelBuilder.Entity<ProjectAssent>(entity =>
        {
            entity.HasKey(e => e.PassentsId).HasName("PK__projectA__A852A60925D0FE56");

            entity.ToTable("projectAssents");

            entity.Property(e => e.PassentsId).HasColumnName("passentsID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RosterId).HasColumnName("RosterID");
            entity.Property(e => e.SignData).HasColumnName("signData");
            entity.Property(e => e.SignDate)
                .HasColumnType("datetime")
                .HasColumnName("signDate");
        });

        modelBuilder.Entity<ProjectNote>(entity =>
        {
            entity.HasKey(e => e.ProjectNotesId).HasName("PK__ProjectN__5DBF9709C49AD096");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.DeanComments).HasColumnType("text");
            entity.Property(e => e.DepartmentDirectorComments).HasColumnType("text");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Roles).HasColumnType("text");
            entity.Property(e => e.RosterId).HasColumnName("RosterID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRole)
                .HasColumnType("text")
                .HasColumnName("userRole");
            entity.Property(e => e.Username).HasColumnType("text");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectNotes)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__ProjectNo__Proje__214BF109");

            entity.HasOne(d => d.Roster).WithMany(p => p.ProjectNotes)
                .HasForeignKey(d => d.RosterId)
                .HasConstraintName("FK__ProjectNo__Roste__22401542");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectNotes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ProjectNo__UserI__2057CCD0");
        });

        modelBuilder.Entity<ProjectStatus>(entity =>
        {
            entity.HasKey(e => e.ProjectStatusId).HasName("PK__ProjectS__5D285B23212BDFA7");

            entity.ToTable("ProjectStatus");

            entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolesId).HasName("PK__Roles__C4B27820397EEFC7");

            entity.Property(e => e.RolesId).HasColumnName("RolesID");
            entity.Property(e => e.IsAdministrativeOfficer)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isAdministrativeOfficer");
            entity.Property(e => e.IsExecutiveOfficer)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isExecutiveOfficer");
            entity.Property(e => e.IsExternalResources)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isExternalResources");
            entity.Property(e => e.IsResearchDirector)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isResearchDirector");
            entity.Property(e => e.Rname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RName");
            entity.Property(e => e.RosterId).HasColumnName("rosterID");

            entity.HasOne(d => d.Roster).WithMany(p => p.Roles)
                .HasForeignKey(d => d.RosterId)
                .HasConstraintName("FK__Roles__rosterID__3F466844");
        });

        modelBuilder.Entity<Roster>(entity =>
        {
            entity.HasKey(e => e.RosterId).HasName("PK__roster__66F6BAAA8C8256A5");

            entity.ToTable("roster");

            entity.Property(e => e.RosterId).HasColumnName("RosterID");
            entity.Property(e => e.CanBePi).HasColumnName("CanBePI");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RosterName).HasMaxLength(250);
            entity.Property(e => e.RosterSegSoc).HasMaxLength(255);
        });

        modelBuilder.Entity<SciProject>(entity =>
        {
            entity.HasKey(e => e.SciId).HasName("PK__sciProje__CB9BA1E286343BBD");

            entity.ToTable("sciProjects");

            entity.Property(e => e.SciId).HasColumnName("SciID");
            entity.Property(e => e.Ah)
                .HasColumnType("money")
                .HasColumnName("AH");
            entity.Property(e => e.Ca)
                .HasColumnType("money")
                .HasColumnName("CA");
            entity.Property(e => e.Credits).HasColumnType("money");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.RosterId).HasColumnName("RosterID");
            entity.Property(e => e.SciRolesId).HasColumnName("sciRolesID");
            entity.Property(e => e.ThesisProjectId).HasColumnName("thesisProjectId");
            entity.Property(e => e.Tr)
                .HasColumnType("money")
                .HasColumnName("TR");

            entity.HasOne(d => d.Project).WithMany(p => p.SciProjects)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__sciProjec__Proje__1E6F845E");

            entity.HasOne(d => d.Roster).WithMany(p => p.SciProjects)
                .HasForeignKey(d => d.RosterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sciProjec__Roste__1F63A897");

            entity.HasOne(d => d.SciRoles).WithMany(p => p.SciProjects)
                .HasForeignKey(d => d.SciRolesId)
                .HasConstraintName("FK__sciProjec__sciRo__2116E6DF");

            entity.HasOne(d => d.ThesisProject).WithMany(p => p.SciProjects)
                .HasForeignKey(d => d.ThesisProjectId)
                .HasConstraintName("FK__sciProjec__thesi__2EA5EC27");
        });

        modelBuilder.Entity<SciRole>(entity =>
        {
            entity.HasKey(e => e.SciRolesId).HasName("PK__sciRoles__16C5DC50D6D60DAB");

            entity.ToTable("sciRoles");

            entity.Property(e => e.SciRolesId).HasColumnName("sciRolesID");
            entity.Property(e => e.SciRoleName).HasColumnType("text");
        });

        modelBuilder.Entity<Substacion>(entity =>
        {
            entity.HasKey(e => e.SubstationId).HasName("PK__Substaci__BB479C6F556A2D47");

            entity.ToTable("Substacion");

            entity.Property(e => e.SubstationId).HasColumnName("SubstationID");
            entity.Property(e => e.SubStationName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ThesisProject>(entity =>
        {
            entity.HasKey(e => e.ThesisProjectId).HasName("PK__thesisPr__9806B82188DB597F");

            entity.ToTable("thesisProject");

            entity.Property(e => e.ThesisProjectId).HasColumnName("thesisProjectId");
            entity.Property(e => e.OptionName)
                .HasColumnType("text")
                .HasColumnName("optionName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACB660C449");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.IsEnabled)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isEnabled");
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.Roles).HasColumnType("text");
            entity.Property(e => e.RolesId).HasColumnName("RolesID");
            entity.Property(e => e.RosterId).HasColumnName("RosterID");

            entity.HasOne(d => d.RolesNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("FK__Users__RolesID__0697FACD");

            entity.HasOne(d => d.Roster).WithMany(p => p.Users)
                .HasForeignKey(d => d.RosterId)
                .HasConstraintName("FK__Users__RosterID__6FE99F9F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


   
}
