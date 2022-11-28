using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class RequestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Transport_vehicle_VehicleID",
                table: "Request");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleID",
                table: "Request",
                type: "char(17)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(17)");

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
                name: "CK_Request_Status",
                table: "Request",
                sql: "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена'");

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
                name: "FK_Request_Transport_vehicle_VehicleID",
                table: "Request",
                column: "VehicleID",
                principalTable: "Transport_vehicle",
                principalColumn: "Vehicle_identification_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Transport_vehicle_VehicleID",
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
                name: "CK_Request_Status",
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
                name: "VehicleID",
                table: "Request",
                type: "char(17)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(17)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Transport_vehicle_VehicleID",
                table: "Request",
                column: "VehicleID",
                principalTable: "Transport_vehicle",
                principalColumn: "Vehicle_identification_number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
