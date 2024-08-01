using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMed.Domain.Entities
{
    public class AgendaDia : EntityBase
    {
        public DateTime Data { get; set; }
        public Guid AgendaId { get; set; }
        public Agenda Agenda { get; set; }

        //EF REL.
        public List<HorarioConsulta>? Horarios { get; set; }
        public List<Consulta> Consultas { get; set; }

        public AgendaDia(DateTime data)
        {
            Data = data;
            Horarios = new List<HorarioConsulta>();
            Consultas = new List<Consulta>();
        }

        public void AdicionarHorario(TimeSpan horario)
        {
            Horarios.Add(new HorarioConsulta(horario));
        }

        public void RemoverHorario(TimeSpan horario)
        {
            Horarios.RemoveAll(h => h.Horario == horario);
        }

        public void AlterarDisponibilidade(TimeSpan horario, bool disponivel)
        {
            var horarioConsulta = Horarios.FirstOrDefault(h => h.Horario == horario);
            if (horarioConsulta != null)
            {
                horarioConsulta.Disponivel = disponivel;
            }
        }

        public override string ToString()
        {
            return $"{Data}:\n" + string.Join("\n", Horarios);
        }
    }
}
