using BLL;
using Entities;
using QuijoteFacturaWF.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuijoteFacturaWF.Registros
{
    public partial class UsuarioWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        //Métodos
        private Usuario LlenaClase()
        {
            Usuario usuario = new Usuario();

            usuario.UsuarioId = Utils.ToInt(usuarioIdTextBox.Text);
            usuario.Fecha = Utils.ToDateTime(fechaTextBox.Text).Date;
            usuario.Nombres = nombreTextBox.Text;            
            usuario.NoTelefono = noTelefonoTextBox.Text;
            usuario.Email = emailTextBox.Text;
            usuario.Password = passwordTextBox.Text;
            usuario.CPassword = cpasswordTextBox.Text;

            return usuario;
        }

        private void LimpiaObjetos()
        {
            usuarioIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            nombreTextBox.Text = "";
            noTelefonoTextBox.Text = "";
            emailTextBox.Text = "";
            passwordTextBox.Text = "";
            cpasswordTextBox.Text = "";
        }

        public void LlenaCampos(Usuario usuario)
        {
            LimpiaObjetos();
            fechaTextBox.Text = usuario.Fecha.ToString("yyyy-MM-dd");
            nombreTextBox.Text = usuario.Nombres;
            noTelefonoTextBox.Text = usuario.NoTelefono;
            emailTextBox.Text = usuario.Email;
            passwordTextBox.Text = usuario.Password;
            cpasswordTextBox.Text = usuario.CPassword;
        }

        //Programación de los Botones
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();

            var usuario = repositorio.Buscar(Utils.ToInt(usuarioIdTextBox.Text));
            if (usuario != null)
            {
                LlenaCampos(usuario);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                LimpiaObjetos();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Usuario usuario = new Usuario();

            usuario = LlenaClase();

            if (usuarioIdTextBox.Text == "0")
            {
                paso = repositorio.Guardar(usuario);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                LimpiaObjetos();
            }
            else
            {
                Repositorio<Usuario> repository = new Repositorio<Usuario>();
                int id = Utils.ToInt(usuarioIdTextBox.Text);
                usuario = repository.Buscar(id);

                if (usuario != null)
                {
                    paso = repository.Modificar(LlenaClase());
                    Utils.ShowToastr(this, "Modificado", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "Id no existe", "Error", "error");
            }

            if (paso)
            {
                LimpiaObjetos();
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            int id = Utils.ToInt(usuarioIdTextBox.Text);

            var usuario = repositorio.Buscar(id);

            if (usuario != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    LimpiaObjetos();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
}