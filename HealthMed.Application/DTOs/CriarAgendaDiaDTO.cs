﻿using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class CriarAgendaDiaDTO
    {
        public DateTime Data { get; set; }
        public List<CriarHorarioConsultaDTO>? Horarios { get; set; }
        public Guid AgendaDiaId { get; set; }
    }
}
