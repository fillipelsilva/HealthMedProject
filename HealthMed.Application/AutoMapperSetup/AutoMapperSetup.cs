using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.AutoMapperSetup
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<CriarAgendaDiaDTO, AgendaDia>();

            #endregion

            #region DomainToViewModel

            CreateMap<AgendaDia, CriarAgendaDiaDTO>();

            #endregion
        }
    }
}
