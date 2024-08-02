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
    public class ConsultaRepository : Repository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(AppDbContext Context) : base(Context)
        {
        }

        public async Task<Consulta> ObterComMedicoEPacientePorId(Guid id)
        {
            return _context.Consultas
                .Include(x => x.Medico)
                .Include(a => a.Paciente)
                .Include(a => a.AgendaDia)
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }
    }
}
