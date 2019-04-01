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
    public class ClienteUT
    {
        [TestMethod]
        public void Guardar()
        {
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            Cliente cliente = new Cliente();
            bool paso = false;

            cliente.ClienteId = 2;
            cliente.Fecha = DateTime.Now;
            cliente.Nombres = "Mario";
            cliente.NoTelefono = "8098971234";
            cliente.NoCedula = "00011111112";
            cliente.Direccion = "San Francisco";
            cliente.Deuda = 0;

            paso = repositorio.Guardar(cliente);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var cliente = BuscarM();
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();

            bool paso = false;
            cliente.Nombres = "Fernando";
            paso = repositorio.Modificar(cliente);
            Assert.AreEqual(true, paso);
        }

        public Cliente BuscarM()
        {
            int id = 3;
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            Cliente cliente = new Cliente();
            cliente = repositorio.Buscar(id);
            return cliente;
        }

        [TestMethod]
        public void Eliminar()
        {
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            Cliente cliente = new Cliente();
            cliente = repositorio.Buscar(id);
            Assert.IsNotNull(cliente);
        }

        [TestMethod()]
        public void GetList()
        {
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            List<Cliente> lista = new List<Cliente>();
            Expression<Func<Cliente, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
