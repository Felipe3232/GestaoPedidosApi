using Curitibano.Core.Infra.Data;
using GestaoPedidosAPI.Data.Context;
using GestaoPedidosAPI.Domain;

namespace GestaoPedidosAPI.Data.Repository
{

    public class ProtocoloRepository : BaseRepository<Protocolo, GestaoPedidosDbContext>
    {
        GestaoPedidosDbContext _dbContext;
        public ProtocoloRepository(GestaoPedidosDbContext dbContext) : base(dbContext) { _dbContext = dbContext; }
    }
}
