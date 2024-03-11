using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Domain.Entities.Usuario
{
    public class Usuario : Entity
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
