using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBA.Api.Migrations.PostgresDb
{
    /// <inheritdoc />
    public partial class postgres_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ponente_Evento_EventoId",
                table: "Ponente");

            migrationBuilder.DropForeignKey(
                name: "FK_Ponente_Ponente_PonenteId",
                table: "Ponente");

            migrationBuilder.DropIndex(
                name: "IX_Ponente_EventoId",
                table: "Ponente");

            migrationBuilder.DropIndex(
                name: "IX_Ponente_PonenteId",
                table: "Ponente");

            migrationBuilder.DropColumn(
                name: "PonenteId",
                table: "Ponente");

            migrationBuilder.CreateTable(
                name: "EventoPonente",
                columns: table => new
                {
                    EventosId = table.Column<int>(type: "integer", nullable: false),
                    PonentesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoPonente", x => new { x.EventosId, x.PonentesId });
                    table.ForeignKey(
                        name: "FK_EventoPonente_Evento_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoPonente_Ponente_PonentesId",
                        column: x => x.PonentesId,
                        principalTable: "Ponente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventoPonente_PonentesId",
                table: "EventoPonente",
                column: "PonentesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoPonente");

            migrationBuilder.AddColumn<int>(
                name: "PonenteId",
                table: "Ponente",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ponente_EventoId",
                table: "Ponente",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ponente_PonenteId",
                table: "Ponente",
                column: "PonenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ponente_Evento_EventoId",
                table: "Ponente",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ponente_Ponente_PonenteId",
                table: "Ponente",
                column: "PonenteId",
                principalTable: "Ponente",
                principalColumn: "Id");
        }
    }
}
