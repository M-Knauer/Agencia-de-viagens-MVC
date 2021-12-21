using System.Collections.Generic;

namespace GoodTrip.Models
{
    public class Cliente
    {
        public int Id_cliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public char Sexo { get; set; }

        public ICollection<Passagem> Passagens { get; set; }
        //public ICollection<Telefone> Telefones { get; set; }
    }
}
