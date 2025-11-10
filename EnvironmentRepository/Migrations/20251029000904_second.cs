using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvironmentRepository.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteri_MusteriTip_MusteriTipId",
                table: "Musteri");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_MusteriTipId",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "Kaynak",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "Kontak",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "Sektor",
                table: "Musteri");

            migrationBuilder.RenameColumn(
                name: "MusteriTipId",
                table: "Musteri",
                newName: "RiskDurumu");

            migrationBuilder.AlterColumn<string>(
                name: "Unvan",
                table: "Musteri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Musteri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Musteri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KaynakId",
                table: "Musteri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SektorId",
                table: "Musteri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipId",
                table: "Musteri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Musteri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VergiNo",
                table: "Musteri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MusteriKategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsayilan = table.Column<bool>(type: "bit", nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriKategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriKategori_Sirket_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusteriKaynak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsayilan = table.Column<bool>(type: "bit", nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriKaynak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriKaynak_Sirket_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusteriSektor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsayilan = table.Column<bool>(type: "bit", nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriSektor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriSektor_Sirket_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_KategoriId",
                table: "Musteri",
                column: "KategoriId",
                unique: true,
                filter: "[KategoriId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_KaynakId",
                table: "Musteri",
                column: "KaynakId",
                unique: true,
                filter: "[KaynakId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_SektorId",
                table: "Musteri",
                column: "SektorId",
                unique: true,
                filter: "[SektorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_TipId",
                table: "Musteri",
                column: "TipId",
                unique: true,
                filter: "[TipId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriKategori_SirketId",
                table: "MusteriKategori",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriKaynak_SirketId",
                table: "MusteriKaynak",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriSektor_SirketId",
                table: "MusteriSektor",
                column: "SirketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteri_MusteriKategori_KategoriId",
                table: "Musteri",
                column: "KategoriId",
                principalTable: "MusteriKategori",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteri_MusteriKaynak_KaynakId",
                table: "Musteri",
                column: "KaynakId",
                principalTable: "MusteriKaynak",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteri_MusteriSektor_SektorId",
                table: "Musteri",
                column: "SektorId",
                principalTable: "MusteriSektor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteri_MusteriTip_TipId",
                table: "Musteri",
                column: "TipId",
                principalTable: "MusteriTip",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteri_MusteriKategori_KategoriId",
                table: "Musteri");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteri_MusteriKaynak_KaynakId",
                table: "Musteri");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteri_MusteriSektor_SektorId",
                table: "Musteri");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteri_MusteriTip_TipId",
                table: "Musteri");

            migrationBuilder.DropTable(
                name: "MusteriKategori");

            migrationBuilder.DropTable(
                name: "MusteriKaynak");

            migrationBuilder.DropTable(
                name: "MusteriSektor");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_KategoriId",
                table: "Musteri");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_KaynakId",
                table: "Musteri");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_SektorId",
                table: "Musteri");

            migrationBuilder.DropIndex(
                name: "IX_Musteri_TipId",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "KaynakId",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "SektorId",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "TipId",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Musteri");

            migrationBuilder.DropColumn(
                name: "VergiNo",
                table: "Musteri");

            migrationBuilder.RenameColumn(
                name: "RiskDurumu",
                table: "Musteri",
                newName: "MusteriTipId");

            migrationBuilder.AlterColumn<string>(
                name: "Unvan",
                table: "Musteri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kategori",
                table: "Musteri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kaynak",
                table: "Musteri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kontak",
                table: "Musteri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sektor",
                table: "Musteri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_MusteriTipId",
                table: "Musteri",
                column: "MusteriTipId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musteri_MusteriTip_MusteriTipId",
                table: "Musteri",
                column: "MusteriTipId",
                principalTable: "MusteriTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
