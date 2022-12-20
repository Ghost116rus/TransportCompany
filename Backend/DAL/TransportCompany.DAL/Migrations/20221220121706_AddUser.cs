using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distance_Locations_EndP",
                table: "Distance");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Locations_LocationId",
                table: "Storage");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportation_Driver_DriverID",
                table: "Transportation");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportation_Request_RequestNumber",
                table: "Transportation");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportation_Transport_vehicle_VehicleID",
                table: "Transportation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transportation",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Car_load",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Num_Sending_storage",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Number",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Total_length",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Total_shipping_cost",
                table: "Transportation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distance",
                table: "Distance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Distance_EndP",
                table: "Distance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Distance_StartP",
                table: "Distance");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "locations");

            migrationBuilder.RenameTable(
                name: "Transportation",
                newName: "Transportations");

            migrationBuilder.RenameTable(
                name: "Distance",
                newName: "Distances");

            migrationBuilder.RenameIndex(
                name: "IX_Transportation_VehicleID",
                table: "Transportations",
                newName: "IX_Transportations_VehicleID");

            migrationBuilder.RenameIndex(
                name: "IX_Transportation_RequestNumber",
                table: "Transportations",
                newName: "IX_Transportations_RequestNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Transportation_DriverID",
                table: "Transportations",
                newName: "IX_Transportations_DriverID");

            migrationBuilder.RenameIndex(
                name: "IX_Distance_EndP",
                table: "Distances",
                newName: "IX_Distances_EndP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locations",
                table: "locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transportations",
                table: "Transportations",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distances",
                table: "Distances",
                columns: new[] { "StartP", "EndP" });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ForignKeyToStorage = table.Column<int>(type: "int", nullable: true),
                    ForignKeyToDriver = table.Column<string>(type: "char(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                    table.CheckConstraint("CK_Users_ForignKeyToStorage", "ForignKeyToStorage > 0");
                    table.ForeignKey(
                        name: "FK_Users_Driver_ForignKeyToDriver",
                        column: x => x.ForignKeyToDriver,
                        principalTable: "Driver",
                        principalColumn: "Driver_license_number");
                    table.ForeignKey(
                        name: "FK_Users_Storage_ForignKeyToStorage",
                        column: x => x.ForignKeyToStorage,
                        principalTable: "Storage",
                        principalColumn: "Storage_number");
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportations_Car_load",
                table: "Transportations",
                sql: "Car_load > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportations_Num_Sending_storage",
                table: "Transportations",
                sql: "Num_Sending_storage > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportations_Number",
                table: "Transportations",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportations_Total_length",
                table: "Transportations",
                sql: "Total_length > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportations_Total_shipping_cost",
                table: "Transportations",
                sql: "Total_shipping_cost > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Distances_EndP",
                table: "Distances",
                sql: "EndP > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Distances_StartP",
                table: "Distances",
                sql: "StartP > 0");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ForignKeyToDriver",
                table: "Users",
                column: "ForignKeyToDriver");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ForignKeyToStorage",
                table: "Users",
                column: "ForignKeyToStorage");

            migrationBuilder.AddForeignKey(
                name: "FK_Distances_locations_EndP",
                table: "Distances",
                column: "EndP",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_locations_LocationId",
                table: "Storage",
                column: "LocationId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_Driver_DriverID",
                table: "Transportations",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "Driver_license_number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_Request_RequestNumber",
                table: "Transportations",
                column: "RequestNumber",
                principalTable: "Request",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_Transport_vehicle_VehicleID",
                table: "Transportations",
                column: "VehicleID",
                principalTable: "Transport_vehicle",
                principalColumn: "Vehicle_identification_number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distances_locations_EndP",
                table: "Distances");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_locations_LocationId",
                table: "Storage");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_Driver_DriverID",
                table: "Transportations");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_Request_RequestNumber",
                table: "Transportations");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_Transport_vehicle_VehicleID",
                table: "Transportations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locations",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transportations",
                table: "Transportations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportations_Car_load",
                table: "Transportations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportations_Num_Sending_storage",
                table: "Transportations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportations_Number",
                table: "Transportations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportations_Total_length",
                table: "Transportations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportations_Total_shipping_cost",
                table: "Transportations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distances",
                table: "Distances");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Distances_EndP",
                table: "Distances");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Distances_StartP",
                table: "Distances");

            migrationBuilder.RenameTable(
                name: "locations",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Transportations",
                newName: "Transportation");

            migrationBuilder.RenameTable(
                name: "Distances",
                newName: "Distance");

            migrationBuilder.RenameIndex(
                name: "IX_Transportations_VehicleID",
                table: "Transportation",
                newName: "IX_Transportation_VehicleID");

            migrationBuilder.RenameIndex(
                name: "IX_Transportations_RequestNumber",
                table: "Transportation",
                newName: "IX_Transportation_RequestNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Transportations_DriverID",
                table: "Transportation",
                newName: "IX_Transportation_DriverID");

            migrationBuilder.RenameIndex(
                name: "IX_Distances_EndP",
                table: "Distance",
                newName: "IX_Distance_EndP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transportation",
                table: "Transportation",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distance",
                table: "Distance",
                columns: new[] { "StartP", "EndP" });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Car_load",
                table: "Transportation",
                sql: "Car_load > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Num_Sending_storage",
                table: "Transportation",
                sql: "Num_Sending_storage > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Number",
                table: "Transportation",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Total_length",
                table: "Transportation",
                sql: "Total_length > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Total_shipping_cost",
                table: "Transportation",
                sql: "Total_shipping_cost > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Distance_EndP",
                table: "Distance",
                sql: "EndP > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Distance_StartP",
                table: "Distance",
                sql: "StartP > 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Distance_Locations_EndP",
                table: "Distance",
                column: "EndP",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Locations_LocationId",
                table: "Storage",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportation_Driver_DriverID",
                table: "Transportation",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "Driver_license_number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportation_Request_RequestNumber",
                table: "Transportation",
                column: "RequestNumber",
                principalTable: "Request",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transportation_Transport_vehicle_VehicleID",
                table: "Transportation",
                column: "VehicleID",
                principalTable: "Transport_vehicle",
                principalColumn: "Vehicle_identification_number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
