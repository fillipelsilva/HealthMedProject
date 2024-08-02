using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class RecuperarAgendaDiaDTO
    {
        public DateTime Data { get; set; }
        public Guid AgendaId { get; set; }
        public List<HorarioConsultaDTO> Horarios { get; set; }
        public List<RecuperarConsultaPeloMedicoDTO> Consultas { get; set; }
    }
}
