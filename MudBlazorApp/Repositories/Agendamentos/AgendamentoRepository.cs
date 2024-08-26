using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Data;
using MudBlazorApp.Models;

namespace MudBlazorApp.Repositories.Agendamentos
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Agendamento agendamento)
        {
            await _context.Agendamentos.AddAsync(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var agendamento = await GetByIdAsync(id);
            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            return await _context.Agendamentos.Include(x => x.Medico).Include(x => x.Paciente)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AgendamentosAnuais>?> GetReportYear()
        {
            var result = _context.Database.SqlQuery<AgendamentosAnuais>
                (
                    $"SELECT MONTH(DATACONSULTA) AS MES, COUNT(*) AS QUANTIDADEAGENDAMENTOS FROM AGENDAMENTOS WHERE YEAR(DATACONSULTA) = '2024' GROUP BY MONTH(DATACONSULTA) ORDER BY MES "
                );
            return await Task.FromResult( result.ToList() );
        }

        public async Task UpdateAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            await _context.SaveChangesAsync();
        }
    }
}
