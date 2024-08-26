using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorApp.Models;
using MudBlazorApp.Repositories.Agendamentos;

namespace MudBlazorApp.Components.Pages.Agendamentos
{
	public class IndexAgendamentosPage : ComponentBase
	{
		[Inject]
		public IAgendamentoRepository AgendamentoRepository { get; set; } = null!;
		[Inject]
		public IDialogService Dialog { get; set; } = null!;
		[Inject]
		public ISnackbar Snackbar { get; set; } = null!;
		[Inject]
		public NavigationManager NavigationManager { get; set; } = null!;

		public IEnumerable<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public bool HideButtons { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }// para ver o estado de autenticação do usuario e sua role

        protected override async Task OnInitializedAsync()
        {
			var auth = await AuthenticationState;

			HideButtons = !auth.User.IsInRole("Atendente");

            Agendamentos = await AgendamentoRepository.GetAllAsync();
        }

        public async Task DeleteAgendamento(Agendamento agendamento)
		{
			try
			{
				var result = await Dialog.ShowMessageBox
					(
						"Atenção",
						$"Deseja excluir o agendamento?",
						yesText: "Sim",
						cancelText: "Não"
					);
				if (result is true)
				{
					await AgendamentoRepository.DeleteAsync(agendamento.Id);
					Snackbar.Add("Agendamento excluído do sucesso!", Severity.Success);
					await OnInitializedAsync();
				}
			}
			catch (Exception ex)
			{
				Snackbar.Add(ex.Message, Severity.Error);
			}
		}

		
	}
}
