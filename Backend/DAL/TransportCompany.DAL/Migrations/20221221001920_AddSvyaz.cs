using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class AddSvyaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transportations_RequestNumber",
                table: "Transportations");

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_RequestNumber",
                table: "Transportations",
                column: "RequestNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transportations_RequestNumber",
                table: "Transportations");

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_RequestNumber",
                table: "Transportations",
                column: "RequestNumber");
        }
    }
}
