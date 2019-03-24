using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        public int DepartamentoId { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; }

        public int Costo { get; set; }

        public int Precio { get; set; }

        public int Ganancia { get; set; }

        public int CantidadIventario { get; set; }


        public Producto()
        {
            ProductoId = 0;
            DepartamentoId = 0;
            FechaVencimiento = DateTime.Now;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            Ganancia = 0;
            CantidadIventario = 0;
        }

        public Producto(int productoId, int departamentoId, DateTime fechaVencimiento, string descripcion, int costo, int precio, int ganancia, int cantidadIventario)
        {
            ProductoId = productoId;
            DepartamentoId = departamentoId;
            FechaVencimiento = DateTime.Now;
            Descripcion = descripcion;
            Costo = costo;
            Precio = precio;
            Ganancia = ganancia;
            CantidadIventario = cantidadIventario;
        }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
