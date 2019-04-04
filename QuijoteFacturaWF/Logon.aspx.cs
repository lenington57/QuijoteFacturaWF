using BLL;
using Entities;
using QuijoteFacturaWF.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuijoteFacturaWF
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuario> repositorio = new Repositorio<Usuario>();
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario usuario = new Usuario();

            filtrar = t => t.Email.Equals(emailTextBox.Text) && t.Password.Equals(passwordTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                FormsAuthentication.RedirectFromLoginPage(usuario.Email, true);
                Utils.ShowToastr(this, "Bienvenido", "Correcto", "info");
            }
            else
                Utils.ShowToastr(this, "Email o Contraseña incorrectos", "Error", "error");
        }
    }
}