using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Data;
using MudBlazorApp.Models;

namespace MudBlazorApp.Repositories.Medicos
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Medico medico)
        {
            try
            {
                await _context.Medicos.AddAsync(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
            
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await GetByIdAsync(id);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            return await _context.Medicos.Include(e => e.Especialidade)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Medico?> GetByIdAsync(int id)
        {
            return await _context.Medicos.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Medico medico)
        {
            try
            {
                _context.Medicos.Update(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
            
        }
    }
}
