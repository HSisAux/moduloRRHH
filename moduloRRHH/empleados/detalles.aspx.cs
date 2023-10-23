using Microsoft.SqlServer.Server;
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
using System.Web.Services;
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
                Documentos();
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
                    imgEmpresa.AlternateText = "Jamamadi";
                    break;
                case "4 Matildes":
                    imgEmpresa.ImageUrl = "../Assets/img/4Matildes.png";
                    imgEmpresa.AlternateText = "4 Matildes";

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

            if (Info["salario_actual"] != "Sin asignar")
            {
                txtSalario.Attributes["value"] = Info["salario_actual"];
            }
            else
            {
                txtSalario.TextMode = TextBoxMode.SingleLine;
                txtSalario.Text = "Sin asignar";
                chSHowHide.Visible = false;
            }
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
        public void Documentos()
        {
            gvTest.DataSource = manejoEmpleados.TablaDocumentos(Request["id"]);
            gvTest.DataBind();            
        }

        protected void gvTest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string aux;
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

                    LinkButton btnAceptar = e.Row.FindControl("btnAceptar") as LinkButton;
                    btnAceptar.Visible = false;

                    Panel panel = e.Row.FindControl("PanelOpciones") as Panel;
                    panel.Visible = false;
                    if (!checkBox.Checked)
                    {
                        e.Row.Cells[4].Text = "<label class='estado pendiente'>opcional</label>";

                    }
                    else
                    {
                        e.Row.Cells[4].Text = "<label class='estado pendiente'>Sin entregar</label>";

                    }
                }
                else
                {
                    switch (aux)
                    {
                        case "creado":
                            e.Row.Cells[4].Text = "<label class='estado bg-white text-dark border border-success border-2'>Entregado</label>";
                            break;
                        case "aceptado":
                            e.Row.Cells[4].Text = "<label class='estado'>Aprobado</label>";
                            break;
                        case "actualizado":
                            e.Row.Cells[4].Text = "<label class='estado modificado'>Actualizado</label>";
                            break;
                        case "vencido":
                            e.Row.Cells[4].Text = "<label class='estado inactivo fw-bold'>⚠ VENCIDO ⚠</label>";
                            break;
                        case "actulizar":
                            e.Row.Cells[4].Text = "<label class='estado bg-white text-dark border border-warning border-2'><i class=\"fa-solid fa-arrows-rotate\"></i> Actualizar</label>";
                            break;
                    }

                    if (e.Row.FindControl("btnAceptar") is LinkButton linkBtn && aux != "actualizado"  )
                    {
                        if(aux != "creado"){
                        // Modifica el texto del LinkButton
                        linkBtn.Text = "<i class=\"fa-solid fa-rotate\"></i> Actualizar";
                        linkBtn.Attributes["data-action"] = "editar";
                        }
                        
                    }
                    if (e.Row.FindControl("btnSubir") is LinkButton linkButton)
                    {
                        // Modifica el texto del LinkButton según tu lógica
                        linkButton.Text = "<i class=\"fa-solid fa-pencil\"></i>";
                        linkButton.CssClass = "btn btn-sm btn-warning text-white";
                        linkButton.Attributes["data-accion"] = "editar";
                    }
                    if (e.Row.Cells[3].Text !="sin expiracion")
                    {
                        DateTime vencimiento = DateTime.Parse(e.Row.Cells[3].Text);
                        ManejoDocumentos.ComprobacionVencimiento(e.Row.Cells[7].Text, aux, vencimiento);
                    }
                    if (e.Row.FindControl("btnVer") is LinkButton lbtnVer)
                    {
                        // Modifica el texto del LinkButton según tu lógica
                        lbtnVer.PostBackUrl = "~/empleados/visor.aspx?doc="+ e.Row.Cells[7].Text;


                    }
                }
            }
        }

        protected void chSHowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chSHowHide.Checked)
            {
                txtSalario.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txtSalario.TextMode = TextBoxMode.Password;

            }
        }

        protected void SubirEditar_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            hfDocumento.Value = gvTest.Rows[rowIndex].Cells[5].Text;
            hfExpiracion.Value = gvTest.Rows[rowIndex].Cells[6].Text;
            hfDocumentacionID.Value = gvTest.Rows[rowIndex].Cells[7].Text;

            LinkButton linkButton = gvTest.Rows[rowIndex].FindControl("btnSubir") as LinkButton;
            if (linkButton != null)
            {
                hfAccion.Value = linkButton.Attributes["data-accion"];
            }
            if(gvTest.Rows[rowIndex].Cells[6].Text == "1")
            {
                panelFecha.Visible = true;
            }
            else
            {
                panelFecha.Visible = false;
            }
            ModalPopupExtender1.Show();

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //docid 5, nocontrol
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            DataTable dt = clsHerramientas.SQLConsulta("SELECT Archivo FROM Documentacion WHERE no_empleado='"+txtNoEmpleado.Text.Trim()+"' AND Documentos_ID='"+ gvTest.Rows[rowIndex].Cells[5].Text + "'");
            if(dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "Imprimir('" + dt.Rows[0]["Archivo"].ToString().Replace('\\', '/') + "');", true);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string res = "";
            LinkButton btn = (LinkButton)sender;
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            if (btn.Attributes["data-action"] == "aceptar")
            {
                 res = ManejoDocumentos.AceptarDoc(gvTest.Rows[rowIndex].Cells[7].Text, "014", txtNoEmpleado.Text,"aceptado");
                if (res == "aceptado")
                {
                    Documentos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "Imprimir('" + res + "');", true);
                }
            }
            else if (btn.Attributes["data-action"] == "editar")
            {
                 res = ManejoDocumentos.AceptarDoc(gvTest.Rows[rowIndex].Cells[7].Text, "014", txtNoEmpleado.Text, "actulizar");
                if (res == "actulizar")
                {
                    Documentos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", "Imprimir('" + res + "');", true);
                }
            }
        }

        public void Historial(string archivo)
        {
            //Obtengo el historial por el id de documnetacion.
            gvHistory.DataSource = ManejoDocumentos.ObtenerHistorial(archivo);
            gvHistory.DataBind();
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            //Obtengo el nombre del documento
            lblDocHistorial.Text = "Historial de "+ gvTest.Rows[rowIndex].Cells[0].Text;

            //Obtengo el historial con el dcoumentoid
            Historial(gvTest.Rows[rowIndex].Cells[7].Text);

            //Muestro el modal
            ModalHistorial.Show();

        }
    }
}