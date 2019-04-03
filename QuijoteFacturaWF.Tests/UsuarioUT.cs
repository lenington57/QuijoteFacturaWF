using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuijoteFacturaWF.Tests
{
    [TestClass]
    public class UsuarioUT
    {
        [TestMethod]
        public void Guardar()
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Usuario usuario = new Usuario();
            bool paso = false;

            usuario.UsuarioId = 3;
            usuario.Fecha = DateTime.Now;
            usuario.Nombres = "Avatar";
            usuario.NoTelefono = "8098971234";
            usuario.Email = "avatar@gmail.com";
            usuario.Password = "1234";
            usuario.CPassword = "1234";

            paso = repositorio.Guardar(usuario);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var usuario = BuscarM();
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();

            bool paso = false;
            usuario.Nombres = "Alfredo";
            paso = repositorio.Modificar(usuario);
            Assert.AreEqual(true, paso);
        }

        public Usuario BuscarM()
        {
            int id = 3;
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Usuario cuenta = new Usuario();
            cuenta = repositorio.Buscar(id);
            return cuenta;
        }

        [TestMethod]
        public void Eliminar()
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            int id = 3;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Usuario usuario = new Usuario();
            usuario = repositorio.Buscar(id);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void GetList()
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            List<Usuario> lista = new List<Usuario>();
            Expression<Func<Usuario, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
