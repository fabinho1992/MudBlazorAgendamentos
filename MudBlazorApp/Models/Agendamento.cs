namespace MudBlazorApp.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string? Observacao { get; set; }
        public TimeSpan HoraConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public Paciente Paciente { get; set; } = null!;
        public Medico Medico { get; set; } = null!;
    }
}
