using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorApp.Models;
using MudBlazorApp.Repositories.Agendamentos;
using MudBlazorApp.Repositories.Medicos;
using MudBlazorApp.Repositories.Pacientes;

namespace MudBlazorApp.Components.Pages.Agendamentos
{
	public class CreateAgendamentosPage : ComponentBase
	{
		[Inject]
		public IMedicoRepository MedicoRepository { get; set; } = null!;
		[Inject]
		public IPacienteRepository PacienteRepository { get; set;} = null!;
		[Inject]
		public IAgendamentoRepository AgendamentoRepository { get; set;} = null!;
		[Inject]
		public ISnackbar Snackbar { get; set; } = null!;
		[Inject]
		public NavigationManager NavigationManager { get; set; } = null!;


		public IEnumerable<Medico> Medicos { get; set; } = new List<Medico>();
		public IEnumerable<Paciente> Pacientes { get; set; } = new List<Paciente>();
		public AgendamentoInputModel InputModel { get; set; }= new AgendamentoInputModel();
		public DateTime? date { get; set; } = DateTime.Now.Date;
		public DateTime? minDate { get; set; } = DateTime.Now.Date;

		public TimeSpan? time = new TimeSpan (09, 00, 00);


		public async Task OnValidSubmit(EditContext editContext)
		{
			try
			{
				if (editContext.Model is AgendamentoInputModel model)
				{
					var agendamento = new Agendamento
					{
						Observacao = model.Observacao,
						MedicoId = model.MedicoId,
						PacienteId = model.PacienteId,
						DataConsulta = date!.Value,
						HoraConsulta = time!.Value
					};

					await AgendamentoRepository.AddAsync(agendamento);
					Snackbar.Add($"Agendamento marcado com sucesso, para o dia {agendamento.DataConsulta}", Severity.Success);
					NavigationManager.NavigateTo("/agendamentos");
				}
			}
			catch (Exception ex)
			{
				 Snackbar.Add(ex.Message, Severity.Error);
			}
		}


		protected override async Task OnInitializedAsync()
		{
			Pacientes = await PacienteRepository.GetAllAsync();
			Medicos = await MedicoRepository.GetAllAsync();
		}
	}
}
