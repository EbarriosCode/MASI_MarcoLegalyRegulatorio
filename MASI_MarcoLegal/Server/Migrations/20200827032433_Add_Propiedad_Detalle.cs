using Microsoft.EntityFrameworkCore.Migrations;

namespace MASI_MarcoLegal.Server.Migrations
{
    public partial class Add_Propiedad_Detalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Titulos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Incisos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Capitulos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Articulos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cumplimientos",
                columns: table => new
                {
                    CumplimientoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncisoID = table.Column<int>(nullable: false),
                    Cumple = table.Column<bool>(nullable: false),
                    Evidencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cumplimientos", x => x.CumplimientoID);
                    table.ForeignKey(
                        name: "FK_Cumplimientos_Incisos_IncisoID",
                        column: x => x.IncisoID,
                        principalTable: "Incisos",
                        principalColumn: "IncisoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cumplimientos_IncisoID",
                table: "Cumplimientos",
                column: "IncisoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cumplimientos");

            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Titulos");

            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Incisos");

            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Capitulos");

            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Articulos");
        }
    }
}
