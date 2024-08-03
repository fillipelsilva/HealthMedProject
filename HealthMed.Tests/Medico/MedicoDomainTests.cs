using FluentAssertions;
using HealthMed.Domain.Entities;
using Xunit;

namespace HealthMed.Tests.MedicoTests
{
    [Collection("MedicoTestsCollection")]
    public class MedicoDomainTests
    {
        private readonly MedicoFixtureTests _medicoFixtureTests;

        public MedicoDomainTests(MedicoFixtureTests medicoFixtureTests)
        {
            _medicoFixtureTests = medicoFixtureTests;
        }

        [Fact(DisplayName = "Alterar Médico")]
        [Trait("Medico", "Unit")]
        public void AlterarMedico_DeveAlterarDadosCorretamente()
        {
            // Arrange
            var medico = _medicoFixtureTests.GerarMedicoValido();
            var novoNome = "Novo Nome";
            var novoCPF = "12345678901";
            var novoCRM = "CRM123";

            // Act
            medico.AlterarMedico(novoNome, novoCPF, novoCRM);

            // Assert
            medico.Nome.Should().Be(novoNome);
            medico.CPF.Should().Be(novoCPF);
            medico.CRM.Should().Be(novoCRM);
        }

        [Fact(DisplayName = "Adicionar Email")]
        [Trait("Medico", "Unit")]
        public void AdicionarEmail_DeveAdicionarEmailCorretamente()
        {
            // Arrange
            var medico = _medicoFixtureTests.GerarMedicoValido();
            var novoEmail = "novoemail@example.com";

            // Act
            medico.AdicionarEmail(novoEmail);

            // Assert
            medico.Email.Should().Be(novoEmail);
        }

        [Fact(DisplayName = "Adicionar Password")]
        [Trait("Medico", "Unit")]
        public void AdicionarPassword_DeveAdicionarPasswordCorretamente()
        {
            // Arrange
            var medico = _medicoFixtureTests.GerarMedicoValido();
            var novaSenha = "novaSenha123";

            // Act
            medico.AdicionarPassword(novaSenha);

            // Assert
            medico.Password.Should().Be(novaSenha);
        }

        [Fact(DisplayName = "Alterar Password")]
        [Trait("Medico", "Unit")]
        public void AlterarPassword_DeveAlterarPasswordCorretamente()
        {
            // Arrange
            var medico = _medicoFixtureTests.GerarMedicoValido();
            var novaSenha = "novaSenha123";

            // Act
            medico.AlterarPassword(novaSenha);

            // Assert
            medico.Password.Should().Be(novaSenha);
        }
    }
}
