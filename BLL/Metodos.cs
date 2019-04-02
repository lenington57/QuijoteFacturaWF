using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
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

        //Para verificar el inicio de sesión.
        public static void Autenticar(string email, string password, Page page)
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario usuario = new Usuario();

            filtrar = t => t.Email.Equals(email) && t.Password.Equals(password);

            if (repositorio.GetList(filtrar).Count() != 0)
                FormsAuthentication.RedirectFromLoginPage(usuario.Email, true);
            else
                ShowToastr(page, "Email o Contraseña incorrectos", "Error", "error");
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

        public static List<FacturaDetalle> FilFacturas(int id)
        {
            Expression<Func<FacturaDetalle, bool>> filtro = p => true;
            Repositorio<FacturaDetalle> repositorio = new Repositorio<FacturaDetalle>();
            List<FacturaDetalle> list = new List<FacturaDetalle>();

            list = repositorio.GetList(p=> p.FacturaId == id);

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

        //Toastr.
        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        //Llenar la Descripción.
        public static string Descripcion(int IdLista)
        {
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            Producto producto = new Producto();
            int id = IdLista;
            producto = repositorio.Buscar(id);

            string desc = producto.Descripcion;

            return desc;
        }

        //Llenar la Descripción.
        public static string Usuario(int IdLista)
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Usuario usuario = new Usuario();
            int id = IdLista;
            usuario = repositorio.Buscar(id);

            string desc = usuario.Nombres;

            return desc;
        }

        //Llenar la Cliente.
        public static string Cliente(int IdLista)
        {
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            Cliente cliente = new Cliente();
            int id = IdLista;
            cliente = repositorio.Buscar(id);

            string desc = cliente.Nombres;

            return desc;
        }

        //Lista para el Detalle.
        public static List<FacturaDetalle> ListaDetalle(int IdLista)
        {
            Repositorio<FacturaDetalle> repositorio = new Repositorio<FacturaDetalle>();
            List<FacturaDetalle> list = new List<FacturaDetalle>();
            int id = IdLista;
            list = repositorio.GetList(c => c.FacturaId == id);

            return list;
        }

        //Detalle para el Detalle.
        public static FacturaDetalle Detalle(int IdLista)
        {
            Repositorio<FacturaDetalle> repositorio = new Repositorio<FacturaDetalle>();
            FacturaDetalle detalle = new FacturaDetalle();
            int id = IdLista;
            detalle = repositorio.Buscar(id);

            return detalle;
        }

        //Lista para el Importe del Detalle.
        public static int Importe(int cantidad, int precio)
        {
            int CalImporte = 0;
            CalImporte = cantidad * precio;

            return CalImporte;
        }
    }
}
