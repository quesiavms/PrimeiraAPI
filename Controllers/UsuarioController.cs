﻿using API._1.Models;
using API._1.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API._1.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuarioController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository ?? throw new ArgumentNullException(nameof(IUsuarioRepository));
        }

        [HttpPost] //adicionar usuario no db
        public IActionResult Add(UsuarioViewModel usuarioView)
        {
            var usuario = new Usuario(usuarioView.Nome, usuarioView.Idade);
            _iUsuarioRepository.Add(usuario);
            return Ok();
        }
        [HttpGet] // pegar do db
        public IActionResult Get()
        {
            var usuario = _iUsuarioRepository.Get();
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var usuario = _iUsuarioRepository.GetByID(id);

            if(usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult PutByID(int id, UsuarioViewModel usuarioview)
        {
            var usuario = new Usuario(usuarioview.Nome, usuarioview.Idade);
            try
            {
                _iUsuarioRepository.PutByID(id, usuario);
                return Ok(usuario);
            }
            catch (ArgumentException)
            {
                return NotFound(); // If user doesn't exist
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteByID(int id)
        {
            var usuario = _iUsuarioRepository.GetByID(id);
            if(usuario == null)
            {
                return NotFound();
            }

            _iUsuarioRepository.DeleteByID(id);
            return Ok(usuario);
        }
    }
}
