using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class whydoihavetonamemigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentSpecimenID",
                table: "Specimens");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentSpecimenGuid",
                table: "Specimens",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentSpecimenGuid",
                table: "Specimens");

            migrationBuilder.AddColumn<int>(
                name: "ParentSpecimenID",
                table: "Specimens",
                nullable: false,
                defaultValue: 0);
        }
    }
}
