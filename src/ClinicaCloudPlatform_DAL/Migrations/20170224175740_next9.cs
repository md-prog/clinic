using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Workflows",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "TestResults",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Steps",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Specimens",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "ReportTemplates",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "ReportDocument",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Reports",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Patients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "PanelResults",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Labels",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Labs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Facilities",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Doctors",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Comments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Clients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Cases",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Batches",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Barcode",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Accessions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "ReportTemplates");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "ReportDocument");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "PanelResults");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Barcode");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Accessions");
        }
    }
}
