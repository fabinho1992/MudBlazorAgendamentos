using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Models;

namespace MudBlazorApp.Data
{
    public class DbInitializer // aqui quando fazer a migração , já vou inserir esse dados no banco
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal void Seed()
        {
            var idAtendente = Guid.NewGuid().ToString();
            var idMedico = Guid.NewGuid().ToString();


            _modelBuilder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole
                    {
                        Id = "e756989a-3969-4b40-a970-04696459190c",
                        Name = "Atendente",
                        NormalizedName = "ATENDENTE"
                    },
                    new IdentityRole
                    {
                        Id = "95728255-147e-4153-850e-04337452584c",
                        Name = "Medico",
                        NormalizedName = "MEDICO"
                    }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            var idNewAtendente = Guid.NewGuid().ToString();

            _modelBuilder.Entity<Atendente>().HasData
                (
                    new Atendente
                    {
                        Id = "37595665-0425-451d-8661-951599149790",
                        Nome = "Pro Consulta",
                        Email = "proconsulta@gmail.com",
                        EmailConfirmed = true,
                        UserName = "proconsulta@gmail.com",
                        NormalizedEmail = "PROCONSULTA@GMAIL.COM",
                        NormalizedUserName = "PROCONSULTA@GMAIL.COM",
                        PasswordHash = hasher.HashPassword(null, "F@b250511")
                    }
                );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = "e756989a-3969-4b40-a970-04696459190c",
                        UserId = "37595665-0425-451d-8661-951599149790"

                    }
                );

            _modelBuilder.Entity<Especialidade>().HasData
                (
                    new Especialidade { Id = 1, Nome = "Ortopedia", Descricao = "Especialidade médica que cuida dos ossos" },
                    new Especialidade { Id = 2, Nome = "Cardiologia", Descricao = "Especialidade médica que cuida do coração" },
                    new Especialidade { Id = 3, Nome = "Pediatria", Descricao = "Especialidade médica que cuida de crianças" },
                    new Especialidade { Id = 4, Nome = "Ginecologia", Descricao = "Especialidade médica que cuida do sistema reprodutor feminino" },
                    new Especialidade { Id = 5, Nome = "Dermatologia", Descricao = "Especialidade médica que cuida da pele" }
                );

        }
    }
}
