using Antlr.Runtime.Misc;
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
        CapaManejoEmpleados manejoEmpleados = new CapaManejoEmpleados();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Cambio de foto.
            //string imgsource = "../Assets/img/tomholland.jpg";
            //imgEmpl.Style.Add("background-image", "url("+imgsource+")");

            /* id es el numero de empleado, el cual usaremos para editar la informacion en la BD */
            if (!IsPostBack)
            {
                llenarComboDpto();
                llenarComboEmpresa(); 
                
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

        private void llenarComboEmpresa()
        {
            ddEmpresa.Items.Clear();
            DataTable dt = clsHerramientas.SQLConsultaTUser("SELECT * FROM Empresa");
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ddEmpresa.Items.Add(new ListItem(row["Nombre"].ToString(), row["ID_Empresa"].ToString()));
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
            string accion = "";
            if(btnGuardar.Text == "Registrar")
            {
                accion = "insert";
            }
            else
            {
                accion = "update";
            }
            
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + EmpleadoCE(accion) + "');", true);
            /*if (btnGuardar.Text == "Registrar")
            {
                string foto = "";
                if (Context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = Context.Request.Files;
                    HttpPostedFile file = files[0];
                    if (file.FileName != "")
                    {
                        string link = "\\Archivos\\" + ddEmpresa.SelectedItem.Text + "\\" + txtNombre.Text + " " + txtApellidoP.Text;
                        if (!Directory.Exists(Context.Server.MapPath(link)))
                        {
                            DirectoryInfo di = System.IO.Directory.CreateDirectory(Context.Server.MapPath(link));
                        }
                        foto = link + "\\" + file.FileName;
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
                    "insert",
                    txtNombre.Text.Trim(), txtNoEmpleado.Text.Trim(), txtApellidoP.Text.Trim(), txtApellidoM.Text.Trim(),
                    chkEstatus.Checked, txtRfc.Text.Trim(), txtNSS.Text.Trim(), txtFechaNac.Text,
                    txtFechaIngreso.Text, txtCalle.Text.Trim(), txtcolonia.Text.Trim(), txtCP.Text.Trim(),
                    txtEstado.Text.Trim(), txtCiudad.Text.Trim(), txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),
                    txtTelEmergencia.Text.Trim(), txtContactoEmergencia.Text.Trim(), ddDepartamento.SelectedValue, ddPuesto.SelectedValue,
                    foto, ddEmpresa.SelectedValue);
            }
            else
            {
                registrarEmpleado(
                    "update", txtNoEmpleado.Text.Trim(),txtNombre.Text.Trim(), txtApellidoP.Text.Trim(), txtApellidoM.Text.Trim(),
                    chkEstatus.Checked, txtRfc.Text.Trim(), txtNSS.Text.Trim(), txtFechaNac.Text,
                    txtFechaIngreso.Text, txtCalle.Text.Trim(), txtcolonia.Text.Trim(), txtCP.Text.Trim(),
                    txtEstado.Text.Trim(), txtCiudad.Text.Trim(), txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),
                    txtTelEmergencia.Text.Trim(), txtContactoEmergencia.Text.Trim(), ddDepartamento.SelectedValue, ddPuesto.SelectedValue,
                   "", ddEmpresa.SelectedValue);
            }*/


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
            DataTable dt = manejoEmpleados.LlenarComboDepartamento();            
            foreach (DataRow row in dt.Rows)
            {
                ddDepartamento.Items.Add(new ListItem(row["Nombre"].ToString(), row["ID_Departamento"].ToString()));
            }
        }

        protected void LLenarComboPuesto(string id)
        {
            lblNoHayPuestos.Visible = false;

            ddPuesto.Items.Clear();
            ddPuesto.Items.Add(new ListItem("--Seleccionar puesto", "0"));

            DataTable dt = manejoEmpleados.LLenarComboPuestos(id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ddPuesto.Items.Add(new ListItem(row["Puesto"].ToString(), row["ID_puesto"].ToString()));
                }
            }
            else
            {
                lblNoHayPuestos.Visible = true;
            }

        }

        protected void ddDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarComboPuesto(ddDepartamento.SelectedValue.ToString());
        }

        protected string EmpleadoCE(string accion)
        {
            CapaManejoEmpleados empleado = new CapaManejoEmpleados(
                txtNoEmpleado.Text.Trim(),
                txtNombre.Text.Trim(),
                txtApellidoP.Text.Trim(),
                txtApellidoM.Text.Trim(),
                chkEstatus.Checked,
                txtRfc.Text.Trim(),
                txtNSS.Text.Trim(),
                txtFechaNac.Text,
                txtFechaIngreso.Text,
                txtCalle.Text.Trim(),
                txtcolonia.Text.Trim(),
                txtCP.Text.Trim(),
                txtEstado.Text.Trim(),
                txtCiudad.Text.Trim(),
                txtTelefono.Text.Trim(),
                txtCorreo.Text.Trim(),
                txtTelEmergencia.Text.Trim(),
                txtContactoEmergencia.Text.Trim(),
                ddDepartamento.SelectedValue,
                ddPuesto.SelectedValue,
                ddEmpresa.SelectedValue
                );
             return empleado.RegistrarEmpleado(accion);
                
        }


       /* protected void registrarEmpleado(string accion, string noEmpleado,
            string nombre, string apellidoPaterno, string apellidoMaterno,
            bool status, string rfc, string nss, string FechaNac, string FechaIngreso,
            string Calle, string colonia, string cp, string estado,string ciudad, 
            string telefono, string correo,
            string TelEmergencia, string ContactoEmergencia,
            string IDDepartamento, string idpuesto, string foto, string empresa)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=accion},
                new clsHerramientas.clsParametros{NombreParametro="@no_empleado", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= noEmpleado },
                new clsHerramientas.clsParametros{NombreParametro="@Nombre", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= nombre },
                new clsHerramientas.clsParametros{NombreParametro="@ApellidoP", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= apellidoPaterno },
                new clsHerramientas.clsParametros{NombreParametro="@ApellidoM", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro= apellidoMaterno },
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
                new clsHerramientas.clsParametros{NombreParametro="@Empresa", TipoParametro=System.Data.SqlDbType.Int, ValorParametro= empresa}
            };
          
            if(accion == "insert")
            {
                parametros.Add(new clsHerramientas.clsParametros { NombreParametro = "@foto", TipoParametro = System.Data.SqlDbType.VarChar, ValorParametro = foto });
            }

            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Empleado", parametros);
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + resultado.Item2 + "');", true);

        }*/

            protected void txtNoEmpleado_TextChanged(object sender, EventArgs e)
        {
            if(manejoEmpleados.BuscarNoEmpleado(txtNoEmpleado.Text))
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
            try
            {
               
                Dictionary<string, string> Info = manejoEmpleados.ObtenerInformacion(id,"details");
                imgEmpl.BackImageUrl = Info["foto"];
                txtNombre.Text = Info["Nombre"];
                txtApellidoP.Text = Info["Apellido_P"];
                txtApellidoM.Text = Info["Apellido_M"];
                txtFechaNac.Text = Convert.ToDateTime(Info["Fecha_nacimiento"]).ToString("yyyy-MM-dd");
                txtRfc.Text = Info["RFC"];
                txtNSS.Text = Info["NSS"];
                txtcolonia.Text = Info["Colonia"];
                txtCalle.Text = Info["Calle"];
                txtCiudad.Text = Info["Ciudad"];
                txtEstado.Text = Info["Estado"];
                txtCP.Text = Info["CP"];
                txtTelefono.Text = Info["Telefono"];
                txtContactoEmergencia.Text = Info["Contacto_Emergencia"];
                txtTelEmergencia.Text = Info["Tel_Emergencia"];
                txtNoEmpleado.Text = Info["no_empleado"];
                txtFechaIngreso.Text = Convert.ToDateTime(Info["Fecha_ingreso"]).ToString("yyyy-MM-dd");
                ddEmpresa.Items.FindByValue(Info["Empresa"]).Selected = true;
                ddDepartamento.Items.FindByValue(Info["ID_Departamento"]).Selected = true;
                LLenarComboPuesto(Info["ID_Departamento"]);
                ddPuesto.Items.FindByValue(Info["ID_puesto"]).Selected = true;

                //Label
                if (Info["Status"] == "True")
                {
                    lblStatus.Text = "activo";
                    lblStatus.CssClass = lblStatus.CssClass.Replace("inactivo", "");
                }
                else
                {
                    lblStatus.Text = "baja";
                    lblStatus.CssClass = "ms-2 estado inactivo";
                    chkEstatus.Checked = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('No existe el empleado  " + ex.Message + "');", true);
                
                Response.Redirect("crud.aspx");
            }


        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            
            var foto = manejoEmpleados.CambiarFoto(Request["id"], ddEmpresa.SelectedItem.Text,txtNoEmpleado.Text.Trim()+" "+ txtNombre.Text.Trim()+" "+txtApellidoP.Text.Trim()+" "+txtApellidoM.Text.Trim());
            if(foto.Item2 != "")
            {
                imgEmpl.BackImageUrl = foto.Item2.Replace('\\', '/');
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + foto.Item1 + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + foto.Item1 + "');", true);
            }

        }
    }
}