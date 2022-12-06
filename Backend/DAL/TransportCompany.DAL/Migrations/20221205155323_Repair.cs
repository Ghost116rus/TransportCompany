using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class Repair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Driver_Driver_license_number",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Transport_vehicle_Transport_vehicleVehicle_identification_number",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_Driver_license_number",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_Transport_vehicleVehicle_identification_number",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Driver_license_number",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Transport_vehicleVehicle_identification_number",
                table: "Request");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Driver_license_number",
                table: "Request",
                type: "char(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transport_vehicleVehicle_identification_number",
                table: "Request",
                type: "char(17)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_Driver_license_number",
                table: "Request",
                column: "Driver_license_number");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Transport_vehicleVehicle_identification_number",
                table: "Request",
                column: "Transport_vehicleVehicle_identification_number");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Driver_Driver_license_number",
                table: "Request",
                column: "Driver_license_number",
                principalTable: "Driver",
                principalColumn: "Driver_license_number");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Transport_vehicle_Transport_vehicleVehicle_identification_number",
                table: "Request",
                column: "Transport_vehicleVehicle_identification_number",
                principalTable: "Transport_vehicle",
                principalColumn: "Vehicle_identification_number");
        }
    }
}
