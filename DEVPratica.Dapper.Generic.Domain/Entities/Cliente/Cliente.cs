namespace DEVPratica.Dapper.Generic.Domain.Entities.Cliente
{
    public class Cliente : Entity
    {
        public required string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
