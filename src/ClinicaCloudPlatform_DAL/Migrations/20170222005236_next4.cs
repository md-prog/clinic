using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CollectionDate",
                table: "Specimens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedDate",
                table: "Specimens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectionDate",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "ReceivedDate",
                table: "Specimens");
        }
    }
}
