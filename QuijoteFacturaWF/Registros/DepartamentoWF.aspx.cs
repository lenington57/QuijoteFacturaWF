using BLL;
using Entities;
using QuijoteFacturaWF.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuijoteFacturaWF.Registros
{
    public partial class DepartamentoWF : System.Web.UI.Page
    {
        Repositorio<Departamento> repositorio = new Repositorio<Departamento>();
        Expression<Func<Departamento, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Métodos
        private Departamento LlenaClase()
        {
            Departamento departamento = new Departamento();

            departamento.DepartamentoId = Convert.ToInt32(departamentoIdTextBox.Text);
            departamento.Nombre = nombreTextBox.Text;

            return departamento;
        }

        private void LimpiaObjetos()
        {
            departamentoIdTextBox.Text = "0";
            nombreTextBox.Text = "";
        }

        public void LlenarCampos(Departamento departamento)
        {
            LimpiaObjetos();
            departamentoIdTextBox.Text = departamento.DepartamentoId.ToString();
            nombreTextBox.Text = departamento.Nombre;
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            filtrar = t => t.Nombre.Equals(nombreTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                Utils.ShowToastr(this, "Este Nombre ya existe", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(departamentoIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        //Progrmación de los Botones
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Departamento> repositorio = new Repositorio<Departamento>();

            var deposito = repositorio.Buscar(Utils.ToInt(departamentoIdTextBox.Text));
            if (deposito != null)
            {
                LlenarCampos(deposito);
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
            Repositorio<Departamento> repositorio = new Repositorio<Departamento>();
            Departamento departamento = new Departamento();
            if (HayErrores())
            {
                return;
            }
            else
            {
                departamento = LlenaClase();

                if (departamentoIdTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(departamento);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    LimpiaObjetos();
                }
                else
                {
                    Repositorio<Departamento> repository = new Repositorio<Departamento>();
                    int id = Utils.ToInt(departamentoIdTextBox.Text);
                    departamento = repository.Buscar(id);

                    if (departamento != null)
                    {
                        paso = repository.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                }
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
            Repositorio<Departamento> repositorio = new Repositorio<Departamento>();
            int id = Utils.ToInt(departamentoIdTextBox.Text);

            var departamento = repositorio.Buscar(id);

            if (departamento != null)
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