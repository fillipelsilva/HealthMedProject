using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Repositories
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<Medico> ObterPorIdComConsulta(Guid medicoId);
        Task<List<Medico>> ObterTodosMedicosComAgenda();
    }
}
