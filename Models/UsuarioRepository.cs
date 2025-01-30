using API._1.Models;
using API._1.Data;
using Microsoft.AspNetCore.Connections;

namespace API._1.Models
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario); //adicionando usuario no db
            _context.SaveChanges();
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.ToList(); // trazendo a lista de usuarios do db
        }
    }
}
