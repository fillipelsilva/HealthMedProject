using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMed.Domain.Entities
{
    public class Consulta : EntityBase
    {
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;

        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;

        public Guid AgendaDiaId { get; set; }
        public AgendaDia AgendaDia { get; set; } = null!;

        public TimeSpan Horario { get; set; }
    }
}
