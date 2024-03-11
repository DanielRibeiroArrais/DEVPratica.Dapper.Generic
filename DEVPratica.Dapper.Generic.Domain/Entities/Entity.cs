using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVPratica.Dapper.Generic.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public bool Ativo { get; set; }

        protected Entity()
        {
            DataInclusao = DateTime.Now;
            Ativo = true;
        }
    }
}
