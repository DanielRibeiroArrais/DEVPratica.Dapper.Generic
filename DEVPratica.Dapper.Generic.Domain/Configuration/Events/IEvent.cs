using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Domain.Configuration.Events
{
    public interface IEvent
    {
        bool Success { get; }
        object Data { get; }
        object Warning { get; }
    }
}