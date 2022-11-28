using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class BugFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Request_RequestNumber",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_RequestNumber",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RequestNumber",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestNumber",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_RequestNumber",
                table: "Product",
                column: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Request_RequestNumber",
                table: "Product",
                column: "RequestNumber",
                principalTable: "Request",
                principalColumn: "Number");
        }
    }
}
