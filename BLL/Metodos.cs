using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BLL
{
    public static class Metodos
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        //Métodos que retornan la lista en el Imprimir de las Consultas (Reportes).
        public static List<Cliente> FClientes()
        {
            Expression<Func<Cliente, bool>> filtro = p => true;
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            List<Cliente> list = new List<Cliente>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Departamento> FDepartamentos()
        {
            Expression<Func<Departamento, bool>> filtro = p => true;
            Repositorio<Departamento> repositorio = new Repositorio<Departamento>();
            List<Departamento> list = new List<Departamento>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Entrada> FEntradas()
        {
            Expression<Func<Entrada, bool>> filtro = p => true;
            Repositorio<Entrada> repositorio = new Repositorio<Entrada>();
            List<Entrada> list = new List<Entrada>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Factura> FFacturas()
        {
            Expression<Func<Factura, bool>> filtro = p => true;
            Repositorio<Factura> repositorio = new Repositorio<Factura>();
            List<Factura> list = new List<Factura>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Pago> FPagos()
        {
            Expression<Func<Pago, bool>> filtro = p => true;
            Repositorio<Pago> repositorio = new Repositorio<Pago>();
            List<Pago> list = new List<Pago>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Producto> FProductos()
        {
            Expression<Func<Producto, bool>> filtro = p => true;
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            List<Producto> list = new List<Producto>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Usuario> FUsuarios()
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            List<Usuario> list = new List<Usuario>();

            list = repositorio.GetList(filtro);

            return list;
        }

        //Métodos que retornan la lista en el Buscar de las Consultas.

        public static List<Cliente> FiltrarClientes(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Cliente, bool>> filtro = p => true;
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            List<Cliente> list = new List<Cliente>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ClienteId
                    filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Nombre
                    filtro = p => p.Nombres.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Departamento> FiltrarDepartamentos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Departamento, bool>> filtro = p => true;
            Repositorio<Departamento> repositorio = new Repositorio<Departamento>();
            List<Departamento> list = new List<Departamento>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://DepartamentoId
                    filtro = p => p.DepartamentoId == id;
                    break;
                    
                case 2://Nombre
                    filtro = p => p.Nombre.Contains(criterio);
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Entrada> FiltrarEntradas(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Entrada, bool>> filtro = p => true;
            Repositorio<Entrada> repositorio = new Repositorio<Entrada>();
            List<Entrada> list = new List<Entrada>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://EntradaId
                    filtro = p => p.EntradaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://ProductoId
                    filtro = p => p.ProductoId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Factura> FiltrarFacturas(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Factura, bool>> filtro = p => true;
            Repositorio<Factura> repositorio = new Repositorio<Factura>();
            List<Factura> list = new List<Factura>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://FacturaId
                    filtro = p => p.FacturaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://ClienteId
                    filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Pago> FiltrarPagos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Pago, bool>> filtro = p => true;
            Repositorio<Pago> repositorio = new Repositorio<Pago>();
            List<Pago> list = new List<Pago>();

            int id = ToInt(criterio);
            int monto = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ClienteId
                    filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                    
                case 3://Monto
                    filtro = p => p.Monto.Equals(monto) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Producto> FiltrarProductos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Producto, bool>> filtro = p => true;
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            List<Producto> list = new List<Producto>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.FechaVencimiento >= desde && p.FechaVencimiento <= hasta;
                    break;

                case 2://ProductoId
                    filtro = p => p.ProductoId == id && p.FechaVencimiento >= desde && p.FechaVencimiento <= hasta;
                    break;

                case 3://Descripcion
                    filtro = p => p.Descripcion.Contains(criterio) && p.FechaVencimiento >= desde && p.FechaVencimiento <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Usuario> FiltrarUsuarios(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            List<Usuario> list = new List<Usuario>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://UsuarioId
                    filtro = p => p.UsuarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://CuentaId
                    filtro = p => p.Nombres.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static double ToDouble(string valor)
        {
            double retorno = 0;
            double.TryParse(valor, out retorno);

            return retorno;
        }

        //Método para obtener la Ganancia.
        public static double Ganancia(double costo, double precio)
        {
            double PctGanancia = 0;

            PctGanancia = precio - costo;
            PctGanancia = PctGanancia / costo;
            PctGanancia *= 100;

            return PctGanancia;
        }

        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
    }
}
