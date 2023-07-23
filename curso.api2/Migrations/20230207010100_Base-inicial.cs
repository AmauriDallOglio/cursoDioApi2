using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace curso.api2.Migrations
{
    /// <inheritdoc />
    public partial class Baseinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaUsuario",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaUsuario", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "TabelaCurso",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaCurso", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_TabelaCurso_TabelaUsuario_CodigoUsuario",
                        column: x => x.CodigoUsuario,
                        principalTable: "TabelaUsuario",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabelaCurso_CodigoUsuario",
                table: "TabelaCurso",
                column: "CodigoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaCurso");

            migrationBuilder.DropTable(
                name: "TabelaUsuario");
        }
    }
}
