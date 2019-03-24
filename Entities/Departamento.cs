using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }

        public string Nombre { get; set; }


        public Departamento()
        {
            DepartamentoId = 0;
            Nombre = string.Empty;
        }

        public Departamento(int departamentoId, string nombre)
        {
            DepartamentoId = departamentoId;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
