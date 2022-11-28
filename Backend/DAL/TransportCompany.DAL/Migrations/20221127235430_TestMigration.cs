using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportCompany.DAL.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requare_product_Product_ProductСatalogue_number",
                table: "Requare_product");

            migrationBuilder.DropIndex(
                name: "IX_Requare_product_ProductСatalogue_number",
                table: "Requare_product");

            migrationBuilder.DropColumn(
                name: "ProductСatalogue_number",
                table: "Requare_product");

            migrationBuilder.CreateIndex(
                name: "IX_Requare_product_Сatalogue_number",
                table: "Requare_product",
                column: "Сatalogue_number");

            migrationBuilder.AddForeignKey(
                name: "FK_Requare_product_Product_Сatalogue_number",
                table: "Requare_product",
                column: "Сatalogue_number",
                principalTable: "Product",
                principalColumn: "Сatalogue_number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requare_product_Product_Сatalogue_number",
                table: "Requare_product");

            migrationBuilder.DropIndex(
                name: "IX_Requare_product_Сatalogue_number",
                table: "Requare_product");

            migrationBuilder.AddColumn<string>(
                name: "ProductСatalogue_number",
                table: "Requare_product",
                type: "char(35)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requare_product_ProductСatalogue_number",
                table: "Requare_product",
                column: "ProductСatalogue_number");

            migrationBuilder.AddForeignKey(
                name: "FK_Requare_product_Product_ProductСatalogue_number",
                table: "Requare_product",
                column: "ProductСatalogue_number",
                principalTable: "Product",
                principalColumn: "Сatalogue_number");
        }
    }
}
