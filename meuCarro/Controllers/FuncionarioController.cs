using System;
using meuCarro.Models;
using Microsoft.AspNetCore.Mvc;

namespace meuCarro.Controllers
{
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly LocadouraContext _context;

        public FuncionarioController(LocadouraContext context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetFuncionario")]
        public IActionResult GetById(long id)
        {
            var funcionario = _context.Funcionairo.Find(id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return new ObjectResult(funcionario);
        }

        [HttpPost(Name = "CreateFuncionario")]
        public IActionResult Create([FromBody] Funcionairo funcionario)
        {
            if (funcionario == null)
            {
                return BadRequest();
            }

            var endereco = _context.Endereco.Find(funcionario.endereco.Id);
            funcionario.endereco = endereco;

            _context.Funcionairo.Add(funcionario);
            _context.SaveChanges();

            return CreatedAtRoute("GetFuncionario", new { id = funcionario.Id }, funcionario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Funcionairo body)
        {
            var funcionario = _context.Funcionairo.Find(id);

            if (body == null)
            {
                return BadRequest();
            }

            funcionario.Email = body.Email;
            funcionario.Nome = body.Nome;
            funcionario.endereco = body.endereco;
            funcionario.Telefone = body.Telefone;
            funcionario.Registro = body.Registro;
            funcionario.Password = body.Password;

            _context.Funcionairo.Update(funcionario);
            _context.SaveChanges();

            return CreatedAtRoute("GetFuncionario", new { id = funcionario.Id }, funcionario);
        }
    }
}
