using MudBlazorApp.Models;

namespace MudBlazorApp.Repositories.Pacientes
{
    public interface IPacienteRepository
    {
        Task AddAsync(Paciente paciente);
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(int id);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(int id);
    }
}
