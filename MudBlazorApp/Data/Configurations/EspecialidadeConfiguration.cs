using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazorApp.Models;

namespace MudBlazorApp.Data.Configurations
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("Especialidades");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome).HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Descricao).HasMaxLength(150)
                .IsRequired();

            builder.HasMany(m => m.Medicos)
                .WithOne(e => e.Especialidade)
                .HasForeignKey(m => m.EspecialidadeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
