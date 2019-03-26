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
    public partial class ProductoWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LlenaCombo();
        }

        //Métodos
        private void LlenaCombo()
        {
            Repositorio<Departamento> repositorio = new Repositorio<Departamento>();
            departamentoDropDownList.DataSource = repositorio.GetList(c => true);
            departamentoDropDownList.DataValueField = "DepartamentoId";
            departamentoDropDownList.DataTextField = "Nombre";
            departamentoDropDownList.DataBind();
        }

        private Producto LlenaClase()
        {
            Producto producto = new Producto();

            producto.ProductoId = Utils.ToInt(productoIdTextBox.Text);
            producto.DepartamentoId = Utils.ToInt(departamentoDropDownList.SelectedValue);
            producto.FechaVencimiento = Utils.ToDateTime(fechaTextBox.Text).Date;
            producto.Descripcion = descripcionTextBox.Text;
            producto.Costo = Utils.ToInt(costoTextBox.Text);
            producto.Precio = Utils.ToInt(precioTextBox.Text);
            producto.Ganancia = Utils.ToDouble(porGanTextBox.Text);
            producto.CantidadIventario = 0;

            return producto;
        }

        private void LimpiaObjetos()
        {
            productoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            departamentoDropDownList.SelectedIndex = 0;
            descripcionTextBox.Text = "";
            costoTextBox.Text = "";
            precioTextBox.Text = "";
            porGanTextBox.Text = "";
            canInvTextBox.Text = "";
        }

        public void LlenaCampos(Producto producto)
        {
            LimpiaObjetos();
            fechaTextBox.Text = producto.FechaVencimiento.ToString("yyyy-MM-dd");
            departamentoDropDownList.SelectedValue = producto.DepartamentoId.ToString();
            descripcionTextBox.Text = producto.Descripcion;
            costoTextBox.Text = producto.Costo.ToString();
            precioTextBox.Text = producto.Precio.ToString();
            porGanTextBox.Text = producto.Ganancia.ToString();
            canInvTextBox.Text = producto.CantidadIventario.ToString();
        }

        //Programación de los Botones
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Producto> repositorio = new Repositorio<Producto>();

            var producto = repositorio.Buscar(Utils.ToInt(productoIdTextBox.Text));
            if (producto != null)
            {
                LlenaCampos(producto);
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
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            Producto producto = new Producto();

            producto = LlenaClase();

            if (productoIdTextBox.Text == "0")
            {
                paso = repositorio.Guardar(producto);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                LimpiaObjetos();
            }
            else
            {
                Repositorio<Producto> repository = new Repositorio<Producto>();
                int id = Utils.ToInt(productoIdTextBox.Text);
                producto = repository.Buscar(id);

                if (producto != null)
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
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            int id = Utils.ToInt(productoIdTextBox.Text);

            var producto = repositorio.Buscar(id);

            if (producto != null)
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

        //Programación de los Eventos.
        protected void costoTextBox_TextChanged(object sender, EventArgs e)
        {
            double costo = Utils.ToDouble(costoTextBox.Text);
            double precio = Utils.ToDouble(precioTextBox.Text);
            if (costoTextBox.Text != string.Empty || precioTextBox.Text != string.Empty)
            {
                if (costo > precio)
                {
                    Utils.ShowToastr(this, "No puede ser más alto el costo que el precio", "Error", "error");
                    return;
                }
                else
                    porGanTextBox.Text = Metodos.Ganancia(costo, precio).ToString();
            }
            else
                Utils.ShowToastr(this, "No puede estar vacío Costo ni Precio", "Error", "error");
        }

        protected void precioTextBox_TextChanged(object sender, EventArgs e)
        {
            double costo = Utils.ToDouble(costoTextBox.Text);
            double precio = Utils.ToDouble(precioTextBox.Text);
            if (costoTextBox.Text != string.Empty || precioTextBox.Text != string.Empty)
            {
                if (costo > precio)
                {
                    Utils.ShowToastr(this, "No puede ser más alto el costo que el precio", "Error", "error");
                    return;
                }
                else
                    porGanTextBox.Text = Metodos.Ganancia(costo, precio).ToString();
            }
            else
                Utils.ShowToastr(this, "No puede estar vacío Costo ni Precio", "Error", "error");
        }
    }
}