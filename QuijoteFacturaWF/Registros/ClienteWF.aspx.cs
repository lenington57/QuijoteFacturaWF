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
    public partial class ClienteWF : System.Web.UI.Page
    {
        Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
        Expression<Func<Cliente, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        //Métodos
        private Cliente LlenaClase()
        {
            Cliente cliente = new Cliente();

            cliente.ClienteId = Utils.ToInt(clienteIdTextBox.Text);
            cliente.Fecha = Utils.ToDateTime(fechaTextBox.Text).Date;
            cliente.Nombres = nombreTextBox.Text;
            cliente.NoTelefono = noTelefonoTextBox.Text;
            cliente.NoCedula = noCedulaTextBox.Text;
            cliente.Direccion = direccionTextBox.Text;
            cliente.Deuda = 0;

            return cliente;
        }

        private void LimpiaObjetos()
        {
            clienteIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            nombreTextBox.Text = "0";
            noTelefonoTextBox.Text = "0";
            noCedulaTextBox.Text = "0";
            direccionTextBox.Text = "0";
            deudaTextBox.Text = "0";
        }

        public void LlenaCampos(Cliente cliente)
        {
            LimpiaObjetos();
            fechaTextBox.Text = cliente.Fecha.ToString("yyyy-MM-dd");
            nombreTextBox.Text = cliente.Nombres;
            noTelefonoTextBox.Text = cliente.NoTelefono;
            noCedulaTextBox.Text = cliente.NoCedula;
            direccionTextBox.Text = cliente.Direccion;
            deudaTextBox.Text = cliente.Deuda.ToString();
        }

        private bool VEmail()
        {
            bool HayErrores = false;
            filtrar = t => t.NoCedula.Equals(noCedulaTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                Utils.ShowToastr(this, "Esta Cédula ya existe", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        private bool HayErrores()
        {
            bool HayErrores = false;
            if (noTelefonoTextBox.Text.Length !=10)
            {
                Utils.ShowToastr(this, "No es un Número de Teléfono correcto", "Error", "error");
                HayErrores = true;
            }
            if (noCedulaTextBox.Text.Length != 11)
            {
                Utils.ShowToastr(this, "No es un Número de Cédula correcto", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(clienteIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }


        //Programación de los Botones
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();

            var deposito = repositorio.Buscar(Utils.ToInt(clienteIdTextBox.Text));
            if (deposito != null)
            {
                LlenaCampos(deposito);
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
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            Cliente cliente = new Cliente();

            if (HayErrores())
            {
                return;
            }
            else
            {
                cliente = LlenaClase();

                if (clienteIdTextBox.Text == "0")
                {
                    if (VEmail())
                    {
                        return;
                    }
                    else { 
                    paso = repositorio.Guardar(cliente);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    LimpiaObjetos();
                    }
                }
                else
                {
                    Repositorio<Cliente> repository = new Repositorio<Cliente>();
                    int id = Utils.ToInt(clienteIdTextBox.Text);
                    cliente = repository.Buscar(id);

                    if (cliente != null)
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
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            int id = Utils.ToInt(clienteIdTextBox.Text);

            var cliente = repositorio.Buscar(id);

            if (cliente != null)
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