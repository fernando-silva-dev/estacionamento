using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Precos", new string[] {"HoraInicial", "HoraAdicional", "InicioVigencia", "FimVigencia", "Id"}, new object[] {2, 1, new DateTime(2024,1,1).ToUniversalTime(), new DateTime(2024,12,31).ToUniversalTime(), 1} );
            migrationBuilder.InsertData("Estacionamentos", new string[] {"Id", "HoraEntrada", "HoraSaida", "Placa", "PrecoId"}, new object[] {1, DateTime.Now.ToUniversalTime(), DateTime.Now.AddHours(1).ToUniversalTime(), "AAA-9999", 1} );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Estacionamentos", "Id", "1");
            migrationBuilder.DeleteData("Precos", "Id", "1");
        }
    }
}
