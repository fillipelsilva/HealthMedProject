using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMed.Domain.Entities
{
    public class Agenda : EntityBase
    {
        public List<AgendaDia> Dias { get; set; }

        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }
        public string Nome { get; set; }
        public Agenda()
        {
                
        }

        public Agenda(Guid medicoId, string nome)
        {
            MedicoId = medicoId;
            Nome = nome;    
        }

        public void AdicionarHorario(DateTime data, TimeSpan horario)
        {
            var agendaDia = Dias.FirstOrDefault(d => d.Data == data);
            if (agendaDia != null)
            {
                agendaDia.AdicionarHorario(horario);
            }
        }

        public void RemoverHorario(DateTime data, TimeSpan horario)
        {
            var agendaDia = Dias.FirstOrDefault(d => d.Data == data);
            if (agendaDia != null)
            {
                agendaDia.RemoverHorario(horario);
            }
        }

        public void AlterarDisponibilidade(DateTime Data, TimeSpan horario, bool disponivel)
        {
            var agendaDia = Dias.FirstOrDefault(d => d.Data == Data);
            if (agendaDia != null)
            {
                agendaDia.AlterarDisponibilidade(horario, disponivel);
            }
        }

        public override string ToString()
        {
            return string.Join("\n", Dias);
        }

        public void AlterarAgenda(List<AgendaDia> dias)
        {
            Dias = dias;
        }
    }
}
