using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RDrive.DataAccess.Migrations
{
    public partial class Fix6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHandbrakeActive",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Speed",
                table: "Cars",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SteeringAngle",
                table: "Cars",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastUpdate",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsHandbrakeActive",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SteeringAngle",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "lastUpdate",
                table: "Cars");
        }
    }
}
