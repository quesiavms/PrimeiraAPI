namespace API._1.Application.ViewModel
{
    public class UsuarioViewModel //o que esta sendo mostrado
    {
        //public int id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public IFormFile Foto { get; set; } // acessar todos atributos do arquivo
    }
}
