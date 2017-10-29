using System;
namespace meuCarro.Models
{
    public class Usuario
    {
        public Usuario()
        {
        }
        public Endereco endereco { get; set; }
        public long Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }

    }
}
