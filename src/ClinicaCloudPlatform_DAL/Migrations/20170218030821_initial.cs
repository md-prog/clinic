using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    BatchNumber = table.Column<string>(nullable: true),
                    BatchStatus = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    ClientCode = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LabCode = table.Column<string>(nullable: true),
                    LabName = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    BarcodeFormDefinition = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LabelName = table.Column<string>(nullable: true),
                    LabelType = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    SSN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReportTemplate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    PublicReport = table.Column<bool>(nullable: false),
                    ReportTemplateDefinition = table.Column<string>(nullable: true),
                    ReportTemplateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTemplate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    WorkflowName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    ClientID = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Doctor_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    StateProvince = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Facility_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    WorkflowID = table.Column<int>(nullable: true),
                    WorkflowStepName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Step_Workflow_WorkflowID",
                        column: x => x.WorkflowID,
                        principalTable: "Workflow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accession",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    ClientID = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    Doctor1ID = table.Column<int>(nullable: true),
                    Doctor2ID = table.Column<int>(nullable: true),
                    FacilityID = table.Column<int>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    MRN = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    OrderingLabID = table.Column<int>(nullable: true),
                    PatientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accession", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accession_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accession_Doctor_Doctor1ID",
                        column: x => x.Doctor1ID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accession_Doctor_Doctor2ID",
                        column: x => x.Doctor2ID,
                        principalTable: "Doctor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accession_Facility_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "Facility",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accession_Lab_OrderingLabID",
                        column: x => x.OrderingLabID,
                        principalTable: "Lab",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accession_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccessionID = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    AnalysisLabID = table.Column<int>(nullable: true),
                    CaseNumber = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    ProcessingLabID = table.Column<int>(nullable: true),
                    ProfessionalLabID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Case_Accession_AccessionID",
                        column: x => x.AccessionID,
                        principalTable: "Accession",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Lab_AnalysisLabID",
                        column: x => x.AnalysisLabID,
                        principalTable: "Lab",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Lab_ProcessingLabID",
                        column: x => x.ProcessingLabID,
                        principalTable: "Lab",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Lab_ProfessionalLabID",
                        column: x => x.ProfessionalLabID,
                        principalTable: "Lab",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PanelResult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CaseID = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanelResult", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PanelResult_Case_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Case",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CaseID = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    ReportTemplateID = table.Column<int>(nullable: true),
                    ReportVersion = table.Column<int>(nullable: false),
                    ReportVersionNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Report_Case_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Case",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_ReportTemplate_ReportTemplateID",
                        column: x => x.ReportTemplateID,
                        principalTable: "ReportTemplate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specimen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccessionID = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    BatchID = table.Column<int>(nullable: true),
                    CaseID = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    ExternalSpecimenID = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    SpecimenCode = table.Column<string>(maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specimen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Specimen_Accession_AccessionID",
                        column: x => x.AccessionID,
                        principalTable: "Accession",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specimen_Batch_BatchID",
                        column: x => x.BatchID,
                        principalTable: "Batch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specimen_Case_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Case",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    BatchID = table.Column<int>(nullable: true),
                    CaseID = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestResult_Batch_BatchID",
                        column: x => x.BatchID,
                        principalTable: "Batch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResult_Case_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Case",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportDocument",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: false),
                    ReportDocumentBinary = table.Column<byte[]>(nullable: true),
                    ReportDocumentType = table.Column<int>(nullable: false),
                    ReportID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReportDocument_Report_ReportID",
                        column: x => x.ReportID,
                        principalTable: "Report",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accession_ClientID",
                table: "Accession",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Accession_Doctor1ID",
                table: "Accession",
                column: "Doctor1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Accession_Doctor2ID",
                table: "Accession",
                column: "Doctor2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Accession_FacilityID",
                table: "Accession",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Accession_OrderingLabID",
                table: "Accession",
                column: "OrderingLabID");

            migrationBuilder.CreateIndex(
                name: "IX_Accession_PatientID",
                table: "Accession",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_AccessionID",
                table: "Case",
                column: "AccessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_AnalysisLabID",
                table: "Case",
                column: "AnalysisLabID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_ProcessingLabID",
                table: "Case",
                column: "ProcessingLabID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_ProfessionalLabID",
                table: "Case",
                column: "ProfessionalLabID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClientID",
                table: "Doctor",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_ClientID",
                table: "Facility",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PanelResult_CaseID",
                table: "PanelResult",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CaseID",
                table: "Report",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ReportTemplateID",
                table: "Report",
                column: "ReportTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDocument_ReportID",
                table: "ReportDocument",
                column: "ReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_AccessionID",
                table: "Specimen",
                column: "AccessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_BatchID",
                table: "Specimen",
                column: "BatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_CaseID",
                table: "Specimen",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Step_WorkflowID",
                table: "Step",
                column: "WorkflowID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_BatchID",
                table: "TestResult",
                column: "BatchID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_CaseID",
                table: "TestResult",
                column: "CaseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "PanelResult");

            migrationBuilder.DropTable(
                name: "ReportDocument");

            migrationBuilder.DropTable(
                name: "Specimen");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Workflow");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "ReportTemplate");

            migrationBuilder.DropTable(
                name: "Accession");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
