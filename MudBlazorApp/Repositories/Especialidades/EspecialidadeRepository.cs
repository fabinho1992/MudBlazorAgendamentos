using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Data;
using MudBlazorApp.Models;

namespace MudBlazorApp.Repositories.Especialidades
{
    public class EspecialidadeRepository : IEspecialidadesRepository
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Especialidade>> GetAllAsync()
        {
            return await _context.Especialidades
                .AsNoTracking().ToListAsync();
        }
    }
}
