using Bogus;
using HealthMed.Domain.Entities;
using System;

namespace HealthMed.Tests.MedicoTests
{
    public class MedicoTestsBogus
    {
        public Faker Faker { get; private set; }

        public MedicoTestsBogus()
        {
            Faker = new Faker("pt_BR"); // Configura o Faker para gerar dados em português brasileiro
        }

        public Medico GerarMedicoValido()
        {
            var fakerMedico = new Faker<Medico>("pt_BR")
                .CustomInstantiator(f => new Medico(
                    f.Name.FullName(),
                    f.Random.String2(11, "0123456789"),
                    f.Random.AlphaNumeric(6),
                    f.Internet.Email(),
                    f.Internet.Password()
                ));

            return fakerMedico.Generate();
        }

        public Medico GerarMedicoInvalido()
        {
            return new Medico(
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty
            );
        }
    }
}
