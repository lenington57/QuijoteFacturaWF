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
    public partial class PagoWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LlenaCombo();
        }

        //Métodos
        private void LlenaCombo()
        {
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            clienteDropDownList.DataSource = repositorio.GetList(c => true);
            clienteDropDownList.DataValueField = "ClienteId";
            clienteDropDownList.DataTextField = "Nombres";
            clienteDropDownList.DataBind();
        }

        private Pago LlenaClase()
        {
            Pago pago = new Pago();

            pago.PagoId = Utils.ToInt(pagoIdTextBox.Text);
            pago.Fecha = Utils.ToDateTime(fechaTextBox.Text).Date;
            pago.ClienteId = Utils.ToInt(clienteDropDownList.SelectedValue);
            pago.Monto = Utils.ToInt(montoTextBox.Text);

            return pago;
        }

        private void LimpiaObjetos()
        {
            pagoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            clienteDropDownList.SelectedIndex = 0;
            montoTextBox.Text = "0";
        }

        public void LlenaCampos(Pago pago)
        {
            LimpiaObjetos();
            fechaTextBox.Text = pago.Fecha.ToString("yyyy-MM-dd");
            clienteDropDownList.SelectedValue = pago.ClienteId.ToString();
            montoTextBox.Text = pago.Monto.ToString();
        }

        //Programación de los Botones
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Pago> repositorio = new Repositorio<Pago>();

            var pago = repositorio.Buscar(Utils.ToInt(pagoIdTextBox.Text));
            if (pago != null)
            {
                LlenaCampos(pago);
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
            Repositorio<Pago> repositorio = new Repositorio<Pago>();
            Pago pago = new Pago();

            pago = LlenaClase();

            if (pagoIdTextBox.Text == "0")
            {
                paso = repositorio.Guardar(pago);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                LimpiaObjetos();
            }
            else
            {
                Repositorio<Pago> repository = new Repositorio<Pago>();
                int id = Utils.ToInt(pagoIdTextBox.Text);
                pago = repository.Buscar(id);

                if (pago != null)
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
            Repositorio<Pago> repositorio = new Repositorio<Pago>();
            int id = Utils.ToInt(pagoIdTextBox.Text);

            var pago = repositorio.Buscar(id);

            if (pago != null)
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