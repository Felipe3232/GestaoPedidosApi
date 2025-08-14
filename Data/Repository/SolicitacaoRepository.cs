using Curitibano.Core.Infra.Data;
using GestaoPedidosAPI.Data.Context;
using GestaoPedidosAPI.Domain;

namespace GestaoPedidosAPI.Data.Repository
{

    public class SolicitacaoRepository : BaseRepository<Solicitacao, GestaoPedidosDbContext>
    {
        GestaoPedidosDbContext _dbContext;
        public SolicitacaoRepository(GestaoPedidosDbContext dbContext) : base(dbContext) { _dbContext = dbContext; }
    }
}
