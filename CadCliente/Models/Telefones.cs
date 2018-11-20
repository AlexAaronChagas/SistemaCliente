using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadCliente.Models
{
    public class Telefones
    {
        public int Id { get; set; }

       //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[-]?)?(?|0+$)\\d{10,15}$")]
        public string Telefone { get; set; }

        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }      
    }
}