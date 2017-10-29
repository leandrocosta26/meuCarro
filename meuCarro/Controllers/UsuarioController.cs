using System;
using meuCarro.Models;
using Microsoft.AspNetCore.Mvc;

namespace meuCarro.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly LocadouraContext _context;

        public UsuarioController(LocadouraContext context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(long id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return new ObjectResult(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            var endereco = _context.Endereco.Find(usuario.endereco.Id);
            usuario.endereco = endereco;

            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Usuario body)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return BadRequest();
            }

            usuario.Email = body.Email;
            usuario.Nome = body.Nome;
            usuario.endereco = body.endereco;
            usuario.Telefone = body.Telefone;

            _context.Usuario.Update(usuario);
            _context.SaveChanges();

            return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
        }
    }
}
