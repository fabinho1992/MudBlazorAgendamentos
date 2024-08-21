using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazorApp.Models;
using MudBlazorApp.Repositories.Pacientes;

namespace MudBlazorApp.Components.Pages
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IPacienteRepository Repository { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public IEnumerable<Paciente> Pacientes { get; set; } = new List<Paciente>();

        public async Task DeletePaciente(Paciente paciente)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                    (
                        "Atenção",
                        $"Deseja excluir o paciente {paciente.Nome}?",
                        yesText: "Sim",
                        cancelText: "Não"
                    );
                if(result is true)
                {
                    await Repository.DeleteAsync(paciente.Id);
                    Snackbar.Add($"Paciente {paciente.Nome} excluído do sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }


            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/pacientes/update/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            Pacientes = await Repository.GetAllAsync();
        }
    }
}
