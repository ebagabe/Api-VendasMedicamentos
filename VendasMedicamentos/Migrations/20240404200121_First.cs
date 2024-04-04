using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VendasMedicamentos.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_medicamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false),
                    quantidadeestoque = table.Column<int>(name: "quantidade_estoque", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_medicamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_representantes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    datanascimento = table.Column<DateOnly>(name: "data_nascimento", type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_representantes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_vendas_medicamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clienteid = table.Column<int>(name: "cliente_id", type: "integer", nullable: false),
                    medicamentoid = table.Column<int>(name: "medicamento_id", type: "integer", nullable: false),
                    representanteid = table.Column<int>(name: "representante_id", type: "integer", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    datavenda = table.Column<DateTime>(name: "data_venda", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendas_medicamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_vendas_medicamentos_tb_clientes_cliente_id",
                        column: x => x.clienteid,
                        principalTable: "tb_clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_vendas_medicamentos_tb_medicamentos_medicamento_id",
                        column: x => x.medicamentoid,
                        principalTable: "tb_medicamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_vendas_medicamentos_tb_representantes_representante_id",
                        column: x => x.representanteid,
                        principalTable: "tb_representantes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_medicamentos_cliente_id",
                table: "tb_vendas_medicamentos",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_medicamentos_medicamento_id",
                table: "tb_vendas_medicamentos",
                column: "medicamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_medicamentos_representante_id",
                table: "tb_vendas_medicamentos",
                column: "representante_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_vendas_medicamentos");

            migrationBuilder.DropTable(
                name: "tb_clientes");

            migrationBuilder.DropTable(
                name: "tb_medicamentos");

            migrationBuilder.DropTable(
                name: "tb_representantes");
        }
    }
}
