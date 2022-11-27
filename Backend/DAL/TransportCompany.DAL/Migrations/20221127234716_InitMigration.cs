using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Driver_license_number = table.Column<string>(type: "char(10)", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    Phone_number = table.Column<string>(type: "char(10)", nullable: false),
                    Driver_license_category = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Year_of_start_work = table.Column<string>(type: "char(4)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Driver_license_number);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Storage_number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addres = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    Phone_number = table.Column<string>(type: "char(10)", nullable: false),
                    FIO_manager = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Requests = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Storage_number);
                });

            migrationBuilder.CreateTable(
                name: "Transport_vehicle",
                columns: table => new
                {
                    Vehicle_identification_number = table.Column<string>(type: "char(17)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Transported_volume = table.Column<int>(type: "int", nullable: false),
                    Load_capacity = table.Column<int>(type: "int", nullable: false),
                    Fuel_consumption = table.Column<float>(type: "real", nullable: false),
                    Required_category = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport_vehicle", x => x.Vehicle_identification_number);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Num_Receiving_storage = table.Column<int>(type: "int", nullable: false),
                    Num_Sending_storage = table.Column<int>(type: "int", nullable: false),
                    Date_dispatch = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivery_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_time = table.Column<int>(type: "int", nullable: false),
                    Total_length = table.Column<int>(type: "int", nullable: false),
                    Car_load = table.Column<int>(type: "int", nullable: false),
                    Total_mass = table.Column<int>(type: "int", nullable: false),
                    Total_cost = table.Column<int>(type: "int", nullable: false),
                    Total_shipping_cost = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<string>(type: "char(17)", nullable: false),
                    DriverID = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Number);
                    table.CheckConstraint("CK_Request_Number", "Number > 0");
                    table.ForeignKey(
                        name: "FK_Request_Driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Driver",
                        principalColumn: "Driver_license_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Transport_vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Transport_vehicle",
                        principalColumn: "Vehicle_identification_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Сatalogue_number = table.Column<string>(type: "char(35)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    RequestNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Сatalogue_number);
                    table.ForeignKey(
                        name: "FK_Product_Request_RequestNumber",
                        column: x => x.RequestNumber,
                        principalTable: "Request",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateTable(
                name: "Product_exmp",
                columns: table => new
                {
                    Storage_number = table.Column<int>(type: "int", nullable: false),
                    Сatalogue_number = table.Column<string>(type: "char(35)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_exmp", x => new { x.Storage_number, x.Сatalogue_number });
                    table.ForeignKey(
                        name: "FK_Product_exmp_Product_Сatalogue_number",
                        column: x => x.Сatalogue_number,
                        principalTable: "Product",
                        principalColumn: "Сatalogue_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_exmp_Storage_Storage_number",
                        column: x => x.Storage_number,
                        principalTable: "Storage",
                        principalColumn: "Storage_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requare_product",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    Сatalogue_number = table.Column<string>(type: "char(35)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ProductСatalogue_number = table.Column<string>(type: "char(35)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requare_product", x => new { x.RequestID, x.Сatalogue_number });
                    table.ForeignKey(
                        name: "FK_Requare_product_Product_ProductСatalogue_number",
                        column: x => x.ProductСatalogue_number,
                        principalTable: "Product",
                        principalColumn: "Сatalogue_number");
                    table.ForeignKey(
                        name: "FK_Requare_product_Request_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Request",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_RequestNumber",
                table: "Product",
                column: "RequestNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Product_exmp_Сatalogue_number",
                table: "Product_exmp",
                column: "Сatalogue_number");

            migrationBuilder.CreateIndex(
                name: "IX_Requare_product_ProductСatalogue_number",
                table: "Requare_product",
                column: "ProductСatalogue_number");

            migrationBuilder.CreateIndex(
                name: "IX_Request_DriverID",
                table: "Request",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_VehicleID",
                table: "Request",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_exmp");

            migrationBuilder.DropTable(
                name: "Requare_product");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Transport_vehicle");
        }
    }
}
