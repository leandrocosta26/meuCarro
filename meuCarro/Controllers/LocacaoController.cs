using System;
using meuCarro.Models;
using Microsoft.AspNetCore.Mvc;

namespace meuCarro.Controllers
{
    [Route("api/[controller]")]
    public class LocacaoController : Controller
    {
        public readonly LocadouraContext _context;

        public LocacaoController(LocadouraContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ReservarVeiculo([FromBody] Locacao locacao)
        {
            if (locacao == null)
            {
                return BadRequest();
            }

            var usuario = _context.Usuario.Find(locacao.Usuario.Id);
            var funcionario = _context.Funcionairo.Find(locacao.Funcionario.Id);
            var veiculo = _context.Veiculo.Find(locacao.Veiculo.Id);

            if(veiculo.Reservado){
                return BadRequest("Veiculo ja se encontra reservado");
            }

            veiculo.Reservado = true;

            veiculo.Reservado = true;
            _context.Veiculo.Update(veiculo);
            _context.SaveChanges();


            locacao.Usuario = usuario;
            locacao.Funcionario = funcionario;
            locacao.Veiculo = veiculo;
            locacao.Reserva = DateTime.Now;

            _context.Locacao.Add(locacao);
            _context.SaveChanges();

            return CreatedAtRoute("GetLocacao", new { id = locacao.Id }, locacao);
        }

        [HttpPut("{id}")]
        public IActionResult DevolverVeiculo(long id){

            var locacao = _context.Locacao.Find(id);
            var veiculo = _context.Veiculo.Find(locacao.Veiculo.Id);

            if (locacao == null){
                return BadRequest();
            }

            veiculo.Reservado = true;
            _context.Veiculo.Update(veiculo);
            _context.SaveChanges();

            locacao.Devolucao = DateTime.Now;
            _context.Locacao.Update(locacao);
            _context.SaveChanges();

            return CreatedAtRoute("GetLocacao", new { id = locacao.Id }, locacao);
        }

        [HttpGet("{id}", Name = "GetLocacao")]
        public IActionResult GetById(long id)
        {
            var locacao = _context.Locacao.Find(id);

            if (locacao == null)
            {
                return NotFound();
            }
            return new ObjectResult(locacao);
        }


    }
}
