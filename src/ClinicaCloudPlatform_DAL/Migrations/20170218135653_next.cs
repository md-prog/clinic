using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accession_Client_ClientID",
                table: "Accession");

            migrationBuilder.DropForeignKey(
                name: "FK_Accession_Doctor_Doctor1ID",
                table: "Accession");

            migrationBuilder.DropForeignKey(
                name: "FK_Accession_Doctor_Doctor2ID",
                table: "Accession");

            migrationBuilder.DropForeignKey(
                name: "FK_Accession_Facility_FacilityID",
                table: "Accession");

            migrationBuilder.DropForeignKey(
                name: "FK_Accession_Lab_OrderingLabID",
                table: "Accession");

            migrationBuilder.DropForeignKey(
                name: "FK_Accession_Patient_PatientID",
                table: "Accession");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Accession_AccessionID",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Lab_AnalysisLabID",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Lab_ProcessingLabID",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Case_Lab_ProfessionalLabID",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Client_ClientID",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Client_ClientID",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_PanelResult_Case_CaseID",
                table: "PanelResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Case_CaseID",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_ReportTemplate_ReportTemplateID",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportDocument_Report_ReportID",
                table: "ReportDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Accession_AccessionID",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Batch_BatchID",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Case_CaseID",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_Workflow_WorkflowID",
                table: "Step");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResult_Batch_BatchID",
                table: "TestResult");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResult_Case_CaseID",
                table: "TestResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workflow",
                table: "Workflow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Step",
                table: "Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specimen",
                table: "Specimen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportTemplate",
                table: "ReportTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PanelResult",
                table: "PanelResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Label",
                table: "Label");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lab",
                table: "Lab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facility",
                table: "Facility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Case",
                table: "Case");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batch",
                table: "Batch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accession",
                table: "Accession");

            migrationBuilder.RenameTable(
                name: "Workflow",
                newName: "Workflows");

            migrationBuilder.RenameTable(
                name: "TestResult",
                newName: "TestResults");

            migrationBuilder.RenameTable(
                name: "Step",
                newName: "Steps");

            migrationBuilder.RenameTable(
                name: "Specimen",
                newName: "Specimens");

            migrationBuilder.RenameTable(
                name: "ReportTemplate",
                newName: "ReportTemplates");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "PanelResult",
                newName: "PanelResults");

            migrationBuilder.RenameTable(
                name: "Label",
                newName: "Labels");

            migrationBuilder.RenameTable(
                name: "Lab",
                newName: "Labs");

            migrationBuilder.RenameTable(
                name: "Facility",
                newName: "Facilities");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Case",
                newName: "Cases");

            migrationBuilder.RenameTable(
                name: "Batch",
                newName: "Batches");

            migrationBuilder.RenameTable(
                name: "Accession",
                newName: "Accessions");

            migrationBuilder.RenameIndex(
                name: "IX_TestResult_CaseID",
                table: "TestResults",
                newName: "IX_TestResults_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_TestResult_BatchID",
                table: "TestResults",
                newName: "IX_TestResults_BatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Step_WorkflowID",
                table: "Steps",
                newName: "IX_Steps_WorkflowID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_CaseID",
                table: "Specimens",
                newName: "IX_Specimens_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_BatchID",
                table: "Specimens",
                newName: "IX_Specimens_BatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_AccessionID",
                table: "Specimens",
                newName: "IX_Specimens_AccessionID");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ReportTemplateID",
                table: "Reports",
                newName: "IX_Reports_ReportTemplateID");

            migrationBuilder.RenameIndex(
                name: "IX_Report_CaseID",
                table: "Reports",
                newName: "IX_Reports_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_PanelResult_CaseID",
                table: "PanelResults",
                newName: "IX_PanelResults_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_ClientID",
                table: "Facilities",
                newName: "IX_Facilities_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctor_ClientID",
                table: "Doctors",
                newName: "IX_Doctors_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Case_ProfessionalLabID",
                table: "Cases",
                newName: "IX_Cases_ProfessionalLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Case_ProcessingLabID",
                table: "Cases",
                newName: "IX_Cases_ProcessingLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Case_AnalysisLabID",
                table: "Cases",
                newName: "IX_Cases_AnalysisLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Case_AccessionID",
                table: "Cases",
                newName: "IX_Cases_AccessionID");

            migrationBuilder.RenameIndex(
                name: "IX_Accession_PatientID",
                table: "Accessions",
                newName: "IX_Accessions_PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Accession_OrderingLabID",
                table: "Accessions",
                newName: "IX_Accessions_OrderingLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Accession_FacilityID",
                table: "Accessions",
                newName: "IX_Accessions_FacilityID");

            migrationBuilder.RenameIndex(
                name: "IX_Accession_Doctor2ID",
                table: "Accessions",
                newName: "IX_Accessions_Doctor2ID");

            migrationBuilder.RenameIndex(
                name: "IX_Accession_Doctor1ID",
                table: "Accessions",
                newName: "IX_Accessions_Doctor1ID");

            migrationBuilder.RenameIndex(
                name: "IX_Accession_ClientID",
                table: "Accessions",
                newName: "IX_Accessions_ClientID");

            migrationBuilder.AddColumn<string>(
                name: "TestCode",
                table: "TestResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestName",
                table: "TestResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanelCode",
                table: "PanelResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanelName",
                table: "PanelResults",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workflows",
                table: "Workflows",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Steps",
                table: "Steps",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specimens",
                table: "Specimens",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportTemplates",
                table: "ReportTemplates",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PanelResults",
                table: "PanelResults",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labels",
                table: "Labels",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labs",
                table: "Labs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cases",
                table: "Cases",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batches",
                table: "Batches",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accessions",
                table: "Accessions",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CommentText = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUUID = table.Column<string>(nullable: true),
                    JsonExtendedData = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUUID = table.Column<string>(nullable: true),
                    SecondaryIdentifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Clients_ClientID",
                table: "Accessions",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Doctors_Doctor1ID",
                table: "Accessions",
                column: "Doctor1ID",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Doctors_Doctor2ID",
                table: "Accessions",
                column: "Doctor2ID",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Facilities_FacilityID",
                table: "Accessions",
                column: "FacilityID",
                principalTable: "Facilities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Labs_OrderingLabID",
                table: "Accessions",
                column: "OrderingLabID",
                principalTable: "Labs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Patients_PatientID",
                table: "Accessions",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Accessions_AccessionID",
                table: "Cases",
                column: "AccessionID",
                principalTable: "Accessions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Labs_AnalysisLabID",
                table: "Cases",
                column: "AnalysisLabID",
                principalTable: "Labs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Labs_ProcessingLabID",
                table: "Cases",
                column: "ProcessingLabID",
                principalTable: "Labs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Labs_ProfessionalLabID",
                table: "Cases",
                column: "ProfessionalLabID",
                principalTable: "Labs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Clients_ClientID",
                table: "Doctors",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Clients_ClientID",
                table: "Facilities",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PanelResults_Cases_CaseID",
                table: "PanelResults",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Cases_CaseID",
                table: "Reports",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportTemplates_ReportTemplateID",
                table: "Reports",
                column: "ReportTemplateID",
                principalTable: "ReportTemplates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDocument_Reports_ReportID",
                table: "ReportDocument",
                column: "ReportID",
                principalTable: "Reports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimens_Accessions_AccessionID",
                table: "Specimens",
                column: "AccessionID",
                principalTable: "Accessions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimens_Batches_BatchID",
                table: "Specimens",
                column: "BatchID",
                principalTable: "Batches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimens_Cases_CaseID",
                table: "Specimens",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Workflows_WorkflowID",
                table: "Steps",
                column: "WorkflowID",
                principalTable: "Workflows",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Batches_BatchID",
                table: "TestResults",
                column: "BatchID",
                principalTable: "Batches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Cases_CaseID",
                table: "TestResults",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Clients_ClientID",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Doctors_Doctor1ID",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Doctors_Doctor2ID",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Facilities_FacilityID",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Labs_OrderingLabID",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Patients_PatientID",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Accessions_AccessionID",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Labs_AnalysisLabID",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Labs_ProcessingLabID",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Labs_ProfessionalLabID",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Clients_ClientID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Clients_ClientID",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_PanelResults_Cases_CaseID",
                table: "PanelResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Cases_CaseID",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportTemplates_ReportTemplateID",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportDocument_Reports_ReportID",
                table: "ReportDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimens_Accessions_AccessionID",
                table: "Specimens");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimens_Batches_BatchID",
                table: "Specimens");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimens_Cases_CaseID",
                table: "Specimens");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Workflows_WorkflowID",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Batches_BatchID",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Cases_CaseID",
                table: "TestResults");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workflows",
                table: "Workflows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestResults",
                table: "TestResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Steps",
                table: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specimens",
                table: "Specimens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportTemplates",
                table: "ReportTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PanelResults",
                table: "PanelResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labels",
                table: "Labels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labs",
                table: "Labs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cases",
                table: "Cases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batches",
                table: "Batches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accessions",
                table: "Accessions");

            migrationBuilder.DropColumn(
                name: "TestCode",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "TestName",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "PanelCode",
                table: "PanelResults");

            migrationBuilder.DropColumn(
                name: "PanelName",
                table: "PanelResults");

            migrationBuilder.RenameTable(
                name: "Workflows",
                newName: "Workflow");

            migrationBuilder.RenameTable(
                name: "TestResults",
                newName: "TestResult");

            migrationBuilder.RenameTable(
                name: "Steps",
                newName: "Step");

            migrationBuilder.RenameTable(
                name: "Specimens",
                newName: "Specimen");

            migrationBuilder.RenameTable(
                name: "ReportTemplates",
                newName: "ReportTemplate");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameTable(
                name: "PanelResults",
                newName: "PanelResult");

            migrationBuilder.RenameTable(
                name: "Labels",
                newName: "Label");

            migrationBuilder.RenameTable(
                name: "Labs",
                newName: "Lab");

            migrationBuilder.RenameTable(
                name: "Facilities",
                newName: "Facility");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "Cases",
                newName: "Case");

            migrationBuilder.RenameTable(
                name: "Batches",
                newName: "Batch");

            migrationBuilder.RenameTable(
                name: "Accessions",
                newName: "Accession");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_CaseID",
                table: "TestResult",
                newName: "IX_TestResult_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_BatchID",
                table: "TestResult",
                newName: "IX_TestResult_BatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_WorkflowID",
                table: "Step",
                newName: "IX_Step_WorkflowID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_CaseID",
                table: "Specimen",
                newName: "IX_Specimen_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_BatchID",
                table: "Specimen",
                newName: "IX_Specimen_BatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_AccessionID",
                table: "Specimen",
                newName: "IX_Specimen_AccessionID");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportTemplateID",
                table: "Report",
                newName: "IX_Report_ReportTemplateID");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_CaseID",
                table: "Report",
                newName: "IX_Report_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_PanelResults_CaseID",
                table: "PanelResult",
                newName: "IX_PanelResult_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_ClientID",
                table: "Facility",
                newName: "IX_Facility_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_ClientID",
                table: "Doctor",
                newName: "IX_Doctor_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ProfessionalLabID",
                table: "Case",
                newName: "IX_Case_ProfessionalLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ProcessingLabID",
                table: "Case",
                newName: "IX_Case_ProcessingLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_AnalysisLabID",
                table: "Case",
                newName: "IX_Case_AnalysisLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_AccessionID",
                table: "Case",
                newName: "IX_Case_AccessionID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_PatientID",
                table: "Accession",
                newName: "IX_Accession_PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_OrderingLabID",
                table: "Accession",
                newName: "IX_Accession_OrderingLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_FacilityID",
                table: "Accession",
                newName: "IX_Accession_FacilityID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_Doctor2ID",
                table: "Accession",
                newName: "IX_Accession_Doctor2ID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_Doctor1ID",
                table: "Accession",
                newName: "IX_Accession_Doctor1ID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_ClientID",
                table: "Accession",
                newName: "IX_Accession_ClientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workflow",
                table: "Workflow",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestResult",
                table: "TestResult",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Step",
                table: "Step",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specimen",
                table: "Specimen",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportTemplate",
                table: "ReportTemplate",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PanelResult",
                table: "PanelResult",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Label",
                table: "Label",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lab",
                table: "Lab",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facility",
                table: "Facility",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Case",
                table: "Case",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batch",
                table: "Batch",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accession",
                table: "Accession",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accession_Client_ClientID",
                table: "Accession",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accession_Doctor_Doctor1ID",
                table: "Accession",
                column: "Doctor1ID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accession_Doctor_Doctor2ID",
                table: "Accession",
                column: "Doctor2ID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accession_Facility_FacilityID",
                table: "Accession",
                column: "FacilityID",
                principalTable: "Facility",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accession_Lab_OrderingLabID",
                table: "Accession",
                column: "OrderingLabID",
                principalTable: "Lab",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accession_Patient_PatientID",
                table: "Accession",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Accession_AccessionID",
                table: "Case",
                column: "AccessionID",
                principalTable: "Accession",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Lab_AnalysisLabID",
                table: "Case",
                column: "AnalysisLabID",
                principalTable: "Lab",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Lab_ProcessingLabID",
                table: "Case",
                column: "ProcessingLabID",
                principalTable: "Lab",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Case_Lab_ProfessionalLabID",
                table: "Case",
                column: "ProfessionalLabID",
                principalTable: "Lab",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Client_ClientID",
                table: "Doctor",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Client_ClientID",
                table: "Facility",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PanelResult_Case_CaseID",
                table: "PanelResult",
                column: "CaseID",
                principalTable: "Case",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Case_CaseID",
                table: "Report",
                column: "CaseID",
                principalTable: "Case",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_ReportTemplate_ReportTemplateID",
                table: "Report",
                column: "ReportTemplateID",
                principalTable: "ReportTemplate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDocument_Report_ReportID",
                table: "ReportDocument",
                column: "ReportID",
                principalTable: "Report",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimen_Accession_AccessionID",
                table: "Specimen",
                column: "AccessionID",
                principalTable: "Accession",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimen_Batch_BatchID",
                table: "Specimen",
                column: "BatchID",
                principalTable: "Batch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimen_Case_CaseID",
                table: "Specimen",
                column: "CaseID",
                principalTable: "Case",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Workflow_WorkflowID",
                table: "Step",
                column: "WorkflowID",
                principalTable: "Workflow",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResult_Batch_BatchID",
                table: "TestResult",
                column: "BatchID",
                principalTable: "Batch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResult_Case_CaseID",
                table: "TestResult",
                column: "CaseID",
                principalTable: "Case",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
