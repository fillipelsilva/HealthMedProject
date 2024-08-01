using HealthMed.Domain.Entities;

namespace HealthMed.Application.DTOs
{
    public class AlterarAgendaDTO
    {
        public AlterarAgendaDTO(Guid id, List<AlterarAgendaDiaDTO> dias, Guid medicoId)
        {
            Id = id;
            Dias = dias;
            MedicoId = medicoId;
        }

        public Guid Id { get; set; }
        public List<AlterarAgendaDiaDTO> Dias { get; set; }
        public Guid MedicoId { get; set; }
    }
}
