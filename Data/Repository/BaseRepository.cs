
using GestaoPedidosAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curitibano.Core.Infra.Data
{
    public enum FiltroStatus { Ativo, Inativo, Ambos }

    public interface IBaseRepository<TEntity, TContext> : IBaseReadRepository<TEntity>, IBaseWriteRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
    {

    }

    public interface IBaseWriteRepository<TEntity> where TEntity : BaseEntity
    {
        Task InserirAsync(TEntity obj);
        Task AlterarAsync(TEntity obj);
        Task RemoverAsync(int id);
        Task RemoverPorObjeto(TEntity obj);
    }

    public interface IBaseReadRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> ObterPeloIdAsync(int id);
        Task<TEntity> ObterPeloId(int id);
        IQueryable<TEntity> Obter();
        IQueryable<TEntity> Obter(FiltroStatus filtroStatus);
    }

    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : DbContext
    {
        private readonly TContext _dbContext;

        protected TContext DbContext => _dbContext;

        public BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Obter() => DbContext.Set<TEntity>().Where(o => o.Ativo.Equals(true));
        public IQueryable<TEntity> Obter(FiltroStatus filtroStatus)
        {
            switch (filtroStatus)
            {
                case FiltroStatus.Ativo: return DbContext.Set<TEntity>().Where(o => o.Ativo.Equals(true));
                case FiltroStatus.Inativo: return DbContext.Set<TEntity>().Where(o => o.Ativo.Equals(false));
                case FiltroStatus.Ambos: return DbContext.Set<TEntity>();
                default: throw new ApplicationException("Filtro informado não gerenciado");
            }
        }

        public async Task<IEnumerable<TEntity>> ObterListagem()
        {
            var retorno = await (
                from o in DbContext.Set<TEntity>()
                where
                o.Ativo.Equals(true)
                select o
            )
            .OrderBy(o => o.Id)
            .ToListAsync();

            return retorno;
        }

        public async Task<TEntity> ObterPeloId(int id)
        {
            var ent = await (

                from o in DbContext.Set<TEntity>()
                where o.Id.Equals(id)
                select o

            ).SingleOrDefaultAsync();

            if (ent == null) throw new ApplicationException($"Não foi possível encontrar o associado no Banco de Dados. ID: {id}.");

            return ent;
        }

        public async Task<TEntity> ObterPeloIdAsync(int id)
        {
            var ent = await (

                from o in DbContext.Set<TEntity>()
                where o.Id.Equals(id)
                select o

            ).SingleOrDefaultAsync();

            if (ent == null) throw new ApplicationException($"Não foi possível encontrar o associado no Banco de Dados. ID: {id}.");

            return ent;
        }

        public virtual async Task Inserir(TEntity obj)
        {
            DbContext.Set<TEntity>().Add(obj);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task InserirAsync(TEntity obj)
        {
            DbContext.Set<TEntity>().Add(obj);

            //obj.Version = Guid.NewGuid();
            await DbContext.SaveChangesAsync();
        }

        public async Task Alterar(TEntity obj)
        {
            obj.DataAtualizacao = DateTime.Now;
            DbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task AlterarAsync(TEntity obj)
        {
            try
            {
                obj.DataAtualizacao = DateTime.Now;
                DbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
        }

        public async Task Remover(int id)
        {
            var obj = await ObterPeloIdAsync(id);
            obj.DataAtualizacao = DateTime.Now;

            DbContext.Set<TEntity>().Remove(obj);
            await DbContext.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var obj = await ObterPeloIdAsync(id);
            obj.DataAtualizacao = DateTime.Now;
            try
            {
                DbContext.Set<TEntity>().Remove(obj);

                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw;
            }

        }
        public async Task RemoverPorObjeto(TEntity obj)
        {
            if (obj != null)
            {
                obj.DataAtualizacao = DateTime.Now;

                DbContext.Set<TEntity>().Remove(obj);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}