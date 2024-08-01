using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using HealthMed.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Infraestructure.Repositories
{
    public class HorarioConsultaRepository : Repository<HorarioConsulta>, IHorarioConsultaRepository
    {
        public HorarioConsultaRepository(AppDbContext Context) : base(Context)
        {
        }
    }
}
