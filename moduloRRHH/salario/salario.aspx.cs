using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using moduloRRHH.App_Code;
using System.Data;
using Microsoft.SqlServer.Server;

namespace moduloRRHH.salario
{
    [System.Web.Script.Services.ScriptService]
    public partial class salario : System.Web.UI.Page
    {
        MetodosSalarios Salarios = new MetodosSalarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Salarios";
                SalariosBind("");
            }

        }

        protected void ddRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SalariosBind(string valor)
        {
            gvSalarios.DataSource = Salarios.ObtenerSalarios(valor);
            gvSalarios.DataBind();
            gvSalarios.Caption = string.Format("Total de registros: {0}", gvSalarios.Rows.Count);

        }

        protected void gvSalarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                //se obtiene el nombre el cual separa nombre y apellidos por un -
                //le hago split para mostrarlo con salto de linea
                var aux = e.Row.Cells[1].Text.Split(new char[]{'-'});
                e.Row.Cells[1].Text = string.Format("{0}<br>{1}", aux[0], aux[1]);

                //Si el salario actual no es N/A se le agrega el signo de pesos $
                if (e.Row.Cells[3].Text != "N/A")
                {
                    e.Row.Cells[3].Text = "<span class='badge text-bg-success'><i class=\"fa-solid fa-dollar-sign\"></i>&nbsp;" + e.Row.Cells[3].Text+"</span>";
                }
                //Si el salario anterior no es N/A se le agrega el signo de pesos $
                if (e.Row.Cells[4].Text != "N/A")
                {
                    e.Row.Cells[4].Text = "<span class='badge text-bg-secondary'><i class=\"fa-solid fa-dollar-sign\"></i>&nbsp;" + e.Row.Cells[4].Text+"</span>";
                }
            }
        }

        protected void btnEditarPuesto_Click(object sender, EventArgs e)
        {
            pAlert.Visible = false;

            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;

            string salario = gvSalarios.Rows[rowIndex].Cells[3].Text.Replace("<span class='badge text-bg-success'><i class=\"fa-solid fa-dollar-sign\"></i>&nbsp;", " ");
            salario = salario.Replace("</span>", "").Trim();
            //Obtengo el numero de emlpleado
            txtNoEmpleado.Text= gvSalarios.Rows[rowIndex].Cells[0].Text;

            //Obtengo el nombre del empleado, cambio la etiqueta <br> por un espacio
            txtEmpleado.Text = gvSalarios.Rows[rowIndex].Cells[1].Text.Replace("<br>"," ");

            //Obtengo el salario actual, elimino el simbolo de pesos
            txtSalario.Text = salario;

            //Almaceno el salario actual para poder registrarlo en la bd como salario anterior
            hfSalarioAnterior.Value= salario;

            btnRegistrarSalario.Visible = false;
            btnEditar.Visible = true;
            btnCancelar.Visible = true;
        }

        protected void btnRegistrarSalario_Click(object sender, EventArgs e)
        {
            MetodosSalarios salarios = new MetodosSalarios(txtNoEmpleado.Text, Convert.ToDecimal(00.0), Convert.ToDecimal(txtSalario.Text));
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + salarios.RegistrarSalario() + "');", true);
            LimpiarCampos();
            SalariosBind("");
            //lMensaje.Text = salarios.EditarSalario();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            MetodosSalarios salarios = new MetodosSalarios(txtNoEmpleado.Text, Convert.ToDecimal(hfSalarioAnterior.Value!="N/A"? hfSalarioAnterior.Value:"00.0"), Convert.ToDecimal(txtSalario.Text));
            lMensaje.Text = salarios.EditarSalario();
            //ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + salarios.EditarSalario() + "');", true);
            SalariosBind("");
            LimpiarCampos();
            btnEditar.Visible = false;
            btnCancelar.Visible = false;
            btnRegistrarSalario.Visible = true;
            pAlert.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            btnEditar.Visible = false;
            btnCancelar.Visible = false;
            btnRegistrarSalario.Visible = true;
        }

        protected void LimpiarCampos()
        {
            txtEmpleado.Text = String.Empty;
            txtNoEmpleado.Text = String.Empty; ;
            txtSalario.Text = String.Empty; ;
            hfSalarioAnterior.Value = String.Empty; ;
            pAlert.Visible = false;
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            SalariosBind(txtBusqueda.Text.Trim());
        }

        protected void gvSalarios_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvSalarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SalariosBind(txtBusqueda.Text.Trim());
            gvSalarios.PageIndex = e.NewPageIndex;
            gvSalarios.DataBind();
        }

        protected void btnDismiss_Click(object sender, EventArgs e)
        {
            pAlert.Visible = false;
        }

        protected void txtNoEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (txtNoEmpleado.Text != "")
            {
                lblNoexiste.Visible = false;
                txtEmpleado.Text = "";
                DataTable dt = clsHerramientas.SQLConsulta("SELECT * FROM Empleado WHERE no_empleado='" + txtNoEmpleado.Text + "'");
                if (dt.Rows.Count <= 0)
                {
                    lblNoexiste.Visible = true;
                }
                else
                {
                    if (dt.Rows[0]["Status"].ToString() == "False")
                    {
                        lblNoexiste.Visible = true;
                        lblNoexiste.Text = "El empleado no esta activo";
                    }
                    else
                    {
                        txtEmpleado.Text = dt.Rows[0]["Nombre"].ToString() + " " + dt.Rows[0]["Apellido_P"].ToString() + " " + dt.Rows[0]["Apellido_M"].ToString();
                    }
                }
            }
            else
            {
                txtEmpleado.Text = String.Empty;
            }
        }
    }
}