using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PT_SmartBit.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CrearModeloGastoEncabezado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GastosEncabezados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FondoMonetarioId = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NombreComercio = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosEncabezados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastosEncabezados_FondosMonetarios_FondoMonetarioId",
                        column: x => x.FondoMonetarioId,
                        principalTable: "FondosMonetarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GastosEncabezados_FondoMonetarioId",
                table: "GastosEncabezados",
                column: "FondoMonetarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GastosEncabezados");
        }
    }
}
