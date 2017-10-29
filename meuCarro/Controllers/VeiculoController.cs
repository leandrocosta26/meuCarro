using System;
using meuCarro.Models;
using Microsoft.AspNetCore.Mvc;

namespace meuCarro.Controllers
{
    [Route("api/[controller]")]
    public class VeiculoController : Controller
    {
        private readonly LocadouraContext _context;

        public VeiculoController(LocadouraContext context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetVeiculo")]
        public IActionResult GetById(long id)
        {
            var veiculo = _context.Veiculo.Find(id);

            if (veiculo == null)
            {
                return NotFound();
            }
            return new ObjectResult(veiculo);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Veiculo veiculo)
        {
            if (veiculo == null)
            {
                return BadRequest();
            }

            _context.Veiculo.Add(veiculo);
            _context.SaveChanges();

            return CreatedAtRoute("GetVeiculo", new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Veiculo body)
        {
            var veiculo = _context.Veiculo.Find(id);

            if (body == null)
            {
                return BadRequest();
            }

            veiculo.Marca = body.Marca;
            veiculo.Nome = body.Nome;
            veiculo.Placa = body.Placa;

            _context.Veiculo.Update(veiculo);
            _context.SaveChanges();

            return CreatedAtRoute("GetVeiculo", new { id = veiculo.Id }, veiculo);
        }
    }
}
