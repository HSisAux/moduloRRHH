using moduloRRHH.App_Code;
using moduloRRHH.empleados;
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
        CapaManejoEmpleados capaManejo = new CapaManejoEmpleados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Empleados";
                BindGrid(lblValor.Value,lblParametro.Value,lblAccion.Value);
            }
        }

        protected void ddRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            // (gvEmpleados.FindControl("DataPager1") as DataPager).PageSize = Convert.ToInt32(ddRegistros.SelectedValue);
            //BindGridContacto();
            gvEmpleados.PageSize = Convert.ToInt32(ddRegistros.SelectedValue);
            BindGrid(lblValor.Value, lblParametro.Value, lblAccion.Value);

        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGrid(lblValor.Value, lblParametro.Value, lblAccion.Value);
            gvEmpleados.PageIndex = e.NewPageIndex;
            gvEmpleados.DataBind();
             
        }

        private void BindGrid(string valor, string parametro, string accion)
        {
            gvEmpleados.DataSource = capaManejo.ObtenerEmpleadosBusqueda(valor, parametro, accion);
            gvEmpleados.DataBind();
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            string id = gvEmpleados.Rows[rowIndex].Cells[1].Text;

            Response.Redirect("detalles.aspx?id=" + id);
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            lblAccion.Value = "buscar";
            lblParametro.Value = "@valor";
            lblValor.Value = txtBusqueda.Text;
            BindGrid(lblValor.Value, lblParametro.Value, lblAccion.Value);
        }

        protected void botonesBusqueda_Click(object sender, EventArgs e)
        {
            string boton = (sender as LinkButton).Text;
            //Si en la lista desplegable se selecciono status, activo o nactivo
            if (boton == "Activo" || boton == "Inactivo") {
                lblAccion.Value = "estatus";
                lblParametro.Value = "@status";                                
                lblValor.Value = boton=="Activo"?"True":"False";
            }
            else
            {
                //Si en la lista desplegable se selecciono empresa, hungaros, 4M o Jamamadi

                lblAccion.Value = "selempresa";
                lblParametro.Value = "@Empresa";
                switch (boton)
                {
                    case "Hungaros":
                        lblValor.Value = "1";
                        break;
                    case "4 Matildes":
                        lblValor.Value = "3";
                        break;                   
                    case "Jamamadi":
                        lblValor.Value = "2";
                        break;
                }
            }
            //Se llena el gridview
            BindGrid(lblValor.Value, lblParametro.Value, lblAccion.Value);

        }

      
    }
}