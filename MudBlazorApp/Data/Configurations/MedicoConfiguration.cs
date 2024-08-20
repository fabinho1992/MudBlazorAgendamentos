using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazorApp.Models;

namespace MudBlazorApp.Data.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nome).HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Crm).HasMaxLength(8)
                .IsRequired();

            builder.Property(p => p.Documento).HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.Celular).HasMaxLength(11)
                .IsRequired();

            builder.Property(m => m.EspecialidadeId).IsRequired();

            builder.HasIndex(m => m.Documento)
                .IsUnique();

            builder.HasMany(a => a.Agendamentos)
                .WithOne(m => m.Medico)
                .HasForeignKey(a => a.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
