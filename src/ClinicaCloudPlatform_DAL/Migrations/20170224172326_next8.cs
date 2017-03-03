using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Workflows",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "TestResults",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Steps",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Specimens",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "ReportTemplates",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "ReportDocument",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Reports",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Patients",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "PanelResults",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Labels",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "LabName",
                table: "Labs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LabCode",
                table: "Labs",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Labs",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Facilities",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Doctors",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Comments",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Clients",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Clients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ClientCode",
                table: "Clients",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Cases",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Batches",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Barcode",
                newName: "CustomData");

            migrationBuilder.RenameColumn(
                name: "JsonExtendedData",
                table: "Accessions",
                newName: "CustomData");

            migrationBuilder.AddColumn<int>(
                name: "CurrentTypeSequenceNumber",
                table: "Cases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Cases",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentTypeSequenceNumber",
                table: "Batches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Batches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTypeSequenceNumber",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CurrentTypeSequenceNumber",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Workflows",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "TestResults",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Steps",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Specimens",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "ReportTemplates",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "ReportDocument",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Reports",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Patients",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "PanelResults",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Labels",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Labs",
                newName: "LabName");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Labs",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Labs",
                newName: "LabCode");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Facilities",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Doctors",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Comments",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "ClientName");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Clients",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Clients",
                newName: "ClientCode");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Cases",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Batches",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Barcode",
                newName: "JsonExtendedData");

            migrationBuilder.RenameColumn(
                name: "CustomData",
                table: "Accessions",
                newName: "JsonExtendedData");
        }
    }
}
