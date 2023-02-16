using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sksoft.DataAccess.Migrations
{
    public partial class db_sksoftsS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayarlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hakkimizda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayarlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BaseEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OkunmaSayisi = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeniHatirla = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayarlar");

            migrationBuilder.DropTable(
                name: "BaseEntities");

            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "Kullanici");
        }
    }
}
