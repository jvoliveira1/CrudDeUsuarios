using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioTecnico.Migrations
{
    public partial class TabelaDeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    UserNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAtivo = table.Column<bool>(type: "bit", nullable: false),
                    UserDataCriacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
