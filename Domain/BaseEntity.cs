namespace GestaoPedidosAPI.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; } = true;
        public BaseEntity() { }
        public BaseEntity(int id, DateTime dataCriacao, DateTime? dataAtualizacao, bool ativo)
        {
            Id = id;
            DataCriacao = dataCriacao;
            DataAtualizacao = dataAtualizacao;
            Ativo = ativo;
        }

        public void Inativar()
        {
            Ativo = false;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void Ativar()
        {
            Ativo = true;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
