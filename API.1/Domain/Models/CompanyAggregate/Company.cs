using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API._1.Domain.Models.CompanyAggregate
{
    [Table("company")]
    public class Company
    {
        [Key] 
        public int id { get; set; }
        public string Nome { get; set; }
    }
}
