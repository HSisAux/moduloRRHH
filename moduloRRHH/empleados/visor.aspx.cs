using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH.empleados
{
    public partial class visor : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Documento";
                if ( Request.Params["doc"] != null)
                {
                    Documento(Request.Params["doc"]);
                }
            }

        }


        private void ObtenerInfo(string Empleado_id)
        {

        }

        private void Documento(string Doc_id)
        {
            DataTable dtable = clsHerramientas.SQLConsulta("SELECT * FROM Documentacion WHERE ID_Documentacion='" + Doc_id + "'");
            if(dtable.Rows.Count > 0)
            {
                ifile.Src = dtable.Rows[0]["Archivo"].ToString().Replace('\\', '/');
                btnPaTras.PostBackUrl = "~/empleados/detalles.aspx?id=" + dtable.Rows[0]["no_empleado"].ToString();
            }

            DataTable dt = ManejoDocumentos.ObtenerHistorial(Doc_id);
            gvHistory.DataSource = dt;
            gvHistory.DataBind();
        }

        protected void btnPaTras_Click(object sender, EventArgs e)
        {

        }
    }
}