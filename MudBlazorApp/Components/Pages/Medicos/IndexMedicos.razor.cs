using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazorApp.Models;
using MudBlazorApp.Repositories.Medicos;

namespace MudBlazorApp.Components.Pages.Medicos
{
    public class IndexMedicosPage : ComponentBase
    {
        [Inject]
        public IMedicoRepository MedicosRepository { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public IEnumerable<Medico> Medicos { get; set; } = new List<Medico>();


        public async Task DeleteMedico(Medico medico)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                    (
                        "Atenção",
                        $"Deseja excluir o paciente {medico.Nome}?",
                        yesText: "Sim",
                        cancelText: "Não"
                    );
                if (result is true)
                {
                    await MedicosRepository.DeleteAsync(medico.Id);
                    Snackbar.Add($"Médico {medico.Nome} excluído do sucesso!", Severity.Success);
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
            NavigationManager.NavigateTo($"/medicos/update/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            Medicos = await MedicosRepository.GetAllAsync();
        }
    }
}
