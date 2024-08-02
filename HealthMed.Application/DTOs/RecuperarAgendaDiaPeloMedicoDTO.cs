using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class RecuperarAgendaDiaPeloMedicoDTO
    {
        public DateTime Data { get; set; }
        public Guid AgendaId { get; set; }
        public List<HorarioConsultaDTO> Horarios {get;set;}
    }
}
