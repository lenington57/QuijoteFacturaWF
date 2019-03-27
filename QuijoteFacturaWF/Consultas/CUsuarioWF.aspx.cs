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
    public partial class CUsuarioWF : System.Web.UI.Page
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
            MyUsuariosReportViewer.ProcessingMode = ProcessingMode.Local;
            MyUsuariosReportViewer.Reset();
            MyUsuariosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoProductos.rdlc");
            MyUsuariosReportViewer.LocalReport.DataSources.Clear();
            MyUsuariosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("UsuarioDS", BLL.Metodos.FUsuarios()));
            MyUsuariosReportViewer.LocalReport.Refresh();
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
            UsuarioGridView.DataSource = BLL.Metodos.FiltrarUsuarios(index, CriterioTextBox.Text, desde, hasta);
            UsuarioGridView.DataBind();

            criterioLabel.Text = FiltroDropDownList.Text.ToString();
        }
    }
}