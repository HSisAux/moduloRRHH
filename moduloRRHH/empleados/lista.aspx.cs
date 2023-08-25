using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH
{
    public partial class lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Empleados";
                BindGrid();
            }



        }

        protected void ddRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
           // (ListView1.FindControl("DataPager1") as DataPager).PageSize = Convert.ToInt32(ddRegistros.SelectedValue);
            //BindGridContacto();
        }

        protected void gvEmpleados_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        private void BindGrid()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion",TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="all" }
            };
           
            gvEmpleados.DataSource = clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);
            gvEmpleados.DataBind();
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            string id = gvEmpleados.Rows[rowIndex].Cells[1].Text;

            Response.Redirect("detalles.aspx?id=" + id);
        }
    }
}