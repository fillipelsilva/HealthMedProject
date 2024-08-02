using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class RecuperarConsultaPeloMedicoDTO
    {
        public Guid PacienteId { get; set; }
        public PacienteDTO Paciente { get; set; } = null!;
        public TimeSpan Horario { get; set; }
    }
}
