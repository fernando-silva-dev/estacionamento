using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configuration;

public class PrecoConfiguration : IEntityTypeConfiguration<Preco>
{
    public void Configure(EntityTypeBuilder<Preco> builder)
    {
        builder.HasKey(b => b.Id);
    }
}