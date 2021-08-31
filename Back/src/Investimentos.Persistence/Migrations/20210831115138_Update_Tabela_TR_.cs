using Microsoft.EntityFrameworkCore.Migrations;

namespace Investimentos.Persistence.Migrations
{
    public partial class Update_Tabela_TR_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vendido",
                table: "Transacao",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendido",
                table: "Transacao");
        }
    }
}
