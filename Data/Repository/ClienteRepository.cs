using Curitibano.Core.Infra.Data;
using GestaoPedidosAPI.Data.Context;
using GestaoPedidosAPI.Domain;

namespace GestaoPedidosAPI.Data.Repository
{

    public class ClienteRepository : BaseRepository<Cliente, GestaoPedidosDbContext>
    {
        GestaoPedidosDbContext _dbContext;
        public ClienteRepository(GestaoPedidosDbContext dbContext) : base(dbContext) { _dbContext = dbContext; }

    }
}
