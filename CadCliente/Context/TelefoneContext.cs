using CadCliente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadCliente.Context
{
    public class TelefoneContext : DbContext
    {
        public TelefoneContext()
            : base("ClienteConexao")
        {

        }

        public DbSet<Telefones> Telefone { get; set; }

        public System.Data.Entity.DbSet<CadCliente.Models.Cliente> Clientes { get; set; }
    }
}