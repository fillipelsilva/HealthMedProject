using FluentAssertions;
using HealthMed.Domain.Entities;
using Xunit;

namespace HealthMed.Tests.HorarioConsultaTests
{
    [Collection("HorarioConsultaTestsCollection")]
    public class HorarioConsultaDomainTests
    {
        private readonly HorarioConsultaFixtureTests _horarioConsultaFixtureTests;

        public HorarioConsultaDomainTests(HorarioConsultaFixtureTests horarioConsultaFixtureTests)
        {
            _horarioConsultaFixtureTests = horarioConsultaFixtureTests;
        }

        [Fact(DisplayName = "HorarioConsulta Válido")]
        [Trait("HorarioConsulta", "Unit")]
        public void NovoHorarioConsulta_DeveSerValido()
        {
            // Arrange
            var horarioConsulta = _horarioConsultaFixtureTests.GerarValida();

            // Act
            var result = horarioConsulta != null &&
                         horarioConsulta.Horario != TimeSpan.Zero;

            // Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "HorarioConsulta Inválido")]
        [Trait("HorarioConsulta", "Unit")]
        public void NovoHorarioConsulta_DeveSerInvalido()
        {
            // Arrange
            var horarioConsulta = _horarioConsultaFixtureTests.GerarInvalida();

            // Act
            var result = horarioConsulta.Horario == TimeSpan.Zero &&
                         !horarioConsulta.Disponivel;

            // Assert
            result.Should().BeTrue();
        }
    }
}
