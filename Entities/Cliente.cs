using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombres { get; set; }

        public string NoTelefono { get; set; }

        public string NoCedula { get; set; }

        public string Direccion { get; set; }

        public int Deuda { get; set; }


        public Cliente()
        {
            ClienteId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            NoTelefono = string.Empty;
            NoCedula = string.Empty;
            Direccion = string.Empty;
            Deuda = 0;
        }

        public Cliente(int clienteId, DateTime fecha, string nombres, string noTelefono, string noCedula, string direccion, int deuda)
        {
            ClienteId = clienteId;
            Fecha = fecha;
            Nombres = nombres;
            NoTelefono = noTelefono;
            NoCedula = noCedula;
            Direccion = direccion;
            Deuda = deuda;
        }

        public override string ToString()
        {
            return Nombres;
        }
    }
}
