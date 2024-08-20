using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazorApp.Models;

namespace MudBlazorApp.Data.Configurations
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Observacao).HasMaxLength(150)
                .IsRequired(false);

            builder.Property(a => a.MedicoId).IsRequired();

            builder.Property(a => a.PacienteId).IsRequired();


        }
    }
}
