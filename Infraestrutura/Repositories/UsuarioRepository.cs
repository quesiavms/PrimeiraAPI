using API._1.Domain.DTOs;
using API._1.Domain.Models.UsuarioAggregate;
using API._1.Migrations.Data;
using Microsoft.AspNetCore.Connections;

namespace API._1.Infraestrutura.Repositories
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

        public List<UsuarioDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Usuarios.Skip(pageNumber * pageQuantity)
                                    .Take(pageQuantity)
                                    .Select(b => 
                                    new UsuarioDTO
                                    {
                                        Nome = b.Nome,
                                        idade = b.idade,
                                        Foto = b.Foto
                                    })
                                    .ToList(); // trazendo a lista de usuarios do db
        }

        public Usuario GetByID(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void PutByID(int id, Usuario usuario)
        {
            var usuarioExistente = _context.Usuarios.Find(id);
            if (usuarioExistente == null)
            {
                throw new ArgumentException("User not found");
            }

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.idade = usuario.idade;

            _context.Usuarios.Update(usuarioExistente);
            _context.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            var usuarioExiste = _context.Usuarios.Find(id);
            if (usuarioExiste == null)
            {
                throw new ArgumentException("User not Found");
            }

            _context.Usuarios.Remove(usuarioExiste);
            _context.SaveChanges();
        }
    }
}
