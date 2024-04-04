using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VendasMedicamentos.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTabelasInicial : Migration
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
                    telefone = table.Column<string>(type: "varchar(20)", nullable: false)
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
                    quantidadeestoque = table.Column<int>(name: "quantidade_estoque", type: "integer", nullable: false)
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
                    datanascimento = table.Column<DateTime>(name: "data_nascimento", type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_representantes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_vendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idcliente = table.Column<int>(name: "id_cliente", type: "integer", nullable: false),
                    idmedicamento = table.Column<int>(name: "id_medicamento", type: "integer", nullable: false),
                    idrepresentante = table.Column<int>(name: "id_representante", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_clientes_id_cliente",
                        column: x => x.idcliente,
                        principalTable: "tb_clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_medicamentos_id_medicamento",
                        column: x => x.idmedicamento,
                        principalTable: "tb_medicamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_representantes_id_representante",
                        column: x => x.idrepresentante,
                        principalTable: "tb_representantes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_id_cliente",
                table: "tb_vendas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_id_medicamento",
                table: "tb_vendas",
                column: "id_medicamento");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_id_representante",
                table: "tb_vendas",
                column: "id_representante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_vendas");

            migrationBuilder.DropTable(
                name: "tb_clientes");

            migrationBuilder.DropTable(
                name: "tb_medicamentos");

            migrationBuilder.DropTable(
                name: "tb_representantes");
        }
    }
}
