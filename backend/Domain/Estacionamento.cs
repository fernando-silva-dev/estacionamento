namespace Domain;

public class Estacionamento
{
    public long Id { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime? HoraSaida { get; set; }
    public required string Placa { get; set; }
    public Preco? Preco { get; set; }
    double? DuracaoMinutos
        => HoraSaida?.Subtract(HoraEntrada).TotalMinutes;

    public decimal? HorasCobradas
    {
        get
        {
            // O valor da hora adicional possui uma tolerância de 10 minutos para cada 1 hora.
            const int toleranciaMinutos = 10;

            if(!DuracaoMinutos.HasValue)
                return null;

            // Será cobrado metade do valor da hora inicial quando o tempo 
            // total de permanência no estacionamento for igual ou inferior a 30 minutos.
            if(DuracaoMinutos <= 30)
                return 0.5m;

            return (decimal)Math.Ceiling((DuracaoMinutos.Value - toleranciaMinutos) / 60);
        }
    }

    public decimal? ValorTotal
    {
        get
        {
            var horas = HorasCobradas;
            if (horas.HasValue && Preco is not null)
            {
                // Será cobrado metade do valor da hora inicial quando o tempo 
                // total de permanência no estacionamento for igual ou inferior a 30 minutos.
                if (horas <= 0.5m)
                    return Preco.HoraInicial / 2;

                return Preco.HoraInicial + (Preco.HoraAdicional * (horas - 1));
            }

            return null;
        }
    }
}
