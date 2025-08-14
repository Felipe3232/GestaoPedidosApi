namespace GestaoPedidosAPI.Domain
{
    public class Protocolo : BaseEntity
    {
        public virtual Solicitacao Solicitacao { get; set; } = null!;
        public string Observacao { get; set; } = null!;
        public DateTime DataAbertura { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public TipoStatus Status { get; set; }
        public enum TipoStatus
        {
            Pendente,
            EmAndamento,
            Concluido,
            Cancelado
        }
    }
}
