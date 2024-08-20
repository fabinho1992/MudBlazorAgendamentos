using System.Collections.ObjectModel;

namespace MudBlazorApp.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Crm { get; set; } = null!;
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; } = null!;
        public ICollection<Agendamento> Agendamentos { get; set; } = new Collection<Agendamento>();
    }
}
