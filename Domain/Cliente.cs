namespace GestaoPedidosAPI.Domain
{
    public class Cliente : Pessoa
    {
        public virtual ICollection<Protocolo> Protocolos { get; set; } = new List<Protocolo>();
    }
}
