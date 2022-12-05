using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class NewEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Transportation_TransportationID",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Car_load",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Num_Sending_storage",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Status",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_length",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_shipping_cost",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_time",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "TransportationID",
                table: "Request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Total_volume",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Car_load",
                table: "Transportation",
                sql: "Car_load > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Num_Sending_storage",
                table: "Transportation",
                sql: "Num_Sending_storage > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Total_length",
                table: "Transportation",
                sql: "Total_length > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Total_shipping_cost",
                table: "Transportation",
                sql: "Total_shipping_cost > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transportation_Total_time",
                table: "Transportation",
                sql: "Total_time > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Status",
                table: "Request",
                sql: "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена' OR Status LIKE 'Отказана'");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Transportation_TransportationID",
                table: "Request",
                column: "TransportationID",
                principalTable: "Transportation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Transportation_TransportationID",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Car_load",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Num_Sending_storage",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Total_length",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Total_shipping_cost",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Transportation_Total_time",
                table: "Transportation");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Status",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Total_volume",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "TransportationID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Car_load",
                table: "Request",
                sql: "Car_load > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Num_Sending_storage",
                table: "Request",
                sql: "Num_Sending_storage > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Status",
                table: "Request",
                sql: "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_length",
                table: "Request",
                sql: "Total_length > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_shipping_cost",
                table: "Request",
                sql: "Total_shipping_cost > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_time",
                table: "Request",
                sql: "Total_time > 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Transportation_TransportationID",
                table: "Request",
                column: "TransportationID",
                principalTable: "Transportation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
