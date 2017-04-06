using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    public partial class barcodechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Barcode",
                table: "Barcode");

            migrationBuilder.RenameTable(
                name: "Barcode",
                newName: "Barcodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barcodes",
                table: "Barcodes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Barcodes",
                table: "Barcodes");

            migrationBuilder.RenameTable(
                name: "Barcodes",
                newName: "Barcode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barcode",
                table: "Barcode",
                column: "Id");
        }
    }
}
