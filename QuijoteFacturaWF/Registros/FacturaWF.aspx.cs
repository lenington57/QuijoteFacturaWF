using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuijoteFacturaWF.Registros
{
    public partial class FacturaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        //Métodos
        //Programación de los Botones

        //Eventos de los Objetos
        protected void productoIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

}