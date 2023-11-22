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
            cargar2();
        }

        public void cargar()
        {
            var tupla = inicio.ObtenerDocumentacion();
            gvDocumentosFaltantes.DataSource = tupla.Item1;
            gvDocumentosFaltantes.DataBind();

            //gvDocumentosVencidos.DataSource = tupla.Item2;
            //gvDocumentosVencidos.DataBind();
        }

        public void cargar2()
        {
            gvDocumentosVencidos.DataSource = inicio.Separacion();
            gvDocumentosVencidos.DataBind();

        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}