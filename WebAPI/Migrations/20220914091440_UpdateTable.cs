using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IDocNo",
                table: "Idoc_Item",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Idoc_Item_IDocNo",
                table: "Idoc_Item",
                column: "IDocNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Idoc_Item_Idoc_Header_IDocNo",
                table: "Idoc_Item",
                column: "IDocNo",
                principalTable: "Idoc_Header",
                principalColumn: "IDocNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idoc_Item_Idoc_Header_IDocNo",
                table: "Idoc_Item");

            migrationBuilder.DropIndex(
                name: "IX_Idoc_Item_IDocNo",
                table: "Idoc_Item");

            migrationBuilder.AlterColumn<string>(
                name: "IDocNo",
                table: "Idoc_Item",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
