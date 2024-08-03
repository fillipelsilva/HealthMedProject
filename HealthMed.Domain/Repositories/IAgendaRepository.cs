using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Repositories
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        Task<Agenda> ObterComDiasPorId(Guid id);
        Task<List<Agenda>?> ObterPorMedicoId(Guid medicoId);
    }
}
