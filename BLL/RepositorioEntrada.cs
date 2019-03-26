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
    public class RepositorioEntrada : Repositorio<Entrada>
    {
        public override bool Guardar(Entrada entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Entrada.Add(entrada) != null)
                {
                    contexto.Producto.Find(entrada.ProductoId).CantidadIventario += entrada.Cantidad;

                    contexto.SaveChanges();
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


        public override bool Modificar(Entrada entrada)
        {
            bool paso = false;
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            Repositorio<Entrada> repository = new Repositorio<Entrada>();
            Contexto contexto = new Contexto();
            try
            {
                Entrada EntrAnt = repository.Buscar(entrada.EntradaId);

                if (EntrAnt.ProductoId != entrada.ProductoId)
                {
                    ModificarBien(entrada, EntrAnt);
                }

                int modificado = entrada.Cantidad - EntrAnt.Cantidad;

                var Producto = contexto.Producto.Find(entrada.ProductoId);
                Producto.CantidadIventario += modificado;
                repositorio.Modificar(Producto);

                //Limpiando el Contexto.
                contexto = new Contexto();
                contexto.Entry(entrada).State = EntityState.Modified;
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


        public override bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Entrada entrada = contexto.Entrada.Find(id);

                contexto.Producto.Find(entrada.ProductoId).CantidadIventario -= entrada.Cantidad;

                contexto.Entrada.Remove(entrada);

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


        public override Entrada Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entrada entrada = new Entrada();

            try
            {
                entrada = contexto.Entrada.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }


        public override List<Entrada> GetList(Expression<Func<Entrada, bool>> expression)
        {
            List<Entrada> list = new List<Entrada>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.Entrada.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public static void ModificarBien(Entrada entradas, Entrada EntradasAnteriores)
        {
            Contexto contexto = new Contexto();
            var Producto = contexto.Producto.Find(entradas.ProductoId);
            var ProductosAnteriores = contexto.Producto.Find(EntradasAnteriores.ProductoId);
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            Repositorio<Producto> repository = new Repositorio<Producto>();

            Producto.CantidadIventario += entradas.Cantidad;
            ProductosAnteriores.CantidadIventario -= EntradasAnteriores.Cantidad;
            repositorio.Modificar(Producto);
            repository.Modificar(ProductosAnteriores);
        }

    }
}
