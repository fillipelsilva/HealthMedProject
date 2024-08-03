using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class PacienteDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public List<PacienteConsultaDTO> Consultas { get; set; }
    }
}
