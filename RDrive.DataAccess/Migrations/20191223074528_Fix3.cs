using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RDrive.DataAccess.Migrations
{
    public partial class Fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnded",
                table: "Contracts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrateDate",
                table: "Contracts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isEnable",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnded",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "RegistrateDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "isEnable",
                table: "AspNetUsers");
        }
    }
}
