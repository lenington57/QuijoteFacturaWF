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
    public partial class EntradaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LlenaCombo();
        }

        //Métodos
        private void LlenaCombo()
        {
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            productoDropDownList.DataSource = repositorio.GetList(c => true);
            productoDropDownList.DataValueField = "ProductoId";
            productoDropDownList.DataTextField = "Descripcion";
            productoDropDownList.DataBind();
        }

        private Entrada LlenaClase()
        {
            Entrada entrada = new Entrada();

            entrada.EntradaId = Utils.ToInt(entradaIdTextBox.Text);
            entrada.Fecha = Utils.ToDateTime(fechaTextBox.Text).Date;
            entrada.ProductoId = Utils.ToInt(productoDropDownList.SelectedValue);
            entrada.Cantidad = Utils.ToInt(cantidadTextBox.Text);

            return entrada;
        }

        private void LimpiaObjetos()
        {
            entradaIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            productoDropDownList.SelectedIndex = 0; ;
            cantidadTextBox.Text = "0";
        }

        public void LlenaCampos(Entrada entrada)
        {
            LimpiaObjetos();
            fechaTextBox.Text = entrada.Fecha.ToString("yyyy-MM-dd");
            productoDropDownList.SelectedValue = entrada.ProductoId.ToString();
            cantidadTextBox.Text = entrada.Cantidad.ToString();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;
            if (Utils.ToIntObjetos(productoDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Debe tener al menos un Producto guardado", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(entradaIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        //Programación de los Botones
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioEntrada repositorio = new RepositorioEntrada();

            var entrada = repositorio.Buscar(Utils.ToInt(entradaIdTextBox.Text));
            if (entrada != null)
            {
                LlenaCampos(entrada);
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
            RepositorioEntrada repositorio = new RepositorioEntrada();
            Entrada entrada = new Entrada();

            if (HayErrores())
            {
                return;
            }
            else
            {
                entrada = LlenaClase();

                if (entradaIdTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(entrada);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    LimpiaObjetos();
                }
                else
                {
                    RepositorioEntrada repository = new RepositorioEntrada();
                    int id = Utils.ToInt(entradaIdTextBox.Text);
                    entrada = repository.Buscar(id);

                    if (entrada != null)
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
        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            RepositorioEntrada repositorio = new RepositorioEntrada();
            int id = Utils.ToInt(entradaIdTextBox.Text);

            var entrada = repositorio.Buscar(id);

            if (entrada != null)
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