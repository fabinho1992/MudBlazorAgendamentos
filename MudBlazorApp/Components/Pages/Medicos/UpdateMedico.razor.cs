using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorApp.Extensions;
using MudBlazorApp.Models;
using MudBlazorApp.Repositories.Especialidades;
using MudBlazorApp.Repositories.Medicos;

namespace MudBlazorApp.Components.Pages.Medicos
{
    public class UpdateMedicoPage : ComponentBase
    {
        [Parameter]
        public int MedicoId { get; set; }
		[Inject]
		public IEspecialidadesRepository EspecialidadesRepository { get; set; } = null!;
		[Inject]
		public IMedicoRepository MedicoRepository { get; set; } = null!;
		[Inject]
		public ISnackbar Snackbar { get; set; } = null!;
		[Inject]
		public NavigationManager NavigationManager { get; set; } = null!;

		public IEnumerable<Especialidade> Especialidades { get; set; } = new List<Especialidade>();
		public Medico? CurrentMedico { get; set; } = null!;
		public MedicoInputModel InputModel { get; set; } = new();



		public async Task OnValidSubmit(EditContext editContext)
		{
			try
			{
				if (editContext.Model is MedicoInputModel model)
				{
					CurrentMedico.Nome = model.Nome;
					CurrentMedico.Documento = model.Documento.SomenteCaracteres();
					CurrentMedico.Crm = model.Crm.SomenteCaracteres();
					CurrentMedico.Celular = model.Celular.SomenteCaracteres();
					CurrentMedico.EspecialidadeId = model.EspecialidadeId;

				}

				await MedicoRepository.UpdateAsync(CurrentMedico);
				Snackbar.Add("Médico atualizado!", Severity.Success);
				NavigationManager.NavigateTo("/medicos");
			}
			catch (Exception ex)
			{
				Snackbar.Add(ex.Message, Severity.Error);
			}
		}



		protected override async Task OnInitializedAsync()
		{
			CurrentMedico = await MedicoRepository.GetByIdAsync(MedicoId);
			Especialidades = await EspecialidadesRepository.GetAllAsync();

			if (CurrentMedico is null)
			{
				return;
			}
			InputModel = new MedicoInputModel
			{
				Id = MedicoId,
				Nome = CurrentMedico.Nome,
				Documento = CurrentMedico.Documento,
				Celular = CurrentMedico.Celular,
				Crm = CurrentMedico.Crm,
				EspecialidadeId = CurrentMedico.EspecialidadeId
			};
		}
	}
}
