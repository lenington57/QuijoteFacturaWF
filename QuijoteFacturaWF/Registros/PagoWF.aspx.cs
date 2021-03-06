﻿using BLL;
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
            if (!Page.IsPostBack)
            {
                fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaCombo();
            }
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
            bool resultado = DateTime.TryParse(fechaTextBox.Text, out DateTime fecha);
            pago.Fecha = fecha;
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
            pagoIdTextBox.Text = pago.PagoId.ToString();
            fechaTextBox.Text = pago.Fecha.ToString("yyyy-MM-dd");
            clienteDropDownList.SelectedValue = pago.ClienteId.ToString();
            montoTextBox.Text = pago.Monto.ToString();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;
            if (Utils.ToIntObjetos(clienteDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Debe tener al menos un Cliente guardado", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(pagoIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        //Programación de los Botones
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioPago repositorio = new RepositorioPago();

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
            RepositorioPago repositorio = new RepositorioPago();
            Pago pago = new Pago();

            if (HayErrores())
            {
                return;
            }
            else
            {
                pago = LlenaClase();

                if (pagoIdTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(pago);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    LimpiaObjetos();
                }
                else
                {
                    RepositorioPago repository = new RepositorioPago();
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
            RepositorioPago repositorio = new RepositorioPago();
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