using System;
namespace meuCarro.Models
{
    public class Locacao
    {
        public Locacao()
        {
        }

        public long Id { get; set; }
        public Funcionairo Funcionario { get; set; }
        public Usuario Usuario { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime Reserva { get; set; }
        public DateTime Devolucao { get; set; }
    }
}
