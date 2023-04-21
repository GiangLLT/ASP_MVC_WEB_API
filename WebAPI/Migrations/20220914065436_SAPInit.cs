using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class SAPInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Idoc_Header",
                columns: table => new
                {
                    IDocNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDOCType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SITECode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idoc_Header", x => x.IDocNo);
                });

            migrationBuilder.CreateTable(
                name: "Idoc_Item",
                columns: table => new
                {
                    IDocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDocNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmplCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DptmCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job_Cod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PstnCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrShft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmplType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beg_Temp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth_dat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth_plc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IC_numbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IC_numbr_dat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R_Street_numbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R_Prov_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R_Prov_DES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R_Dist_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R_Dist_DES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R_Wards_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R_Wards_DES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street_numbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prov_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prov_DES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dist_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dist_DES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wards_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wards_DES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_numbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank_acc_numbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bankey_numbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idoc_Item", x => x.IDocID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Idoc_Header");

            migrationBuilder.DropTable(
                name: "Idoc_Item");
        }
    }
}
