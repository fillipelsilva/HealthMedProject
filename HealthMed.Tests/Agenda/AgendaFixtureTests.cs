using System;
using System.Collections.Generic;
using HealthMed.Domain.Entities;
using Xunit;

namespace HealthMed.Tests.AgendaTests
{
    [CollectionDefinition("AgendaTestsCollection")]
    public class AgendaTestsCollection : ICollectionFixture<AgendaFixtureTests> { }

    public class AgendaFixtureTests : IDisposable
    {
        private readonly AgendaTestsBogus _agendaTests;

        public AgendaFixtureTests()
        {
            _agendaTests = new AgendaTestsBogus();
        }

        public Agenda GerarAgendaValida()
        {
            return _agendaTests.GerarAgendaValida();
        }

        public Agenda GerarAgendaInvalida()
        {
            return _agendaTests.GerarAgendaInvalida();
        }

        public void Dispose()
        {
        }
    }
}
