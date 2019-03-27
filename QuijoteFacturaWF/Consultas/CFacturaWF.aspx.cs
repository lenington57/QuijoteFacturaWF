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
    public partial class CFacturaWF : System.Web.UI.Page
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
            MyFacturasReportViewer.ProcessingMode = ProcessingMode.Local;
            MyFacturasReportViewer.Reset();
            MyFacturasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoFacturas.rdlc");
            MyFacturasReportViewer.LocalReport.DataSources.Clear();
            MyFacturasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("FacturaDS", BLL.Metodos.FFacturas()));
            MyFacturasReportViewer.LocalReport.Refresh();
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
            FacturaGridView.DataSource = BLL.Metodos.FiltrarFacturas(index, CriterioTextBox.Text, desde, hasta);
            FacturaGridView.DataBind();

            criterioLabel.Text = FiltroDropDownList.Text.ToString();
        }
    }
}