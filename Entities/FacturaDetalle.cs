using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class FacturaDetalle
    {
        [Key]
        public int Id { get; set; }

        public int FacturaId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public int Precio { get; set; }

        public int Importe { get; set; }

        [ForeignKey("FacturaId")]
        public virtual Factura Factura { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }


        public FacturaDetalle()
        {
            Id = 0;
            FacturaId = 0;
            ProductoId = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public FacturaDetalle(int id, int facturaId, int productoId, int cantidad, int precio, int importe)
        {
            Id = id;
            FacturaId = facturaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

    }
}
