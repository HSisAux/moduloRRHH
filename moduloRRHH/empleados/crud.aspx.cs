using Microsoft.Ajax.Utilities;
using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Optimization;
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
            if (!IsPostBack)
            {
                llenarComboDpto();
                if (Request["id"] != null)
                {
                    this.Page.Title = "Edicion";
                    ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Editar información de empleado";
                    llenarInformacion(Request["id"]);
                    txtNoEmpleado.ReadOnly = true;
                    btnSubirImagen.Visible = true;
                }
                else
                {
                    ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Registro empleado";
                    this.Page.Title = "Registro";
                    btnGuardar.Text = "Registrar";
                }
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string foto = "";    
            
            if(Context.Request.Files.Count > 0)
            {
                HttpFileCollection files = Context.Request.Files;
                HttpPostedFile file = files[0];
                if(file.FileName != "")
                {
                    string link = "\\Archivos\\" + ddEmpresa.SelectedItem.Text + "\\" + txtNombre.Text + " " + txtApellidoP.Text;
                    if (!Directory.Exists(Context.Server.MapPath(link)))
                    {
                        DirectoryInfo di = System.IO.Directory.CreateDirectory(Context.Server.MapPath(link));
                    }
                    foto = link +"\\"+ file.FileName;                    
                    file.SaveAs(Context.Server.MapPath(foto));

                }
                else
                {
                    foto = "\\Assets\\img\\default-user.png";
                }
            }
            else
            {
                foto = "\\Assets\\img\\default-user.png";
            }

            registrarEmpleado(
                "",
                txtNombre.Text.Trim(), txtNoEmpleado.Text.Trim(), txtApellidoP.Text.Trim(), txtApellidoM.Text.Trim(),
                chkEstatus.Checked, txtRfc.Text.Trim(), txtNSS.Text.Trim(), txtFechaNac.Text,
                txtFechaIngreso.Text, txtCalle.Text.Trim(), txtcolonia.Text.Trim(), txtCP.Text.Trim(),
                txtEstado.Text.Trim(), txtCiudad.Text.Trim(), txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),
                txtTelEmergencia.Text.Trim(), txtContactoEmergencia.Text.Trim(), ddDepartamento.SelectedValue, ddPuesto.SelectedValue,
                foto, ddEmpresa.SelectedValue);

        }

        protected void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtFechaNac.Text = "";
            txtFechaIngreso.Text = "";
            txtNSS.Text = "";
            txtRfc.Text = "";
            txtcolonia.Text = "";
            txtCalle.Text = "";
            txtCiudad.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtContactoEmergencia.Text = "";
            txtTelEmergencia.Text = "";
            txtNoEmpleado.Text = "";
            txtFechaIngreso.Text= "";
           // txtDpto.Text = "";
            txtSalarioActual.Text = "";
            txtSalarioNuevo.Text = "";

        }

        public void llenarComboDpto()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=""}
            };
            DataTable dt = clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
            
            foreach (DataRow row in dt.Rows)
            {
                ddDepartamento.Items.Add(new ListItem(row["Nombre"].ToString(), row["ID_Departamento"].ToString()));
            }
        }

        protected void LLenarComboPuesto(string id)
        {
            ddPuesto.Items.Clear();
            ddPuesto.Items.Add(new ListItem("--Seleccionar puesto", "0"));
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="seleccionarPuesto"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=id}
            };
            DataTable dt = clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ddPuesto.Items.Add(new ListItem(row["Puesto"].ToString(), row["ID_puesto"].ToString()));
                }
            }
            else
            {
                rvDepto.Visible = true;
                rvDepto.Text = "Este departamento no cuenta con puestos";
            }

        }

        protected void ddDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarComboPuesto(ddDepartamento.SelectedValue.ToString());
        }


        protected void registrarEmpleado(string pagetitle, string noEmpleado,
            string nombre, string apellidoPaterno, string apellidoMaterno,
            bool status, string rfc, string nss, string FechaNac, string FechaIngreso,
            string Calle, string colonia, string cp, string estado,string ciudad, 
            string telefono, string correo,
            string TelEmergencia, string ContactoEmergencia,
            string IDDepartamento, string idpuesto, string foto, string empresa)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="insert"},
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= txtNoEmpleado.Text },
                new clsHerramientas.clsParametros{NombreParametro="@Nombre", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= txtNombre.Text },
                new clsHerramientas.clsParametros{NombreParametro="@ApellidoP", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= txtApellidoP.Text },
                new clsHerramientas.clsParametros{NombreParametro="@ApellidoM", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= txtApellidoM.Text },
                new clsHerramientas.clsParametros{NombreParametro="@status", TipoParametro=System.Data.SqlDbType.Bit , ValorParametro= status.ToString() },
                new clsHerramientas.clsParametros{NombreParametro="@rfc", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= rfc },
                new clsHerramientas.clsParametros{NombreParametro="@nss", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= nss },
                new clsHerramientas.clsParametros{NombreParametro="@fechaNacimiento", TipoParametro=System.Data.SqlDbType.Date, ValorParametro= FechaNac },
                new clsHerramientas.clsParametros{NombreParametro="@fechaIngreso", TipoParametro=System.Data.SqlDbType.Date, ValorParametro= FechaIngreso },
                new clsHerramientas.clsParametros{NombreParametro="@Calle", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= Calle},
                new clsHerramientas.clsParametros{NombreParametro="@Colonia", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= colonia},
                new clsHerramientas.clsParametros{NombreParametro="@cp", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= cp},
                new clsHerramientas.clsParametros{NombreParametro="@Estado", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= estado},
                new clsHerramientas.clsParametros{NombreParametro="@Ciudad", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= ciudad},
                new clsHerramientas.clsParametros{NombreParametro="@Telefono", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= telefono},
                new clsHerramientas.clsParametros{NombreParametro="@TelEmergencia", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro = TelEmergencia},
                new clsHerramientas.clsParametros{NombreParametro="@ContactoEmergencia", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= ContactoEmergencia},
                new clsHerramientas.clsParametros{NombreParametro="@Correo", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= correo},
                new clsHerramientas.clsParametros{NombreParametro="@IDdepartamento", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= IDDepartamento},
                new clsHerramientas.clsParametros{NombreParametro="@IDpuesto", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= idpuesto},
                new clsHerramientas.clsParametros{NombreParametro="@foto", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= foto},
                new clsHerramientas.clsParametros{NombreParametro="@Empresa", TipoParametro=System.Data.SqlDbType.Int, ValorParametro= empresa}
            };

            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Empleado", parametros);
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('"+resultado.Item2+"');", true);

        }

        protected void txtNoEmpleado_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = clsHerramientas.SQLConsulta("SELECT no_empleado FROM Empleado WHERE no_empleado='"+txtNoEmpleado.Text+"'");
            if(dt.Rows.Count > 0)
            {
                lblYaexiste.Visible = true;
                lblYaexiste.Text = "<i class=\"fa-regular fa-circle-xmark\"></i> Este numero ya esta asignado";
            }
            else
            {
                lblYaexiste.Visible = false;
                lblYaexiste.Text = "";
            }
        }

        protected void llenarInformacion(string id)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro=id},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="details"},
            };
            DataTable dt = clsHerramientas.ProcedimientoAlmacenado("Master_Empleado", parametros);

            if(dt.Rows.Count > 0)
            {
                //Imagen
                imgEmpl.BackImageUrl = dt.Rows[0]["foto"].ToString().Replace('\\','/');

                //Nombre
                txtNombre.Text = dt.Rows[0]["Nombre"].ToString();

                //Apellidos
                txtApellidoP.Text = dt.Rows[0]["Apellido_P"].ToString();
                txtApellidoM.Text= dt.Rows[0]["Apellido_M"].ToString();

                //fecha de nacimineto
                txtFechaNac.Text = Convert.ToDateTime(dt.Rows[0]["Fecha_ingreso"].ToString()).Date.ToString("yyyy-MM-dd");

                //rfc
                txtRfc.Text = dt.Rows[0]["RFC"].ToString();

                //NSS
                txtNSS.Text = dt.Rows[0]["NSS"].ToString();

                //fracc
                txtcolonia.Text= dt.Rows[0]["Colonia"].ToString();
                
                //Calle
                txtCalle.Text= dt.Rows[0]["Calle"].ToString();

                //CP
                txtCP.Text = dt.Rows[0]["CP"].ToString();

                //telefono
                txtTelefono.Text = dt.Rows[0]["Telefono"].ToString();

            }
        }

    }
}