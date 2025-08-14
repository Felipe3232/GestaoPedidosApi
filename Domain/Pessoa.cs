namespace GestaoPedidosAPI.Domain
{
    public class Pessoa  : BaseEntity
    {
        public string Nome { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public virtual Endereco Endereco { get; set; } = null!;

    }
}
