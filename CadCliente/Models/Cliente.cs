using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadCliente.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString ="{0:d}")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [EmailAddress(ErrorMessage="E-mail em formato inválido")]
        public string Email { get; set; }

        [ForeignKey("ClienteId")]
        public ICollection<Telefones> Telefones { get; set; }
    }
}