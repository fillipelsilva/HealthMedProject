namespace HealthMed.Domain.Entities
{
    public class Medico : EntityBase
    {
        public Medico() 
        {
            Agendas = new List<Agenda>();
        }

        public Medico(string nome, string cPF, string cRM, string email, string password)
        {
            Nome = nome;
            CPF = cPF;
            CRM = cRM;
            Agendas = new List<Agenda>();
            Email = email;
            Password = password;
        }

        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = null!;
        public string CRM { get; set; } = null!;
        public List<Agenda> Agendas { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public void AlterarMedico(string nome, string cPF, string cRM)
        {
            Nome = nome;
            CPF = cPF;
            CRM = cRM;
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
    }
}
