using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class MedicoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<AgendaDTO> Agendas { get; set; }
    }
}
