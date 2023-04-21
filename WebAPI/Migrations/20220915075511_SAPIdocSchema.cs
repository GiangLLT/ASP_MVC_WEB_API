using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class SAPIdocSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idoc_Item_Idoc_Header_IDocNo",
                table: "Idoc_Item");

            migrationBuilder.AddForeignKey(
                name: "FK_IDOCSAP_ITEM",
                table: "Idoc_Item",
                column: "IDocNo",
                principalTable: "Idoc_Header",
                principalColumn: "IDocNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IDOCSAP_ITEM",
                table: "Idoc_Item");

            migrationBuilder.AddForeignKey(
                name: "FK_Idoc_Item_Idoc_Header_IDocNo",
                table: "Idoc_Item",
                column: "IDocNo",
                principalTable: "Idoc_Header",
                principalColumn: "IDocNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
