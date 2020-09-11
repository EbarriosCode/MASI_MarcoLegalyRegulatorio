using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MASI_MarcoLegal.Server.Migrations
{
    public partial class Modelo_Verificacion_Y_Cumplimientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cumplimientos");

            migrationBuilder.DropTable(
                name: "LeyesOrganizaciones");

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

            migrationBuilder.CreateTable(
                name: "Verificacion",
                columns: table => new
                {
                    VerificacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeyID = table.Column<int>(nullable: false),
                    OrganizacionID = table.Column<int>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificacion", x => x.VerificacionID);
                    table.ForeignKey(
                        name: "FK_Verificacion_Leyes_LeyID",
                        column: x => x.LeyID,
                        principalTable: "Leyes",
                        principalColumn: "LeyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verificacion_Organizaciones_OrganizacionID",
                        column: x => x.OrganizacionID,
                        principalTable: "Organizaciones",
                        principalColumn: "OrganizacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CumplimientoArticulo",
                columns: table => new
                {
                    CumplimientoArticuloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerificacionID = table.Column<int>(nullable: true),
                    Cumple = table.Column<bool>(nullable: false),
                    Evidencia = table.Column<string>(nullable: true),
                    ArticuloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CumplimientoArticulo", x => x.CumplimientoArticuloID);
                    table.ForeignKey(
                        name: "FK_CumplimientoArticulo_Articulos_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CumplimientoArticulo_Verificacion_VerificacionID",
                        column: x => x.VerificacionID,
                        principalTable: "Verificacion",
                        principalColumn: "VerificacionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CumplimientoInciso",
                columns: table => new
                {
                    CumplimientoIncisoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerificacionID = table.Column<int>(nullable: true),
                    Cumple = table.Column<bool>(nullable: false),
                    Evidencia = table.Column<string>(nullable: true),
                    IncisoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CumplimientoInciso", x => x.CumplimientoIncisoID);
                    table.ForeignKey(
                        name: "FK_CumplimientoInciso_Incisos_IncisoID",
                        column: x => x.IncisoID,
                        principalTable: "Incisos",
                        principalColumn: "IncisoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CumplimientoInciso_Verificacion_VerificacionID",
                        column: x => x.VerificacionID,
                        principalTable: "Verificacion",
                        principalColumn: "VerificacionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CumplimientoSubInciso",
                columns: table => new
                {
                    CumplimientoIncisoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerificacionID = table.Column<int>(nullable: true),
                    Cumple = table.Column<bool>(nullable: false),
                    Evidencia = table.Column<string>(nullable: true),
                    SubIncisoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CumplimientoSubInciso", x => x.CumplimientoIncisoID);
                    table.ForeignKey(
                        name: "FK_CumplimientoSubInciso_SubIncisos_SubIncisoID",
                        column: x => x.SubIncisoID,
                        principalTable: "SubIncisos",
                        principalColumn: "SubIncisoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CumplimientoSubInciso_Verificacion_VerificacionID",
                        column: x => x.VerificacionID,
                        principalTable: "Verificacion",
                        principalColumn: "VerificacionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CumplimientoArticulo_ArticuloID",
                table: "CumplimientoArticulo",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_CumplimientoArticulo_VerificacionID",
                table: "CumplimientoArticulo",
                column: "VerificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_CumplimientoInciso_IncisoID",
                table: "CumplimientoInciso",
                column: "IncisoID");

            migrationBuilder.CreateIndex(
                name: "IX_CumplimientoInciso_VerificacionID",
                table: "CumplimientoInciso",
                column: "VerificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_CumplimientoSubInciso_SubIncisoID",
                table: "CumplimientoSubInciso",
                column: "SubIncisoID");

            migrationBuilder.CreateIndex(
                name: "IX_CumplimientoSubInciso_VerificacionID",
                table: "CumplimientoSubInciso",
                column: "VerificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_SubIncisos_IncisoID",
                table: "SubIncisos",
                column: "IncisoID");

            migrationBuilder.CreateIndex(
                name: "IX_Verificacion_LeyID",
                table: "Verificacion",
                column: "LeyID");

            migrationBuilder.CreateIndex(
                name: "IX_Verificacion_OrganizacionID",
                table: "Verificacion",
                column: "OrganizacionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CumplimientoArticulo");

            migrationBuilder.DropTable(
                name: "CumplimientoInciso");

            migrationBuilder.DropTable(
                name: "CumplimientoSubInciso");

            migrationBuilder.DropTable(
                name: "SubIncisos");

            migrationBuilder.DropTable(
                name: "Verificacion");

            migrationBuilder.DropColumn(
                name: "Verificable",
                table: "Incisos");

            migrationBuilder.DropColumn(
                name: "Verificable",
                table: "Articulos");

            migrationBuilder.CreateTable(
                name: "Cumplimientos",
                columns: table => new
                {
                    CumplimientoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cumple = table.Column<bool>(type: "bit", nullable: false),
                    Evidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncisoID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "LeyesOrganizaciones",
                columns: table => new
                {
                    OrganizacionID = table.Column<int>(type: "int", nullable: false),
                    LeyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeyesOrganizaciones", x => new { x.OrganizacionID, x.LeyID });
                    table.ForeignKey(
                        name: "FK_LeyesOrganizaciones_Leyes_LeyID",
                        column: x => x.LeyID,
                        principalTable: "Leyes",
                        principalColumn: "LeyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeyesOrganizaciones_Organizaciones_OrganizacionID",
                        column: x => x.OrganizacionID,
                        principalTable: "Organizaciones",
                        principalColumn: "OrganizacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cumplimientos_IncisoID",
                table: "Cumplimientos",
                column: "IncisoID");

            migrationBuilder.CreateIndex(
                name: "IX_LeyesOrganizaciones_LeyID",
                table: "LeyesOrganizaciones",
                column: "LeyID");
        }
    }
}
