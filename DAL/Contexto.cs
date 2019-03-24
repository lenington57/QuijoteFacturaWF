using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<Entrada> Entrada { get; set; }

        public DbSet<Factura> Factura { get; set; }

        public DbSet<Pago> Pago { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Usuario> Usuario { get; set; }


        public Contexto() : base("ConStr")
        {

        }
    }
}
