namespace HealthMed.Application.DTOs
{
    public class AlterarPacienteDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = null!;
    }
}
