using FluentAssertions;
using HealthMed.Domain.Entities;
using Xunit;

namespace HealthMed.Tests.AgendaDiaTests
{
    [Collection("AgendaDiaTestsCollection")]
    public class AgendaDiaDomainTests
    {
        private readonly AgendaDiaFixtureTests _agendaDiaFixtureTests;

        public AgendaDiaDomainTests(AgendaDiaFixtureTests agendaDiaFixtureTests)
        {
            _agendaDiaFixtureTests = agendaDiaFixtureTests;
        }

        [Fact(DisplayName = "AgendaDia Válido")]
        [Trait("AgendaDia", "Unit")]
        public void NovoAgendaDia_DeveEstarValido()
        {
            // Arrange
            var agendaDia = _agendaDiaFixtureTests.GerarValido();

            // Act
            var result = agendaDia.Horarios != null && agendaDia.Horarios.Count > 0;

            // Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "AgendaDia Inválido")]
        [Trait("AgendaDia", "Unit")]
        public void NovoAgendaDia_DeveEstarInvalido()
        {
            // Arrange
            var agendaDia = _agendaDiaFixtureTests.GerarInvalido();

            // Act
            var result = agendaDia.Horarios == null;

            // Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Adicionar Horário")]
        [Trait("AgendaDia", "Unit")]
        public void AdicionarHorario_DeveAdicionarHorario()
        {
            // Arrange
            var agendaDia = _agendaDiaFixtureTests.GerarValido();
            var horario = TimeSpan.FromHours(9);

            // Act
            agendaDia.AdicionarHorario(horario);

            // Assert
            agendaDia.Horarios.Should().Contain(h => h.Horario == horario);
        }

        [Fact(DisplayName = "Remover Horário")]
        [Trait("AgendaDia", "Unit")]
        public void RemoverHorario_DeveRemoverHorario()
        {
            // Arrange
            var agendaDia = _agendaDiaFixtureTests.GerarValido();
            var horario = TimeSpan.FromHours(9);

            agendaDia.AdicionarHorario(horario);

            // Act
            agendaDia.RemoverHorario(horario);

            // Assert
            agendaDia.Horarios.Should().NotContain(h => h.Horario == horario);
        }

        [Fact(DisplayName = "Alterar Disponibilidade")]
        [Trait("AgendaDia", "Unit")]
        public void AlterarDisponibilidade_DeveAlterarDisponibilidade()
        {
            // Arrange
            var agendaDia = _agendaDiaFixtureTests.GerarValido();
            var horario = TimeSpan.FromHours(9);

            agendaDia.AdicionarHorario(horario);

            // Act
            agendaDia.AlterarDisponibilidade(horario, false);

            // Assert
            var horarioConsulta = agendaDia.Horarios.Find(h => h.Horario == horario);
            horarioConsulta.Should().NotBeNull();
            horarioConsulta.Disponivel.Should().BeFalse();
        }
    }
}
