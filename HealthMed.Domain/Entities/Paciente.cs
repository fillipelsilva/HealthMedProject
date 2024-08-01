using FluentValidation.Results;
using HealthMed.Domain.Validations;

namespace HealthMed.Domain.Entities
{
    public class Paciente : EntityBase
    {
        public Paciente()
        {
            Consultas = new List<Consulta>();
        }

        public Paciente(string nome, string cPF, string email, string password)
        {
            Nome = nome;
            CPF = cPF;
            Consultas = new List<Consulta>();
            Email = email;
            Password = password;
        }

        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Consulta> Consultas { get; set; }

        public void AlterarPaciente(string nome, string cPF)
        {
            Nome = nome;
            CPF = cPF;
        }

        public void AdicionarEmail(string email)
        {
            Email = email;
        }
        public void AdicionarPassword(string password)
        {
            Password = password;
        }

        public void AlterarPassword(string plainTextPassword)
        {
            Password = plainTextPassword;
        }

        public override ValidationResult IsValid()
        {
            ValidationResult = new PacienteValidation().Validate(this);
            return ValidationResult;
        }
    }
}
