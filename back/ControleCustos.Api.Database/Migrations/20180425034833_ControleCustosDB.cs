using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleCustos.Api.Database.Migrations
{
    public partial class ControleCustosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ControleCustosDB");

            migrationBuilder.CreateTable(
                name: "Departamento",
                schema: "ControleCustosDB",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CodigoDepartamento", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                schema: "ControleCustosDB",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartamentoCodigo = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CodigoFuncionario", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Funcionario_Departamento_DepartamentoCodigo",
                        column: x => x.DepartamentoCodigo,
                        principalSchema: "ControleCustosDB",
                        principalTable: "Departamento",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                schema: "ControleCustosDB",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 500, nullable: true),
                    FuncionarioCodigo = table.Column<int>(nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CodigoMovimentacao", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Funcionario_FuncionarioCodigo",
                        column: x => x.FuncionarioCodigo,
                        principalSchema: "ControleCustosDB",
                        principalTable: "Funcionario",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoCodigo",
                schema: "ControleCustosDB",
                table: "Funcionario",
                column: "DepartamentoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_FuncionarioCodigo",
                schema: "ControleCustosDB",
                table: "Movimentacao",
                column: "FuncionarioCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao",
                schema: "ControleCustosDB");

            migrationBuilder.DropTable(
                name: "Funcionario",
                schema: "ControleCustosDB");

            migrationBuilder.DropTable(
                name: "Departamento",
                schema: "ControleCustosDB");
        }
    }
}
