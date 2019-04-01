using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuijoteFacturaWF.Tests
{
    [TestClass]
    public class FacturaUT
    {
        [TestMethod()]
        public void Guardar()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            Factura factura = new Factura();
            factura.FacturaId = 5;
            factura.Fecha = DateTime.Now;
            factura.UsuarioId = 1;
            factura.NombreUsuario = "Lenington";
            factura.ClienteId = 1;
            factura.NombreUsuario = "Albert";
            factura.Itbis = 200f;
            factura.SubTotal = 800f;
            factura.Total = 1000;

            factura.Detalle.Add(new FacturaDetalle(0, 1, 1, "Salami Induveca", 2, 150, 300));
            factura.Detalle.Add(new FacturaDetalle(0, 2, 1, "Queso Geo", 1, 200, 200));

            bool paso = repositorio.Guardar(factura);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void Modificar()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            int id = 2;
            var factura = repositorio.Buscar(id);

            factura.Detalle.Add(new FacturaDetalle(0, 2, 1, "Queso Geo", 2, 200, 400));
            bool paso = repositorio.Modificar(factura);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void Eliminar()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            int id = 2;
            bool paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void Buscar()
        {
            int id = 1;
            RepositorioFactura repositorio = new RepositorioFactura();
            Factura factura = new Factura();
            bool paso = factura.Detalle.Count > 0;
            factura = repositorio.Buscar(id);
            Assert.IsNotNull(factura);
        }

        [TestMethod()]
        public void GetList()
        {
            Repositorio<Factura> repositorio = new Repositorio<Factura>();
            List<Factura> lista = new List<Factura>();
            Expression<Func<Factura, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
