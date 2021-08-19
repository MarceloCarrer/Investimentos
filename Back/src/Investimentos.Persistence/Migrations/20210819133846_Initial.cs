using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investimentos.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ativo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sigla = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Setor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Imagem = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataCompra = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorCompra = table.Column<decimal>(type: "TEXT", nullable: false),
                    QtdCompra = table.Column<int>(type: "INTEGER", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "TEXT", nullable: false),
                    QtdVenda = table.Column<int>(type: "INTEGER", nullable: false),
                    AtivoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Ativo_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_AtivoId",
                table: "Transacao",
                column: "AtivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Ativo");
        }
    }
}
