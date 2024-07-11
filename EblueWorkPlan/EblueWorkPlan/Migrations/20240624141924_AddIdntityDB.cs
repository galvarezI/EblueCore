using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EblueWorkPlan.Migrations
{
    /// <inheritdoc />
    public partial class AddIdntityDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "commodity",
            //    columns: table => new
            //    {
            //        CommID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CommName = table.Column<string>(type: "nvarchar(210)", maxLength: 210, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__commodit__AF8CE2B9D73102EF", x => x.CommID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Departments",
            //    columns: table => new
            //    {
            //        DepartmentID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        DepartmentCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        DepartmentOf = table.Column<int>(type: "int", nullable: true),
            //        DepartmentOldID = table.Column<int>(type: "int", nullable: true),
            //        RosterDepartmentDirectorId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Departme__B2079BCD83D4441F", x => x.DepartmentID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "fieldOption",
            //    columns: table => new
            //    {
            //        fieldoptionId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OptionName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__fieldOpt__07A1D99EA2DE5B4F", x => x.fieldoptionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FiscalYearStatus",
            //    columns: table => new
            //    {
            //        FiscalYearStatusID = table.Column<int>(type: "int", nullable: false),
            //        FiscalYearStatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__FiscalYe__B9296B5B9DD4ADE8", x => x.FiscalYearStatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FundType",
            //    columns: table => new
            //    {
            //        FundTypeID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FundTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        IsFederal = table.Column<bool>(type: "bit", nullable: true),
            //        IsState = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__FundType__1CA29CB4FFE3D5BA", x => x.FundTypeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "gradOption",
            //    columns: table => new
            //    {
            //        gradoptionId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        gradOptionName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__gradOpti__C83A08D1B9826E3F", x => x.gradoptionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Locationn",
            //    columns: table => new
            //    {
            //        LocationID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LocationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        LocationOldID = table.Column<int>(type: "int", nullable: true),
            //        FundsVar = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Location__E7FEA4779DCBB781", x => x.LocationID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "POrganization",
            //    columns: table => new
            //    {
            //        POrganizationID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        POrganizationName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__POrganiz__52E382BC29BC6268", x => x.POrganizationID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "principalLocation",
            //    columns: table => new
            //    {
            //        PrincLocID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PrincLocName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__principa__E67880F7556F770A", x => x.PrincLocID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProgramArea",
            //    columns: table => new
            //    {
            //        ProgramAreaID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProgramAreaName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        ProgramAreaOldID = table.Column<int>(type: "int", nullable: true),
            //        RosterProgragmaticCoordinatorID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ProgramA__FB5F0C9B6EAB4578", x => x.ProgramAreaID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "projectAssents",
            //    columns: table => new
            //    {
            //        passentsID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectID = table.Column<int>(type: "int", nullable: true),
            //        RosterID = table.Column<int>(type: "int", nullable: true),
            //        RoleID = table.Column<int>(type: "int", nullable: true),
            //        signData = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        signDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        RosterData = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__projectA__A852A60925D0FE56", x => x.passentsID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProjectStatus",
            //    columns: table => new
            //    {
            //        ProjectStatusID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StatusNumber = table.Column<int>(type: "int", nullable: true),
            //        StatusName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ProjectS__5D285B23212BDFA7", x => x.ProjectStatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "roster",
            //    columns: table => new
            //    {
            //        RosterID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RosterSegSoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        RosterName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        DepartmentID = table.Column<int>(type: "int", nullable: false),
            //        LocationID = table.Column<int>(type: "int", nullable: false),
            //        CanBePI = table.Column<bool>(type: "bit", nullable: false),
            //        RoleID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__roster__66F6BAAA8C8256A5", x => x.RosterID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "sciRoles",
            //    columns: table => new
            //    {
            //        sciRolesID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SciRoleName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__sciRoles__16C5DC50D6D60DAB", x => x.sciRolesID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Substacion",
            //    columns: table => new
            //    {
            //        SubstationID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SubStationName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Substaci__BB479C6F556A2D47", x => x.SubstationID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "thesisProject",
            //    columns: table => new
            //    {
            //        thesisProjectId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        optionName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__thesisPr__9806B82188DB597F", x => x.thesisProjectId);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "fiscalYear",
            //    columns: table => new
            //    {
            //        FiscalYearID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FiscalYearName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        FiscalYearNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        FiscalYearStatusID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__fiscalYe__A4E4808FFED4D144", x => x.FiscalYearID);
            //        table.ForeignKey(
            //            name: "FK__fiscalYea__Fisca__5AEE82B9",
            //            column: x => x.FiscalYearStatusID,
            //            principalTable: "FiscalYearStatus",
            //            principalColumn: "FiscalYearStatusID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        RolesID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
            //        isResearchDirector = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        isExecutiveOfficer = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        isAdministrativeOfficer = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        isExternalResources = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        rosterID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Roles__C4B27820397EEFC7", x => x.RolesID);
            //        table.ForeignKey(
            //            name: "FK__Roles__rosterID__3F466844",
            //            column: x => x.rosterID,
            //            principalTable: "roster",
            //            principalColumn: "RosterID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "projects",
            //    columns: table => new
            //    {
            //        ProjectID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        ProjectTitle = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        DepartmentID = table.Column<int>(type: "int", nullable: true),
            //        CommID = table.Column<int>(type: "int", nullable: true),
            //        ProgramAreaID = table.Column<int>(type: "int", nullable: true),
            //        SubStationID = table.Column<int>(type: "int", nullable: true),
            //        DateRegister = table.Column<DateTime>(type: "datetime", nullable: true),
            //        LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        FiscalYearID = table.Column<int>(type: "int", nullable: true),
            //        Objectives = table.Column<string>(type: "text", nullable: true),
            //        ObjWorkPlan = table.Column<string>(type: "text", nullable: true),
            //        PresentOutlook = table.Column<string>(type: "text", nullable: true),
            //        WP1FieldWork = table.Column<string>(type: "text", nullable: true),
            //        WP2ID = table.Column<int>(type: "int", nullable: true),
            //        Workplan2Desc = table.Column<string>(type: "text", nullable: true),
            //        ResultsAvailable = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Facilities = table.Column<string>(type: "text", nullable: true),
            //        Impact = table.Column<string>(type: "text", nullable: true),
            //        Salaries = table.Column<string>(type: "text", nullable: true),
            //        Materials = table.Column<string>(type: "text", nullable: true),
            //        Equipment = table.Column<string>(type: "text", nullable: true),
            //        Travel = table.Column<string>(type: "text", nullable: true),
            //        Abroad = table.Column<string>(type: "text", nullable: true),
            //        Others = table.Column<string>(type: "text", nullable: true),
            //        WFSID = table.Column<int>(type: "int", nullable: true),
            //        WFUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        TerminationDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        FundTypeID = table.Column<int>(type: "int", nullable: true),
            //        WorkPlan2 = table.Column<string>(type: "text", nullable: true),
            //        Wages = table.Column<string>(type: "text", nullable: true),
            //        Benefits = table.Column<string>(type: "text", nullable: true),
            //        Assistant = table.Column<string>(type: "text", nullable: true),
            //        Subcontracts = table.Column<string>(type: "text", nullable: true),
            //        IndirectCosts = table.Column<string>(type: "text", nullable: true),
            //        ContractNumber = table.Column<string>(type: "text", nullable: true),
            //        ORCID = table.Column<string>(type: "text", nullable: true),
            //        ProcessProjectWayID = table.Column<int>(type: "int", nullable: true),
            //        POrganizationsId = table.Column<int>(type: "int", nullable: true),
            //        LocationID = table.Column<int>(type: "int", nullable: true),
            //        ProjectPI = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
            //        RosterID = table.Column<int>(type: "int", nullable: true),
            //        Objectives2 = table.Column<string>(type: "text", nullable: true),
            //        Objectives3 = table.Column<string>(type: "text", nullable: true),
            //        Objectives4 = table.Column<string>(type: "text", nullable: true),
            //        Objectives5 = table.Column<string>(type: "text", nullable: true),
            //        Objectives6 = table.Column<string>(type: "text", nullable: true),
            //        Substation = table.Column<string>(type: "text", nullable: true),
            //        ProjectStatusID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__projects__761ABED05384DF0D", x => x.ProjectID);
            //        table.ForeignKey(
            //            name: "FK__projects__CommID__797309D9",
            //            column: x => x.CommID,
            //            principalTable: "commodity",
            //            principalColumn: "CommID");
            //        table.ForeignKey(
            //            name: "FK__projects__Depart__75A278F5",
            //            column: x => x.DepartmentID,
            //            principalTable: "Departments",
            //            principalColumn: "DepartmentID");
            //        table.ForeignKey(
            //            name: "FK__projects__Fiscal__787EE5A0",
            //            column: x => x.FiscalYearID,
            //            principalTable: "fiscalYear",
            //            principalColumn: "FiscalYearID");
            //        table.ForeignKey(
            //            name: "FK__projects__FundTy__160F4887",
            //            column: x => x.FundTypeID,
            //            principalTable: "FundType",
            //            principalColumn: "FundTypeID");
            //        table.ForeignKey(
            //            name: "FK__projects__Locati__14270015",
            //            column: x => x.LocationID,
            //            principalTable: "Locationn",
            //            principalColumn: "LocationID");
            //        table.ForeignKey(
            //            name: "FK__projects__POrgan__151B244E",
            //            column: x => x.POrganizationsId,
            //            principalTable: "POrganization",
            //            principalColumn: "POrganizationID");
            //        table.ForeignKey(
            //            name: "FK__projects__Progra__76969D2E",
            //            column: x => x.ProgramAreaID,
            //            principalTable: "ProgramArea",
            //            principalColumn: "ProgramAreaID");
            //        table.ForeignKey(
            //            name: "FK__projects__Projec__595B4002",
            //            column: x => x.ProjectStatusID,
            //            principalTable: "ProjectStatus",
            //            principalColumn: "ProjectStatusID");
            //        table.ForeignKey(
            //            name: "FK__projects__Roster__3D2915A8",
            //            column: x => x.RosterID,
            //            principalTable: "roster",
            //            principalColumn: "RosterID");
            //        table.ForeignKey(
            //            name: "FK__projects__SubSta__3C34F16F",
            //            column: x => x.SubStationID,
            //            principalTable: "Substacion",
            //            principalColumn: "SubstationID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        UserID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        RosterID = table.Column<int>(type: "int", nullable: true),
            //        isEnabled = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        RolesID = table.Column<int>(type: "int", nullable: true),
            //        Roles = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Users__1788CCACB660C449", x => x.UserID);
            //        table.ForeignKey(
            //            name: "FK__Users__RolesID__0697FACD",
            //            column: x => x.RolesID,
            //            principalTable: "Roles",
            //            principalColumn: "RolesID");
            //        table.ForeignKey(
            //            name: "FK__Users__RosterID__6FE99F9F",
            //            column: x => x.RosterID,
            //            principalTable: "roster",
            //            principalColumn: "RosterID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "adminOfficerComments",
            //    columns: table => new
            //    {
            //        adminOfficerCommentsID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AdComments = table.Column<string>(type: "text", nullable: true),
            //        projectVigency = table.Column<DateTime>(type: "date", nullable: true),
            //        ReviewDate = table.Column<DateTime>(type: "date", nullable: true),
            //        WorkplanQuantity = table.Column<string>(type: "text", nullable: true),
            //        FundsComments = table.Column<string>(type: "text", nullable: true),
            //        ProjectID = table.Column<int>(type: "int", nullable: true),
            //        Username = table.Column<string>(type: "text", nullable: true),
            //        UserRole = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__adminOff__83E2C4E3A74A6E2A", x => x.adminOfficerCommentsID);
            //        table.ForeignKey(
            //            name: "FK__adminOffi__Proje__3429BB53",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Analytical",
            //    columns: table => new
            //    {
            //        AnalyticalID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        analysisRequired = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
            //        numSamples = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        ProbableDate = table.Column<DateTime>(type: "date", nullable: true),
            //        ProjectID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Analytic__B1E78B77D97F9138", x => x.AnalyticalID);
            //        table.ForeignKey(
            //            name: "FK__Analytica__Proje__2B0A656D",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FieldWork",
            //    columns: table => new
            //    {
            //        FieldWorkID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectID = table.Column<int>(type: "int", nullable: false),
            //        LocationID = table.Column<int>(type: "int", nullable: false),
            //        dateStarted = table.Column<DateTime>(type: "date", nullable: true),
            //        dateEnded = table.Column<DateTime>(type: "date", nullable: true),
            //        InProgress = table.Column<bool>(type: "bit", nullable: false),
            //        ToBeInitiated = table.Column<bool>(type: "bit", nullable: false),
            //        WFieldwork = table.Column<string>(type: "text", nullable: true),
            //        Area = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
            //        fieldoptionId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__FieldWor__460E4F22C33E2AF1", x => x.FieldWorkID);
            //        table.ForeignKey(
            //            name: "FK__FieldWork__Locat__68487DD7",
            //            column: x => x.LocationID,
            //            principalTable: "Locationn",
            //            principalColumn: "LocationID");
            //        table.ForeignKey(
            //            name: "FK__FieldWork__Proje__6754599E",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //        table.ForeignKey(
            //            name: "FK__FieldWork__field__54CB950F",
            //            column: x => x.fieldoptionId,
            //            principalTable: "fieldOption",
            //            principalColumn: "fieldoptionId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "funds",
            //    columns: table => new
            //    {
            //        FundID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LocationID = table.Column<int>(type: "int", nullable: false),
            //        Salaries = table.Column<decimal>(type: "money", nullable: true),
            //        Wages = table.Column<decimal>(type: "money", nullable: true),
            //        Benefits = table.Column<decimal>(type: "money", nullable: true),
            //        Assistant = table.Column<decimal>(type: "money", nullable: true),
            //        Materials = table.Column<decimal>(type: "money", nullable: true),
            //        Equipment = table.Column<decimal>(type: "money", nullable: true),
            //        Travel = table.Column<decimal>(type: "money", nullable: true),
            //        Abroad = table.Column<decimal>(type: "money", nullable: true),
            //        Subcontracts = table.Column<decimal>(type: "money", nullable: true),
            //        Others = table.Column<decimal>(type: "money", nullable: true),
            //        ProjectID = table.Column<int>(type: "int", nullable: false),
            //        UFISaccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        IndirectCosts = table.Column<decimal>(type: "money", nullable: true),
            //        TotalAmount = table.Column<decimal>(type: "money", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__funds__830DFC7A77D3E65F", x => x.FundID);
            //        table.ForeignKey(
            //            name: "FK__funds__LocationI__6383C8BA",
            //            column: x => x.LocationID,
            //            principalTable: "Locationn",
            //            principalColumn: "LocationID");
            //        table.ForeignKey(
            //            name: "FK__funds__ProjectID__6477ECF3",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "gradAss",
            //    columns: table => new
            //    {
            //        GAID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Gname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Thesis = table.Column<string>(type: "text", nullable: true),
            //        ProjectID = table.Column<int>(type: "int", nullable: true),
            //        StudentID = table.Column<int>(type: "int", nullable: true),
            //        Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
            //        RoleID = table.Column<int>(type: "int", nullable: true),
            //        StudentName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        IsGraduated = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        IsUndergraduated = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        thesisProjectId = table.Column<int>(type: "int", nullable: true),
            //        gradoptionId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__gradAss__53B87C56576534AD", x => x.GAID);
            //        table.ForeignKey(
            //            name: "FK__gradAss__Project__5441852A",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //        table.ForeignKey(
            //            name: "FK__gradAss__gradopt__589C25F3",
            //            column: x => x.gradoptionId,
            //            principalTable: "gradOption",
            //            principalColumn: "gradoptionId");
            //        table.ForeignKey(
            //            name: "FK__gradAss__thesisP__3FD07829",
            //            column: x => x.thesisProjectId,
            //            principalTable: "thesisProject",
            //            principalColumn: "thesisProjectId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "laboratory",
            //    columns: table => new
            //    {
            //        LabID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AReq = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        NoSamples = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
            //        SamplesDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ProjectID = table.Column<int>(type: "int", nullable: true),
            //        WorkPlanned = table.Column<string>(type: "text", nullable: true),
            //        Descriptions = table.Column<string>(type: "text", nullable: true),
            //        EstimatedTime = table.Column<string>(type: "text", nullable: true),
            //        FacilitiesNeeded = table.Column<string>(type: "text", nullable: true),
            //        timeEstimated = table.Column<DateTime>(type: "date", nullable: true),
            //        centralLaboratory = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__laborato__EDBD773A43FC9BAF", x => x.LabID);
            //        table.ForeignKey(
            //            name: "FK__laborator__Proje__49C3F6B7",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OtherPersonel",
            //    columns: table => new
            //    {
            //        OPID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        PerTime = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
            //        ProjectID = table.Column<int>(type: "int", nullable: true),
            //        LocationID = table.Column<int>(type: "int", nullable: true),
            //        RosterID = table.Column<int>(type: "int", nullable: true),
            //        PersonnelManAdded = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        RoleManAdded = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__OtherPer__AE2CBE1E1138560E", x => x.OPID);
            //        table.ForeignKey(
            //            name: "FK__OtherPers__Locat__6C190EBB",
            //            column: x => x.LocationID,
            //            principalTable: "Locationn",
            //            principalColumn: "LocationID");
            //        table.ForeignKey(
            //            name: "FK__OtherPers__Proje__6B24EA82",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //        table.ForeignKey(
            //            name: "FK__OtherPers__Roste__6D0D32F4",
            //            column: x => x.RosterID,
            //            principalTable: "roster",
            //            principalColumn: "RosterID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "processProjectWay",
            //    columns: table => new
            //    {
            //        ProcessProjectWayID = table.Column<int>(type: "int", nullable: false),
            //        ProjectId = table.Column<int>(type: "int", nullable: false),
            //        ProcessId = table.Column<int>(type: "int", nullable: false),
            //        EstatusId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.ForeignKey(
            //            name: "FK__processPr__Proje__4D94879B",
            //            column: x => x.ProjectId,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "sciProjects",
            //    columns: table => new
            //    {
            //        SciID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RosterID = table.Column<int>(type: "int", nullable: false),
            //        Roles = table.Column<int>(type: "int", nullable: false),
            //        Credits = table.Column<decimal>(type: "money", nullable: true),
            //        TR = table.Column<decimal>(type: "money", nullable: true),
            //        CA = table.Column<decimal>(type: "money", nullable: true),
            //        AH = table.Column<decimal>(type: "money", nullable: true),
            //        AdHonorem = table.Column<bool>(type: "bit", nullable: true),
            //        ProjectID = table.Column<int>(type: "int", nullable: true),
            //        thesisProjectId = table.Column<int>(type: "int", nullable: true),
            //        sciRolesID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__sciProje__CB9BA1E286343BBD", x => x.SciID);
            //        table.ForeignKey(
            //            name: "FK__sciProjec__Proje__1E6F845E",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //        table.ForeignKey(
            //            name: "FK__sciProjec__Roste__1F63A897",
            //            column: x => x.RosterID,
            //            principalTable: "roster",
            //            principalColumn: "RosterID");
            //        table.ForeignKey(
            //            name: "FK__sciProjec__sciRo__2116E6DF",
            //            column: x => x.sciRolesID,
            //            principalTable: "sciRoles",
            //            principalColumn: "sciRolesID");
            //        table.ForeignKey(
            //            name: "FK__sciProjec__thesi__2EA5EC27",
            //            column: x => x.thesisProjectId,
            //            principalTable: "thesisProject",
            //            principalColumn: "thesisProjectId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProjectNotes",
            //    columns: table => new
            //    {
            //        ProjectNotesId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Comment = table.Column<string>(type: "text", nullable: true),
            //        LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UserID = table.Column<int>(type: "int", nullable: true),
            //        ProjectID = table.Column<int>(type: "int", nullable: true),
            //        RosterID = table.Column<int>(type: "int", nullable: true),
            //        Username = table.Column<string>(type: "text", nullable: true),
            //        DepartmentDirectorComments = table.Column<string>(type: "text", nullable: true),
            //        DeanComments = table.Column<string>(type: "text", nullable: true),
            //        Roles = table.Column<string>(type: "text", nullable: true),
            //        userRole = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ProjectN__5DBF9709C49AD096", x => x.ProjectNotesId);
            //        table.ForeignKey(
            //            name: "FK__ProjectNo__Proje__214BF109",
            //            column: x => x.ProjectID,
            //            principalTable: "projects",
            //            principalColumn: "ProjectID");
            //        table.ForeignKey(
            //            name: "FK__ProjectNo__Roste__22401542",
            //            column: x => x.RosterID,
            //            principalTable: "roster",
            //            principalColumn: "RosterID");
            //        table.ForeignKey(
            //            name: "FK__ProjectNo__UserI__2057CCD0",
            //            column: x => x.UserID,
            //            principalTable: "Users",
            //            principalColumn: "UserID");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_adminOfficerComments_ProjectID",
            //    table: "adminOfficerComments",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Analytical_ProjectID",
            //    table: "Analytical",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FieldWork_fieldoptionId",
            //    table: "FieldWork",
            //    column: "fieldoptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FieldWork_LocationID",
            //    table: "FieldWork",
            //    column: "LocationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FieldWork_ProjectID",
            //    table: "FieldWork",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_fiscalYear_FiscalYearStatusID",
            //    table: "fiscalYear",
            //    column: "FiscalYearStatusID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_funds_LocationID",
            //    table: "funds",
            //    column: "LocationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_funds_ProjectID",
            //    table: "funds",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_gradAss_gradoptionId",
            //    table: "gradAss",
            //    column: "gradoptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_gradAss_ProjectID",
            //    table: "gradAss",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_gradAss_thesisProjectId",
            //    table: "gradAss",
            //    column: "thesisProjectId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_laboratory_ProjectID",
            //    table: "laboratory",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OtherPersonel_LocationID",
            //    table: "OtherPersonel",
            //    column: "LocationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OtherPersonel_ProjectID",
            //    table: "OtherPersonel",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OtherPersonel_RosterID",
            //    table: "OtherPersonel",
            //    column: "RosterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_processProjectWay_ProjectId",
            //    table: "processProjectWay",
            //    column: "ProjectId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProjectNotes_ProjectID",
            //    table: "ProjectNotes",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProjectNotes_RosterID",
            //    table: "ProjectNotes",
            //    column: "RosterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProjectNotes_UserID",
            //    table: "ProjectNotes",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_CommID",
            //    table: "projects",
            //    column: "CommID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_DepartmentID",
            //    table: "projects",
            //    column: "DepartmentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_FiscalYearID",
            //    table: "projects",
            //    column: "FiscalYearID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_FundTypeID",
            //    table: "projects",
            //    column: "FundTypeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_LocationID",
            //    table: "projects",
            //    column: "LocationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_POrganizationsId",
            //    table: "projects",
            //    column: "POrganizationsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_ProgramAreaID",
            //    table: "projects",
            //    column: "ProgramAreaID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_ProjectStatusID",
            //    table: "projects",
            //    column: "ProjectStatusID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_RosterID",
            //    table: "projects",
            //    column: "RosterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_projects_SubStationID",
            //    table: "projects",
            //    column: "SubStationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Roles_rosterID",
            //    table: "Roles",
            //    column: "rosterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_sciProjects_ProjectID",
            //    table: "sciProjects",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_sciProjects_RosterID",
            //    table: "sciProjects",
            //    column: "RosterID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_sciProjects_sciRolesID",
            //    table: "sciProjects",
            //    column: "sciRolesID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_sciProjects_thesisProjectId",
            //    table: "sciProjects",
            //    column: "thesisProjectId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_RolesID",
            //    table: "Users",
            //    column: "RolesID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_RosterID",
            //    table: "Users",
            //    column: "RosterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "adminOfficerComments");

            //migrationBuilder.DropTable(
            //    name: "Analytical");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "FieldWork");

            //migrationBuilder.DropTable(
            //    name: "funds");

            //migrationBuilder.DropTable(
            //    name: "gradAss");

            //migrationBuilder.DropTable(
            //    name: "laboratory");

            //migrationBuilder.DropTable(
            //    name: "OtherPersonel");

            //migrationBuilder.DropTable(
            //    name: "principalLocation");

            //migrationBuilder.DropTable(
            //    name: "processProjectWay");

            //migrationBuilder.DropTable(
            //    name: "projectAssents");

            //migrationBuilder.DropTable(
            //    name: "ProjectNotes");

            //migrationBuilder.DropTable(
            //    name: "sciProjects");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "fieldOption");

            //migrationBuilder.DropTable(
            //    name: "gradOption");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "projects");

            //migrationBuilder.DropTable(
            //    name: "sciRoles");

            //migrationBuilder.DropTable(
            //    name: "thesisProject");

            //migrationBuilder.DropTable(
            //    name: "Roles");

            //migrationBuilder.DropTable(
            //    name: "commodity");

            //migrationBuilder.DropTable(
            //    name: "Departments");

            //migrationBuilder.DropTable(
            //    name: "fiscalYear");

            //migrationBuilder.DropTable(
            //    name: "FundType");

            //migrationBuilder.DropTable(
            //    name: "Locationn");

            //migrationBuilder.DropTable(
            //    name: "POrganization");

            //migrationBuilder.DropTable(
            //    name: "ProgramArea");

            //migrationBuilder.DropTable(
            //    name: "ProjectStatus");

            //migrationBuilder.DropTable(
            //    name: "Substacion");

            //migrationBuilder.DropTable(
            //    name: "roster");

            //migrationBuilder.DropTable(
            //    name: "FiscalYearStatus");
        }
    }
}
