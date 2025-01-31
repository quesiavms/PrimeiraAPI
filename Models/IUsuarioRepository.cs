namespace API._1.Models
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        List<Usuario> Get();

        Usuario GetByID(int id);

        void PutByID(int id, Usuario usuario);

        void DeleteByID(int id);
    }
}
