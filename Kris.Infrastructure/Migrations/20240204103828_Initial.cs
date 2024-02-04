using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kris.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Product's Name"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true, comment: "Product Description"),
                    Category = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Product category type"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Product price")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                },
                comment: "Products for the Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
