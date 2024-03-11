using DEVPratica.Dapper.Generic.Domain.Repositories;
using DEVPratica.Dapper.Generic.Infra.Services;

namespace DEVPratica.Dapper.Generic.Infra.Repositories
{
    public class FornecedorRepository : BaseRepository, IFornecedorRepository
    {
        public FornecedorRepository(DbContext dbContext) : base(dbContext) { }
    }
}
