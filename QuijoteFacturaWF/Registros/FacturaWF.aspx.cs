﻿using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using QuijoteFacturaWF.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuijoteFacturaWF.Registros
{
    public partial class FacturaWF : System.Web.UI.Page
    {
        public Factura facturita = new Factura();
        public List<FacturaDetalle> lista = new List<FacturaDetalle>();
        List<FacturaDetalle> list = new List<FacturaDetalle>();
        public int row;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaCombo();
                ViewState["FacturaDetalle"] = new FacturaDetalle();
                ViewState["Detalle"] = new Factura().Detalle;
                LlenaReport();
            }
        }

        //Métodos
        private void LlenaCombo()
        {
            Repositorio<Usuario> repositoriu = new Repositorio<Usuario>();
            Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
            Repositorio<Producto> repository = new Repositorio<Producto>();

            usuarioDropDownList.DataSource = repositoriu.GetList(t => true);
            usuarioDropDownList.DataValueField = "UsuarioId";
            usuarioDropDownList.DataTextField = "Nombres";
            usuarioDropDownList.DataBind();

            clienteDropDownList.DataSource = repositorio.GetList(t => true);
            clienteDropDownList.DataValueField = "ClienteId";
            clienteDropDownList.DataTextField = "Nombres";
            clienteDropDownList.DataBind();

            productoDropDownList.DataSource = repository.GetList(t => true);
            productoDropDownList.DataValueField = "ProductoId";
            productoDropDownList.DataTextField = "Descripcion";
            productoDropDownList.DataBind();
        }

        public void LlenaReport()
        {
            int id = Utils.ToInt(facturaIdTextBox.Text);
            MyFacturasReportViewer.ProcessingMode = ProcessingMode.Local;
            MyFacturasReportViewer.Reset();
            MyFacturasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReciboFactura.rdlc");
            MyFacturasReportViewer.LocalReport.DataSources.Clear();
            MyFacturasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DetallesDS", Metodos.ListaDetalle(Utils.ToInt(facturaIdTextBox.Text))));
            MyFacturasReportViewer.LocalReport.Refresh();
        }

        public Factura LlenarClase()
        {
            Factura factura = new Factura();

            factura.FacturaId = Utils.ToInt(facturaIdTextBox.Text);
            bool resultado = DateTime.TryParse(fechaTextBox.Text, out DateTime fecha);
            factura.Fecha = fecha;
            factura.UsuarioId = Utils.ToIntObjetos(usuarioDropDownList.SelectedValue);
            factura.NombreUsuario = Metodos.Usuario(Utils.ToInt(usuarioDropDownList.SelectedValue));
            factura.ClienteId = Utils.ToIntObjetos(clienteDropDownList.SelectedValue);
            factura.NombreCliente = Metodos.Cliente(Utils.ToInt(clienteDropDownList.SelectedValue));
            factura.Itbis = Utils.ToDouble(itbisTextBox.Text);
            factura.SubTotal = Utils.ToDouble(subtotalTextBox.Text);
            factura.Total = Utils.ToInt(totalTextBox.Text);
            
            factura.Detalle = (List<FacturaDetalle>)ViewState["Detalle"];

            return factura;
        }

        public void LlenarCampos(Factura factura)
        {
            List<FacturaDetalle> detalles = Metodos.ListaDetalle(Utils.ToInt(facturaIdTextBox.Text));
            ViewState["Detalle"] = detalles;
            fechaTextBox.Text = factura.Fecha.ToString("yyyy-MM-dd");
            usuarioDropDownList.SelectedValue = factura.UsuarioId.ToString();
            clienteDropDownList.SelectedValue = factura.ClienteId.ToString();
            detalleGridView.DataSource = ViewState["Detalle"];
            detalleGridView.DataBind();
            itbisTextBox.Text = factura.Itbis.ToString();
            subtotalTextBox.Text = factura.SubTotal.ToString();
            totalTextBox.Text = factura.Total.ToString();
        }

        protected void LimpiaObjetos()
        {
            facturaIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            usuarioDropDownList.SelectedIndex = 0;
            clienteDropDownList.SelectedIndex = 0;
            cantidadTextBox.Text = "";
            precioTextBox.Text = "";
            importeTextBox.Text = "";
            itbisTextBox.Text = "";
            subtotalTextBox.Text = "";
            totalTextBox.Text = "";
            detalleGridView.DataSource = null;
            detalleGridView.DataBind();
        }        

        private bool HayErrores()
        {
            bool HayErrores = false;
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            Producto producto = new Producto();
            int id = Utils.ToIntObjetos(productoDropDownList.SelectedValue);
            int cant = 0;
            producto = repositorio.Buscar(id);
            cant = producto.CantidadIventario;

            if (cant <= 0)
            {
                Utils.ShowToastr(this, "Producto agotado.", "Error", "error");
                HayErrores = true;
            }

            if (detalleGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar.", "Error", "error");
                HayErrores = true;
            }
            if (Utils.ToIntObjetos(clienteDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay un Cliente guardado.", "Error", "error");
                HayErrores = true;
            }
            if (Utils.ToIntObjetos(productoDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay un Producto guardado.", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(facturaIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        private void LlenaPrecio()
        {
            int id = Utils.ToInt(productoDropDownList.SelectedValue);
            Repositorio<Producto> repositorio = new Repositorio<Producto>();
            List<Producto> ListProductos = repositorio.GetList(c => c.ProductoId == id);
            foreach (var item in ListProductos)
            {
                precioTextBox.Text = item.Precio.ToString();
            }
        }

        private void LlenaImporte()
        {
            int cantidad, precio;

            cantidad = Utils.ToInt(cantidadTextBox.Text);
            precio = Utils.ToInt(precioTextBox.Text);
            importeTextBox.Text = Metodos.Importe(cantidad, precio).ToString();
        }
        
        protected void productoIdTextBox_TextChanged(object sender, EventArgs e)
        {
            LlenaPrecio();
        }

        private void LlenaValores()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            int total = 0;
            List<FacturaDetalle>  lista = (List<FacturaDetalle>)ViewState["Detalle"];
            foreach (var item in lista)
            {
                total += item.Importe;
            }

            double Itbis = 0;
            double SubTotal = 0;
            Itbis = total * 0.18f;
            SubTotal = total - Itbis;
            subtotalTextBox.Text = SubTotal.ToString();
            itbisTextBox.Text = Itbis.ToString();
            totalTextBox.Text = total.ToString();
        }        

        //Programación de los Botones
        protected void agregarLinkButton_Click(object sender, EventArgs e)
        {
            List<FacturaDetalle> detalles = new List<FacturaDetalle>();
            if (IsValid)
            {
                DateTime date = DateTime.Now.Date;
                int cantidad = Utils.ToInt(cantidadTextBox.Text);
                int precio = Utils.ToInt(precioTextBox.Text);
                int importe = Utils.ToInt(importeTextBox.Text);
                
                int productoId = Utils.ToIntObjetos(productoDropDownList.SelectedValue);
                string descripcion = Metodos.Descripcion(productoId);

                if (detalleGridView.Rows.Count != 0)
                {
                    facturita.Detalle = (List<FacturaDetalle>)ViewState["Detalle"];
                }

                FacturaDetalle detalle = new FacturaDetalle();
                facturita.Detalle.Add(new FacturaDetalle(0, detalle.FacturaId, productoId, descripcion, cantidad, precio, importe));
                
                ViewState["Detalle"] = facturita.Detalle;
                detalleGridView.DataSource = ViewState["Detalle"];
                detalleGridView.DataBind();
                LlenaValores();
            }
        }        

        protected void cantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            LlenaPrecio();
            LlenaImporte();
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioFactura repositorio = new RepositorioFactura();
            Factura factura = new Factura();

            if (HayErrores())
            {
                return;
            }
            else
            {
                factura = LlenarClase();

                if (Utils.ToInt(facturaIdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(factura);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    LimpiaObjetos();
                }
                else
                {
                    RepositorioFactura repository = new RepositorioFactura();
                    int id = Utils.ToInt(facturaIdTextBox.Text);
                    factura = repository.Buscar(id);

                    if (factura != null)
                    {
                        paso = repository.Modificar(LlenarClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                        LimpiaObjetos();
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
            RepositorioFactura repositorio = new RepositorioFactura();
            int id = Utils.ToInt(facturaIdTextBox.Text);

            var factura = repositorio.Buscar(id);

            if (factura != null)
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

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioFactura repositorio = new RepositorioFactura();

            var factura = repositorio.Buscar(Utils.ToInt(facturaIdTextBox.Text));
            lista = Metodos.ListaDetalle(Utils.ToInt(facturaIdTextBox.Text));
            if (factura != null)
            {
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                LlenarCampos(factura);
            }
            else
            {
                LimpiaObjetos();
                Utils.ShowToastr(this, "No existe la Factura especificada", "Error", "error");
            }
        }

        protected void detalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Expression<Func<Producto, bool>> filtro = p => true;
                Repositorio<Producto> repositorio = new Repositorio<Producto>();
                var lista = repositorio.GetList(c => true);
                var combos = repositorio.Buscar(lista[index].ProductoId);
                ((List<FacturaDetalle>)ViewState["Detalle"]).RemoveAt(index);
                detalleGridView.DataSource = ViewState["Detalle"];
                detalleGridView.DataBind();
                LlenaValores();
            }
        }

        protected void detalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            detalleGridView.DataSource = ViewState["Detalle"];
            detalleGridView.PageIndex = e.NewPageIndex;
            detalleGridView.DataBind();
        }
    }

}