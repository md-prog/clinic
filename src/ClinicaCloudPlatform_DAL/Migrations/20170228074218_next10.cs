using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            //migrationBuilder.RenameColumn(
            //    name: "ID",
            //    table: "Workflows",
            //    newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CaseID",
                table: "TestResults",
                newName: "CaseId");

            migrationBuilder.RenameColumn(
                name: "BatchID",
                table: "TestResults",
                newName: "BatchId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TestResults",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_CaseID",
                table: "TestResults",
                newName: "IX_TestResults_CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_BatchID",
                table: "TestResults",
                newName: "IX_TestResults_BatchId");

            migrationBuilder.RenameColumn(
                name: "WorkflowID",
                table: "Steps",
                newName: "WorkflowId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Steps",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_WorkflowID",
                table: "Steps",
                newName: "IX_Steps_WorkflowId");

            migrationBuilder.RenameColumn(
                name: "CaseID",
                table: "Specimens",
                newName: "CaseId");

            migrationBuilder.RenameColumn(
                name: "BatchID",
                table: "Specimens",
                newName: "BatchId");

            migrationBuilder.RenameColumn(
                name: "AccessionID",
                table: "Specimens",
                newName: "AccessionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Specimens",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_CaseID",
                table: "Specimens",
                newName: "IX_Specimens_CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_BatchID",
                table: "Specimens",
                newName: "IX_Specimens_BatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_AccessionID",
                table: "Specimens",
                newName: "IX_Specimens_AccessionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ReportTemplates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ReportID",
                table: "ReportDocument",
                newName: "ReportId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ReportDocument",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ReportDocument_ReportID",
                table: "ReportDocument",
                newName: "IX_ReportDocument_ReportId");

            migrationBuilder.RenameColumn(
                name: "ReportTemplateID",
                table: "Reports",
                newName: "ReportTemplateId");

            migrationBuilder.RenameColumn(
                name: "CaseID",
                table: "Reports",
                newName: "CaseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reports",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportTemplateID",
                table: "Reports",
                newName: "IX_Reports_ReportTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_CaseID",
                table: "Reports",
                newName: "IX_Reports_CaseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Patients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CaseID",
                table: "PanelResults",
                newName: "CaseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PanelResults",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PanelResults_CaseID",
                table: "PanelResults",
                newName: "IX_PanelResults_CaseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Labels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Labs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Facilities",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Facilities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_ClientID",
                table: "Facilities",
                newName: "IX_Facilities_ClientId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Doctors",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_ClientID",
                table: "Doctors",
                newName: "IX_Doctors_ClientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Clients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfessionalLabID",
                table: "Cases",
                newName: "ProfessionalLabId");

            migrationBuilder.RenameColumn(
                name: "ProcessingLabID",
                table: "Cases",
                newName: "ProcessingLabId");

            migrationBuilder.RenameColumn(
                name: "AnalysisLabID",
                table: "Cases",
                newName: "AnalysisLabId");

            migrationBuilder.RenameColumn(
                name: "AccessionID",
                table: "Cases",
                newName: "AccessionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Cases",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ProfessionalLabID",
                table: "Cases",
                newName: "IX_Cases_ProfessionalLabId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ProcessingLabID",
                table: "Cases",
                newName: "IX_Cases_ProcessingLabId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_AnalysisLabID",
                table: "Cases",
                newName: "IX_Cases_AnalysisLabId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_AccessionID",
                table: "Cases",
                newName: "IX_Cases_AccessionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Batches",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Barcode",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Accessions",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "OrderingLabID",
                table: "Accessions",
                newName: "OrderingLabId");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "Accessions",
                newName: "FacilityId");

            migrationBuilder.RenameColumn(
                name: "Doctor2ID",
                table: "Accessions",
                newName: "Doctor2Id");

            migrationBuilder.RenameColumn(
                name: "Doctor1ID",
                table: "Accessions",
                newName: "Doctor1Id");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Accessions",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Accessions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_PatientID",
                table: "Accessions",
                newName: "IX_Accessions_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_OrderingLabID",
                table: "Accessions",
                newName: "IX_Accessions_OrderingLabId");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_FacilityID",
                table: "Accessions",
                newName: "IX_Accessions_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_Doctor2ID",
                table: "Accessions",
                newName: "IX_Accessions_Doctor2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_Doctor1ID",
                table: "Accessions",
                newName: "IX_Accessions_Doctor1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_ClientID",
                table: "Accessions",
                newName: "IX_Accessions_ClientId");

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Workflows",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "TestResults",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Steps",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Specimens",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "ReportTemplates",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "ReportDocument",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Reports",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Patients",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "PanelResults",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Labels",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Labs",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Facilities",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Doctors",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Comments",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Clients",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Cases",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Batches",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Barcode",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "Accessions",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Clients_ClientId",
                table: "Accessions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Doctors_Doctor1Id",
                table: "Accessions",
                column: "Doctor1Id",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Doctors_Doctor2Id",
                table: "Accessions",
                column: "Doctor2Id",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Facilities_FacilityId",
                table: "Accessions",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Labs_OrderingLabId",
                table: "Accessions",
                column: "OrderingLabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accessions_Patients_PatientId",
                table: "Accessions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Accessions_AccessionId",
                table: "Cases",
                column: "AccessionId",
                principalTable: "Accessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Labs_AnalysisLabId",
                table: "Cases",
                column: "AnalysisLabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Labs_ProcessingLabId",
                table: "Cases",
                column: "ProcessingLabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Labs_ProfessionalLabId",
                table: "Cases",
                column: "ProfessionalLabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Clients_ClientId",
                table: "Doctors",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Clients_ClientId",
                table: "Facilities",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PanelResults_Cases_CaseId",
                table: "PanelResults",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Cases_CaseId",
                table: "Reports",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportTemplates_ReportTemplateId",
                table: "Reports",
                column: "ReportTemplateId",
                principalTable: "ReportTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDocument_Reports_ReportId",
                table: "ReportDocument",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimens_Accessions_AccessionId",
                table: "Specimens",
                column: "AccessionId",
                principalTable: "Accessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimens_Batches_BatchId",
                table: "Specimens",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimens_Cases_CaseId",
                table: "Specimens",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Workflows_WorkflowId",
                table: "Steps",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Batches_BatchId",
                table: "TestResults",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Cases_CaseId",
                table: "TestResults",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Clients_ClientId",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Doctors_Doctor1Id",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Doctors_Doctor2Id",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Facilities_FacilityId",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Labs_OrderingLabId",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessions_Patients_PatientId",
                table: "Accessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Accessions_AccessionId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Labs_AnalysisLabId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Labs_ProcessingLabId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Labs_ProfessionalLabId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Clients_ClientId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Clients_ClientId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_PanelResults_Cases_CaseId",
                table: "PanelResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Cases_CaseId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportTemplates_ReportTemplateId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportDocument_Reports_ReportId",
                table: "ReportDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimens_Accessions_AccessionId",
                table: "Specimens");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimens_Batches_BatchId",
                table: "Specimens");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimens_Cases_CaseId",
                table: "Specimens");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Workflows_WorkflowId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Batches_BatchId",
                table: "TestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Cases_CaseId",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReportTemplates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReportDocument");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PanelResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Barcode");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Accessions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Workflows",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "TestResults",
                newName: "CaseID");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                table: "TestResults",
                newName: "BatchID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TestResults",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_CaseId",
                table: "TestResults",
                newName: "IX_TestResults_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_TestResults_BatchId",
                table: "TestResults",
                newName: "IX_TestResults_BatchID");

            migrationBuilder.RenameColumn(
                name: "WorkflowId",
                table: "Steps",
                newName: "WorkflowID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Steps",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_WorkflowId",
                table: "Steps",
                newName: "IX_Steps_WorkflowID");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Specimens",
                newName: "CaseID");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                table: "Specimens",
                newName: "BatchID");

            migrationBuilder.RenameColumn(
                name: "AccessionId",
                table: "Specimens",
                newName: "AccessionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Specimens",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_CaseId",
                table: "Specimens",
                newName: "IX_Specimens_CaseID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_BatchId",
                table: "Specimens",
                newName: "IX_Specimens_BatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Specimens_AccessionId",
                table: "Specimens",
                newName: "IX_Specimens_AccessionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReportTemplates",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "ReportDocument",
                newName: "ReportID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReportDocument",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportDocument_ReportId",
                table: "ReportDocument",
                newName: "IX_ReportDocument_ReportID");

            migrationBuilder.RenameColumn(
                name: "ReportTemplateId",
                table: "Reports",
                newName: "ReportTemplateID");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Reports",
                newName: "CaseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reports",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportTemplateId",
                table: "Reports",
                newName: "IX_Reports_ReportTemplateID");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_CaseId",
                table: "Reports",
                newName: "IX_Reports_CaseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "PanelResults",
                newName: "CaseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PanelResults",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_PanelResults_CaseId",
                table: "PanelResults",
                newName: "IX_PanelResults_CaseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Labels",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Labs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Facilities",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Facilities",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_ClientId",
                table: "Facilities",
                newName: "IX_Facilities_ClientID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Doctors",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_ClientId",
                table: "Doctors",
                newName: "IX_Doctors_ClientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ProfessionalLabId",
                table: "Cases",
                newName: "ProfessionalLabID");

            migrationBuilder.RenameColumn(
                name: "ProcessingLabId",
                table: "Cases",
                newName: "ProcessingLabID");

            migrationBuilder.RenameColumn(
                name: "AnalysisLabId",
                table: "Cases",
                newName: "AnalysisLabID");

            migrationBuilder.RenameColumn(
                name: "AccessionId",
                table: "Cases",
                newName: "AccessionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cases",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ProfessionalLabId",
                table: "Cases",
                newName: "IX_Cases_ProfessionalLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_ProcessingLabId",
                table: "Cases",
                newName: "IX_Cases_ProcessingLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_AnalysisLabId",
                table: "Cases",
                newName: "IX_Cases_AnalysisLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_AccessionId",
                table: "Cases",
                newName: "IX_Cases_AccessionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Batches",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Barcode",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Accessions",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "OrderingLabId",
                table: "Accessions",
                newName: "OrderingLabID");

            migrationBuilder.RenameColumn(
                name: "FacilityId",
                table: "Accessions",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "Doctor2Id",
                table: "Accessions",
                newName: "Doctor2ID");

            migrationBuilder.RenameColumn(
                name: "Doctor1Id",
                table: "Accessions",
                newName: "Doctor1ID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Accessions",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accessions",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_PatientId",
                table: "Accessions",
                newName: "IX_Accessions_PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_OrderingLabId",
                table: "Accessions",
                newName: "IX_Accessions_OrderingLabID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_FacilityId",
                table: "Accessions",
                newName: "IX_Accessions_FacilityID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_Doctor2Id",
                table: "Accessions",
                newName: "IX_Accessions_Doctor2ID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_Doctor1Id",
                table: "Accessions",
                newName: "IX_Accessions_Doctor1ID");

            migrationBuilder.RenameIndex(
                name: "IX_Accessions_ClientId",
                table: "Accessions",
                newName: "IX_Accessions_ClientID");

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
    }
}
