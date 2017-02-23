using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Workflows",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Workflows",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "TestResults",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "TestResults",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "WorkflowStepName",
                table: "Steps",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Steps",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Steps",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Specimens",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Specimens",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "ReportTemplates",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "ReportTemplates",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "ReportDocument",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "ReportDocument",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Reports",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Reports",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Patients",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Patients",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "PanelResults",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "PanelResults",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Labels",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Labels",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Labs",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Labs",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Facilities",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Facilities",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Doctors",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Doctors",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Comments",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Comments",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Clients",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Clients",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Cases",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Cases",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Batches",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Batches",
                newName: "ModifiedFullName");

            migrationBuilder.RenameColumn(
                name: "ModifiedUUID",
                table: "Accessions",
                newName: "ModifiedHref");

            migrationBuilder.RenameColumn(
                name: "CreatedUUID",
                table: "Accessions",
                newName: "ModifiedFullName");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Workflows",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Workflows",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "TestResults",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "TestResults",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Steps",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Steps",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Specimens",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Specimens",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "ReportTemplates",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "ReportTemplates",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "ReportDocument",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "ReportDocument",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Reports",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Reports",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Patients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Patients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "PanelResults",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "PanelResults",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Labels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Labels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Labs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Labs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Facilities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Facilities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Doctors",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Doctors",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Cases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Cases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Batches",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Batches",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedFullName",
                table: "Accessions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedHref",
                table: "Accessions",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "ReportTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "ReportTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "ReportDocument");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "ReportDocument");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "PanelResults");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "PanelResults");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedFullName",
                table: "Accessions");

            migrationBuilder.DropColumn(
                name: "CreatedHref",
                table: "Accessions");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Workflows",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Workflows",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "TestResults",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "TestResults",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Steps",
                newName: "WorkflowStepName");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Steps",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Steps",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Specimens",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Specimens",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "ReportTemplates",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "ReportTemplates",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "ReportDocument",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "ReportDocument",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Reports",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Reports",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Patients",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Patients",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "PanelResults",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "PanelResults",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Labels",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Labels",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Labs",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Labs",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Facilities",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Facilities",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Doctors",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Doctors",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Comments",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Comments",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Clients",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Clients",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Cases",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Cases",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Batches",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Batches",
                newName: "CreatedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedHref",
                table: "Accessions",
                newName: "ModifiedUUID");

            migrationBuilder.RenameColumn(
                name: "ModifiedFullName",
                table: "Accessions",
                newName: "CreatedUUID");
        }
    }
}
