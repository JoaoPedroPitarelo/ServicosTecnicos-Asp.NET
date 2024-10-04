using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicosTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id_departamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.id_departamento);
                });

            migrationBuilder.CreateTable(
                name: "maquina",
                columns: table => new
                {
                    patrimonio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maquina", x => x.patrimonio);
                });

            migrationBuilder.CreateTable(
                name: "tecnico",
                columns: table => new
                {
                    id_tecnico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MyProperty = table.Column<DateOnly>(type: "date", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tecnico", x => x.id_tecnico);
                });

            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    data_nascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    id_departamento = table.Column<int>(type: "int", nullable: false),
                    departamentoid_departamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.id_funcionario);
                    table.ForeignKey(
                        name: "FK_funcionario_departamento_departamentoid_departamento",
                        column: x => x.departamentoid_departamento,
                        principalTable: "departamento",
                        principalColumn: "id_departamento");
                });

            migrationBuilder.CreateTable(
                name: "chamado",
                columns: table => new
                {
                    id_chamado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_funcionario = table.Column<int>(type: "int", nullable: false),
                    patrimonio = table.Column<int>(type: "int", nullable: false),
                    id_tecnico = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chamado", x => x.id_chamado);
                    table.ForeignKey(
                        name: "FK_chamado_funcionario_id_funcionario",
                        column: x => x.id_funcionario,
                        principalTable: "funcionario",
                        principalColumn: "id_funcionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chamado_maquina_patrimonio",
                        column: x => x.patrimonio,
                        principalTable: "maquina",
                        principalColumn: "patrimonio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chamado_tecnico_id_tecnico",
                        column: x => x.id_tecnico,
                        principalTable: "tecnico",
                        principalColumn: "id_tecnico",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_departamentoid_departamento",
                table: "funcionario",
                column: "departamentoid_departamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chamado");

            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "maquina");

            migrationBuilder.DropTable(
                name: "tecnico");

            migrationBuilder.DropTable(
                name: "departamento");
        }
    }
}
