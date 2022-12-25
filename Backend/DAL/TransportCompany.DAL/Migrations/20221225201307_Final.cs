using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Status",
                table: "Request");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Status",
                table: "Request",
                sql: "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена' OR Status LIKE 'Отказано'");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Total_volume",
                table: "Request",
                sql: "Total_volume > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Status",
                table: "Request");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Total_volume",
                table: "Request");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Status",
                table: "Request",
                sql: "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена' OR Status LIKE 'Прервана' OR Status LIKE 'Отказано'");
        }
    }
}
