using System;
using HealthMed.Domain.Entities;
using Xunit;

namespace HealthMed.Tests.HorarioConsultaTests
{
    [CollectionDefinition("HorarioConsultaTestsCollection")]
    public class HorarioConsultaTestsCollection : ICollectionFixture<HorarioConsultaFixtureTests> { }

    public class HorarioConsultaFixtureTests : IDisposable
    {
        private readonly HorarioConsultaTestsBogus _horarioConsultaTests;

        public HorarioConsultaFixtureTests()
        {
            _horarioConsultaTests = new HorarioConsultaTestsBogus();
        }

        public HorarioConsulta GerarValida()
        {
            return _horarioConsultaTests.GerarHorarioConsultaValido();
        }

        public HorarioConsulta GerarInvalida()
        {
            return _horarioConsultaTests.GerarHorarioConsultaInvalido();
        }

        public void Dispose()
        {
        }
    }
}
