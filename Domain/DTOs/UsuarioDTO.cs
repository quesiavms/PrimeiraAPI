namespace API._1.Domain.DTOs
{/*
  DTO Impedem que informações sensiveis ou privadas sejam expostas para o front, nosso exemplo ID
  */
    public class UsuarioDTO
    {
        public string? Nome { get; set; }

        public int? idade { get; set; }

        public string? Foto { get; set; }
    }
}
