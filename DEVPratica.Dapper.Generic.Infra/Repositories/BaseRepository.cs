using Dapper.Contrib.Extensions;
using DEVPratica.Dapper.Generic.Domain.Repositories;
using DEVPratica.Dapper.Generic.Infra.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Infra.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected SqlTransaction transaction;
        protected DbContext _context;

        public BaseRepository()
        {
        }

        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
            SetTable();
        }

        public void BeginTransaction()
        {
            if (_context.Transaction == null)
                _context.Transaction = _context.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            if (_context.Transaction != null)
                _context.Transaction.Commit();
        }

        public void Rollback()
        {
            if (_context.Transaction != null)
                _context.Transaction.Rollback();
        }

        public static void SetTable()
        {
            SqlMapperExtensions.TableNameMapper = (type) => type.Name;
        }

        public async Task<T> SalvarAsync<T>(T entity) where T : class
        {
            var _success = await _context.Connection.InsertAsync(entity, _context.Transaction);

            if (_success < 1)
                return null;

            return await _context.Connection.GetAsync<T>(_success, _context.Transaction);
        }

        public async Task<bool> SalvarAllAsync<T>(T entity) where T : class
        {
            var rowsAffected = await _context.Connection.InsertAsync(entity, _context.Transaction);

            return rowsAffected > 0;
        }

        public async Task<bool> DeletarAsync<T>(T entity) where T : class
        {
            return await _context.Connection.DeleteAsync(entity, _context.Transaction);
        }

        public async Task<IEnumerable<T>> ObterTodosAsync<T>() where T : class
        {
            return await _context.Connection.GetAllAsync<T>(_context.Transaction);
        }

        public async Task<T> ObterPorIdAsync<T>(int id) where T : class
        {

            return await _context.Connection.GetAsync<T>(id, _context.Transaction);
        }

        public async Task<T> ObterPorGuidAsync<T>(Guid guid) where T : class
        {

            return await _context.Connection.GetAsync<T>(guid, _context.Transaction);
        }

        public async Task<T> AtualizarAsync<T>(T entity) where T : class
        {
            var _success = await _context.Connection.UpdateAsync(entity, _context.Transaction);

            if (!_success)
                return null;

            return entity;
        }
    }
}