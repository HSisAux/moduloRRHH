using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH
{
    public partial class detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "DETALLES DEL EMPLEADO";
                if (Request["id"] != null )
                {
                   RellenarCampos(Request["id"]);
                }    
            }
        }

        protected void RellenarCampos( string id)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="detalles"},
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=id},
            };
            DataTable dt = clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);

            if(dt.Rows.Count > 0)
            {
                //Empresa
                switch (dt.Rows[0]["Empresa"].ToString())
                {
                    case "Jamamadi":
                        imgEmpresa.ImageUrl = "../Assets/img/jamamadi.png";
                    break;
                    case "4 Matildes":
                        imgEmpresa.ImageUrl = "../Assets/img/4Matildes.png";
                    break;
                }
                //Foto
                imgEmpleado.ImageUrl = dt.Rows[0]["foto"].ToString();
                //Nombre
                lblNombres.Text = dt.Rows[0]["Nombre"].ToString();
                //Apellidos
                lblApellido.Text = dt.Rows[0]["Apellido_P"].ToString() + " " + dt.Rows[0]["Apellido_M"].ToString();
                //Puesto
                lblPuesto.Text = dt.Rows[0]["Puesto"].ToString() + "<br>" +"<small class='text-secondary'>"+dt.Rows[0]["Departamento"].ToString()+"</small>";
                //status
                if(dt.Rows[0]["Status"].ToString() != "True")
                {
                    lblStatus.Text = "Inactivo";
                    lblStatus.CssClass = "estado inactivo";
                    btnActivarEstado.Visible = true;
                    btnBajaTemporal.Visible = false;
                    imgEmpleado.Style.Add("filter", "grayscale(1)");
                }
                //==============Numero de empleado==================================
                txtNoEmpleado.Text = dt.Rows[0]["no_empleado"].ToString();
                //===========Fecha de ingreso
                txtFechaIngeso.Text = Convert.ToDateTime(dt.Rows[0]["Fecha_ingreso"].ToString()).Date.ToString("yyyy-MM-dd");
                //===========Salario
                //----------------------------Pendiente jsjs

                //================================RFC
                txtRFC.Text = dt.Rows[0]["RFC"].ToString();
                //================================NSS
                txtNSS.Text = dt.Rows[0]["NSS"].ToString();
                //================================Fecha nacimiento
                txtFechaNac.Text = Convert.ToDateTime(dt.Rows[0]["Fecha_nacimiento"].ToString()).Date.ToString("yyyy-MM-dd");
                //================================Fraccionamiento
                txtFracc.Text = dt.Rows[0]["Colonia"].ToString();
                //================================calle
                txtCalle.Text = dt.Rows[0]["Calle"].ToString();
                //=================================Estado
                txtEstado.Text = dt.Rows[0]["Estado"].ToString();
                //=================================Ciudad
                txtCiudad.Text = dt.Rows[0]["Ciudad"].ToString();
                //==============codigo postal
                txtCP.Text = dt.Rows[0]["CP"].ToString();
                //=======================Telefono
                txtTelefono.Text = dt.Rows[0]["Telefono"].ToString();
                //=======================Correo
                txtCorreo.Text = dt.Rows[0]["Correo"].ToString();

                //=======================Contacto emergencia
                txtContactoEmrgecia.Text= dt.Rows[0]["Contacto_Emergencia"].ToString();
                //=======================Tel Emergencia
                txtTelEmergencia.Text = dt.Rows[0]["Tel_Emergencia"].ToString();
            }
            else
            {

            }
        }

        protected void btnBajaTemporal_Click(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="switch"},
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=Request["id"]},
                new clsHerramientas.clsParametros{NombreParametro="@Estado", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="False"},
            };
                var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Empleado", parametros);
                //ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('"+resultado.Item2+"');", true);
               
                lblStatus.Text = "Inactivo";
                lblStatus.CssClass = "estado inactivo";
                imgEmpleado.Style.Add("filter", "grayscale(1)");

                btnActivarEstado.Visible = true;
                btnBajaTemporal.Visible = false;
            }
        }

        protected void btnActivarEstado_Click(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="switch"},
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=Request["id"]},
                new clsHerramientas.clsParametros{NombreParametro="@Estado", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="True"},
            };
                var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Empleado", parametros);
                //ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + resultado.Item2 + "');", true);

                lblStatus.Text = "ACTIVO";
                lblStatus.CssClass = "estado";
                imgEmpleado.Style.Add("filter", "none");

                btnActivarEstado.Visible = false;
                btnBajaTemporal.Visible = true;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                Response.Redirect("crud.aspx?id=" + Request["id"]);
            }
        }
    }
}