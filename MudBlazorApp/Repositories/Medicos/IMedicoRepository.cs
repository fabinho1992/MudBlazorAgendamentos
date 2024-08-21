using MudBlazorApp.Models;

namespace MudBlazorApp.Repositories.Medicos
{
    public interface IMedicoRepository
    {
        Task AddAsync(Medico medico);
        Task<IEnumerable<Medico>> GetAllAsync();
        Task<Medico?> GetByIdAsync(int id);
        Task UpdateAsync(Medico medico);
        Task DeleteAsync(int id);
    }
}
