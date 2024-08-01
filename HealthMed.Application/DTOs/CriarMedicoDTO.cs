namespace HealthMed.Application.DTOs
{
    public class CriarMedicoDTO
    {
        public CriarMedicoDTO(Guid id, string nome, string cPF, string cRM)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            CRM = cRM;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = null!;
        public string CRM { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
