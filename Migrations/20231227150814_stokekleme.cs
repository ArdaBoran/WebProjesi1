using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjesi1.Migrations
{
    /// <inheritdoc />
    public partial class stokekleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StokMiktari",
                table: "Urunlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "urunadedi",
                table: "Satislar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StokMiktari",
                table: "Urunlar");

            migrationBuilder.DropColumn(
                name: "urunadedi",
                table: "Satislar");
        }
    }
}
