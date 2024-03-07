using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SogeVet.Server.Migrations
{
    /// <inheritdoc />
    public partial class ajout1ordertest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "Status", "UserId" },
                values: new object[] { 1, "Adress 1", "En attente de traitement", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
