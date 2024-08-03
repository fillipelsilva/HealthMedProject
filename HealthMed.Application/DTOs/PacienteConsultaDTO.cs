using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class PacienteConsultaDTO
    {
        public DateTime Data { get; set; }

        public TimeSpan Horario { get; set; }
        public Guid PacienteId  { get; set; }
        public Guid MedicoId  { get; set; }
    }
}
