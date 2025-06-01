using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PT_SmartBit.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CrearModeloGastoDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GastosDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GastoEncabezadoId = table.Column<int>(type: "int", nullable: false),
                    TipoGastoId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastosDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastosDetalles_GastosEncabezados_GastoEncabezadoId",
                        column: x => x.GastoEncabezadoId,
                        principalTable: "GastosEncabezados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GastosDetalles_TipoGastos_TipoGastoId",
                        column: x => x.TipoGastoId,
                        principalTable: "TipoGastos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GastosDetalles_GastoEncabezadoId",
                table: "GastosDetalles",
                column: "GastoEncabezadoId");

            migrationBuilder.CreateIndex(
                name: "IX_GastosDetalles_TipoGastoId",
                table: "GastosDetalles",
                column: "TipoGastoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GastosDetalles");
        }
    }
}
