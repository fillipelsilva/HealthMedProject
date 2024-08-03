using Bogus;
using HealthMed.Domain.Entities;
using System;

namespace HealthMed.Tests.HorarioConsultaTests
{
    public class HorarioConsultaTestsBogus
    {
        public Faker Faker { get; private set; }

        public HorarioConsultaTestsBogus()
        {
            Faker = new Faker("pt_BR"); // Configura o Faker para gerar dados em português brasileiro
        }

        public HorarioConsulta GerarHorarioConsultaValido()
        {
            var fakerHorarioConsulta = new Faker<HorarioConsulta>("pt_BR")
                .CustomInstantiator(f => new HorarioConsulta(
                    f.Date.Timespan(), // Gera um horário aleatório
                    f.Random.Bool()   // Gera um valor booleano aleatório para disponibilidade
                ));

            return fakerHorarioConsulta.Generate();
        }

        public HorarioConsulta GerarHorarioConsultaInvalido()
        {
            return new HorarioConsulta(
                TimeSpan.Zero,    // Valor inválido para o horário
                false              // Disponibilidade inválida
            );
        }
    }
}
