using HealthMed.Domain.Entities;
using Moq.AutoMock;
using Xunit;

namespace HealthMed.Tests.PacienteTests
{

    [CollectionDefinition("PacienteTestsCollection")]
    public class PacienteTestsCollection : ICollectionFixture<PacienteFixtureTests> { }

    public class PacienteFixtureTests: IDisposable
    {
        private readonly PacienteTestsBogus _pacienteTests;

        public AutoMocker Mocker { get; set; }

        public PacienteFixtureTests()
        {
           _pacienteTests = new PacienteTestsBogus();
        }

        public Paciente GerarAtivoValido()
        {
            return _pacienteTests.GerarPacienteValido();
        }

        public HealthMed.Domain.Entities.Paciente GerarAtivoInvalido()
        {
            return _pacienteTests.GerarPacienteInvalido();
        }

        public void Dispose()
        {
        }
    }
}
