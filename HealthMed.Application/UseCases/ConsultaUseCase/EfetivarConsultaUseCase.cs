using AutoMapper;
using HealthMed.Application.DTOs;
using HealthMed.Application.Services;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.UseCases.ConsultaUseCase
{
    public class EfetivarConsultaUseCase
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public EfetivarConsultaUseCase(IConsultaRepository consultaRepository, HttpClient httpClient, IMapper mapper, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
        {
            _consultaRepository = consultaRepository;
            _httpClient = httpClient;
            _mapper = mapper;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
        }

        public async Task Execute(CriacaoConsultaDTO consultaDTO)
        {
            var urlMedico = "https://send-email-grupo1-hackathon.azurewebsites.net/send-email";
            var urlPaciente = "https://send-email-grupo1-hackathon.azurewebsites.net/send-email-patient";

            var medico = await _medicoRepository.ObterPorId(consultaDTO.MedicoId);
            var paciente = await _pacienteRepository.ObterPorIdComConsulta(consultaDTO.PacienteId);

            if (_consultaRepository.Find(x => x.MedicoId == consultaDTO.MedicoId && x.Horario.ToString() == consultaDTO.Horario) is null)
            {
                await EnviarEmail(urlPaciente, FormatarEmailErro(paciente, medico));
            }
            else
            {

                await _consultaRepository.Adicionar(_mapper.Map<Consulta>(consultaDTO));
                await EnviarEmail(urlMedico, FormatarEmail(medico, paciente));
            }
        }

        private string FormatarEmailErro(Paciente paciente, Medico medico)
        {
            EmailDTO email = new EmailDTO();

            var appointmentData = paciente.Consultas.FirstOrDefault(x => x.PacienteId == paciente.Id)!.AgendaDia.Data.ToString("yyyy-MM-dd") + "T"; 
            var appointmentHora = paciente.Consultas.FirstOrDefault(x => x.PacienteId == paciente.Id).Horario;
            var hora = string.Concat(appointmentData, appointmentHora);

            email.Patient = paciente.Nome;
            email.To = paciente.Email;
            email.Appointment = hora;
            email.Doctor = medico.Nome;
            email.IsConfirmed = false;

            return JsonConvert.SerializeObject(email);
        }

        private string FormatarEmail(Medico medico, Paciente paciente)
        {
            EmailDTO email = new EmailDTO();

            var appointmentData = paciente.Consultas.FirstOrDefault(x => x.PacienteId == paciente.Id)!.AgendaDia.Data.ToString("yyyy-MM-dd") + "T";
            var appointmentHora = paciente.Consultas.FirstOrDefault(x => x.PacienteId == paciente.Id).Horario;
            var hora = string.Concat(appointmentData, appointmentHora);

            email.Patient = paciente.Nome;
            email.To = paciente.Email;
            email.Appointment = hora;
            email.Doctor = medico.Nome;

            return JsonConvert.SerializeObject(email);

        }

        public async Task EnviarEmail(string apiUrl, string json)
        {
            using (var httpClient = new HttpClient())
            {
                // Create a StringContent object from the JSON message
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Send the message via POST request
                    var response = await httpClient.PostAsync(apiUrl, content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
