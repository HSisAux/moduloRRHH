using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace moduloRRHH.documentos
{
    public partial class crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Documentos";
                BindGrid("");
            }

        }

        protected void ddCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvDocumentos.PageSize = Convert.ToInt16(ddCantidad.SelectedValue);
            BindGrid(txtBuscar.Text.Trim());

        }

        protected void btnRegistrarDoc_Click(object sender, EventArgs e)
        {
            PAlerta.Visible = false;
            string id = txtDocID.Text;
            string nombre = txtNombre.Text;
            string expiracion = ddVencimiento.SelectedValue;
            string requerido = "0";
            if (chRequerido.Checked)
            {
                requerido = "1";
            }
            DataTable dt = new DataTable();
            if(id!= "" && nombre != "")
            {
                
                DataTable table = clsHerramientas.SQLConsulta("SELECT * FROM Documentos WHERE ID='" + id + "'");
                if (table.Rows.Count > 0 )
                {
                    lblResult.Text= "ya existe un documento registrado con el ID especificado";
                    PAlerta.Visible = true;

                }
                else
                {
                    List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                {
                    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="create"},
                    new clsHerramientas.clsParametros{NombreParametro="@ID",TipoParametro=SqlDbType.VarChar, ValorParametro=id},
                    new clsHerramientas.clsParametros{NombreParametro="@nombre",TipoParametro=SqlDbType.VarChar, ValorParametro=nombre},
                    new clsHerramientas.clsParametros{NombreParametro="@expiracion",TipoParametro=SqlDbType.VarChar, ValorParametro=expiracion},
                    new clsHerramientas.clsParametros{NombreParametro="@requerido",TipoParametro=SqlDbType.VarChar, ValorParametro=requerido}

                };

                    //dt = clsHerramientas.ProcedimientoAlmacenado("Master_Documentos",parametros);

                    var ejecutacion = clsHerramientas.TProcedimientoAlmacenado("Master_Documentos", parametros);
                dt = ejecutacion.Item1;

               
                    lblResult.Text = ejecutacion.Item2;
                    PAlerta.Visible = true;
               
                }


                BindGrid(txtBuscar.Text.Trim());
                txtDocID.Text = "";
                txtNombre.Text = "";
                chRequerido.Checked = false;

            }
            
        }

        private void BindGrid(string buscar)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="read"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro=SqlDbType.VarChar,ValorParametro=buscar}
            };
            gvDocumentos.DataSource = clsHerramientas.ProcedimientoAlmacenado("Master_Documentos", parametros);
            gvDocumentos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BindGrid(txtBuscar.Text.Trim());
        }

        //Generacion de rows de gridview
        protected void gvDocumentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                string expiracion = DataBinder.Eval(e.Row.DataItem, "expiracion").ToString();
                string requerido = DataBinder.Eval(e.Row.DataItem, "requerido").ToString();

                //Mostrar el tipo de expiracion
                switch (expiracion)
                {
                    case "0":
                        e.Row.Cells[2].Text = "No expira";
                        break;
                    case "1":
                        e.Row.Cells[2].Text = "Por fecha";
                        break;
                    case "2":
                        e.Row.Cells[2].Text = "cada 6 meses";
                        break;
                    case "3":
                        e.Row.Cells[2].Text = "cada 3 meses";
                        break;
                    case "4":
                        e.Row.Cells[2].Text = "cada 1 año";
                        break;
                   
                }
                //Mostrar si es requerido o no
                if (requerido == "True")
                {
                    e.Row.Cells[3].Text = "Si";
                }
                else
                {
                    e.Row.Cells[3].Text = "No";
                }

            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            txtDocID.Text = gvDocumentos.Rows[rowIndex].Cells[0].Text;
            txtNombre.Text = gvDocumentos.Rows[rowIndex].Cells[1].Text;
            if(gvDocumentos.Rows[rowIndex].Cells[3].Text == "Si")
            {
                chRequerido.Checked = true;
            }
            ddVencimiento.SelectedValue = ddVencimiento.Items.FindByText(gvDocumentos.Rows[rowIndex].Cells[2].Text).Value;
            btnRegistrarDoc.Visible = false;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
            txtDocID.ReadOnly = true;
            lblRowIndex.Text = rowIndex.ToString();
            gvDocumentos.Rows[rowIndex].Cells[0].BackColor = Color.Yellow;
            gvDocumentos.Rows[rowIndex].Cells[1].BackColor = Color.Yellow;
            gvDocumentos.Rows[rowIndex].Cells[2].BackColor = Color.Yellow;
            gvDocumentos.Rows[rowIndex].Cells[3].BackColor = Color.Yellow;
            gvDocumentos.Rows[rowIndex].Cells[4].BackColor = Color.Yellow;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gvDocumentos.Rows[Convert.ToInt32(lblRowIndex.Text)].Cells[0].BackColor = Color.White;
            gvDocumentos.Rows[Convert.ToInt32(lblRowIndex.Text)].Cells[1].BackColor = Color.White;
            gvDocumentos.Rows[Convert.ToInt32(lblRowIndex.Text)].Cells[2].BackColor = Color.White;
            gvDocumentos.Rows[Convert.ToInt32(lblRowIndex.Text)].Cells[3].BackColor = Color.White;
            gvDocumentos.Rows[Convert.ToInt32(lblRowIndex.Text)].Cells[4].BackColor = Color.White;

            btnRegistrarDoc.Visible = true;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            txtDocID.ReadOnly =false;

            txtDocID.Text = "";
            txtNombre.Text = "";
            chRequerido.Checked = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            PAlerta.Visible = false;
            string id = txtDocID.Text;
            string nombre = txtNombre.Text;
            string expiracion = ddVencimiento.SelectedValue;
            string requerido = "0";
            if (chRequerido.Checked)
            {
                requerido = "1";
            }
            DataTable dt = new DataTable();
            if (id != "" && nombre != "")
            {
                List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                {
                    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="update"},
                    new clsHerramientas.clsParametros{NombreParametro="@ID",TipoParametro=SqlDbType.VarChar, ValorParametro=id},
                    new clsHerramientas.clsParametros{NombreParametro="@nombre",TipoParametro=SqlDbType.VarChar, ValorParametro=nombre},
                    new clsHerramientas.clsParametros{NombreParametro="@expiracion",TipoParametro=SqlDbType.VarChar, ValorParametro=expiracion},
                    new clsHerramientas.clsParametros{NombreParametro="@requerido",TipoParametro=SqlDbType.VarChar, ValorParametro=requerido}

                };
                var ejecutado = clsHerramientas.TProcedimientoAlmacenado("Master_Documentos", parametros);

                //dt = clsHerramientas.ProcedimientoAlmacenado("Master_Documentos", parametros);

                dt = ejecutado.Item1;
                
                    lblResult.Text = ejecutado.Item2;
                    PAlerta.Visible = true;
                
               

                BindGrid(txtBuscar.Text.Trim());
                btnRegistrarDoc.Visible = true;
                btnAceptar.Visible = false;
                btnCancelar.Visible = false;
                txtDocID.ReadOnly = false;

                txtDocID.Text = "";
                txtNombre.Text = "";
                chRequerido.Checked = false;

            }
            else
            {
                lblResult.Text = "LLene los campos";
                PAlerta.Visible = true;

            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            btnCloseModal.Text = "Cancelar";
            btnAceptarModal.Visible = true;
            lblHeader.Text = "<i class=\"fa-solid fa-triangle-exclamation\"></i> Precaucion";
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            lblDocDel.Text = "Esta por eliminar el documento <br><strong style=\"margin-left: 40%;\">" + gvDocumentos.Rows[rowIndex].Cells[1].Text + "</strong><br>¿Desea continuar?";
            ModalPopupExtender1.Show();
            lblData.Text = gvDocumentos.Rows[rowIndex].Cells[0].Text;
        }

        protected void gvDocumentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGrid(txtBuscar.Text.Trim());
            gvDocumentos.PageIndex = e.NewPageIndex;
            gvDocumentos.DataBind();
        }

        protected void btnAceptarModal_Click(object sender, EventArgs e)
        {

            (DataTable, string) tupla;
            DataTable dt = new DataTable();
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                {
                    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro=SqlDbType.VarChar, ValorParametro="delete"},
                    new clsHerramientas.clsParametros{NombreParametro="@ID",TipoParametro=SqlDbType.VarChar, ValorParametro= lblData.Text  },
                };
            tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Documentos", parametros);

            dt = /*clsHerramientas.ProcedimientoAlmacenado("Master_Documentos", parametros);*/ tupla.Item1;

            BindGrid(txtBuscar.Text.Trim());

            lblHeader.Text = "<i class=\"fa-solid fa-circle-info\"></i> Informacion";

            lblDocDel.Text = tupla.Item2 ;
            btnCloseModal.Text = "Ok";
            btnAceptarModal.Visible = false;
        }

        protected void btnCloseAlert_Click(object sender, EventArgs e)
        {
            PAlerta.Visible = false;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid("");
            txtBuscar.Text = "";
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BindGrid(txtBuscar.Text.Trim());
        }
    }
}