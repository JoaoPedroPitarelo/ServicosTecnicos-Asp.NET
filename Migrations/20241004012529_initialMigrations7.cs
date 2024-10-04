using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicosTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_chamado_id_funcionario",
                table: "chamado",
                column: "id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_id_tecnico",
                table: "chamado",
                column: "id_tecnico");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_patrimonio",
                table: "chamado",
                column: "patrimonio");

            migrationBuilder.AddForeignKey(
                name: "FK_chamado_funcionario_id_funcionario",
                table: "chamado",
                column: "id_funcionario",
                principalTable: "funcionario",
                principalColumn: "id_funcionario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chamado_maquina_patrimonio",
                table: "chamado",
                column: "patrimonio",
                principalTable: "maquina",
                principalColumn: "patrimonio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chamado_tecnico_id_tecnico",
                table: "chamado",
                column: "id_tecnico",
                principalTable: "tecnico",
                principalColumn: "id_tecnico",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chamado_funcionario_id_funcionario",
                table: "chamado");

            migrationBuilder.DropForeignKey(
                name: "FK_chamado_maquina_patrimonio",
                table: "chamado");

            migrationBuilder.DropForeignKey(
                name: "FK_chamado_tecnico_id_tecnico",
                table: "chamado");

            migrationBuilder.DropIndex(
                name: "IX_chamado_id_funcionario",
                table: "chamado");

            migrationBuilder.DropIndex(
                name: "IX_chamado_id_tecnico",
                table: "chamado");

            migrationBuilder.DropIndex(
                name: "IX_chamado_patrimonio",
                table: "chamado");
        }
    }
}
