using Bogus;
using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HealthMed.Tests.AgendaDiaTests
{
    public class AgendaDiaTestsBogus
    {
        public Faker Faker { get; private set; }

        public AgendaDiaTestsBogus()
        {
            Faker = new Faker("pt_BR"); // Configura o Faker para gerar dados em português brasileiro
        }

        public AgendaDia GerarAgendaDiaValida()
        {
            var fakerAgendaDia = new Faker<AgendaDia>("pt_BR")
                .CustomInstantiator(f => new AgendaDia(
                    f.Date.Past()
                ))
                .RuleFor(ad => ad.Horarios, f =>
                    new List<HorarioConsulta>
                    {
                        new HorarioConsulta(f.Date.Timespan())
                    });

            return fakerAgendaDia.Generate();
        }

        public AgendaDia GerarAgendaDiaInvalida()
        {
            return new AgendaDia(
                DateTime.MinValue
            )
            {
                Horarios = null // Definindo como nulo para simular uma agenda dia inválida
            };
        }
    }
}
