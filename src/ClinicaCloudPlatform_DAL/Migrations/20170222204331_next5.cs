using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecimenCategory",
                table: "Specimens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecimenType",
                table: "Specimens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecimenCategory",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "SpecimenType",
                table: "Specimens");
        }
    }
}
