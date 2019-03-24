using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Entrada
    {
        [Key]
        public int EntradaId { get; set; }

        public DateTime Fecha { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }


        public Entrada()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            ProductoId = 0;
            Cantidad = 0;
        }

        public Entrada(int entradaId, DateTime fecha, int productoId, int cantidad)
        {
            EntradaId = entradaId;
            Fecha = fecha;
            ProductoId = productoId;
            Cantidad = cantidad;
        }

    }
}
