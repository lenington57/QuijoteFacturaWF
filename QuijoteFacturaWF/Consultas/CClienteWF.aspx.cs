using Entities;
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
    public partial class CClienteWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaReport();
            }
            
        }

        public void LlenaReport()
        {
            MyClientesReportViewer.ProcessingMode = ProcessingMode.Local;
            MyClientesReportViewer.Reset();
            MyClientesReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoClientes.rdlc");
            MyClientesReportViewer.LocalReport.DataSources.Clear();
            MyClientesReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ClienteDS", BLL.Metodos.FClientes()));
            MyClientesReportViewer.LocalReport.Refresh();
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
            ClienteGridView.DataSource = BLL.Metodos.FiltrarClientes(index, CriterioTextBox.Text, desde, hasta);
            ClienteGridView.DataBind();

            criterioLabel.Text = FiltroDropDownList.Text.ToString();
        }
    }
}