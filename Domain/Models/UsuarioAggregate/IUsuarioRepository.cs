using API._1.Domain.DTOs;

namespace API._1.Domain.Models.UsuarioAggregate
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        List<UsuarioDTO> Get(int pageNumber, int pageQuantity); //parametros para paginação

        Usuario? GetByID(int id);

        void PutByID(int id, Usuario usuario);

        void DeleteByID(int id);
    }
}
