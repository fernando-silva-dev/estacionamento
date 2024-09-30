using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database;
public class Context : DbContext
{
    const string connection = "Server=127.0.0.1;Port=5432;Database=estacionamento;User Id=postgres;Password=admin;";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseNpgsql(connection);


    public virtual DbSet<Estacionamento> Estacionamentos { get; set; }
    public virtual DbSet<Preco> Precos { get; set; }
}
