using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Domain.Repositories
{
    public interface IBaseRepository
    {
        Task<T> SalvarAsync<T>(T entity) where T : class;

        Task<bool> SalvarAllAsync<T>(T entity) where T : class;

        Task<T> AtualizarAsync<T>(T entity) where T : class;

        Task<bool> DeletarAsync<T>(T entity) where T : class;

        Task<IEnumerable<T>> ObterTodosAsync<T>() where T : class;

        Task<T> ObterPorIdAsync<T>(int id) where T : class;

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}