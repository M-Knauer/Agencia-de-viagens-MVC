

namespace GoodTrip.Models
{
    public class Passagem
    {
        public int Id_pass { get; set; }
        public float preco { get; set; }
        public string Embarque { get; set; }
        public string Desembarque { get; set; }
        public int Id_cliente_pass { get; set; }
        public Cliente Cliente { get; set; }

    }
}
