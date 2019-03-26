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
    public class RepositorioPago : Repositorio<Pago>
    {
        public override bool Guardar(Pago pago)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Pago.Add(pago) != null)
                {
                    contexto.Cliente.Find(pago.ClienteId).Deuda -= pago.Monto;

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


        public override bool Modificar(Pago pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Pago> repositorio = new Repositorio<Pago>();
            Repositorio<Cliente> repository = new Repositorio<Cliente>();
            try
            {
                Pago PagoAnt = repositorio.Buscar(pago.PagoId);

                if (PagoAnt.ClienteId != pago.ClienteId)
                {
                    ModificarBien(pago, PagoAnt);
                }

                int modificado = pago.Monto - PagoAnt.Monto;

                var Cliente = contexto.Cliente.Find(pago.ClienteId);
                Cliente.Deuda += modificado;
                repository.Modificar(Cliente);

                //Limpiando el Contexto.
                contexto = new Contexto();
                contexto.Entry(pago).State = EntityState.Modified;
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
                Pago pago = contexto.Pago.Find(id);

                contexto.Cliente.Find(pago.ClienteId).Deuda += pago.Monto;

                contexto.Pago.Remove(pago);

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


        public override Pago Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pago pago = new Pago();

            try
            {
                pago = contexto.Pago.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
        }


        public override List<Pago> GetList(Expression<Func<Pago, bool>> expression)
        {
            List<Pago> pagos = new List<Pago>();
            Contexto contexto = new Contexto();

            try
            {
                pagos = contexto.Pago.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return pagos;
        }

        public static void ModificarBien(Pago pago, Pago PagoAnterior)
        {
            Contexto contexto = new Contexto();
            var Cliente = contexto.Cliente.Find(pago.ClienteId);
            var ClienteAnterior = contexto.Cliente.Find(PagoAnterior.ClienteId);
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            Repositorio<Cliente> repository = new Repositorio<Cliente>();

            Cliente.Deuda += pago.Monto;
            ClienteAnterior.Deuda -= PagoAnterior.Monto;
            repositorio.Modificar(Cliente);
            repository.Modificar(ClienteAnterior);
        }
    }
}
