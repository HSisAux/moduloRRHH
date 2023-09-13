using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace moduloRRHH.compania
{
    public partial class division : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Departamentos";
                BindDataDpto("");
                BindDataPuesto("");
                llenarCombo();
                //LlenarDataList();
            }

        }

        protected void ddRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvDepartamentos.PageSize = Convert.ToInt16(ddRegistros.SelectedValue);
            BindDataDpto(txtBusqueda.Text.Trim());
        }

        protected void gvPuestos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindDataPuesto(txtSearchPuesto.Text.Trim());
            gvPuestos.PageIndex = e.NewPageIndex;
            gvPuestos.DataBind();
        }

        protected void gvDepartamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindDataDpto(txtBusqueda.Text.Trim());
            gvDepartamentos.PageIndex = e.NewPageIndex;
            gvDepartamentos.DataBind();
        }

        protected void btnEditarDpto_Click(object sender, EventArgs e)
        {

            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;

            btnRegistrarDpto.Visible = false;
            btnCancelarDpto.Visible = true;
            btnAceptarDpto.Visible = true;
            txtIDdpto.ReadOnly = true;
            txtIDdpto.Text = gvDepartamentos.Rows[rowIndex].Cells[0].Text;
            txtDpto.Text = gvDepartamentos.Rows[rowIndex].Cells[1].Text;

            gvDepartamentos.Rows[rowIndex].Cells[0].BackColor = Color.Yellow;
            gvDepartamentos.Rows[rowIndex].Cells[1].BackColor = Color.Yellow;
            gvDepartamentos.Rows[rowIndex].Cells[2].BackColor = Color.Yellow;

            lblRowIndexDpto.Text = rowIndex.ToString();
        }

        protected void btnBorrarDpto_Click(object sender, EventArgs e)
        {
            pAlertaModal.Visible = true;
            txtPD.Text = "";

            lblTabla.Text = "departamento";
            btnCloseModal.Text = "Cancelar";
            btnAceptarModal.Visible = true;
            lblHeader.Text = "<i class=\"fa-solid fa-triangle-exclamation\"></i> Advertencia";
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            lblDocDel.Text = "Esta por eliminar el departamento <br><strong>" + gvDepartamentos.Rows[rowIndex].Cells[1].Text + "</strong><br>Si lo elimina, se borraran todos los puestos relacionados a este departamento<br>¿Desea continuar?";
            lblData.Text = gvDepartamentos.Rows[rowIndex].Cells[0].Text;
            ModalPopupExtender1.Show();
            
        }

        protected void BindDataDpto(string valor)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=valor}
            };
            DataTable dt = clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
            gvDepartamentos.DataSource = dt;
            gvDepartamentos.DataBind();

            lblTotalDpto.Text = "Total de registros: " + dt.Rows.Count;
        }
        protected void BindDataPuesto(string valor)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=valor}
            };
            DataTable dtP = clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
            gvPuestos.DataSource = dtP;
            gvPuestos.DataBind();
            lblTotalPuesto.Text = "Total de registros: "+dtP.Rows.Count;
        }

        protected void btnRegistrarDpto_Click(object sender, EventArgs e)
        {
            PAlerta.Visible = true;

            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="insert"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= txtIDdpto.Text},
                new clsHerramientas.clsParametros{NombreParametro="@Nombre", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= txtDpto.Text},
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            gvDepartamentos.DataSource = resultado.Item1;
            lblResult.Text = resultado.Item2;
            BindDataDpto("");

            txtIDdpto.Text = "";
            txtDpto.Text = "";
            llenarCombo();
        }

        protected void btnCloseAlert_Click(object sender, EventArgs e)
        {
            PAlerta.Visible = false;
        }

        protected void btnAceptarDpto_Click(object sender, EventArgs e)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="update"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= txtIDdpto.Text},
                new clsHerramientas.clsParametros{NombreParametro="@Nombre", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= txtDpto.Text},
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            gvDepartamentos.DataSource = resultado.Item1;
            lblResult.Text = resultado.Item2;
            BindDataDpto("");
            PAlerta.Visible = true;


            btnRegistrarDpto.Visible = true;
            btnCancelarDpto.Visible = false;
            btnAceptarDpto.Visible = false;
            txtIDdpto.ReadOnly = false;
            txtIDdpto.Text = "";
            txtDpto.Text = "";
            llenarCombo();
        }

        protected void btnCancelarDpto_Click(object sender, EventArgs e)
        {
            btnRegistrarDpto.Visible = true;
            btnCancelarDpto.Visible = false;
            btnAceptarDpto.Visible = false;
            txtIDdpto.ReadOnly = false;
            txtIDdpto.Text = "";
            txtDpto.Text = "";

            gvDepartamentos.Rows[Convert.ToInt16(lblRowIndexDpto.Text)].Cells[0].BackColor = Color.White;
            gvDepartamentos.Rows[Convert.ToInt16(lblRowIndexDpto.Text)].Cells[1].BackColor = Color.White;
            gvDepartamentos.Rows[Convert.ToInt16(lblRowIndexDpto.Text)].Cells[2].BackColor = Color.White;

        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            BindDataDpto(txtBusqueda.Text.Trim());
        }

        public void llenarCombo()
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=""}
            };
            DataTable dt = clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros);
            cbDepartamento.DataSource = dt;
            cbDepartamento.DataTextField = "Nombre";
            cbDepartamento.DataValueField = "ID_Departamento";
            cbDepartamento.DataBind();
        }

        protected void btnRegistrarPuesto_Click(object sender, EventArgs e)
        {
            PAlertaPuesto.Visible = true;

            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="insert"},
                new clsHerramientas.clsParametros{NombreParametro="@ID_puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= txtPuestosID.Text},
                new clsHerramientas.clsParametros{NombreParametro="@Puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= txtPuestosDescripcion.Text},
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= cbDepartamento.SelectedValue},
            };
            var resultado = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            gvPuestos.DataSource = resultado.Item1;
            lblPuestoAlert.Text = resultado.Item2;
            BindDataPuesto("");
            txtPuestosDescripcion.Text = "";
            txtPuestosID.Text = "";
            cbDepartamento.SelectedIndex = -1;
        }

        protected void btnPuestoAlert_Click(object sender, EventArgs e)
        {
            PAlertaPuesto.Visible = false;
        }

        protected void btnEditarPuesto_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            txtPuestosID.Text = gvPuestos.Rows[rowIndex].Cells[0].Text;
            txtPuestosDescripcion.Text = gvPuestos.Rows[rowIndex].Cells[1].Text;
            SetSelectedValue(gvPuestos.Rows[rowIndex].Cells[3].Text);

            btnAceptarPuesto.Visible = true;
            btnCancelarPuesto.Visible = true;
            btnRegistrarPuesto.Visible = false;
        }


        protected void btnBorrarPuesto_Click(object sender, EventArgs e)
        {
            pAlertaModal.Visible = true;
            txtPD.Text = "";

            lblTabla.Text = "puesto";
            btnCloseModal.Text = "Cancelar";
            btnAceptarModal.Visible = true;
            lblHeader.Text = "<i class=\"fa-solid fa-triangle-exclamation\"></i> Advertencia";
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            lblDocDel.Text = "Esta por eliminar el siguiente puesto";
            lblDptoPuesto.Text = gvPuestos.Rows[rowIndex].Cells[1].Text;
            lblTipo.Text = "puesto";
            lblData.Text = gvPuestos.Rows[rowIndex].Cells[0].Text;
            ModalPopupExtender1.Show();

            //PAlertaPuesto.Visible = true;
            //int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            //List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            //{
            //    new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
            //    new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="delete"},
            //    new clsHerramientas.clsParametros{NombreParametro="@ID_puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= gvPuestos.Rows[rowIndex].Cells[0].Text}
            //};

            //var tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            //lblPuestoAlert.Text = tupla.Item2;
            ////dt = /*clsHerramientas.ProcedimientoAlmacenado("Master_Documentos", parametros);*/ tupla.Item1;

            //BindDataPuesto("");
        }

        //Establece el valor en el combobox
        private void SetSelectedValue(string valueToSelect)
        {
            // Find the item with the desired value
            int selectedIndex = -1;
            for (int i = 0; i < cbDepartamento.Items.Count; i++)
            {
                if (cbDepartamento.Items[i].Value == valueToSelect)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex >= 0)
            {
                cbDepartamento.SelectedIndex = selectedIndex;
            }
        }

        protected void btnAceptarPuesto_Click(object sender, EventArgs e)
        {
            PAlertaPuesto.Visible = true;
            //int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="update"},
                new clsHerramientas.clsParametros{NombreParametro="@Puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=txtPuestosDescripcion.Text },
                new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= cbDepartamento.SelectedValue },
                new clsHerramientas.clsParametros{NombreParametro="@ID_puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= txtPuestosID.Text}
            };

            var tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
            lblPuestoAlert.Text = tupla.Item2;;
            BindDataPuesto("");

            btnAceptarPuesto.Visible = false;
            btnCancelarPuesto.Visible = false;
            btnRegistrarPuesto.Visible = true;
            txtPuestosDescripcion.Text = "";
            txtPuestosID.Text = "";
            cbDepartamento.SelectedIndex = -1;
        }

        protected void btnCancelarPuesto_Click(object sender, EventArgs e)
        {
            btnAceptarPuesto.Visible = false;
            btnCancelarPuesto.Visible = false;
            btnRegistrarPuesto.Visible = true;
            txtPuestosDescripcion.Text = "";
            txtPuestosID.Text = "";
            cbDepartamento.SelectedIndex = -1;
        }

        protected void btnSearchPuesto_Click(object sender, EventArgs e)
        {
            BindDataPuesto(txtSearchPuesto.Text.Trim());
        }

        protected void ddPuestoCant_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPuestos.PageSize = Convert.ToInt16(ddPuestoCant.SelectedValue);
            BindDataPuesto(txtSearchPuesto.Text.Trim());

        }

        protected void gvPuestos_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=""}
            };

            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";

            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "Asc";

            }
            DataView sortedView = new DataView(clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros));
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            Session["SortedView"] = sortedView;
            gvPuestos.DataSource = sortedView;
            gvPuestos.DataBind();
        }

        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }

        protected void gvDepartamentos_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
            {
                new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="select"},
                new clsHerramientas.clsParametros{NombreParametro="@valor", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro=""}
            };

            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";

            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "Asc";

            }
            DataView sortedView = new DataView(clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros));
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            Session["SortedView"] = sortedView;
            gvDepartamentos.DataSource = sortedView;
            gvDepartamentos.DataBind();
        }

        protected void btnAceptarModal_Click(object sender, EventArgs e)
        {
            DataTable dtTest;
            if (lblDptoPuesto.Text == txtPD.Text)
            {
                pAlertaModal.Visible = false;

                if (lblTabla.Text == "departamento")
                {
                    dtTest = clsHerramientas.SQLConsulta("SELECT * FROM Empleado WHERE ID_Departamento='" + lblData.Text + "'");
                    if (dtTest.Rows.Count > 0)
                    {

                        lblHeader.Text = "<i class=\"fa-solid fa-triangle-exclamation\"></i> Advertencia";
                        lblDocDel.Text = "Tiene empleados asignados a este departamento, ";
                        btnCloseModal.Text = "Ok";
                        btnAceptarModal.Visible = false;

                        
                        BindDataDpto("");
                        BindDataPuesto("");
                        llenarCombo();
                    }
                    else
                    {

                        List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                    {
                        new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="departamento"},
                        new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="delete"},
                        new clsHerramientas.clsParametros{NombreParametro="@ID_Departamento", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= lblData.Text}
                    };

                        var tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
                        lblHeader.Text = "<i class=\"fa-solid fa-circle-info\"></i> Informacion";
                        lblDocDel.Text = tupla.Item2;
                        btnCloseModal.Text = "Ok";
                        btnAceptarModal.Visible = false;

                        BindDataDpto("");
                        BindDataPuesto("");
                        llenarCombo();

                    }

                }
                else if (lblTabla.Text == "puesto")
                {
                    dtTest = clsHerramientas.SQLConsulta("SELECT * FROM Empleado WHERE ID_puesto='" + lblData.Text + "'");
                    if (dtTest.Rows.Count > 0)
                    {

                        lblHeader.Text = "<i class=\"fa-solid fa-triangle-exclamation\"></i> Advertencia";
                        lblDocDel.Text = "Tiene empleados con este puesto asignado";
                        btnCloseModal.Text = "Ok";
                        btnAceptarModal.Visible = false;

                        BindDataDpto("");
                        BindDataPuesto("");
                        llenarCombo();
                    }
                    else
                    {

                        List<clsHerramientas.clsParametros> parametros = new List<clsHerramientas.clsParametros>()
                    {
                        new clsHerramientas.clsParametros{NombreParametro="@tabla", TipoParametro=System.Data.SqlDbType.VarChar, ValorParametro="puesto"},
                        new clsHerramientas.clsParametros{NombreParametro="@accion", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro="delete"},
                        new clsHerramientas.clsParametros{NombreParametro="@ID_puesto", TipoParametro= System.Data.SqlDbType.VarChar, ValorParametro= lblData.Text}
                    };

                        var tupla = clsHerramientas.TProcedimientoAlmacenado("Master_Division", parametros);
                        lblPuestoAlert.Text = tupla.Item2;
                        BindDataPuesto("");

                        lblHeader.Text = "<i class=\"fa-solid fa-circle-info\"></i> Informacion";
                        lblDocDel.Text = tupla.Item2 + " 😞";
                        btnCloseModal.Text = "Ok";
                        btnAceptarModal.Visible = false;
                    }

                } 
            }
        }
    }
}