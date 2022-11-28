using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class FinalConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Storage_number",
                table: "Storage",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transport_vehicle_Fuel_consumption",
                table: "Transport_vehicle",
                sql: "Fuel_consumption > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transport_vehicle_Load_capacity",
                table: "Transport_vehicle",
                sql: "Load_capacity > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transport_vehicle_Status",
                table: "Transport_vehicle",
                sql: "Status LIKE 'Свободен' OR Status LIKE 'В рейсе' OR Status LIKE 'В ремонте'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transport_vehicle_Transported_volume",
                table: "Transport_vehicle",
                sql: "Transported_volume > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Requare_product_RequestID",
                table: "Requare_product",
                sql: "RequestID > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_exmp_Storage_number",
                table: "Product_exmp",
                sql: "Storage_number > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Driver_Year_of_start_work",
                table: "Driver",
                sql: "Year_of_start_work LIKE '[1-2][0,9][0-9][0-9]'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Transport_vehicle_Fuel_consumption",
                table: "Transport_vehicle");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transport_vehicle_Load_capacity",
                table: "Transport_vehicle");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transport_vehicle_Status",
                table: "Transport_vehicle");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transport_vehicle_Transported_volume",
                table: "Transport_vehicle");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Requare_product_RequestID",
                table: "Requare_product");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_exmp_Storage_number",
                table: "Product_exmp");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Driver_Year_of_start_work",
                table: "Driver");

            migrationBuilder.AlterColumn<int>(
                name: "Storage_number",
                table: "Storage",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
