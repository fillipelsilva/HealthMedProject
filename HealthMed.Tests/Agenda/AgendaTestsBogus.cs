using Bogus;
using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HealthMed.Tests.AgendaTests
{
    public class AgendaTestsBogus
    {
        public Faker Faker { get; private set; }

        public AgendaTestsBogus()
        {
            Faker = new Faker("pt_BR"); // Configura o Faker para gerar dados em português brasileiro
        }

        public Agenda GerarAgendaValida()
        {
            var fakerAgenda = new Faker<Agenda>("pt_BR")
                .CustomInstantiator(f => new Agenda(
                    f.Random.Guid(),  // Gera um ID aleatório para o médico
                    f.Company.CompanyName()
                ))
                .RuleFor(a => a.Dias, f => new List<AgendaDia>
                {
                    new AgendaDia(f.Date.Recent()),
                    new AgendaDia(f.Date.Recent())
                });

            return fakerAgenda.Generate();
        }

        public Agenda GerarAgendaInvalida()
        {
            return new Agenda(
                Guid.Empty,  // ID inválido
                string.Empty // Nome inválido
            )
            {
                Dias = new List<AgendaDia>()
            };
        }
    }
}
