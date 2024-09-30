using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Precos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InicioVigencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FimVigencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoraInicial = table.Column<decimal>(type: "numeric", nullable: false),
                    HoraAdicional = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoraEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoraSaida = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    PrecoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estacionamentos_Precos_PrecoId",
                        column: x => x.PrecoId,
                        principalTable: "Precos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamentos_Placa",
                table: "Estacionamentos",
                column: "Placa");

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamentos_PrecoId",
                table: "Estacionamentos",
                column: "PrecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "Precos");
        }
    }
}
