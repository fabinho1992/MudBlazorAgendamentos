using System.ComponentModel.DataAnnotations;

namespace MudBlazorApp.Components.Pages.Agendamentos
{
	public class AgendamentoInputModel
	{
		public int Id { get; set; }
		public string? Observacao { get; set; }
		[Required(ErrorMessage = "{0} Obrigatório")]
		public TimeSpan HoraConsulta { get; set; }
		[Required(ErrorMessage = "{0} Obrigatório")]
		public DateTime DataConsulta { get; set; }
		[Required(ErrorMessage = "{0} Obrigatório")]
		public int PacienteId { get; set; }
		[Required(ErrorMessage = "{0} Obrigatório")]
		public int MedicoId { get; set; }
	}
}
