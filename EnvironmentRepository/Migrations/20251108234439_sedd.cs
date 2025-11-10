using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvironmentRepository.Migrations
{
    /// <inheritdoc />
    public partial class sedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Ulke_UlkeId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_UlkeId",
                table: "Adres");

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "Adres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_UlkeId",
                table: "Adres",
                column: "UlkeId",
                unique: true,
                filter: "[UlkeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Ulke_UlkeId",
                table: "Adres",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Ulke_UlkeId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_UlkeId",
                table: "Adres");

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "Adres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adres_UlkeId",
                table: "Adres",
                column: "UlkeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Ulke_UlkeId",
                table: "Adres",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
