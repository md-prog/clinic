using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class npgsqlchg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransportCode",
                table: "Specimens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeCode",
                table: "Specimens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportCode",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "TypeCode",
                table: "Specimens");
        }
    }
}
