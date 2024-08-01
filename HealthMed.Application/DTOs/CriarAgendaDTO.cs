using HealthMed.Domain.Entities;

namespace HealthMed.Application.DTOs
{
    public class CriarAgendaDTO
    {
        public CriarAgendaDTO(Guid id, List<CriarAgendaDiaDTO> dias, Guid medicoId)
        {
            Id = id;
            Dias = dias;
            MedicoId = medicoId;
        }

        public Guid Id { get; set; }
        public List<CriarAgendaDiaDTO> Dias { get; set; }
        public Guid MedicoId { get; set; }
    }
}
