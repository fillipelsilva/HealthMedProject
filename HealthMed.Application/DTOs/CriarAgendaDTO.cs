using HealthMed.Domain.Entities;

namespace HealthMed.Application.DTOs
{
    public class CriarAgendaDTO
    {

        public Guid Id { get; set; }
        public Guid MedicoId { get; set; }
        public string Nome { get; set; }
    }
}
