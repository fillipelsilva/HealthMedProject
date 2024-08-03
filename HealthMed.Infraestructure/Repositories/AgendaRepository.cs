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
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(AppDbContext Context) : base(Context)
        {
        }

        public async Task<Agenda> ObterComDiasPorId(Guid id)
        {
            return _context.Agendas
                .Include(a => a.Dias)
                .ThenInclude(d => d.Horarios.Where(x => x.Disponivel))
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public async Task<List<Agenda>?> ObterPorMedicoId(Guid medicoId)
        {
            return _context.Agendas
                .Include(x => x.Medico)
                .Include(a => a.Dias)
                .ThenInclude(d => d.Horarios.Where(x => x.Disponivel))
                .Where(a => a.MedicoId == medicoId)
                .ToList();
        }
    }
}
