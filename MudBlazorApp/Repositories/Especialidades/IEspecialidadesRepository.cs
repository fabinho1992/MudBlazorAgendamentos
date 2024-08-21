using MudBlazorApp.Models;

namespace MudBlazorApp.Repositories.Especialidades
{
    public interface IEspecialidadesRepository
    {
        Task<IEnumerable<Especialidade>> GetAllAsync();
    }
}
