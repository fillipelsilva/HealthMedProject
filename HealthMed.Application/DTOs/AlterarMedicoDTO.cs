namespace HealthMed.Application.DTOs
{
    public class AlterarMedicoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = null!;
        public string CRM { get; set; } = null!;
    }
}
