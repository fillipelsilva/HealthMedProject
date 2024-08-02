using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class AgendaDTO
    {
        public List<RecuperarAgendaDiaPeloMedicoDTO> Dias { get; set; }

        public string Nome { get; set; }
    }
}
