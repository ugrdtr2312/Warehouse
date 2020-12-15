using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { 1, "Sandora" },
                    { 9, "Jack Daniel's" },
                    { 8, "Jameson" },
                    { 7, "Morshynska" },
                    { 6, "Hoegaarden" },
                    { 10, "French rose" },
                    { 4, "Coca-Cola Company" },
                    { 3, "PepsiCo" },
                    { 2, "OKZDP" },
                    { 5, "Guinness" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Juice", "Description how to store juice..." },
                    { 2, "Water", "Description how to store water..." },
                    { 3, "Soda", "Description how to store soda..." },
                    { 4, "Beer", "Description how to store beer..." },
                    { 5, "Wine", "Description how to store wine..." },
                    { 6, "Whiskey", "Description how to store whiskey..." }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CompanyName", "FirstName", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 3, "OOO \"Fedorenko\"", "Danial", "050-333-33-33", "Fedorenko" },
                    { 1, "OOO \"Sidorov\"", "Nikita", "050-111-11-11", "Sidorov" },
                    { 2, "OOO \"Stepaniuk\"", "Ira", "050-222-22-22", "Stepaniuk" },
                    { 4, "FLP \"Dolid\"", "Vova", "050-444-44-44", "Dolid" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "BrandId", "CategoryId", "Price", "ProductName", "SupplierId" },
                values: new object[,]
                {
                    { 2, 4, 2, 1, 220m, "Tomato juice 0,5lx12", 1 },
                    { 1, 5, 1, 1, 210m, "Apple juice 0,5lx12", 4 },
                    { 14, 14, 7, 2, 120m, "Morshynska 0,5lx12", 3 },
                    { 12, 16, 4, 3, 250m, "Pepsi 1,5lx12", 3 },
                    { 8, 16, 4, 3, 250m, "Coca-cola 1,5lx12", 3 },
                    { 3, 3, 2, 1, 310m, "Apple juice 1lx12", 3 },
                    { 17, 13, 6, 4, 680m, "Hoegaarden 1lx12", 2 },
                    { 10, 21, 4, 3, 180m, "Pepsi 0,5lx12", 2 },
                    { 6, 21, 4, 3, 180m, "Coca-cola 0,5lx12", 2 },
                    { 4, 14, 1, 1, 340m, "Tomato juice 1lx12", 2 },
                    { 18, 8, 5, 4, 800m, "Guinness 0,435lx12", 1 },
                    { 16, 6, 6, 4, 480m, "Hoegaarden 0,5lx12", 1 },
                    { 15, 3, 10, 5, 600m, "Mansion No.9", 1 },
                    { 11, 5, 4, 3, 230m, "Pepsi 1lx12", 1 },
                    { 7, 5, 4, 3, 230m, "Coca-cola 1lx12", 1 },
                    { 5, 10, 1, 1, 480m, "Apple juice 1,5lx12", 1 },
                    { 9, 12, 4, 3, 270m, "Coca-cola 2lx12", 4 },
                    { 13, 12, 4, 3, 270m, "Pepsi 2lx12", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
