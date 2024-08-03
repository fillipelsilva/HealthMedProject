using HealthMed.Domain.Entities;

namespace HealthMed.Domain.Repositories
{
    public interface IConsultaRepository : IRepository<Consulta>
    {
        Task<Consulta> ObterComMedicoEPacientePorId(Guid id);

    }
}
