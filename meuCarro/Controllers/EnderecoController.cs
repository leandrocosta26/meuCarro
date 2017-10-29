using System;
using meuCarro.Models;
using Microsoft.AspNetCore.Mvc;

namespace meuCarro.Controllers
{
    [Route("api/[controller]")]
    public class EnderecoController : Controller
    {
        private readonly LocadouraContext _context;

        public EnderecoController(LocadouraContext context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetEndereco")]
        public IActionResult GetById(long id)
        {
            var endereco = _context.Endereco.Find(id);
                
            if (endereco == null)
            {
                return NotFound();
            }
            return new ObjectResult(endereco);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Endereco endereco){
            if(endereco == null){
                return BadRequest();
            }

            _context.Endereco.Add(endereco);
            _context.SaveChanges();

            return CreatedAtRoute("GetEndereco", new { id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Endereco body)
        {
            var endereco = _context.Endereco.Find(id);

            if (endereco == null)
            {
                return BadRequest();
            }

            endereco.Bairro = body.Bairro;
            endereco.Logradouro = body.Logradouro;
            endereco.Cidade = body.Cidade;
            endereco.Estado = body.Estado;
            endereco.Numero = body.Numero;

            _context.Endereco.Update(endereco);
            _context.SaveChanges();

            return CreatedAtRoute("GetEndereco", new { id = endereco.Id }, endereco);
        }

    }
}
