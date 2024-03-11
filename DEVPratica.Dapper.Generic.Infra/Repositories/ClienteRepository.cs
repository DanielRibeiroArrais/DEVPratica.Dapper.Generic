using DEVPratica.Dapper.Generic.Domain.Repositories;
using DEVPratica.Dapper.Generic.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Infra.Repositories
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(DbContext dbContext) : base(dbContext) { }


    }
}
