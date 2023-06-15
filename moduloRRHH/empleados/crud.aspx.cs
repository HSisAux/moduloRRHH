using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH.empleados
{
    public partial class crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cambio de foto.
            //string imgsource = "../Assets/img/tomholland.jpg";
            //imgEmpl.Style.Add("background-image", "url("+imgsource+")");
            
            /* id es el numero de empleado, el cual usaremos para editar la informacion en la BD */
            if (Request["id"] != null)
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Editar información de empleado";
            }
            else
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Registro empleado";
                btnGuardar.Text = "Registrar";
            }

        }

        protected void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstatus.Checked)
            {
                lblStatus.Text = "activo";
                lblStatus.CssClass = lblStatus.CssClass.Replace("inactivo", "");
            }
            else
            {
                lblStatus.Text = "baja";
                lblStatus.CssClass = "ms-2 estado inactivo";

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                Response.Redirect("detalles.aspx?id=" + Request["id"].ToString());
            }
            else
            {
                Response.Redirect("lista.aspx");

            }
        }
    }
}