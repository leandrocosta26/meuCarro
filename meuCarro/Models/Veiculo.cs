using System;
namespace meuCarro.Models
{
    public class Veiculo
    {
        public Veiculo()
        {
        }
        public long Id { get; set; }
        public String Nome { get; set; }
        public String Marca { get; set; }
        public String Placa { get; set; }
        public Boolean Reservado { get; set; }
    }
}
