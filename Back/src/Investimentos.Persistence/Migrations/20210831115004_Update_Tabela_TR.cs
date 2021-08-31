using Microsoft.EntityFrameworkCore.Migrations;

namespace Investimentos.Persistence.Migrations
{
    public partial class Update_Tabela_TR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Imposto",
                table: "Transacao",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Lucro",
                table: "Transacao",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LucroLiquido",
                table: "Transacao",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LucroPorc",
                table: "Transacao",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RetornoLiquido",
                table: "Transacao",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotalVenda",
                table: "Transacao",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imposto",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "Lucro",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "LucroLiquido",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "LucroPorc",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "RetornoLiquido",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "ValorTotalVenda",
                table: "Transacao");
        }
    }
}
