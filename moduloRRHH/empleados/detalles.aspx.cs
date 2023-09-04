using moduloRRHH.App_Code;
using moduloRRHH.empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH
{
    public partial class detalles : System.Web.UI.Page
    {
        CapaManejoEmpleados manejoEmpleados = new CapaManejoEmpleados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTest();
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "DETALLES DEL EMPLEADO";
                if (Request["id"] != null )
                {
                   RellenarCampos(Request["id"]);
                }    
            }
        }

        protected void RellenarCampos( string id)
        {            
            Dictionary<string, string> Info = manejoEmpleados.ObtenerInformacion(id, "detalles");
            switch (Info["Empresa"])
            {
                case "Jamamadi":
                    imgEmpresa.ImageUrl = "../Assets/img/jamamadi.png";
                    break;
                case "4 Matildes":
                    imgEmpresa.ImageUrl = "../Assets/img/4Matildes.png";
                    break;
            }
            imgEmpleado.ImageUrl = Info["foto"];
            lblNombres.Text = Info["Nombre"];
            lblApellido.Text = Info["Apellido_P"] + " " + Info["Apellido_M"];
            lblPuesto.Text = Info["Puesto"] + "<br>" +"<small class='text-secondary'>"+Info["Departamento"] +"</small>";
            EstadoStatus(Info["Status"]);
            txtNoEmpleado.Text = Info["no_empleado"];
            txtFechaIngeso.Text = Convert.ToDateTime(Info["Fecha_ingreso"]).Date.ToString("yyyy-MM-dd");              
            txtRFC.Text = Info["RFC"];
            txtNSS.Text = Info["NSS"];
            txtFechaNac.Text = Convert.ToDateTime(Info["Fecha_nacimiento"]).Date.ToString("yyyy-MM-dd");
            txtFracc.Text = Info["Colonia"];
            txtCalle.Text = Info["Calle"];
            txtEstado.Text = Info["Estado"];
            txtCiudad.Text = Info["Ciudad"];
            txtCP.Text = Info["CP"];
            txtTelefono.Text = Info["Telefono"];
            txtCorreo.Text = Info["Correo"];
            txtContactoEmrgecia.Text= Info["Contacto_Emergencia"];
            txtTelEmergencia.Text = Info["Tel_Emergencia"];
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                Response.Redirect("crud.aspx?id=" + Request["id"]);
            }
        }

        protected void btnCambioEstado_Click(object sender, EventArgs e)
        {
            string status;
            if (Request["id"] != null)
            {
                if(btnCambioEstado.Text == "Baja temporal <i class=\"fa-solid fa-ban ms-1\"></i>")
                {
                    status = "False";
                }
                else
                {
                    status = "True";
            }
                EstadoStatus(status);
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + manejoEmpleados.CambiarStatus(Request["id"],status)+"');", true);
            }
        }

        private void EstadoStatus(string status)
        {
            if(status == "True")
            {
                btnCambioEstado.Text = "Baja temporal <i class=\"fa-solid fa-ban ms-1\"></i>";
                btnCambioEstado.CssClass = "btn btn-sm btn-outline-danger";

                lblStatus.Text = "ACTIVO";
                lblStatus.CssClass = "estado";
                imgEmpleado.Style.Add("filter", "none");
            }
            else
            {
                btnCambioEstado.Text = "Activar <i class=\"fa-solid fa-power-off ms-1\"></i>";
                btnCambioEstado.CssClass = "btn btn-sm btn-outline-success";

                lblStatus.Text = "Inactivo";
                lblStatus.CssClass = "estado inactivo";
                imgEmpleado.Style.Add("filter", "grayscale(1)");
            }
        }

        private void llenarTest()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro = "@accion", TipoParametro = SqlDbType.VarChar, ValorParametro="prueba"},
                new clsHerramientas.clsParametros{NombreParametro = "@no_empleado", TipoParametro = SqlDbType.VarChar, ValorParametro=Request["id"]},
            };
            gvTest.DataSource = clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);
            gvTest.DataBind();
            
        }

        protected void gvTest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string aux = "";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                aux = e.Row.Cells[4].Text;
                //TableCell checkBoxCell = ;
                CheckBox checkBox = e.Row.Cells[1].Controls[0] as CheckBox;
                if (checkBox != null)
                {
                    // Ahora puedes acceder al valor del CheckBox
                    bool isChecked = checkBox.Checked;
                    // Haz lo que necesites con el valor
                    if (!isChecked)
                    {
                        e.Row.Cells[4].Text = "<label class='estado pendiente'>opcional</label>";
                    }
                }

                if (aux == "&nbsp;")
                {
                    if (!checkBox.Checked)
                    {
                        e.Row.Cells[4].Text = "<label class='estado pendiente'>opcional</label>";

                    }
                    else
                    {
                        e.Row.Cells[4].Text = "<label class='estado inactivo'>Sin entregar</label>";

                    }
                }
                else if(aux == "activo")
                {
                    e.Row.Cells[4].Text = "<label class='estado'>Entregado</label>";

                }
            }
        }
    }
}