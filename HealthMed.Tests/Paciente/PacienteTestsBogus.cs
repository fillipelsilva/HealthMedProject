using Bogus;
using HealthMed.Domain.Entities;

namespace HealthMed.Tests.PacienteTests
{
    public class PacienteTestsBogus
    {
        public Faker Faker { get; private set; }

        public PacienteTestsBogus()
        {
            Faker = new Faker("pt_BR"); // Configura o Faker para gerar dados em português brasileiro
        }

        public HealthMed.Domain.Entities.Paciente GerarPacienteValido()
        {
            var fakerPaciente = new Faker<HealthMed.Domain.Entities.Paciente>("pt_BR")
                .CustomInstantiator(f => new HealthMed.Domain.Entities.Paciente(
                    f.Name.FullName(),
                    f.Random.String2(11, "0123456789"),
                    f.Internet.Email(),
                    f.Internet.Password()
                ));

            return fakerPaciente.Generate();
        }

        public HealthMed.Domain.Entities.Paciente GerarPacienteInvalido()
        {
            return new HealthMed.Domain.Entities.Paciente(
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty
            );
        }
    }
}
