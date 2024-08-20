using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazorApp.Models;

namespace MudBlazorApp.Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nome).HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Email).HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Documento).HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.Celular).HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(p => p.Documento).IsUnique();

            builder.HasMany(a => a.Agendamentos)
                .WithOne(p => p.Paciente).HasForeignKey(a => a.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
