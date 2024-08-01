using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class CriarHorarioConsultaDTO
    {
        public TimeSpan Horario { get; set; }
        public bool Disponivel { get; set; }

        public Guid AgendaDiaId { get; set; }
    }
}
