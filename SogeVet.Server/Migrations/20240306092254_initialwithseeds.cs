using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SogeVet.Server.Migrations
{
    /// <inheritdoc />
    public partial class initialwithseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Homme" },
                    { 2, "Femme" },
                    { 3, "Enfant" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsAdmin", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "addressadmin1", "MailAdmin1", "Admin1", true, "Admin1L", "PasswordAdmin1" },
                    { 2, "addressadmin2", "MailAdmin2", "Admin2", true, "Admin2L", "PasswordAdmin2" },
                    { 3, "addressUser1", "MailUser1", "User1", false, "User1L", "PasswordUser1" },
                    { 4, "addressUser2", "MailUser2", "User2", false, "User2L", "PasswordUser2" },
                    { 5, "addressUser3", "MailUser3", "User3", false, "User3L", "PasswordUser3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "Images", "Name", "Quantity", "Size", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "Blanc", "Description du produit 1", "[\"URL1.1\",\"URL1.2\",\"URL1.3\"]", "Produit 1", 10, 30, 20.5f },
                    { 2, 2, "Noir", "Description du produit 2", "[\"URL2.1\",\"URL2.2\",\"URL2.3\"]", "Produit 2", 12, 41, 19.58f },
                    { 3, 3, "Rouge", "Description du produit 3", "[\"URL3.1\",\"URL3.2\",\"URL3.3\"]", "Produit 3", 40, 52, 10.2f },
                    { 4, 3, "Rouge", "Description du produit 4", "[\"URL4.1\",\"URL4.2\",\"URL4.3\"]", "Produit 4", 60, 32, 40.5f },
                    { 5, 2, "Vert", "Description du produit 5", "[\"URL5.1\",\"URL5.2\",\"URL5.3\"]", "Produit 5", 100, 36, 1.58f },
                    { 6, 1, "Bleu", "Description du produit 6", "[\"URL6.1\",\"URL6.2\",\"URL6.3\"]", "Produit 6", 2, 38, 3.22f },
                    { 7, 2, "Violet", "Description du produit 7", "[\"URL7.1\",\"URL7.2\",\"URL7.3\"]", "Produit 7", 12, 20, 3.5f },
                    { 8, 3, "Vert", "Description du produit 8", "[\"URL8.1\",\"URL8.2\",\"URL8.3\"]", "Produit 8", 13, 27, 10.58f },
                    { 9, 1, "Marron", "Description du produit 9", "[\"URL9.1\",\"URL9.2\",\"URL9.3\"]", "Produit 9", 24, 25, 6.2f },
                    { 10, 3, "Turquoise", "Description du produit 10", "[\"URL10.1\",\"URL10.2\",\"URL10.3\"]", "Produit 10", 52, 8, 79.99f },
                    { 11, 1, "Vert", "Description du produit 11", "[\"URL11.1\",\"URL11.2\",\"URL11.3\"]", "Produit 11", 62, 10, 19.58f },
                    { 12, 2, "Noir", "Description du produit 12", "[\"URL12.1\",\"URL12.2\",\"URL12.3\"]", "Produit 12", 5, 30, 3.22f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
