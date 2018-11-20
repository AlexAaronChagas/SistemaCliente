using CadCliente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadCliente.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext()
            : base("ClienteConexao")
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}