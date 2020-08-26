using Microsoft.EntityFrameworkCore.Migrations;

namespace MASI_MarcoLegal.Server.Migrations
{
    public partial class ModeloInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leyes",
                columns: table => new
                {
                    LeyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leyes", x => x.LeyID);
                });

            migrationBuilder.CreateTable(
                name: "Considerandos",
                columns: table => new
                {
                    ConsideranoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    LeyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Considerandos", x => x.ConsideranoID);
                    table.ForeignKey(
                        name: "FK_Considerandos_Leyes_LeyID",
                        column: x => x.LeyID,
                        principalTable: "Leyes",
                        principalColumn: "LeyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    TituloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    LeyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.TituloID);
                    table.ForeignKey(
                        name: "FK_Titulos_Leyes_LeyID",
                        column: x => x.LeyID,
                        principalTable: "Leyes",
                        principalColumn: "LeyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capitulos",
                columns: table => new
                {
                    CapituloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    TituloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulos", x => x.CapituloID);
                    table.ForeignKey(
                        name: "FK_Capitulos_Titulos_TituloID",
                        column: x => x.TituloID,
                        principalTable: "Titulos",
                        principalColumn: "TituloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    CapituloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloID);
                    table.ForeignKey(
                        name: "FK_Articulos_Capitulos_CapituloID",
                        column: x => x.CapituloID,
                        principalTable: "Capitulos",
                        principalColumn: "CapituloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incisos",
                columns: table => new
                {
                    IncisoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    ArticuloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incisos", x => x.IncisoID);
                    table.ForeignKey(
                        name: "FK_Incisos_Articulos_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CapituloID",
                table: "Articulos",
                column: "CapituloID");

            migrationBuilder.CreateIndex(
                name: "IX_Capitulos_TituloID",
                table: "Capitulos",
                column: "TituloID");

            migrationBuilder.CreateIndex(
                name: "IX_Considerandos_LeyID",
                table: "Considerandos",
                column: "LeyID");

            migrationBuilder.CreateIndex(
                name: "IX_Incisos_ArticuloID",
                table: "Incisos",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_Titulos_LeyID",
                table: "Titulos",
                column: "LeyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Considerandos");

            migrationBuilder.DropTable(
                name: "Incisos");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Capitulos");

            migrationBuilder.DropTable(
                name: "Titulos");

            migrationBuilder.DropTable(
                name: "Leyes");
        }
    }
}
