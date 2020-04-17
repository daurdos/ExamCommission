using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phd.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationCommission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationCommission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisCouncil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<string>(nullable: false),
                    CouncilChairman = table.Column<string>(nullable: false),
                    CouncilSecretary = table.Column<string>(nullable: false),
                    CouncilMember = table.Column<string>(nullable: false),
                    DefenceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisCouncil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MajorCypher = table.Column<string>(nullable: true),
                    MajorCypherName = table.Column<string>(nullable: true),
                    MajorCypherNameKaz = table.Column<string>(nullable: true),
                    MajorCypherNameEng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    FullNameKaz = table.Column<string>(nullable: true),
                    FullNameEng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentDocType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDocType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDirection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrainingDirectionCypher = table.Column<string>(nullable: true),
                    TrainingDirectionCypherName = table.Column<string>(nullable: true),
                    TrainingDirectionCypherNameKaz = table.Column<string>(nullable: true),
                    TrainingDirectionCypherNameEng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDirection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "DisCouncilChairman",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    FullNameKaz = table.Column<string>(nullable: true),
                    FullNameEng = table.Column<string>(nullable: true),
                    DisCouncilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisCouncilChairman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisCouncilChairman_DisCouncil_DisCouncilId",
                        column: x => x.DisCouncilId,
                        principalTable: "DisCouncil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicDepartment_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(nullable: true),
                    MName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false),
                    CertificationCommissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_CertificationCommission_CertificationCommissionId",
                        column: x => x.CertificationCommissionId,
                        principalTable: "CertificationCommission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhdStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    MajorCode = table.Column<string>(nullable: true),
                    MajorName = table.Column<string>(nullable: true),
                    LastNameKaz = table.Column<string>(nullable: true),
                    FirstNameKaz = table.Column<string>(nullable: true),
                    MiddleNameKaz = table.Column<string>(nullable: true),
                    LastNameEng = table.Column<string>(nullable: true),
                    FirstNameEng = table.Column<string>(nullable: true),
                    MiddleNameEng = table.Column<string>(nullable: true),
                    RectorId = table.Column<int>(nullable: false),
                    ThesisNameRus = table.Column<string>(nullable: false),
                    ThesisNameKaz = table.Column<string>(nullable: true),
                    ThesisNameEng = table.Column<string>(nullable: true),
                    ThesisComDate = table.Column<DateTime>(nullable: false),
                    ComMemberNumberTotal = table.Column<int>(nullable: false),
                    ComMemberNumberSpecific = table.Column<int>(nullable: false),
                    EducationDirection = table.Column<string>(nullable: true),
                    MajorId = table.Column<int>(nullable: false),
                    TrainingDirectionId = table.Column<int>(nullable: false),
                    DisCouncilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhdStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhdStudent_DisCouncil_DisCouncilId",
                        column: x => x.DisCouncilId,
                        principalTable: "DisCouncil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhdStudent_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhdStudent_Rector_RectorId",
                        column: x => x.RectorId,
                        principalTable: "Rector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhdStudent_TrainingDirection_TrainingDirectionId",
                        column: x => x.TrainingDirectionId,
                        principalTable: "TrainingDirection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhdStudentManual",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastNameKaz = table.Column<string>(nullable: true),
                    FirstNameKaz = table.Column<string>(nullable: true),
                    MiddleNameKaz = table.Column<string>(nullable: true),
                    LastNameEng = table.Column<string>(nullable: true),
                    FirstNameEng = table.Column<string>(nullable: true),
                    MiddleNameEng = table.Column<string>(nullable: true),
                    RectorId = table.Column<int>(nullable: false),
                    ThesisNameRus = table.Column<string>(nullable: false),
                    ThesisNameKaz = table.Column<string>(nullable: true),
                    ThesisNameEng = table.Column<string>(nullable: true),
                    ThesisComDate = table.Column<DateTime>(nullable: false),
                    ComMemberNumberTotal = table.Column<int>(nullable: false),
                    ComMemberNumberSpecific = table.Column<int>(nullable: false),
                    MajorId = table.Column<int>(nullable: false),
                    TrainingDirectionId = table.Column<int>(nullable: false),
                    DisCouncilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhdStudentManual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhdStudentManual_DisCouncil_DisCouncilId",
                        column: x => x.DisCouncilId,
                        principalTable: "DisCouncil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhdStudentManual_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhdStudentManual_Rector_RectorId",
                        column: x => x.RectorId,
                        principalTable: "Rector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhdStudentManual_TrainingDirection_TrainingDirectionId",
                        column: x => x.TrainingDirectionId,
                        principalTable: "TrainingDirection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    DisCouncilId = table.Column<int>(nullable: false),
                    CertificationCommissionId = table.Column<int>(nullable: false),
                    AcademicDepartmentId = table.Column<int>(nullable: false),
                    BMajorId = table.Column<int>(nullable: false),
                    BRExamCommissionId = table.Column<int>(nullable: false),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AcademicDepartment_AcademicDepartmentId",
                        column: x => x.AcademicDepartmentId,
                        principalTable: "AcademicDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CertificationCommission_CertificationCommissionId",
                        column: x => x.CertificationCommissionId,
                        principalTable: "CertificationCommission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_DisCouncil_DisCouncilId",
                        column: x => x.DisCouncilId,
                        principalTable: "DisCouncil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BDirection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cypher = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    NameKaz = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    AcademicDepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BDirection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BDirection_AcademicDepartment_AcademicDepartmentId",
                        column: x => x.AcademicDepartmentId,
                        principalTable: "AcademicDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BMajor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cypher = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    NameKaz = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    AcademicDepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMajor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BMajor_AcademicDepartment_AcademicDepartmentId",
                        column: x => x.AcademicDepartmentId,
                        principalTable: "AcademicDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiplomaFormOne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Damaged = table.Column<bool>(nullable: false),
                    Lost = table.Column<bool>(nullable: false),
                    PhdStudentId = table.Column<int>(nullable: true),
                    PhdStudentManualId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomaFormOne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomaFormOne_PhdStudent_PhdStudentId",
                        column: x => x.PhdStudentId,
                        principalTable: "PhdStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiplomaFormOne_PhdStudentManual_PhdStudentManualId",
                        column: x => x.PhdStudentManualId,
                        principalTable: "PhdStudentManual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Voice = table.Column<string>(nullable: true),
                    PhdStudentId = table.Column<int>(nullable: false),
                    PhdStudentManualId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_PhdStudent_PhdStudentId",
                        column: x => x.PhdStudentId,
                        principalTable: "PhdStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_PhdStudentManual_PhdStudentManualId",
                        column: x => x.PhdStudentManualId,
                        principalTable: "PhdStudentManual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grade_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BRExamCommission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BMajorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRExamCommission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRExamCommission_BMajor_BMajorId",
                        column: x => x.BMajorId,
                        principalTable: "BMajor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BRStudentGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BRExamCommissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRStudentGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRStudentGroup_BRExamCommission_BRExamCommissionId",
                        column: x => x.BRExamCommissionId,
                        principalTable: "BRExamCommission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BRStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BRStudentGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRStudent_BRStudentGroup_BRStudentGroupId",
                        column: x => x.BRStudentGroupId,
                        principalTable: "BRStudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BRStudentDoc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BRStudentId = table.Column<int>(nullable: false),
                    StudentDocTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRStudentDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRStudentDoc_BRStudent_BRStudentId",
                        column: x => x.BRStudentId,
                        principalTable: "BRStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BRStudentDoc_StudentDocType_StudentDocTypeId",
                        column: x => x.StudentDocTypeId,
                        principalTable: "StudentDocType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BRStudentGrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    BRStudentId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRStudentGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRStudentGrade_BRStudent_BRStudentId",
                        column: x => x.BRStudentId,
                        principalTable: "BRStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BRStudentGrade_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicDepartment_FacultyId",
                table: "AcademicDepartment",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AcademicDepartmentId",
                table: "AspNetUsers",
                column: "AcademicDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CertificationCommissionId",
                table: "AspNetUsers",
                column: "CertificationCommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DisCouncilId",
                table: "AspNetUsers",
                column: "DisCouncilId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BDirection_AcademicDepartmentId",
                table: "BDirection",
                column: "AcademicDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BMajor_AcademicDepartmentId",
                table: "BMajor",
                column: "AcademicDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BRExamCommission_BMajorId",
                table: "BRExamCommission",
                column: "BMajorId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudent_BRStudentGroupId",
                table: "BRStudent",
                column: "BRStudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentDoc_BRStudentId",
                table: "BRStudentDoc",
                column: "BRStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentDoc_StudentDocTypeId",
                table: "BRStudentDoc",
                column: "StudentDocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentGrade_BRStudentId",
                table: "BRStudentGrade",
                column: "BRStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentGrade_UserId",
                table: "BRStudentGrade",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentGroup_BRExamCommissionId",
                table: "BRStudentGroup",
                column: "BRExamCommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomaFormOne_PhdStudentId",
                table: "DiplomaFormOne",
                column: "PhdStudentId",
                unique: true,
                filter: "[PhdStudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomaFormOne_PhdStudentManualId",
                table: "DiplomaFormOne",
                column: "PhdStudentManualId",
                unique: true,
                filter: "[PhdStudentManualId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DisCouncilChairman_DisCouncilId",
                table: "DisCouncilChairman",
                column: "DisCouncilId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentId",
                table: "Grade",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_UserId",
                table: "Grade",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdStudent_DisCouncilId",
                table: "PhdStudent",
                column: "DisCouncilId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdStudent_MajorId",
                table: "PhdStudent",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdStudent_RectorId",
                table: "PhdStudent",
                column: "RectorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdStudent_TrainingDirectionId",
                table: "PhdStudent",
                column: "TrainingDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdStudentManual_DisCouncilId",
                table: "PhdStudentManual",
                column: "DisCouncilId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdStudentManual_MajorId",
                table: "PhdStudentManual",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdStudentManual_RectorId",
                table: "PhdStudentManual",
                column: "RectorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdStudentManual_TrainingDirectionId",
                table: "PhdStudentManual",
                column: "TrainingDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CertificationCommissionId",
                table: "Student",
                column: "CertificationCommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FacultyId",
                table: "Student",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_PhdStudentId",
                table: "Vote",
                column: "PhdStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_PhdStudentManualId",
                table: "Vote",
                column: "PhdStudentManualId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "BDirection");

            migrationBuilder.DropTable(
                name: "BRStudentDoc");

            migrationBuilder.DropTable(
                name: "BRStudentGrade");

            migrationBuilder.DropTable(
                name: "DiplomaFormOne");

            migrationBuilder.DropTable(
                name: "DisCouncilChairman");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "StudentDocType");

            migrationBuilder.DropTable(
                name: "BRStudent");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PhdStudent");

            migrationBuilder.DropTable(
                name: "PhdStudentManual");

            migrationBuilder.DropTable(
                name: "BRStudentGroup");

            migrationBuilder.DropTable(
                name: "CertificationCommission");

            migrationBuilder.DropTable(
                name: "DisCouncil");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "Rector");

            migrationBuilder.DropTable(
                name: "TrainingDirection");

            migrationBuilder.DropTable(
                name: "BRExamCommission");

            migrationBuilder.DropTable(
                name: "BMajor");

            migrationBuilder.DropTable(
                name: "AcademicDepartment");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
