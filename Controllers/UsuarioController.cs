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
        public IActionResult Add([FromForm] UsuarioViewModel usuarioView) //from form para enviar arquivos nao apenas no formato json
        {
            var filePath = Path.Combine("Storage", usuarioView.Foto.FileName); //criando o caminho da foto
            using Stream fileStream = new FileStream(filePath, FileMode.Create); // salvando na api
            usuarioView.Foto.CopyTo(fileStream); // criando na pasta storage
            var usuario = new Usuario(usuarioView.Nome, usuarioView.Idade, filePath); // salvando no banco
            _iUsuarioRepository.Add(usuario);
            return Ok();
        }

        [HttpGet] // pegar do db
        public IActionResult Get()
        {
            var usuario = _iUsuarioRepository.Get();
            return Ok(usuario);
        }

        [HttpGet("{id}")] // pega do db pelo id
        public IActionResult GetByID(int id)
        {
            var usuario = _iUsuarioRepository.GetByID(id);

            if(usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadFoto(int id)
        {
            var usuario = _iUsuarioRepository.GetByID(id);
            var dataBytes = System.IO.File.ReadAllBytes(usuario.Foto);

            return File(dataBytes, "image/png");
        }

        [HttpPut("{id}")] // atualiza user pelo id
        public IActionResult PutByID(int id, UsuarioViewModel usuarioview)
        {
            var usuario = new Usuario(usuarioview.Nome, usuarioview.Idade, usuarioview.Foto.FileName);
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

        [HttpDelete("{id}")] // deleta user pelo id
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
