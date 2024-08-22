using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorApp.Extensions;
using MudBlazorApp.Models;
using MudBlazorApp.Repositories.Pacientes;

namespace MudBlazorApp.Components.Pages.Pacientes
{
    public class CreatePacientePage : ComponentBase
    {
        [Inject]
        public IPacienteRepository Repository { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public PacienteInputModel InputModel { get; set; } = new PacienteInputModel();
        public DateTime? DataNascimento { get; set; } = DateTime.Today;
        public DateTime? MaxDate {  get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PacienteInputModel model)
                {
                    var paciente = new Paciente 
                    {
                        Nome = model.Nome,
                        Documento = model.Documento.SomenteCaracteres(),
                        Email = model.Email,
                        Celular = model.Celular.SomenteCaracteres(),
                        DataNascimento = DataNascimento.Value
                    };
                    await Repository.AddAsync(paciente);
                    Snackbar.Add("Paciente adicionado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/pacientes");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
                throw;
            }
        }
    }
}
