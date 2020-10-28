using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usuario = table.Column<string>(nullable: true),
                    Palabra = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    CantIntentos = table.Column<int>(nullable: false),
                    Puntaje = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LetraIngresadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Letra = table.Column<string>(nullable: true),
                    JuegoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetraIngresadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetraIngresadas_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Juegos",
                columns: new[] { "Id", "CantIntentos", "Modelo", "Palabra", "Puntaje", "Usuario" },
                values: new object[] { 1, 6, "_ _ _ _ _ _ _ _ _", "automovil", 0, "Pepe" });

            migrationBuilder.CreateIndex(
                name: "IX_LetraIngresadas_JuegoId",
                table: "LetraIngresadas",
                column: "JuegoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LetraIngresadas");

            migrationBuilder.DropTable(
                name: "Juegos");
        }
    }
}
