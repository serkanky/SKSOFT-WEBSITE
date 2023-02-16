using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sksoft.DataAccess.Migrations
{
    public partial class db_oo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntities",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "OkunmaSayisi",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "BaseEntities");

            migrationBuilder.RenameTable(
                name: "BaseEntities",
                newName: "Urunlerimiz");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urunlerimiz",
                table: "Urunlerimiz",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkunmaSayisi = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hakkimizda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkimizda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Hakkimizda");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urunlerimiz",
                table: "Urunlerimiz");

            migrationBuilder.RenameTable(
                name: "Urunlerimiz",
                newName: "BaseEntities");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OkunmaSayisi",
                table: "BaseEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "BaseEntities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntities",
                table: "BaseEntities",
                column: "ID");
        }
    }
}
