using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class NewForignKeyInRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Request_Num_Receiving_storage",
                table: "Request",
                column: "Num_Receiving_storage");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Storage_Num_Receiving_storage",
                table: "Request",
                column: "Num_Receiving_storage",
                principalTable: "Storage",
                principalColumn: "Storage_number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Storage_Num_Receiving_storage",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_Num_Receiving_storage",
                table: "Request");
        }
    }
}
