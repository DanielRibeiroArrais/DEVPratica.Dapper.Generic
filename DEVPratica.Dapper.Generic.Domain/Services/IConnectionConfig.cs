using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Domain.Services
{
    public interface IConnectionConfig
    {
        string GetConnectionString();
    }
}