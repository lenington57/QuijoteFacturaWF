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
    public class ProductoUT
    {
        [TestMethod]
        public void Guardar()
        {
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            Producto producto = new Producto();
            bool paso = false;

            producto.ProductoId = 6;
            producto.FechaVencimiento = DateTime.Now;
            producto.DepartamentoId = 1;
            producto.Descripcion = "Queso Geo";
            producto.Costo = 120;
            producto.Precio = 150;
            producto.Ganancia = 12.54; 
            producto.CantidadIventario = 0;

            paso = repositorio.Guardar(producto);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var producto = BuscarM();
            Repositorio<Producto> repositorio = new Repositorio<Producto>();

            bool paso = false;
            producto.Descripcion = "Queso Hoja";
            paso = repositorio.Modificar(producto);
            Assert.AreEqual(true, paso);
        }

        public Producto BuscarM()
        {
            int id = 6;
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            Producto producto = new Producto();
            producto = repositorio.Buscar(id);
            return producto;
        }

        [TestMethod]
        public void Eliminar()
        {
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            int id = 6;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            Producto producto = new Producto();
            producto = repositorio.Buscar(id);
            Assert.IsNotNull(producto);
        }

        [TestMethod()]
        public void GetList()
        {
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            List<Producto> lista = new List<Producto>();
            Expression<Func<Producto, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
