using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using HealthMed.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Infraestructure.Repositories
{
    public class AgendaDiaRepository : Repository<AgendaDia>, IAgendaDiaRepository
    {
        public AgendaDiaRepository(AppDbContext Context) : base(Context)
        {
        }

        public async Task<AgendaDia> ObterPorIdPeloMedico(Guid id)
        {
            return _context.AgendaDias
                .Include(ad => ad.Horarios)
                .Include(ad => ad.Consultas)
                .ThenInclude(ad => ad.Paciente)
                .Where(ad => ad.Id == id).FirstOrDefault();
        }
    }
}
