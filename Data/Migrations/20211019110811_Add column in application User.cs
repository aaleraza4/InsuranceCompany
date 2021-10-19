using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddcolumninapplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentlyInsured",
                table: "HealthInsurances");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MedicalInsurances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HealthInsurances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MedicalInsurances");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HealthInsurances");

            migrationBuilder.AddColumn<bool>(
                name: "CurrentlyInsured",
                table: "HealthInsurances",
                type: "bit",
                nullable: true);
        }
    }
}
