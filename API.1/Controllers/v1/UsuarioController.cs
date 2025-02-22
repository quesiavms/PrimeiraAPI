﻿using System.Collections.Specialized;
using API._1.Application.ViewModel;
using API._1.Domain.DTOs;
using API._1.Domain.Models;
using API._1.Domain.Models.UsuarioAggregate;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API._1.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository iUsuarioRepository, ILogger<UsuarioController> logger, IMapper mapper)
        {
            _iUsuarioRepository = iUsuarioRepository ?? throw new ArgumentNullException(nameof(iUsuarioRepository));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [Authorize]
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
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            //_logger.Log(LogLevel.Error, "Theres a error"); //aparece no cmd

            //throw new Exception("Erro de Teste");

            var usuario = _iUsuarioRepository.Get(pageNumber, pageQuantity);

            //_logger.LogInformation("Teste"); //aparece no cmd tambem

            return Ok(usuario);
        }

        [HttpGet("{id}")] // pega do db pelo id
        public IActionResult GetByID(int id)
        {
            var usuario = _iUsuarioRepository.GetByID(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadFoto(int id)
        {
            var usuario = _iUsuarioRepository.GetByID(id);
            var dataBytes = System.IO.File.ReadAllBytes(usuario.Foto);

            return File(dataBytes, "image/png");
        }

        [Authorize]
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

        [Authorize]
        [HttpDelete("{id}")] // deleta user pelo id
        public IActionResult DeleteByID(int id)
        {
            var usuario = _iUsuarioRepository.GetByID(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _iUsuarioRepository.DeleteByID(id);
            return Ok(usuario);
        }

        [HttpGet]
        [Route("/automapper/{id}")] //usando o automapper
        public IActionResult Search(int id)
        {
            var usuario = _iUsuarioRepository.GetByID(id);
            var usuarioDTOS = _mapper.Map<UsuarioDTO>(usuario);

            return Ok(usuario);
        }

    }
}
