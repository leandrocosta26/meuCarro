using System;
namespace meuCarro.Models
{
    public class Endereco
    {
        public Endereco()
        {
        }
        public long Id { get; set; }
        public Decimal Numero{ get; set; }
        public String Logradouro { get; set; }
        public String Bairro{ get; set; }
        public String Cidade{ get; set; }
        public String Estado{ get; set; }
        public Decimal Cep { get; set;  }
    }
}
