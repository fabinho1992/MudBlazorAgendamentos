using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorApp.Extensions;
using MudBlazorApp.Models;
using MudBlazorApp.Repositories.Especialidades;
using MudBlazorApp.Repositories.Medicos;

namespace MudBlazorApp.Components.Pages.Medicos
{
    public class CreateMedicosPage : ComponentBase
    {
        [Inject]
        public IEspecialidadesRepository EspecialidadesRepository { get; set; } = null!;
        [Inject]
        public IMedicoRepository MedicoRepository { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public IEnumerable<Especialidade> Especialidades { get; set; } = new List<Especialidade>();

        public MedicoInputModel InputModel { get; set; } = new MedicoInputModel();


        public async Task OnValidSubmit(EditContext editContext)
        {
            try
            {
                if (editContext.Model is MedicoInputModel model)
                {
                    var medico = new Medico
                    {
                        Nome = model.Nome,
                        Documento = model.Documento.SomenteCaracteres(),
                        Celular = model.Celular.SomenteCaracteres(),
                        Crm = model.Crm.SomenteCaracteres(),
                        EspecialidadeId = model.EspecialidadeId
                    };

                    await MedicoRepository.AddAsync(medico);
                    Snackbar.Add("Médico adicionado com sucesso !", Severity.Success);
                    NavigationManager.NavigateTo("/medicos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            
            
        }

        protected override async Task OnInitializedAsync()
        {
            Especialidades = await EspecialidadesRepository.GetAllAsync();
        }

    }
}
