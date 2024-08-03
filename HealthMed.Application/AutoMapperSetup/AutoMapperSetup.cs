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
            CreateMap<AgendaDTO, Agenda>();
            CreateMap<RecuperarAgendaDiaPeloMedicoDTO, AgendaDia>();
            CreateMap<HorarioConsultaDTO, HorarioConsulta>();
            CreateMap<RecuperarConsultaPeloMedicoDTO, Consulta>();
            CreateMap<RecuperarAgendaDiaDTO, AgendaDia>();
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<MedicoDTO, Medico>();
            CreateMap<ConsultaDTO, Consulta>();
            CreateMap<PacienteConsultaDTO, Consulta>();

            #endregion

            #region DomainToViewModel

            CreateMap<AgendaDia, CriarAgendaDiaDTO>();
            CreateMap<Agenda, AgendaDTO>();
            CreateMap<AgendaDia, RecuperarAgendaDiaPeloMedicoDTO>();
            CreateMap<HorarioConsulta, HorarioConsultaDTO>();
            CreateMap<Consulta, RecuperarConsultaPeloMedicoDTO>();
            CreateMap<AgendaDia, RecuperarAgendaDiaDTO>();
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<Medico, MedicoDTO>();
            CreateMap<Consulta, PacienteConsultaDTO>();
            CreateMap<Consulta, ConsultaDTO>()
                .ForMember(c => c.Data, opt => opt.MapFrom(x => x.AgendaDia.Data));

            #endregion
        }
    }
}
