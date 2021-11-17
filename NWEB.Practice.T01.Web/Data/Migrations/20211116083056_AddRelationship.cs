using Microsoft.EntityFrameworkCore.Migrations;

namespace NWEB.Practice.T01.Web.Data.Migrations
{
    public partial class AddRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_Categories_CategoryId",
                table: "Flowers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Flowers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_Categories_CategoryId",
                table: "Flowers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_Categories_CategoryId",
                table: "Flowers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Flowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_Categories_CategoryId",
                table: "Flowers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
