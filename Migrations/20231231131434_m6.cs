using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_pro.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pathImage",
                table: "_product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pathImage",
                table: "_product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
