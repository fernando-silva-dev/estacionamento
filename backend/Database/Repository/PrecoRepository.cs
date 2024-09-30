using Domain;

namespace Database.Repository;

public class PrecoRepository
{
    private readonly Context context;

    public PrecoRepository(Context context)
    {
        this.context = context;
    }

    public IQueryable<Preco> Listar()
        => context.Precos;

    public long Add(Preco preco)
    {
        var result = context.Add(preco);
        context.SaveChanges();

        return result.Entity.Id;
    }
}