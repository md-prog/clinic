using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArsMachinaLIMSDAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    BatchNumber = table.Column<string>(nullable: true),
                    BatchStatus = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "DashboardComponent",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    ComponentAngular2CSS = table.Column<string>(nullable: true),
                    ComponentAngular2HTMLTemplate = table.Column<string>(nullable: true),
                    ComponentAngular2Path = table.Column<string>(nullable: true),
                    DashboardComponentName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardComponent", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    BarcodeFormDefinition = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LabelName = table.Column<string>(nullable: true),
                    LabelType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Layout",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Panel",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    PanelCode = table.Column<string>(maxLength: 6, nullable: true),
                    PanelDescription = table.Column<string>(nullable: true),
                    PanelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panel", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Worklist",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    WorklistType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worklist", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "WorklistColumn",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    WorklistColumnDataType = table.Column<int>(nullable: false),
                    WorklistColumnLinkType = table.Column<int>(nullable: false),
                    WorklistColumnName = table.Column<string>(nullable: true),
                    WorklistGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorklistColumn", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_WorklistColumn_Worklist_WorklistGUID",
                        column: x => x.WorklistGUID,
                        principalTable: "Worklist",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccessionGUID = table.Column<Guid>(nullable: true),
                    AuditLevel = table.Column<int>(nullable: false),
                    BatchGUID = table.Column<Guid>(nullable: true),
                    BatchTypeGUID = table.Column<Guid>(nullable: true),
                    CaseGUID = table.Column<Guid>(nullable: true),
                    CaseTypeGUID = table.Column<Guid>(nullable: true),
                    ClientGUID = table.Column<Guid>(nullable: true),
                    CommentGUID = table.Column<Guid>(nullable: true),
                    DashboardComponentGUID = table.Column<Guid>(nullable: true),
                    DashboardGUID = table.Column<Guid>(nullable: true),
                    DashboardSectionGUID = table.Column<Guid>(nullable: true),
                    DepartmentGUID = table.Column<Guid>(nullable: true),
                    Diff = table.Column<string>(nullable: true),
                    DoctorGUID = table.Column<Guid>(nullable: true),
                    DotNetTimeZone = table.Column<string>(nullable: true),
                    FacilityGUID = table.Column<Guid>(nullable: true),
                    LabGUID = table.Column<Guid>(nullable: true),
                    LabelGUID = table.Column<Guid>(nullable: true),
                    LayoutGUID = table.Column<Guid>(nullable: true),
                    PanelGUID = table.Column<Guid>(nullable: true),
                    PanelResultGUID = table.Column<Guid>(nullable: true),
                    PatientGUID = table.Column<Guid>(nullable: true),
                    ReportDocumentGUID = table.Column<Guid>(nullable: true),
                    ReportGUID = table.Column<Guid>(nullable: true),
                    ReportTemplateGUID = table.Column<Guid>(nullable: true),
                    SpecimenGUID = table.Column<Guid>(nullable: true),
                    SpecimenTransportGUID = table.Column<Guid>(nullable: true),
                    SpecimenTypeGUID = table.Column<Guid>(nullable: true),
                    StepGUID = table.Column<Guid>(nullable: true),
                    TestGUID = table.Column<Guid>(nullable: true),
                    TestResultGUID = table.Column<Guid>(nullable: true),
                    TestTypeGUID = table.Column<Guid>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false),
                    UtcDate = table.Column<DateTime>(nullable: false),
                    WorkflowGUID = table.Column<Guid>(nullable: true),
                    WorkflowStepGUID = table.Column<Guid>(nullable: true),
                    WorklistColumnGUID = table.Column<Guid>(nullable: true),
                    WorklistConfigurationGUID = table.Column<Guid>(nullable: true),
                    WorklistGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Audit_Batch_BatchGUID",
                        column: x => x.BatchGUID,
                        principalTable: "Batch",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_DashboardComponent_DashboardComponentGUID",
                        column: x => x.DashboardComponentGUID,
                        principalTable: "DashboardComponent",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Label_LabelGUID",
                        column: x => x.LabelGUID,
                        principalTable: "Label",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Layout_LayoutGUID",
                        column: x => x.LayoutGUID,
                        principalTable: "Layout",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Panel_PanelGUID",
                        column: x => x.PanelGUID,
                        principalTable: "Panel",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_WorklistColumn_WorklistColumnGUID",
                        column: x => x.WorklistColumnGUID,
                        principalTable: "WorklistColumn",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Worklist_WorklistGUID",
                        column: x => x.WorklistGUID,
                        principalTable: "Worklist",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    ClientCode = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    ID = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    UserGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    AccessionGUID = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    CaseGUID = table.Column<Guid>(nullable: true),
                    ClientGUID = table.Column<Guid>(nullable: true),
                    CommentText = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    SecondaryIdentifier = table.Column<string>(nullable: true),
                    SpecimenGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Comment_Client_ClientGUID",
                        column: x => x.ClientGUID,
                        principalTable: "Client",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    ClientGUID = table.Column<Guid>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Doctor_Client_ClientGUID",
                        column: x => x.ClientGUID,
                        principalTable: "Client",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accession",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    Doctor2GUID = table.Column<Guid>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    MRN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accession", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Accession_Doctor_Doctor2GUID",
                        column: x => x.Doctor2GUID,
                        principalTable: "Doctor",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    ClientGUID = table.Column<Guid>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    StateProvince = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Facility_Client_ClientGUID",
                        column: x => x.ClientGUID,
                        principalTable: "Client",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facility_Accession_GUID",
                        column: x => x.GUID,
                        principalTable: "Accession",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    SSN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Patient_Accession_GUID",
                        column: x => x.GUID,
                        principalTable: "Accession",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LabCode = table.Column<string>(nullable: true),
                    LabName = table.Column<string>(nullable: true),
                    UserGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Lab_Accession_GUID",
                        column: x => x.GUID,
                        principalTable: "Accession",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AnalysisLabGUID = table.Column<Guid>(nullable: true),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    CaseNumber = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ProcessingLabGUID = table.Column<Guid>(nullable: true),
                    ProfessionalLabGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Case_Lab_AnalysisLabGUID",
                        column: x => x.AnalysisLabGUID,
                        principalTable: "Lab",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Lab_ProcessingLabGUID",
                        column: x => x.ProcessingLabGUID,
                        principalTable: "Lab",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Lab_ProfessionalLabGUID",
                        column: x => x.ProfessionalLabGUID,
                        principalTable: "Lab",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AllClients = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    Credentials = table.Column<string>(nullable: true),
                    DotNetTimeZone = table.Column<string>(nullable: true),
                    IdentityReferenceID = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    PrimaryGroupReferenceID = table.Column<string>(nullable: true),
                    PrimaryLabGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_User_Lab_PrimaryLabGUID",
                        column: x => x.PrimaryLabGUID,
                        principalTable: "Lab",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PanelResult",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    CaseGUID = table.Column<Guid>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    PanelGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanelResult", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_PanelResult_Case_CaseGUID",
                        column: x => x.CaseGUID,
                        principalTable: "Case",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PanelResult_Panel_PanelGUID",
                        column: x => x.PanelGUID,
                        principalTable: "Panel",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    CaseGUID = table.Column<Guid>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ReportVersion = table.Column<int>(nullable: false),
                    ReportVersionNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Report_Case_CaseGUID",
                        column: x => x.CaseGUID,
                        principalTable: "Case",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    UserGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Department_User_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "User",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorklistConfiguration",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    Default = table.Column<bool>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    Public = table.Column<bool>(nullable: false),
                    WorklistConfigurationName = table.Column<string>(nullable: true),
                    WorklistGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorklistConfiguration", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_WorklistConfiguration_User_GUID",
                        column: x => x.GUID,
                        principalTable: "User",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorklistConfiguration_Worklist_WorklistGUID",
                        column: x => x.WorklistGUID,
                        principalTable: "Worklist",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportDocument",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ReportDocumentBinary = table.Column<byte[]>(nullable: true),
                    ReportDocumentType = table.Column<int>(nullable: false),
                    ReportGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDocument", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_ReportDocument_Report_ReportGUID",
                        column: x => x.ReportGUID,
                        principalTable: "Report",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportTemplate",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    PublicReport = table.Column<bool>(nullable: false),
                    ReportTemplateDefinition = table.Column<string>(nullable: true),
                    ReportTemplateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTemplate", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_ReportTemplate_Report_GUID",
                        column: x => x.GUID,
                        principalTable: "Report",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseType",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    CaseNumberPrefix = table.Column<string>(maxLength: 4, nullable: true),
                    CaseTypeName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ReportTemplateGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseType", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_CaseType_Case_GUID",
                        column: x => x.GUID,
                        principalTable: "Case",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseType_ReportTemplate_ReportTemplateGUID",
                        column: x => x.ReportTemplateGUID,
                        principalTable: "ReportTemplate",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatchType",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AllowAddOnStartingStepOnly = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    BatchItemType = table.Column<int>(nullable: false),
                    BatchPrefix = table.Column<string>(maxLength: 4, nullable: true),
                    BatchRestrictionType = table.Column<int>(nullable: false),
                    BatchTypeName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    StartingStepGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchType", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_BatchType_Batch_GUID",
                        column: x => x.GUID,
                        principalTable: "Batch",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecimenTransport",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    BatchTypeGUID = table.Column<Guid>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    SpecimenTransportCode = table.Column<string>(maxLength: 3, nullable: true),
                    SpecimenTransportName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecimenTransport", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_SpecimenTransport_BatchType_BatchTypeGUID",
                        column: x => x.BatchTypeGUID,
                        principalTable: "BatchType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecimenType",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    BatchTypeGUID = table.Column<Guid>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    SpecimenTypeCode = table.Column<string>(maxLength: 3, nullable: true),
                    SpecimenTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecimenType", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_SpecimenType_BatchType_BatchTypeGUID",
                        column: x => x.BatchTypeGUID,
                        principalTable: "BatchType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LayoutGUID = table.Column<Guid>(nullable: true),
                    WorkflowStepName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Step_BatchType_GUID",
                        column: x => x.GUID,
                        principalTable: "BatchType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Step_Layout_LayoutGUID",
                        column: x => x.LayoutGUID,
                        principalTable: "Layout",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestType",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    BatchTypeGUID = table.Column<Guid>(nullable: true),
                    CaseTypeGUID = table.Column<Guid>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    TestTypeCode = table.Column<string>(nullable: true),
                    TestTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestType", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_TestType_BatchType_BatchTypeGUID",
                        column: x => x.BatchTypeGUID,
                        principalTable: "BatchType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestType_CaseType_CaseTypeGUID",
                        column: x => x.CaseTypeGUID,
                        principalTable: "CaseType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    WorkflowName = table.Column<string>(nullable: true),
                    WorkflowType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Workflow_BatchType_GUID",
                        column: x => x.GUID,
                        principalTable: "BatchType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specimen",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    BatchGUID = table.Column<Guid>(nullable: true),
                    CaseGUID = table.Column<Guid>(nullable: true),
                    ExternalSpecimenID = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    SpecimenCode = table.Column<string>(maxLength: 7, nullable: true),
                    SpecimenGUID = table.Column<Guid>(nullable: true),
                    SpecimenTransportGUID = table.Column<Guid>(nullable: true),
                    SpecimenTypeGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specimen", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Specimen_Batch_BatchGUID",
                        column: x => x.BatchGUID,
                        principalTable: "Batch",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specimen_Case_CaseGUID",
                        column: x => x.CaseGUID,
                        principalTable: "Case",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specimen_Specimen_SpecimenGUID",
                        column: x => x.SpecimenGUID,
                        principalTable: "Specimen",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specimen_SpecimenTransport_SpecimenTransportGUID",
                        column: x => x.SpecimenTransportGUID,
                        principalTable: "SpecimenTransport",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specimen_SpecimenType_SpecimenTypeGUID",
                        column: x => x.SpecimenTypeGUID,
                        principalTable: "SpecimenType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    TestCode = table.Column<string>(maxLength: 6, nullable: true),
                    TestName = table.Column<string>(nullable: true),
                    TestTypeGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Test_TestType_TestTypeGUID",
                        column: x => x.TestTypeGUID,
                        principalTable: "TestType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStep",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    StepGUID = table.Column<Guid>(nullable: true),
                    StepOrder = table.Column<int>(nullable: false),
                    WorkflowGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStep", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Step_StepGUID",
                        column: x => x.StepGUID,
                        principalTable: "Step",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Workflow_WorkflowGUID",
                        column: x => x.WorkflowGUID,
                        principalTable: "Workflow",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    BatchGUID = table.Column<Guid>(nullable: true),
                    CaseGUID = table.Column<Guid>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    PanelGUID = table.Column<Guid>(nullable: true),
                    TestGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_TestResult_Batch_BatchGUID",
                        column: x => x.BatchGUID,
                        principalTable: "Batch",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResult_Case_CaseGUID",
                        column: x => x.CaseGUID,
                        principalTable: "Case",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResult_Panel_PanelGUID",
                        column: x => x.PanelGUID,
                        principalTable: "Panel",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResult_Test_TestGUID",
                        column: x => x.TestGUID,
                        principalTable: "Test",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DashboardSection",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    DashboardSectionName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardSection", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AuditLevel = table.Column<int>(nullable: false),
                    AuditLogReturnLevel = table.Column<int>(nullable: false),
                    DashboardName = table.Column<string>(nullable: true),
                    DashboardType = table.Column<int>(nullable: false),
                    DefaultDashboard = table.Column<bool>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LeftSectionGUID = table.Column<Guid>(nullable: true),
                    RightSectionGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboard", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Dashboard_DashboardSection_LeftSectionGUID",
                        column: x => x.LeftSectionGUID,
                        principalTable: "DashboardSection",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dashboard_DashboardSection_RightSectionGUID",
                        column: x => x.RightSectionGUID,
                        principalTable: "DashboardSection",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accession_Doctor2GUID",
                table: "Accession",
                column: "Doctor2GUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_AccessionGUID",
                table: "Audit",
                column: "AccessionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_BatchGUID",
                table: "Audit",
                column: "BatchGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_BatchTypeGUID",
                table: "Audit",
                column: "BatchTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_CaseGUID",
                table: "Audit",
                column: "CaseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_CaseTypeGUID",
                table: "Audit",
                column: "CaseTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_ClientGUID",
                table: "Audit",
                column: "ClientGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_CommentGUID",
                table: "Audit",
                column: "CommentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_DashboardComponentGUID",
                table: "Audit",
                column: "DashboardComponentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_DashboardGUID",
                table: "Audit",
                column: "DashboardGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_DashboardSectionGUID",
                table: "Audit",
                column: "DashboardSectionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_DepartmentGUID",
                table: "Audit",
                column: "DepartmentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_DoctorGUID",
                table: "Audit",
                column: "DoctorGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_FacilityGUID",
                table: "Audit",
                column: "FacilityGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_LabGUID",
                table: "Audit",
                column: "LabGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_LabelGUID",
                table: "Audit",
                column: "LabelGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_LayoutGUID",
                table: "Audit",
                column: "LayoutGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_PanelGUID",
                table: "Audit",
                column: "PanelGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_PanelResultGUID",
                table: "Audit",
                column: "PanelResultGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_PatientGUID",
                table: "Audit",
                column: "PatientGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_ReportDocumentGUID",
                table: "Audit",
                column: "ReportDocumentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_ReportGUID",
                table: "Audit",
                column: "ReportGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_ReportTemplateGUID",
                table: "Audit",
                column: "ReportTemplateGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_SpecimenGUID",
                table: "Audit",
                column: "SpecimenGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_SpecimenTransportGUID",
                table: "Audit",
                column: "SpecimenTransportGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_SpecimenTypeGUID",
                table: "Audit",
                column: "SpecimenTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_StepGUID",
                table: "Audit",
                column: "StepGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_TestGUID",
                table: "Audit",
                column: "TestGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_TestResultGUID",
                table: "Audit",
                column: "TestResultGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_TestTypeGUID",
                table: "Audit",
                column: "TestTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_UserID",
                table: "Audit",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_WorkflowGUID",
                table: "Audit",
                column: "WorkflowGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_WorkflowStepGUID",
                table: "Audit",
                column: "WorkflowStepGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_WorklistColumnGUID",
                table: "Audit",
                column: "WorklistColumnGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_WorklistConfigurationGUID",
                table: "Audit",
                column: "WorklistConfigurationGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_WorklistGUID",
                table: "Audit",
                column: "WorklistGUID");

            migrationBuilder.CreateIndex(
                name: "IX_BatchType_StartingStepGUID",
                table: "BatchType",
                column: "StartingStepGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_AnalysisLabGUID",
                table: "Case",
                column: "AnalysisLabGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_ProcessingLabGUID",
                table: "Case",
                column: "ProcessingLabGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_ProfessionalLabGUID",
                table: "Case",
                column: "ProfessionalLabGUID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseType_ReportTemplateGUID",
                table: "CaseType",
                column: "ReportTemplateGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserGUID",
                table: "Client",
                column: "UserGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AccessionGUID",
                table: "Comment",
                column: "AccessionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CaseGUID",
                table: "Comment",
                column: "CaseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ClientGUID",
                table: "Comment",
                column: "ClientGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SpecimenGUID",
                table: "Comment",
                column: "SpecimenGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_LeftSectionGUID",
                table: "Dashboard",
                column: "LeftSectionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_RightSectionGUID",
                table: "Dashboard",
                column: "RightSectionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_UserGUID",
                table: "Department",
                column: "UserGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClientGUID",
                table: "Doctor",
                column: "ClientGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_ClientGUID",
                table: "Facility",
                column: "ClientGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Lab_UserGUID",
                table: "Lab",
                column: "UserGUID");

            migrationBuilder.CreateIndex(
                name: "IX_PanelResult_CaseGUID",
                table: "PanelResult",
                column: "CaseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_PanelResult_PanelGUID",
                table: "PanelResult",
                column: "PanelGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CaseGUID",
                table: "Report",
                column: "CaseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDocument_ReportGUID",
                table: "ReportDocument",
                column: "ReportGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_BatchGUID",
                table: "Specimen",
                column: "BatchGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_CaseGUID",
                table: "Specimen",
                column: "CaseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_SpecimenGUID",
                table: "Specimen",
                column: "SpecimenGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_SpecimenTransportGUID",
                table: "Specimen",
                column: "SpecimenTransportGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_SpecimenTypeGUID",
                table: "Specimen",
                column: "SpecimenTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecimenTransport_BatchTypeGUID",
                table: "SpecimenTransport",
                column: "BatchTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecimenType_BatchTypeGUID",
                table: "SpecimenType",
                column: "BatchTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Step_LayoutGUID",
                table: "Step",
                column: "LayoutGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Test_TestTypeGUID",
                table: "Test",
                column: "TestTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_BatchGUID",
                table: "TestResult",
                column: "BatchGUID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_CaseGUID",
                table: "TestResult",
                column: "CaseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_PanelGUID",
                table: "TestResult",
                column: "PanelGUID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_TestGUID",
                table: "TestResult",
                column: "TestGUID");

            migrationBuilder.CreateIndex(
                name: "IX_TestType_BatchTypeGUID",
                table: "TestType",
                column: "BatchTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_TestType_CaseTypeGUID",
                table: "TestType",
                column: "CaseTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_User_PrimaryLabGUID",
                table: "User",
                column: "PrimaryLabGUID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStep_StepGUID",
                table: "WorkflowStep",
                column: "StepGUID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStep_WorkflowGUID",
                table: "WorkflowStep",
                column: "WorkflowGUID");

            migrationBuilder.CreateIndex(
                name: "IX_WorklistColumn_WorklistGUID",
                table: "WorklistColumn",
                column: "WorklistGUID");

            migrationBuilder.CreateIndex(
                name: "IX_WorklistConfiguration_WorklistGUID",
                table: "WorklistConfiguration",
                column: "WorklistGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Doctor_DoctorGUID",
                table: "Audit",
                column: "DoctorGUID",
                principalTable: "Doctor",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Accession_AccessionGUID",
                table: "Audit",
                column: "AccessionGUID",
                principalTable: "Accession",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_BatchType_BatchTypeGUID",
                table: "Audit",
                column: "BatchTypeGUID",
                principalTable: "BatchType",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Case_CaseGUID",
                table: "Audit",
                column: "CaseGUID",
                principalTable: "Case",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_CaseType_CaseTypeGUID",
                table: "Audit",
                column: "CaseTypeGUID",
                principalTable: "CaseType",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Client_ClientGUID",
                table: "Audit",
                column: "ClientGUID",
                principalTable: "Client",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Comment_CommentGUID",
                table: "Audit",
                column: "CommentGUID",
                principalTable: "Comment",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Dashboard_DashboardGUID",
                table: "Audit",
                column: "DashboardGUID",
                principalTable: "Dashboard",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_DashboardSection_DashboardSectionGUID",
                table: "Audit",
                column: "DashboardSectionGUID",
                principalTable: "DashboardSection",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Department_DepartmentGUID",
                table: "Audit",
                column: "DepartmentGUID",
                principalTable: "Department",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Facility_FacilityGUID",
                table: "Audit",
                column: "FacilityGUID",
                principalTable: "Facility",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Lab_LabGUID",
                table: "Audit",
                column: "LabGUID",
                principalTable: "Lab",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_PanelResult_PanelResultGUID",
                table: "Audit",
                column: "PanelResultGUID",
                principalTable: "PanelResult",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Patient_PatientGUID",
                table: "Audit",
                column: "PatientGUID",
                principalTable: "Patient",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_ReportDocument_ReportDocumentGUID",
                table: "Audit",
                column: "ReportDocumentGUID",
                principalTable: "ReportDocument",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Report_ReportGUID",
                table: "Audit",
                column: "ReportGUID",
                principalTable: "Report",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_ReportTemplate_ReportTemplateGUID",
                table: "Audit",
                column: "ReportTemplateGUID",
                principalTable: "ReportTemplate",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Specimen_SpecimenGUID",
                table: "Audit",
                column: "SpecimenGUID",
                principalTable: "Specimen",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_SpecimenTransport_SpecimenTransportGUID",
                table: "Audit",
                column: "SpecimenTransportGUID",
                principalTable: "SpecimenTransport",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_SpecimenType_SpecimenTypeGUID",
                table: "Audit",
                column: "SpecimenTypeGUID",
                principalTable: "SpecimenType",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Step_StepGUID",
                table: "Audit",
                column: "StepGUID",
                principalTable: "Step",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Test_TestGUID",
                table: "Audit",
                column: "TestGUID",
                principalTable: "Test",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_TestResult_TestResultGUID",
                table: "Audit",
                column: "TestResultGUID",
                principalTable: "TestResult",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_TestType_TestTypeGUID",
                table: "Audit",
                column: "TestTypeGUID",
                principalTable: "TestType",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_User_UserID",
                table: "Audit",
                column: "UserID",
                principalTable: "User",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Workflow_WorkflowGUID",
                table: "Audit",
                column: "WorkflowGUID",
                principalTable: "Workflow",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_WorkflowStep_WorkflowStepGUID",
                table: "Audit",
                column: "WorkflowStepGUID",
                principalTable: "WorkflowStep",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_WorklistConfiguration_WorklistConfigurationGUID",
                table: "Audit",
                column: "WorklistConfigurationGUID",
                principalTable: "WorklistConfiguration",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Accession_GUID",
                table: "Client",
                column: "GUID",
                principalTable: "Accession",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_User_UserGUID",
                table: "Client",
                column: "UserGUID",
                principalTable: "User",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Accession_AccessionGUID",
                table: "Comment",
                column: "AccessionGUID",
                principalTable: "Accession",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Case_CaseGUID",
                table: "Comment",
                column: "CaseGUID",
                principalTable: "Case",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Specimen_SpecimenGUID",
                table: "Comment",
                column: "SpecimenGUID",
                principalTable: "Specimen",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Accession_GUID",
                table: "Doctor",
                column: "GUID",
                principalTable: "Accession",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lab_User_UserGUID",
                table: "Lab",
                column: "UserGUID",
                principalTable: "User",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchType_Step_StartingStepGUID",
                table: "BatchType",
                column: "StartingStepGUID",
                principalTable: "Step",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DashboardSection_Dashboard_GUID",
                table: "DashboardSection",
                column: "GUID",
                principalTable: "Dashboard",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accession_Doctor_Doctor2GUID",
                table: "Accession");

            migrationBuilder.DropForeignKey(
                name: "FK_Lab_Accession_GUID",
                table: "Lab");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchType_Batch_GUID",
                table: "BatchType");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_BatchType_GUID",
                table: "Step");

            migrationBuilder.DropForeignKey(
                name: "FK_DashboardSection_Dashboard_GUID",
                table: "DashboardSection");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Lab_PrimaryLabGUID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "DashboardComponent");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "PanelResult");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "ReportDocument");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "WorkflowStep");

            migrationBuilder.DropTable(
                name: "WorklistColumn");

            migrationBuilder.DropTable(
                name: "WorklistConfiguration");

            migrationBuilder.DropTable(
                name: "Specimen");

            migrationBuilder.DropTable(
                name: "Panel");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Workflow");

            migrationBuilder.DropTable(
                name: "Worklist");

            migrationBuilder.DropTable(
                name: "SpecimenTransport");

            migrationBuilder.DropTable(
                name: "SpecimenType");

            migrationBuilder.DropTable(
                name: "TestType");

            migrationBuilder.DropTable(
                name: "CaseType");

            migrationBuilder.DropTable(
                name: "ReportTemplate");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Accession");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "BatchType");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Layout");

            migrationBuilder.DropTable(
                name: "Dashboard");

            migrationBuilder.DropTable(
                name: "DashboardSection");

            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
