using FluentAssertions;
using HealthMed.Domain.Entities;
using Xunit;

namespace HealthMed.Tests.ConsultaTests
{
    [Collection("ConsultaTestsCollection")]
    public class ConsultaDomainTests
    {
        private readonly ConsultaFixtureTests _consultaFixtureTests;

        public ConsultaDomainTests(ConsultaFixtureTests consultaFixtureTests)
        {
            _consultaFixtureTests = consultaFixtureTests;
        }

        [Fact(DisplayName = "Consulta Válida")]
        [Trait("Consulta", "Unit")]
        public void NovaConsulta_DeveSerValida()
        {
            // Arrange
            var consulta = _consultaFixtureTests.GerarValida();

            // Act
            var result = consulta != null && consulta.Horario != TimeSpan.Zero;

            // Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Consulta Inválida")]
        [Trait("Consulta", "Unit")]
        public void NovaConsulta_DeveSerInvalida()
        {
            // Arrange
            var consulta = _consultaFixtureTests.GerarInvalida();

            // Act
            var result = consulta.PacienteId == Guid.Empty &&
                         consulta.MedicoId == Guid.Empty &&
                         consulta.AgendaDiaId == Guid.Empty &&
                         consulta.Horario == TimeSpan.Zero;

            // Assert
            result.Should().BeTrue();
        }
    }
}
