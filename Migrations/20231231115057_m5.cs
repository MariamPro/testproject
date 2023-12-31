using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_pro.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pathImage",
                table: "_product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "_product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pathImage",
                table: "_product");

            migrationBuilder.DropColumn(
                name: "price",
                table: "_product");
        }
    }
}
