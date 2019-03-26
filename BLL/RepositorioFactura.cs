using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioFactura : Repositorio<Factura>
    {
        public override bool Guardar(Factura factura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Factura.Add(factura) != null)

                    foreach (var item in factura.Detalle)
                    {
                        contexto.Producto.Find(item.ProductoId).CantidadIventario -= item.Cantidad;
                    }

                contexto.Cliente.Find(factura.ClienteId).Deuda += factura.Total;

                contexto.SaveChanges();
                paso = true;

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static void ModificarBien(Factura factura, Factura FacturasAnteriores)
        {
            Contexto contexto = new Contexto();
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            Repositorio<Cliente> repository = new Repositorio<Cliente>();
            var Cliente = contexto.Cliente.Find(factura.ClienteId);
            var ClientesAnteriores = contexto.Cliente.Find(FacturasAnteriores.ClienteId);

            Cliente.Deuda += factura.Total;
            ClientesAnteriores.Deuda -= FacturasAnteriores.Total;
            repositorio.Modificar(Cliente);
            repository.Modificar(ClientesAnteriores);

        }

        public override bool Modificar(Factura factura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Factura> repositorio = new Repositorio<Factura>();
            try
            {
                var FactAnt = repositorio.Buscar(factura.FacturaId);

                if (factura.ClienteId != FactAnt.ClienteId)
                {
                    ModificarBien(factura, FactAnt);
                }

                if (factura != null)
                {
                    foreach (var item in FactAnt.Detalle)
                    {
                        contexto.Producto.Find(item.ProductoId).CantidadIventario += item.Cantidad;

                        if (!factura.Detalle.ToList().Exists(v => v.Id == item.Id))
                        {
                            item.Producto = null;
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    //Limpiando el Contexto.
                    contexto = new Contexto();

                    foreach (var item in factura.Detalle)
                    {
                        contexto.Producto.Find(item.ProductoId).CantidadIventario -= item.Cantidad;
                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }
                    //Limpiando el Contexto.
                    contexto = new Contexto();
                    contexto.Entry(factura).State = EntityState.Modified;
                }

                Modifica(factura, FactAnt, contexto);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }



        public static void Modifica(Factura factura, Factura FactAnt, Contexto contexto)
        {
            double modificado = factura.Total - FactAnt.Total;
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            var Cliente = contexto.Cliente.Find(factura.FacturaId);
            Cliente.Deuda += Convert.ToInt32(modificado);
            repositorio.Modificar(Cliente);
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Factura factura = contexto.Factura.Find(id);

                foreach (var item in factura.Detalle)
                {
                    var EliminInventario = contexto.Producto.Find(item.ProductoId);
                    EliminInventario.CantidadIventario += item.Cantidad;
                }

                contexto.Cliente.Find(factura.ClienteId).Deuda -= factura.Total;

                contexto.Factura.Remove(factura);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public override Factura Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Factura factura = new Factura();
            try
            {
                factura = contexto.Factura.Find(id);

                if (factura != null)
                {
                    factura.Detalle.Count();

                    foreach (var item in factura.Detalle)
                    {
                        string s = item.Producto.Descripcion;
                        string ss = item.Factura.FacturaId.ToString();
                    }
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return factura;
        }


        public override List<Factura> GetList(Expression<Func<Factura, bool>> expression)
        {
            List<Factura> list = new List<Factura>();
            Contexto contexto = new Contexto();
            try
            {
                list = contexto.Factura.Where(expression).ToList();

                foreach (var item in list)
                {
                    item.Detalle.Count();
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

    }
}
