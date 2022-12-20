using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class AddUserPlusType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfUser",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Users_TypeOfUser",
                table: "Users",
                sql: "TypeOfUser > 0 AND TypeOfUser < 3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Users_TypeOfUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeOfUser",
                table: "Users");
        }
    }
}
