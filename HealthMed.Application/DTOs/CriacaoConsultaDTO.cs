using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class CriacaoConsultaDTO
    {
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public Guid AgendaDiaId { get; set; }
        public string Horario { get; set; }
    }
}
