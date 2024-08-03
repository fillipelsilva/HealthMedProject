using FluentAssertions;
using HealthMed.Tests.PacienteTests;
using Xunit;

namespace Health.Tests.PacienteTests
{
    [Collection("PacienteTestsCollection")]
    public class PacienteDomainTests
    {
        private readonly PacienteFixtureTests _pacienteFixtureTests;

        public PacienteDomainTests(PacienteFixtureTests pacienteFixtureTests)
        {
            _pacienteFixtureTests = pacienteFixtureTests;
        }

        [Fact(DisplayName = "Paciente Válido")]
        [Trait("Paciente", "Unit")]
        public void NovoAtivo_DeveEstarValido()
        {
            // Arrange
            var paciente = _pacienteFixtureTests.GerarAtivoValido();

            // Act
            var result = paciente.IsValid();

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact(DisplayName = "Paciente Inválido")]
        [Trait("Paciente", "Unit")]
        public void NovoAtivo_DeveEstarInvalido()
        {
            // Arrange
            var paciente = _pacienteFixtureTests.GerarAtivoInvalido();

            // Act
            var result = paciente.IsValid();

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
