using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Nombres { get; set; }

        public string NoTelefono { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public Usuario()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            NoTelefono = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }

        public Usuario(int usuarioId, string nombres, string noTelefono, string email, string password)
        {
            UsuarioId = usuarioId;
            Nombres = nombres;
            NoTelefono = noTelefono;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return Nombres;
        }
    }
}
