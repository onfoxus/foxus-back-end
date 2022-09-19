using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxus.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POMODOROTIMER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMPOFOCO = table.Column<TimeSpan>(type: "time", nullable: false),
                    TEMPODESCANSO = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POMODOROTIMER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGIN = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    SENHA = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXECUCAO",
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
                    table.PrimaryKey("PK_EXECUCAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXECUCAO_POMODOROTIMER_PomodoroTimerId",
                        column: x => x.PomodoroTimerId,
                        principalTable: "POMODOROTIMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXECUCAO_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TAREFAPRIMARIA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PRIORIDADE = table.Column<int>(type: "int", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DURACAO = table.Column<TimeSpan>(type: "time", nullable: false),
                    ExecucaoId = table.Column<int>(type: "int", nullable: true),
                    TITULO = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    FINALIZADA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREFAPRIMARIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TAREFAPRIMARIA_EXECUCAO_ExecucaoId",
                        column: x => x.ExecucaoId,
                        principalTable: "EXECUCAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TAREFASECUNDARIA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarefaPrimariaId = table.Column<int>(type: "int", nullable: true),
                    TITULO = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    FINALIZADA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREFASECUNDARIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TAREFASECUNDARIA_TAREFAPRIMARIA_TarefaPrimariaId",
                        column: x => x.TarefaPrimariaId,
                        principalTable: "TAREFAPRIMARIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EXECUCAO_PomodoroTimerId",
                table: "EXECUCAO",
                column: "PomodoroTimerId");

            migrationBuilder.CreateIndex(
                name: "IX_EXECUCAO_UsuarioId",
                table: "EXECUCAO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TAREFAPRIMARIA_ExecucaoId",
                table: "TAREFAPRIMARIA",
                column: "ExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TAREFASECUNDARIA_TarefaPrimariaId",
                table: "TAREFASECUNDARIA",
                column: "TarefaPrimariaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAREFASECUNDARIA");

            migrationBuilder.DropTable(
                name: "TAREFAPRIMARIA");

            migrationBuilder.DropTable(
                name: "EXECUCAO");

            migrationBuilder.DropTable(
                name: "POMODOROTIMER");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
