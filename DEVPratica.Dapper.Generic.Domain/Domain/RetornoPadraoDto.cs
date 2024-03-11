using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Domain.Domain
{
    public class RetornoPadraoDto
    {
        public bool HasError { get; set; }
        public object Data { get; set; }
        public object Notifications { get; set; }
    }
}
