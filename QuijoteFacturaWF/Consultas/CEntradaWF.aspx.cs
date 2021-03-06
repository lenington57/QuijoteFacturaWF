﻿using Entities;
using Microsoft.Reporting.WebForms;
using QuijoteFacturaWF.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuijoteFacturaWF.Consultas
{
    public partial class CEntradaWF : System.Web.UI.Page
    {
        public List<Entrada> lista = new List<Entrada>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaReport();
                Session["Lista"] = lista;
            }
        }

        public void LlenaReport()
        {
            MyEntradasReportViewer.ProcessingMode = ProcessingMode.Local;
            MyEntradasReportViewer.Reset();
            MyEntradasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoEntradas.rdlc");
            MyEntradasReportViewer.LocalReport.DataSources.Clear();
            MyEntradasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("EntradaDS", lista));
            MyEntradasReportViewer.LocalReport.Refresh();
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        protected void buscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(CriterioTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
            lista = BLL.Metodos.FiltrarEntradas(index, CriterioTextBox.Text, desde, hasta);
            EntradaGridView.DataSource = lista;
            EntradaGridView.DataBind();

            criterioLabel.Text = FiltroDropDownList.Text.ToString();
        }
    }
}