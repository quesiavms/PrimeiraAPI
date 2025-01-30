using API._1.Models;
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

    }
}
