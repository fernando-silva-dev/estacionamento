using Domain;
using Microsoft.EntityFrameworkCore;
namespace Database.Repository;

public class EstacionamentoRepository
{
    private readonly Context context;

    public EstacionamentoRepository(Context context)
    {
        this.context = context;
    }

    public IQueryable<Estacionamento> Listar()
        => context.Estacionamentos.Include(e => e.Preco);

    public long Add(Estacionamento estacionamento)
    {
        var preco = BuscarPrecoPorVigencia(estacionamento.HoraEntrada);
        estacionamento.Preco = preco;

        var result = context.Add(estacionamento);
        context.SaveChanges();

        return result.Entity.Id;
    }

    public void MarcarSaida(long id, DateTime saida)
    {
        var estacionamento = context.Estacionamentos.Find(id);
        if (estacionamento is not null)
        {
            estacionamento.HoraSaida = saida;
            context.Estacionamentos.Update(estacionamento);
            context.SaveChanges();
        }
    }

    private Preco? BuscarPrecoPorVigencia(DateTime dataRef)
        => context.Precos.FirstOrDefault(p => p.InicioVigencia <= dataRef && p.FimVigencia >= dataRef);
}
