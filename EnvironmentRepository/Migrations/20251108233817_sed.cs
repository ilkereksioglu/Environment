using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvironmentRepository.Migrations
{
    /// <inheritdoc />
    public partial class sed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_AdresTip_AdresTipId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_AdresTipId",
                table: "Adres");

            migrationBuilder.AlterColumn<int>(
                name: "AdresTipId",
                table: "Adres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_AdresTipId",
                table: "Adres",
                column: "AdresTipId",
                unique: true,
                filter: "[AdresTipId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_AdresTip_AdresTipId",
                table: "Adres",
                column: "AdresTipId",
                principalTable: "AdresTip",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_AdresTip_AdresTipId",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_AdresTipId",
                table: "Adres");

            migrationBuilder.AlterColumn<int>(
                name: "AdresTipId",
                table: "Adres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adres_AdresTipId",
                table: "Adres",
                column: "AdresTipId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_AdresTip_AdresTipId",
                table: "Adres",
                column: "AdresTipId",
                principalTable: "AdresTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
