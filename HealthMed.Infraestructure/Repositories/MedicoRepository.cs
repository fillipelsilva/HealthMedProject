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
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        public MedicoRepository(AppDbContext Context) : base(Context)
        {
        }

        public async Task<Medico> ObterPorIdComConsulta(Guid medicoId)
        {
           throw new NotImplementedException();
        }

        public async Task<List<Medico>> ObterTodosMedicosComAgenda()
        {
            return _context.Medicos
                .Include(x => x.Agendas)
                .ThenInclude(x => x.Dias)
                .ThenInclude(x => x.Horarios)
                .ToList();
        }
    }
}
