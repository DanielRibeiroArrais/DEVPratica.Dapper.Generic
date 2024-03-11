using Dapper;
using DEVPratica.Dapper.Generic.Domain.Entities.Usuario;
using DEVPratica.Dapper.Generic.Domain.Repositories;
using DEVPratica.Dapper.Generic.Infra.Services;

namespace DEVPratica.Dapper.Generic.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<List<Usuario>> ObterUsuarioPorNomeAsync(string nome)
        {
            var query = @"SELECT * FROM Usuario WITH (NOLOCK) WHERE Nome LIKE @nome";

            var param = new DynamicParameters();
            param.Add("@nome", $"%{nome}%");

            var result = await _context.Connection.QueryAsync<Usuario>(query, param, _context.Transaction);

            return result.ToList();
        }
    }
}