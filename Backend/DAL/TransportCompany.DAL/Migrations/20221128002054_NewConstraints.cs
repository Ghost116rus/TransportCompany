using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class NewConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Driver_DriverID",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Car_load",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Num_Receiving_storage",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Num_Sending_storage",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_cost",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_length",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_mass",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_shipping_cost",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_time",
                table: "Request");

            migrationBuilder.AlterColumn<string>(
                name: "DriverID",
                table: "Request",
                type: "char(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Phone_number",
                table: "Storage",
                column: "Phone_number",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Storage_Requests",
                table: "Storage",
                sql: "Requests LIKE 'Отсутствуют' OR Requests LIKE 'Есть'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Storage_Storage_number",
                table: "Storage",
                sql: "Storage_number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Car_load",
                table: "Request",
                sql: "Car_load > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Num_Receiving_storage",
                table: "Request",
                sql: "Num_Receiving_storage > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Num_Sending_storage",
                table: "Request",
                sql: "Num_Sending_storage > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_cost",
                table: "Request",
                sql: "Total_cost > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_length",
                table: "Request",
                sql: "Total_length > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_mass",
                table: "Request",
                sql: "Total_mass > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_shipping_cost",
                table: "Request",
                sql: "Total_shipping_cost > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_time",
                table: "Request",
                sql: "Total_time > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Cost",
                table: "Product",
                sql: "Cost > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Height",
                table: "Product",
                sql: "Height > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Length",
                table: "Product",
                sql: "Length > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Type",
                table: "Product",
                sql: "Type LIKE 'крупногабаритный' OR Type LIKE 'малогабаритный'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Weight",
                table: "Product",
                sql: "Weight > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Width",
                table: "Product",
                sql: "Width > 0");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_Phone_number",
                table: "Driver",
                column: "Phone_number",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Driver_Status",
                table: "Driver",
                sql: "Status LIKE 'Свободен' OR Status LIKE 'В рейсе' OR Status LIKE 'На больничном'");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Driver_DriverID",
                table: "Request",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "Driver_license_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Driver_DriverID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Storage_Phone_number",
                table: "Storage");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Storage_Requests",
                table: "Storage");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Storage_Storage_number",
                table: "Storage");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Car_load",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Num_Receiving_storage",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Num_Sending_storage",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_cost",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_length",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_mass",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_shipping_cost",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_time",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Cost",
                table: "Product");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Height",
                table: "Product");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Length",
                table: "Product");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Type",
                table: "Product");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Weight",
                table: "Product");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Width",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Driver_Phone_number",
                table: "Driver");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Driver_Status",
                table: "Driver");

            migrationBuilder.AlterColumn<string>(
                name: "DriverID",
                table: "Request",
                type: "char(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Car_load",
                table: "Request",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Num_Receiving_storage",
                table: "Request",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Num_Sending_storage",
                table: "Request",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_cost",
                table: "Request",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_length",
                table: "Request",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_mass",
                table: "Request",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_shipping_cost",
                table: "Request",
                sql: "Number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_time",
                table: "Request",
                sql: "Number > 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Driver_DriverID",
                table: "Request",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "Driver_license_number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
