namespace API._1.Domain.Models
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        List<Usuario> Get(int pageNumber, int pageQuantity); //parametros para paginação

        Usuario? GetByID(int id);

        void PutByID(int id, Usuario usuario);

        void DeleteByID(int id);
    }
}
