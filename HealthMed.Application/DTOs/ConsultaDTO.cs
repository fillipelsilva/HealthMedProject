using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class ConsultaDTO
    {
        public PacienteDTO Paciente { get; set; } = null!;
        public MedicoDTO Medico { get; set; } = null!;
        public DateTime Data { get; set; }

        public TimeSpan Horario { get; set; }
    }
}
