using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class AutenticarPacienteDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
