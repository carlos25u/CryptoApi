using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoApi.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    CoinId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<double>(type: "REAL", nullable: true),
                    ImagenUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.CoinId);
                });

            migrationBuilder.InsertData(
                table: "Coins",
                columns: new[] { "CoinId", "Descripcion", "ImagenUrl", "Valor" },
                values: new object[] { 1, "Bitcoin", "https://cdn.icon-icons.com/icons2/1487/PNG/512/8369-bitcoin_102502.png", 20916.5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
