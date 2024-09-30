using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configuration;

public class EstacionamentoConfiguration : IEntityTypeConfiguration<Estacionamento>
{
    public void Configure(EntityTypeBuilder<Estacionamento> builder)
    {
        builder.HasKey(b => b.Id);
        // Utilizar a placa do veículo como chave de busca.
        builder.HasIndex(b => b.Placa);
        builder.HasOne(b => b.Preco).WithMany();
    }
}