using System;
using HealthMed.Domain.Entities;
using HealthMed.Tests.ConsultaTests;
using Xunit;

namespace HealthMed.Tests.ConsultaTests
{
    [CollectionDefinition("ConsultaTestsCollection")]
    public class ConsultaTestsCollection : ICollectionFixture<ConsultaFixtureTests> { }

    public class ConsultaFixtureTests : IDisposable
    {
        private readonly ConsultaTestsBogus _consultaTests;

        public ConsultaFixtureTests()
        {
            _consultaTests = new ConsultaTestsBogus();
        }

        public Consulta GerarValida()
        {
            return _consultaTests.GerarConsultaValida();
        }

        public Consulta GerarInvalida()
        {
            return _consultaTests.GerarConsultaInvalida();
        }

        public void Dispose()
        {
        }
    }
}
