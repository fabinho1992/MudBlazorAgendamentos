using MudBlazorApp.Models;

namespace MudBlazorApp.Repositories.Agendamentos
{
    public interface IAgendamentoRepository
    {
        Task AddAsync(Agendamento agendamento);
        Task<IEnumerable<Agendamento>> GetAllAsync();
        Task<Agendamento?> GetByIdAsync(int id);
        Task UpdateAsync(Agendamento agendamento);
        Task DeleteAsync(int id);
    }
}
