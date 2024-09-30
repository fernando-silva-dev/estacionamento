using Domain;
using FluentAssertions;

namespace Tests;

public class EstacionamentoTests
{
    /*
    O valor da hora adicional possui uma tolerância de 10 minutos para cada 1 hora. 
    Exemplo: 
        30 minutos              valor   R$ 1,00
        1 hora                  valor   R$ 2,00
        1 hora 10 minutos       valor   R$ 2,00
        1 hora e 15 minutos     valor   R$ 3,00
        2 horas e 5 minutos     valor   R$ 3,00
        2 horas e 15 minutos    valor   R$ 4,00
    */

    private readonly Preco preco = new()
    {
        HoraInicial = 2,
        HoraAdicional = 1,
    };

    [Theory]
    [InlineData(0, 30, 1.0)]
    [InlineData(1, 00, 2.0)]
    [InlineData(1, 10, 2.0)]
    [InlineData(1, 15, 3.0)]
    [InlineData(2, 05, 3.0)]
    [InlineData(2, 15, 4.0)]
    public void Calculo_De_Tempo_E_Valor_Deve_Condizer_Com_Tabela(int horas, int minutos, decimal precoEsperado)
    {
        var dataEntrada = DateTime.Now;

        var estacionamento = new Estacionamento()
        {
            Id = 1,
            Placa = "AAA-9999",
            HoraEntrada = dataEntrada,
            HoraSaida = dataEntrada.AddHours(horas).AddMinutes(minutos),
            Preco = preco,
        };

        estacionamento.ValorTotal.Should().Be(precoEsperado);
    }

    [Fact]
    public void Calculo_De_Tempo_Deve_Retornar_Null_Quando_Nao_Houver_Saida()
    {
        var estacionamento = new Estacionamento()
        {
            Id = 1,
            Placa = "AAA-9999",
            HoraEntrada = DateTime.Now,
            HoraSaida = null,
            Preco = preco,
        };

        estacionamento.ValorTotal.Should().BeNull();
    }

    [Fact]
    public void Calculo_De_Tempo_Deve_Retornar_Null_Quando_Nao_Houver_Preco_Associado()
    {
        var estacionamento = new Estacionamento()
        {
            Id = 1,
            Placa = "AAA-9999",
            HoraEntrada = DateTime.Now,
            HoraSaida = DateTime.Now.AddHours(1),
            Preco = null,
        };

        estacionamento.ValorTotal.Should().BeNull();
    }
}