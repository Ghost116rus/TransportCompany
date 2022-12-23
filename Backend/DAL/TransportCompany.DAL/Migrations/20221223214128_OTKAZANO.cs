using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class OTKAZANO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Status",
                table: "Request");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Status",
                table: "Request",
                sql: "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена' OR Status LIKE 'Прервана' OR Status LIKE 'Отказано'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_Status",
                table: "Request");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_Status",
                table: "Request",
                sql: "Status LIKE 'Обрабатывается' OR Status LIKE 'Сформирована' OR Status LIKE 'Доставляется' OR Status LIKE 'Выполнена' OR Status LIKE 'Прервана'");
        }
    }
}
