using Microsoft.EntityFrameworkCore.Migrations;

namespace NWEB.Practice.T01.Web.Data.Migrations
{
    public partial class AddColumOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Categories");
        }
    }
}
