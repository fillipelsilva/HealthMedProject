using FluentAssertions;
using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace HealthMed.Tests.AgendaTests
{
    [Collection("AgendaTestsCollection")]
    public class AgendaDomainTests
    {
        private readonly AgendaFixtureTests _agendaFixtureTests;

        public AgendaDomainTests(AgendaFixtureTests agendaFixtureTests)
        {
            _agendaFixtureTests = agendaFixtureTests;
        }

        [Fact(DisplayName = "Adicionar Horário")]
        [Trait("Agenda", "Unit")]
        public void AdicionarHorario_DeveAdicionarHorarioCorretamente()
        {
            // Arrange
            var agenda = _agendaFixtureTests.GerarAgendaValida();
            var data = DateTime.Now;
            var horario = TimeSpan.FromHours(9);

            agenda.Dias.Add(new AgendaDia(data)); // Adiciona um dia à agenda

            // Act
            agenda.AdicionarHorario(data, horario);

            // Assert
            agenda.Dias.Should().ContainSingle(d => d.Data == data && d.Horarios.Exists(h => h.Horario == horario));
        }

        [Fact(DisplayName = "Remover Horário")]
        [Trait("Agenda", "Unit")]
        public void RemoverHorario_DeveRemoverHorarioCorretamente()
        {
            // Arrange
            var agenda = _agendaFixtureTests.GerarAgendaValida();
            var data = DateTime.Now;
            var horario = TimeSpan.FromHours(9);

            var agendaDia = new AgendaDia(data);
            agendaDia.AdicionarHorario(horario);
            agenda.Dias.Add(agendaDia);

            // Act
            agenda.RemoverHorario(data, horario);

            // Assert
            agenda.Dias.Should().ContainSingle(d => d.Data == data && !d.Horarios.Exists(h => h.Horario == horario));
        }

        [Fact(DisplayName = "Alterar Disponibilidade")]
        [Trait("Agenda", "Unit")]
        public void AlterarDisponibilidade_DeveAlterarDisponibilidadeCorretamente()
        {
            // Arrange
            var agenda = _agendaFixtureTests.GerarAgendaValida();
            var data = DateTime.Now;
            var horario = TimeSpan.FromHours(9);
            var disponivel = false;

            var agendaDia = new AgendaDia(data);
            agendaDia.AdicionarHorario(horario);
            agenda.Dias.Add(agendaDia);

            // Act
            agenda.AlterarDisponibilidade(data, horario, disponivel);

            // Assert
            agenda.Dias.Should().ContainSingle(d => d.Data == data && d.Horarios.Exists(h => h.Horario == horario && h.Disponivel == disponivel));
        }

        [Fact(DisplayName = "Alterar Agenda")]
        [Trait("Agenda", "Unit")]
        public void AlterarAgenda_DeveAlterarAgendaCorretamente()
        {
            // Arrange
            var agenda = _agendaFixtureTests.GerarAgendaValida();
            var novaListaDeDias = new List<AgendaDia>
            {
                new AgendaDia(DateTime.Now.AddDays(1)),
                new AgendaDia(DateTime.Now.AddDays(2))
            };

            // Act
            agenda.AlterarAgenda(novaListaDeDias);

            // Assert
            agenda.Dias.Should().BeEquivalentTo(novaListaDeDias);
        }
    }
}
