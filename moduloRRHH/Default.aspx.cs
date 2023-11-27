using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using moduloRRHH.App_Code;


namespace moduloRRHH
{
    public partial class _Default : Page
    {
        MetodosInicio inicio = new MetodosInicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lblPaginaTitulo")).Text = "inicio";
            cargar();
            //cargar2();
        }

        public void cargar()
        {
            var tupla = inicio.ObtenerDocumentacion();
            gvDocumentosFaltantes.DataSource = /*tupla.Item1*/inicio.Separacion("faltantes");
            gvDocumentosFaltantes.DataBind();

            gvDocumentosVencidos.DataSource = /*tupla.Item2*/ inicio.Separacion("vencidos");
            gvDocumentosVencidos.DataBind();
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            //No_empleado
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            Context.Response.Redirect("empleados/detalles.aspx?id="+gvDocumentosFaltantes.Rows[rowIndex].Cells[0].Text);
        }

        protected void btnPerfilVencido_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            Context.Response.Redirect("empleados/detalles.aspx?id=" + gvDocumentosVencidos.Rows[rowIndex].Cells[0].Text);

        }
    }
}