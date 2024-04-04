using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasMedicamentos.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDataVendaFromVendaMedicamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_venda",
                table: "tb_vendas_medicamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_venda",
                table: "tb_vendas_medicamentos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
