using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
using moduloRRHH.App_Code;
using moduloRRHH.salario;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
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
        CapaManejoEmpleados ManejoEmpleados = new CapaManejoEmpleados();
        CapaSalarios CapaSalarios = new CapaSalarios();

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
            txtSalarioActual.Text = "";
            txtSalarioNuevo.Text = "";

        }

        public void llenarComboDpto()
        {
            DataTable dt = ManejoEmpleados.LlenarComboDepartamento();            
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

            DataTable dt = ManejoEmpleados.LLenarComboPuestos(id);
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


      

            protected void txtNoEmpleado_TextChanged(object sender, EventArgs e)
        {
            if(ManejoEmpleados.BuscarNoEmpleado(txtNoEmpleado.Text))
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
               
                Dictionary<string, string> Info = ManejoEmpleados.ObtenerInformacion(id,"details");
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

                if (Info["ID_Departamento"] != "gend")
                {
                    ddDepartamento.Items.FindByValue(Info["ID_Departamento"]).Selected = true;
                    LLenarComboPuesto(Info["ID_Departamento"]);
                    if (Info["ID_puesto"] != "genp")
                    {
                        ddPuesto.Items.FindByValue(Info["ID_puesto"]).Selected = true;

                    }
                }
                

                //Obtencion del salario del empleado
                DataTable dtSalario = CapaSalarios.ObtenerSalario(Info["no_empleado"]);
                if (dtSalario.Rows.Count > 0)
                {
                    txtSalarioActual.Text = dtSalario.Rows[0]["salario_actual"].ToString();                    

                    //Como el textbox esta en modo password, no sep puede llenar con .Text, en cambio se establece la propiedad value del input
                    txtSalario.Attributes["value"] = dtSalario.Rows[0]["salario_actual"].ToString();
                }
                else
                {
                    txtSalario.TextMode = TextBoxMode.SingleLine;
                    txtSalario.Text = "Sin asignar";
                }
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
            
            var foto = ManejoEmpleados.CambiarFoto(Request["id"], ddEmpresa.SelectedItem.Text,txtNoEmpleado.Text.Trim()+" "+ txtNombre.Text.Trim()+" "+txtApellidoP.Text.Trim()+" "+txtApellidoM.Text.Trim());
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

        protected void btnAceptarModal_Click(object sender, EventArgs e)
        {
                if (txtNoEmpleado.Text != "")
                {
                    MetodosSalarios salarios = new MetodosSalarios(txtNoEmpleado.Text, Convert.ToDecimal(00.0), Convert.ToDecimal(txtSalarioNuevo.Text));
                //ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "alert('" + salarios.RegistrarSalario() + "');", true);
                lblRes.Text = salarios.RegistrarSalario();
                DataTable dtSalario = CapaSalarios.ObtenerSalario(txtNoEmpleado.Text);
                txtSalarioActual.Text = dtSalario.Rows[0]["salario_actual"].ToString();
                txtSalarioNuevo.Text = "";
            }
                else
                {
                    lblRes.ForeColor = Color.FromArgb(204, 0, 0);
                    lblRes.Text = "*Debe ingresar un numero de empleado para poder continuar";
                }
        }

        protected void btnShowModalAJAX_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            lblRes.Text = "";
            
        }
    }
}