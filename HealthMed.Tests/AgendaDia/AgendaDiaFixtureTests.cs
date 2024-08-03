using System;
using HealthMed.Domain.Entities;
using HealthMed.Tests.AgendaTests;
using Xunit;

namespace HealthMed.Tests.AgendaDiaTests
{
    [CollectionDefinition("AgendaDiaTestsCollection")]
    public class AgendaDiaTestsCollection : ICollectionFixture<AgendaDiaFixtureTests> { }

    public class AgendaDiaFixtureTests : IDisposable
    {
        private readonly AgendaDiaTestsBogus _agendaDiaTests;

        public AgendaDiaFixtureTests()
        {
            _agendaDiaTests = new AgendaDiaTestsBogus();
        }

        public AgendaDia GerarValido()
        {
            return _agendaDiaTests.GerarAgendaDiaValida();
        }

        public AgendaDia GerarInvalido()
        {
            return _agendaDiaTests.GerarAgendaDiaInvalida();
        }

        public void Dispose()
        {
        }
    }
}
