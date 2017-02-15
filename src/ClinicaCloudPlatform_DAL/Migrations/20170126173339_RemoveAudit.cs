using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArsMachinaLIMSDAL.Migrations
{
    public partial class RemoveAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DashboardSection_Dashboard_GUID",
                table: "DashboardSection");

            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "WorklistConfiguration");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "WorklistConfiguration");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "WorklistColumn");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "WorklistColumn");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Worklist");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Worklist");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "WorkflowStep");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "WorkflowStep");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Workflow");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Workflow");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "TestType");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "TestType");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "SpecimenType");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "SpecimenType");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "SpecimenTransport");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "SpecimenTransport");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Specimen");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Specimen");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "ReportTemplate");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "ReportTemplate");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "ReportDocument");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "ReportDocument");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "PanelResult");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "PanelResult");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Panel");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Panel");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Label");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Label");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Lab");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Lab");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Facility");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Facility");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "DashboardSection");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "DashboardSection");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "DashboardComponent");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "DashboardComponent");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "CaseType");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "CaseType");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Case");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "BatchType");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "BatchType");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Batch");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Batch");

            migrationBuilder.DropColumn(
                name: "AuditLevel",
                table: "Accession");

            migrationBuilder.DropColumn(
                name: "AuditLogReturnLevel",
                table: "Accession");

            migrationBuilder.AddColumn<Guid>(
                name: "HeaderSectionGUID",
                table: "Dashboard",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_HeaderSectionGUID",
                table: "Dashboard",
                column: "HeaderSectionGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboard_DashboardSection_HeaderSectionGUID",
                table: "Dashboard",
                column: "HeaderSectionGUID",
                principalTable: "DashboardSection",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboard_DashboardSection_HeaderSectionGUID",
                table: "Dashboard");

            migrationBuilder.DropIndex(
                name: "IX_Dashboard_HeaderSectionGUID",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "HeaderSectionGUID",
                table: "Dashboard");

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "WorklistConfiguration",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "WorklistConfiguration",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "WorklistColumn",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "WorklistColumn",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Worklist",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Worklist",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "WorkflowStep",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "WorkflowStep",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Workflow",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Workflow",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "TestType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "TestType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "TestResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "TestResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Test",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Test",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Step",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Step",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "SpecimenType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "SpecimenType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "SpecimenTransport",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "SpecimenTransport",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Specimen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Specimen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "ReportTemplate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "ReportTemplate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "ReportDocument",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "ReportDocument",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Report",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Report",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Patient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Patient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "PanelResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "PanelResult",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Panel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Panel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Layout",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Layout",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Label",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Label",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Lab",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Lab",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Facility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Facility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Doctor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Doctor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Department",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Department",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "DashboardSection",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "DashboardSection",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "DashboardComponent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "DashboardComponent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Dashboard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Dashboard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "CaseType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "CaseType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Case",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Case",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "BatchType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "BatchType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Batch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Batch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLevel",
                table: "Accession",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditLogReturnLevel",
                table: "Accession",
                nullable: false,
                defaultValue: 0);

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
                        name: "FK_Audit_Accession_AccessionGUID",
                        column: x => x.AccessionGUID,
                        principalTable: "Accession",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Batch_BatchGUID",
                        column: x => x.BatchGUID,
                        principalTable: "Batch",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_BatchType_BatchTypeGUID",
                        column: x => x.BatchTypeGUID,
                        principalTable: "BatchType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Case_CaseGUID",
                        column: x => x.CaseGUID,
                        principalTable: "Case",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_CaseType_CaseTypeGUID",
                        column: x => x.CaseTypeGUID,
                        principalTable: "CaseType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Client_ClientGUID",
                        column: x => x.ClientGUID,
                        principalTable: "Client",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Comment_CommentGUID",
                        column: x => x.CommentGUID,
                        principalTable: "Comment",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_DashboardComponent_DashboardComponentGUID",
                        column: x => x.DashboardComponentGUID,
                        principalTable: "DashboardComponent",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Dashboard_DashboardGUID",
                        column: x => x.DashboardGUID,
                        principalTable: "Dashboard",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_DashboardSection_DashboardSectionGUID",
                        column: x => x.DashboardSectionGUID,
                        principalTable: "DashboardSection",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Department_DepartmentGUID",
                        column: x => x.DepartmentGUID,
                        principalTable: "Department",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Doctor_DoctorGUID",
                        column: x => x.DoctorGUID,
                        principalTable: "Doctor",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Facility_FacilityGUID",
                        column: x => x.FacilityGUID,
                        principalTable: "Facility",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Lab_LabGUID",
                        column: x => x.LabGUID,
                        principalTable: "Lab",
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
                        name: "FK_Audit_PanelResult_PanelResultGUID",
                        column: x => x.PanelResultGUID,
                        principalTable: "PanelResult",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Patient_PatientGUID",
                        column: x => x.PatientGUID,
                        principalTable: "Patient",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_ReportDocument_ReportDocumentGUID",
                        column: x => x.ReportDocumentGUID,
                        principalTable: "ReportDocument",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Report_ReportGUID",
                        column: x => x.ReportGUID,
                        principalTable: "Report",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_ReportTemplate_ReportTemplateGUID",
                        column: x => x.ReportTemplateGUID,
                        principalTable: "ReportTemplate",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Specimen_SpecimenGUID",
                        column: x => x.SpecimenGUID,
                        principalTable: "Specimen",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_SpecimenTransport_SpecimenTransportGUID",
                        column: x => x.SpecimenTransportGUID,
                        principalTable: "SpecimenTransport",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_SpecimenType_SpecimenTypeGUID",
                        column: x => x.SpecimenTypeGUID,
                        principalTable: "SpecimenType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Step_StepGUID",
                        column: x => x.StepGUID,
                        principalTable: "Step",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Test_TestGUID",
                        column: x => x.TestGUID,
                        principalTable: "Test",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_TestResult_TestResultGUID",
                        column: x => x.TestResultGUID,
                        principalTable: "TestResult",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_TestType_TestTypeGUID",
                        column: x => x.TestTypeGUID,
                        principalTable: "TestType",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_Workflow_WorkflowGUID",
                        column: x => x.WorkflowGUID,
                        principalTable: "Workflow",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_WorkflowStep_WorkflowStepGUID",
                        column: x => x.WorkflowStepGUID,
                        principalTable: "WorkflowStep",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_WorklistColumn_WorklistColumnGUID",
                        column: x => x.WorklistColumnGUID,
                        principalTable: "WorklistColumn",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_WorklistConfiguration_WorklistConfigurationGUID",
                        column: x => x.WorklistConfigurationGUID,
                        principalTable: "WorklistConfiguration",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Worklist_WorklistGUID",
                        column: x => x.WorklistGUID,
                        principalTable: "Worklist",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_DashboardSection_Dashboard_GUID",
                table: "DashboardSection",
                column: "GUID",
                principalTable: "Dashboard",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
