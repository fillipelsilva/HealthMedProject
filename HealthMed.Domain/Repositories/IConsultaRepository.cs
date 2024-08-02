﻿using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Repositories
{
    public interface IConsultaRepository : IRepository<Consulta>
    {
        Task<Consulta> ObterComMedicoEPacientePorId(Guid id);
    }
}
