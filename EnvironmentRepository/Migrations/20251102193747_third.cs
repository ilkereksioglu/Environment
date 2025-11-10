using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvironmentRepository.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Musteri_MusteriId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_MusteriId",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "MusteriId",
                table: "Adres");

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Musteri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Bakiye",
                table: "Musteri",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Iskonto",
                table: "Musteri",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VergiDairesi",
                table: "Musteri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_AdresId",
                table: "Musteri",
                column: "AdresId",
                unique: true,
                filter: "[AdresId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteri_Adres_AdresId",
                table: "Musteri",
                column: "AdresId",
                principalTable: "Adres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteri_Adres_AdresId",
                table: "Musteri");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_AdresId",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "Bakiye",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "Iskonto",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "VergiDairesi",
                table: "Musteri");

            migrationBuilder.AddColumn<int>(
                name: "MusteriId",
                table: "Adres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adres_MusteriId",
                table: "Adres",
                column: "MusteriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Musteri_MusteriId",
                table: "Adres",
                column: "MusteriId",
                principalTable: "Musteri",
                principalColumn: "Id");
        }
    }
}
