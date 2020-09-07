using Microsoft.EntityFrameworkCore.Migrations;

namespace MASI_MarcoLegal.Server.Migrations
{
    public partial class ModeloSubIncisos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Verificable",
                table: "Incisos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Verificable",
                table: "Articulos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SubIncisos",
                columns: table => new
                {
                    SubIncisoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Detalle = table.Column<string>(nullable: true),
                    IncisoID = table.Column<int>(nullable: false),
                    Verificable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubIncisos", x => x.SubIncisoID);
                    table.ForeignKey(
                        name: "FK_SubIncisos_Incisos_IncisoID",
                        column: x => x.IncisoID,
                        principalTable: "Incisos",
                        principalColumn: "IncisoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubIncisos_IncisoID",
                table: "SubIncisos",
                column: "IncisoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubIncisos");

            migrationBuilder.DropColumn(
                name: "Verificable",
                table: "Incisos");

            migrationBuilder.DropColumn(
                name: "Verificable",
                table: "Articulos");
        }
    }
}
