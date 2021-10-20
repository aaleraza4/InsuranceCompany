using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Addnewtableandrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CurrentlyInsured",
                table: "MedicalInsurances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InstructionCheck",
                table: "MedicalInsurances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Smooker",
                table: "MedicalInsurances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MedicalInsurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InstructionCheck",
                table: "HealthInsurances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInsurances_UserId",
                table: "MedicalInsurances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInsurances_AspNetUsers_UserId",
                table: "MedicalInsurances",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInsurances_AspNetUsers_UserId",
                table: "MedicalInsurances");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInsurances_UserId",
                table: "MedicalInsurances");

            migrationBuilder.DropColumn(
                name: "CurrentlyInsured",
                table: "MedicalInsurances");

            migrationBuilder.DropColumn(
                name: "InstructionCheck",
                table: "MedicalInsurances");

            migrationBuilder.DropColumn(
                name: "Smooker",
                table: "MedicalInsurances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MedicalInsurances");

            migrationBuilder.DropColumn(
                name: "InstructionCheck",
                table: "HealthInsurances");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");
        }
    }
}
