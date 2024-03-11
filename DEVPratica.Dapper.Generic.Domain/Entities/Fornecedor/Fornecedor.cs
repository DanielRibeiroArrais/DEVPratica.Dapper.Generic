using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Domain.Entities.Fornecedor
{
    public class Fornecedor : Entity
    {
        public required string RazaoSocial { get; set; }
        public required string CNPJ { get; set; }
    }
}
