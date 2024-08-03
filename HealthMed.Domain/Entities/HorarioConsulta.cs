using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMed.Domain.Entities
{
    public class HorarioConsulta : EntityBase
    {
        public TimeSpan Horario { get; set; }
        public bool Disponivel { get; set; }

        public Guid AgendaDiaId { get; set; }
        public AgendaDia AgendaDia { get; set; }

        public HorarioConsulta(TimeSpan horario, bool disponivel = true)
        {
            Horario = horario;
            Disponivel = disponivel;
        }

        public override string ToString()
        {
            return $"{Horario} - {(Disponivel ? "Disponível" : "Indisponível")}";
        }

        public void DefinirDia(AgendaDia diaConsulta)
        {
            AgendaDia = diaConsulta;
        }
    }
}
