using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class NewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Driver_DriverID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Transport_vehicle_VehicleID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Car_load",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Date_dispatch",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Delivery_date",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Num_Sending_storage",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Total_length",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Total_shipping_cost",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Total_time",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "Request",
                newName: "Transport_vehicleVehicle_identification_number");

            migrationBuilder.RenameColumn(
                name: "DriverID",
                table: "Request",
                newName: "Driver_license_number");

            migrationBuilder.RenameIndex(
                name: "IX_Request_VehicleID",
                table: "Request",
                newName: "IX_Request_Transport_vehicleVehicle_identification_number");

            migrationBuilder.RenameIndex(
                name: "IX_Request_DriverID",
                table: "Request",
                newName: "IX_Request_Driver_license_number");

            migrationBuilder.AddColumn<int>(
                name: "TransportationID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Sending_storage = table.Column<int>(type: "int", nullable: false),
                    Date_dispatch = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivery_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_time = table.Column<int>(type: "int", nullable: false),
                    Total_length = table.Column<int>(type: "int", nullable: false),
                    Car_load = table.Column<int>(type: "int", nullable: false),
                    Total_shipping_cost = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VehicleID = table.Column<string>(type: "char(17)", nullable: false),
                    DriverID = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportation_Driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Driver",
                        principalColumn: "Driver_license_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transportation_Transport_vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Transport_vehicle",
                        principalColumn: "Vehicle_identification_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_TransportationID",
                table: "Request",
                column: "TransportationID");

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_DriverID",
                table: "Transportation",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_VehicleID",
                table: "Transportation",
                column: "VehicleID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Transportation_TransportationID",
                table: "Request",
                column: "TransportationID",
                principalTable: "Transportation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Driver_Driver_license_number",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Transport_vehicle_Transport_vehicleVehicle_identification_number",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Transportation_TransportationID",
                table: "Request");

            migrationBuilder.DropTable(
                name: "Transportation");

            migrationBuilder.DropIndex(
                name: "IX_Request_TransportationID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "TransportationID",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "Transport_vehicleVehicle_identification_number",
                table: "Request",
                newName: "VehicleID");

            migrationBuilder.RenameColumn(
                name: "Driver_license_number",
                table: "Request",
                newName: "DriverID");

            migrationBuilder.RenameIndex(
                name: "IX_Request_Transport_vehicleVehicle_identification_number",
                table: "Request",
                newName: "IX_Request_VehicleID");

            migrationBuilder.RenameIndex(
                name: "IX_Request_Driver_license_number",
                table: "Request",
                newName: "IX_Request_DriverID");

            migrationBuilder.AddColumn<int>(
                name: "Car_load",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_dispatch",
                table: "Request",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Delivery_date",
                table: "Request",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Num_Sending_storage",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_length",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_shipping_cost",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_time",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Driver_DriverID",
                table: "Request",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "Driver_license_number");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Transport_vehicle_VehicleID",
                table: "Request",
                column: "VehicleID",
                principalTable: "Transport_vehicle",
                principalColumn: "Vehicle_identification_number");
        }
    }
}
