using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentSpecimenID",
                table: "Specimens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Barcode",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedFullName = table.Column<string>(nullable: false),
                    CreatedHref = table.Column<string>(nullable: false),
                    JsonExtendedData = table.Column<string>(type: "jsonb", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedFullName = table.Column<string>(nullable: false),
                    ModifiedHref = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barcode");

            migrationBuilder.DropColumn(
                name: "ParentSpecimenID",
                table: "Specimens");
        }
    }
}
