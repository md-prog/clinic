using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class next7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecimenCode",
                table: "Specimens");

            migrationBuilder.RenameColumn(
                name: "SpecimenType",
                table: "Specimens",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "SpecimenTransport",
                table: "Specimens",
                newName: "Transport");

            migrationBuilder.RenameColumn(
                name: "SpecimenCategory",
                table: "Specimens",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Specimens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Specimens");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Specimens",
                newName: "SpecimenType");

            migrationBuilder.RenameColumn(
                name: "Transport",
                table: "Specimens",
                newName: "SpecimenTransport");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Specimens",
                newName: "SpecimenCategory");

            migrationBuilder.AddColumn<string>(
                name: "SpecimenCode",
                table: "Specimens",
                maxLength: 7,
                nullable: true);
        }
    }
}
