using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class TwoNewForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distances_locations_EndP",
                table: "Distances");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Storage_Num_Receiving_storage",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_Num_Sending_storage",
                table: "Transportations",
                column: "Num_Sending_storage");

            migrationBuilder.AddForeignKey(
                name: "FK_Distance_Locations_EndPoint",
                table: "Distances",
                column: "EndP",
                principalTable: "locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Distance_Locations_StartPoint",
                table: "Distances",
                column: "StartP",
                principalTable: "locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Storage_Num_Receiving_storage",
                table: "Request",
                column: "Num_Receiving_storage",
                principalTable: "Storage",
                principalColumn: "Storage_number");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_Storage_Num_Sending_storage",
                table: "Transportations",
                column: "Num_Sending_storage",
                principalTable: "Storage",
                principalColumn: "Storage_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distance_Locations_EndPoint",
                table: "Distances");

            migrationBuilder.DropForeignKey(
                name: "FK_Distance_Locations_StartPoint",
                table: "Distances");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Storage_Num_Receiving_storage",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_Storage_Num_Sending_storage",
                table: "Transportations");

            migrationBuilder.DropIndex(
                name: "IX_Transportations_Num_Sending_storage",
                table: "Transportations");

            migrationBuilder.AddForeignKey(
                name: "FK_Distances_locations_EndP",
                table: "Distances",
                column: "EndP",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Storage_Num_Receiving_storage",
                table: "Request",
                column: "Num_Receiving_storage",
                principalTable: "Storage",
                principalColumn: "Storage_number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
