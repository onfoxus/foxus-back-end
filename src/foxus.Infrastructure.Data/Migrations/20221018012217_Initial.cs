using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxus.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbPomodoroTimer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMPOFOCO = table.Column<TimeSpan>(type: "time", nullable: false),
                    TEMPODESCANSO = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPomodoroTimer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbTarefaPrimaria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false),
                    PRIORIDADE = table.Column<int>(type: "int", nullable: false),
                    DURACAO = table.Column<TimeSpan>(type: "time", nullable: false),
                    TITULO = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    FINALIZADA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTarefaPrimaria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbUsuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGIN = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    SENHA = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbTarefaSecundaria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarefaPrimariaId = table.Column<int>(type: "int", nullable: false),
                    TITULO = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    FINALIZADA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTarefaSecundaria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbTarefaSecundaria_tbTarefaPrimaria_TarefaPrimariaId",
                        column: x => x.TarefaPrimariaId,
                        principalTable: "tbTarefaPrimaria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbExecucao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DURACAO = table.Column<TimeSpan>(type: "time", nullable: false),
                    PomodoroTimerId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbExecucao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbExecucao_tbPomodoroTimer_PomodoroTimerId",
                        column: x => x.PomodoroTimerId,
                        principalTable: "tbPomodoroTimer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbExecucao_tbUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbUsuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExecucaoTarefaPrimaria",
                columns: table => new
                {
                    ExecucoesId = table.Column<int>(type: "int", nullable: false),
                    TarefasPrimariasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecucaoTarefaPrimaria", x => new { x.ExecucoesId, x.TarefasPrimariasId });
                    table.ForeignKey(
                        name: "FK_ExecucaoTarefaPrimaria_tbExecucao_ExecucoesId",
                        column: x => x.ExecucoesId,
                        principalTable: "tbExecucao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExecucaoTarefaPrimaria_tbTarefaPrimaria_TarefasPrimariasId",
                        column: x => x.TarefasPrimariasId,
                        principalTable: "tbTarefaPrimaria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecucaoTarefaPrimaria_TarefasPrimariasId",
                table: "ExecucaoTarefaPrimaria",
                column: "TarefasPrimariasId");

            migrationBuilder.CreateIndex(
                name: "IX_tbExecucao_PomodoroTimerId",
                table: "tbExecucao",
                column: "PomodoroTimerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbExecucao_UsuarioId",
                table: "tbExecucao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTarefaSecundaria_TarefaPrimariaId",
                table: "tbTarefaSecundaria",
                column: "TarefaPrimariaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExecucaoTarefaPrimaria");

            migrationBuilder.DropTable(
                name: "tbTarefaSecundaria");

            migrationBuilder.DropTable(
                name: "tbExecucao");

            migrationBuilder.DropTable(
                name: "tbTarefaPrimaria");

            migrationBuilder.DropTable(
                name: "tbPomodoroTimer");

            migrationBuilder.DropTable(
                name: "tbUsuario");
        }
    }
}
