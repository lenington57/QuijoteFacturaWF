using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; }

        public int ClienteId { get; set; }

        public string NombreCliente { get; set; }

        public DateTime Fecha { get; set; }

        public double SubTotal { get; set; }

        public double Itbis { get; set; }

        public int Total { get; set; }

        public virtual List<FacturaDetalle> Detalle { get; set; }


        public Factura()
        {
            this.Detalle = new List<FacturaDetalle>();
        }

        public void AgregarDetalle(int Id, int FacturaId, int ProductoId, string Descripcion, int Cantidad, int Precio, int Importe)
        {
            this.Detalle.Add(new FacturaDetalle(Id, FacturaId, ProductoId, Descripcion, Cantidad, Precio, Importe));
        }

        public override string ToString()
        {
            return FacturaId.ToString();
        }

    }
}
