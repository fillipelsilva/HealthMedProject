using Bogus;
using HealthMed.Domain.Entities;
using System;

namespace HealthMed.Tests.ConsultaTests
{
    public class ConsultaTestsBogus
    {
        public Faker Faker { get; private set; }

        public ConsultaTestsBogus()
        {
            Faker = new Faker("pt_BR"); // Configura o Faker para gerar dados em português brasileiro
        }

        public Consulta GerarConsultaValida()
        {
            var fakerConsulta = new Faker<Consulta>("pt_BR")
                .CustomInstantiator(f => new Consulta
                {
                    PacienteId = Guid.NewGuid(),
                    MedicoId = Guid.NewGuid(),
                    AgendaDiaId = Guid.NewGuid(),
                    Horario = f.Date.Timespan()
                });

            return fakerConsulta.Generate();
        }

        public Consulta GerarConsultaInvalida()
        {
            return new Consulta
            {
                PacienteId = Guid.Empty,
                MedicoId = Guid.Empty,
                AgendaDiaId = Guid.Empty,
                Horario = TimeSpan.Zero
            };
        }
    }
}
