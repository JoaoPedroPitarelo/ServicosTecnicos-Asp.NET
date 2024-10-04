using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicosTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionario_departamento_departamentoid_departamento",
                table: "funcionario");

            migrationBuilder.DropIndex(
                name: "IX_funcionario_departamentoid_departamento",
                table: "funcionario");

            migrationBuilder.DropColumn(
                name: "departamentoid_departamento",
                table: "funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_id_departamento",
                table: "funcionario",
                column: "id_departamento");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionario_departamento_id_departamento",
                table: "funcionario",
                column: "id_departamento",
                principalTable: "departamento",
                principalColumn: "id_departamento",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionario_departamento_id_departamento",
                table: "funcionario");

            migrationBuilder.DropIndex(
                name: "IX_funcionario_id_departamento",
                table: "funcionario");

            migrationBuilder.AddColumn<int>(
                name: "departamentoid_departamento",
                table: "funcionario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_departamentoid_departamento",
                table: "funcionario",
                column: "departamentoid_departamento");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionario_departamento_departamentoid_departamento",
                table: "funcionario",
                column: "departamentoid_departamento",
                principalTable: "departamento",
                principalColumn: "id_departamento");
        }
    }
}
