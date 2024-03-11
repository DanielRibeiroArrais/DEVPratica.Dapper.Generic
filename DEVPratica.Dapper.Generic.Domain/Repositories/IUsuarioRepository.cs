using DEVPratica.Dapper.Generic.Domain.Entities.Usuario;

namespace DEVPratica.Dapper.Generic.Domain.Repositories
{
    public interface IUsuarioRepository : IBaseRepository
    {
        Task<List<Usuario>> ObterUsuarioPorNomeAsync(string nome);
    }
}
