using API._1.Models;
using API._1.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API._1.Models
{
    /* classe com atributos iguais aos db (precisam ser iguais, exatamente iguais) */
    [Table("Usuarios")] //falando para o sistema o nome da tabela do banco, tendo que o nome da nossa classe é diferente
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? Nome{ get; set; }

        public int idade { get; set; }

        public string Foto { get; set; }
        public Usuario(string nome, int idade, string foto)
        {
            this.Nome = nome ?? throw new ArgumentNullException("name");
            this.idade = idade;
            this.Foto = foto;
        }
    }
}

