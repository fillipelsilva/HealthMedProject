using System;
using HealthMed.Domain.Entities;
using Xunit;

namespace HealthMed.Tests.MedicoTests
{
    [CollectionDefinition("MedicoTestsCollection")]
    public class MedicoTestsCollection : ICollectionFixture<MedicoFixtureTests> { }

    public class MedicoFixtureTests : IDisposable
    {
        private readonly MedicoTestsBogus _medicoTests;

        public MedicoFixtureTests()
        {
            _medicoTests = new MedicoTestsBogus();
        }

        public Medico GerarMedicoValido()
        {
            return _medicoTests.GerarMedicoValido();
        }

        public Medico GerarMedicoInvalido()
        {
            return _medicoTests.GerarMedicoInvalido();
        }

        public void Dispose()
        {
        }
    }
}
