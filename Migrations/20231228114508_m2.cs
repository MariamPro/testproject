using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp_pro.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_product",
                columns: table => new
                {
                    proId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    proDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product", x => x.proId);
                    table.ForeignKey(
                        name: "FK__product__category_CateID",
                        column: x => x.CateID,
                        principalTable: "_category",
                        principalColumn: "cateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__product_CateID",
                table: "_product",
                column: "CateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_product");
        }
    }
}
