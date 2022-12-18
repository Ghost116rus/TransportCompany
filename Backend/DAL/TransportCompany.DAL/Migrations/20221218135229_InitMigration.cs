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
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    table.CheckConstraint("CK_Driver_Status", "Status LIKE 'Свободен' OR Status LIKE 'В рейсе' OR Status LIKE 'На больничном'");
                    table.CheckConstraint("CK_Driver_Year_of_start_work", "Year_of_start_work LIKE '[1-2][0,1,9][0-9][0-9]'");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addres = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
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
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Сatalogue_number);
                    table.CheckConstraint("CK_Product_Cost", "Cost > 0");
                    table.CheckConstraint("CK_Product_Height", "Height > 0");
                    table.CheckConstraint("CK_Product_Length", "Length > 0");
                    table.CheckConstraint("CK_Product_Type", "Type LIKE 'крупногабаритный' OR Type LIKE 'малогабаритный'");
                    table.CheckConstraint("CK_Product_Weight", "Weight > 0");
                    table.CheckConstraint("CK_Product_Width", "Width > 0");
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Num_Receiving_storage = table.Column<int>(type: "int", nullable: false),
                    Total_volume = table.Column<int>(type: "int", nullable: false),
                    Total_mass = table.Column<int>(type: "int", nullable: false),
                    Total_cost = table.Column<int>(type: "int", nullable: false),
                    DateOfCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfComplete = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Number);
                    table.CheckConstraint("CK_Request_Num_Receiving_storage", "Num_Receiving_storage > 0");
                    table.CheckConstraint("CK_Request_Number", "Number > 0");
                    table.CheckConstraint("CK_Request_Status", "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена' OR Status LIKE 'Прервана'");
                    table.CheckConstraint("CK_Request_Total_cost", "Total_cost > 0");
                    table.CheckConstraint("CK_Request_Total_mass", "Total_mass > 0");
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
                    table.CheckConstraint("CK_Transport_vehicle_Fuel_consumption", "Fuel_consumption > 0");
                    table.CheckConstraint("CK_Transport_vehicle_Load_capacity", "Load_capacity > 0");
                    table.CheckConstraint("CK_Transport_vehicle_Status", "Status LIKE 'Свободен' OR Status LIKE 'В рейсе' OR Status LIKE 'В ремонте'");
                    table.CheckConstraint("CK_Transport_vehicle_Transported_volume", "Transported_volume > 0");
                });

            migrationBuilder.CreateTable(
                name: "Distance",
                columns: table => new
                {
                    StartP = table.Column<int>(type: "int", nullable: false),
                    EndP = table.Column<int>(type: "int", nullable: false),
                    TotalLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distance", x => new { x.StartP, x.EndP });
                    table.CheckConstraint("CK_Distance_EndP", "EndP > 0");
                    table.CheckConstraint("CK_Distance_StartP", "StartP > 0");
                    table.ForeignKey(
                        name: "FK_Distance_Locations_EndP",
                        column: x => x.EndP,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Storage_number = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Phone_number = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Storage_number);
                    table.CheckConstraint("CK_Storage_Storage_number", "Storage_number > 0");
                    table.ForeignKey(
                        name: "FK_Storage_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requare_product",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    Сatalogue_number = table.Column<string>(type: "char(35)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requare_product", x => new { x.RequestID, x.Сatalogue_number });
                    table.CheckConstraint("CK_Requare_product_RequestID", "RequestID > 0");
                    table.ForeignKey(
                        name: "FK_Requare_product_Product_Сatalogue_number",
                        column: x => x.Сatalogue_number,
                        principalTable: "Product",
                        principalColumn: "Сatalogue_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requare_product_Request_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Request",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Sending_storage = table.Column<int>(type: "int", nullable: false),
                    Date_dispatch = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivery_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_length = table.Column<int>(type: "int", nullable: false),
                    Car_load = table.Column<int>(type: "int", nullable: false),
                    Total_shipping_cost = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequestNumber = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<string>(type: "char(17)", nullable: false),
                    DriverID = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.Number);
                    table.CheckConstraint("CK_Transportation_Car_load", "Car_load > 0");
                    table.CheckConstraint("CK_Transportation_Num_Sending_storage", "Num_Sending_storage > 0");
                    table.CheckConstraint("CK_Transportation_Number", "Number > 0");
                    table.CheckConstraint("CK_Transportation_Total_length", "Total_length > 0");
                    table.CheckConstraint("CK_Transportation_Total_shipping_cost", "Total_shipping_cost > 0");
                    table.ForeignKey(
                        name: "FK_Transportation_Driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Driver",
                        principalColumn: "Driver_license_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transportation_Request_RequestNumber",
                        column: x => x.RequestNumber,
                        principalTable: "Request",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transportation_Transport_vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Transport_vehicle",
                        principalColumn: "Vehicle_identification_number",
                        onDelete: ReferentialAction.Cascade);
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
                    table.CheckConstraint("CK_Product_exmp_Storage_number", "Storage_number > 0");
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

            migrationBuilder.CreateIndex(
                name: "IX_Distance_EndP",
                table: "Distance",
                column: "EndP");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_Phone_number",
                table: "Driver",
                column: "Phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_exmp_Сatalogue_number",
                table: "Product_exmp",
                column: "Сatalogue_number");

            migrationBuilder.CreateIndex(
                name: "IX_Requare_product_Сatalogue_number",
                table: "Requare_product",
                column: "Сatalogue_number");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_LocationId",
                table: "Storage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Phone_number",
                table: "Storage",
                column: "Phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_DriverID",
                table: "Transportation",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_RequestNumber",
                table: "Transportation",
                column: "RequestNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_VehicleID",
                table: "Transportation",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distance");

            migrationBuilder.DropTable(
                name: "Product_exmp");

            migrationBuilder.DropTable(
                name: "Requare_product");

            migrationBuilder.DropTable(
                name: "Transportation");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Transport_vehicle");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
