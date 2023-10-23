using moduloRRHH.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH.compania
{
    public partial class division : System.Web.UI.Page
    {
        MetodosDepartamentos Departamentos;
        MetodosPuestos Puestos;
        List<ListaEmpleados> _AuxEMpleados;
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

            //Lleno campos
            btnRegistrarDpto.Visible = false;
            btnCancelarDpto.Visible = true;
            btnAceptarDpto.Visible = true;
            txtIDdpto.ReadOnly = true;
            txtIDdpto.Text = gvDepartamentos.Rows[rowIndex].Cells[0].Text;
            txtDpto.Text = gvDepartamentos.Rows[rowIndex].Cells[1].Text;

            //Cambio la fila a un color amarillo para resaltar el que se va a editar
            gvDepartamentos.Rows[rowIndex].Cells[0].BackColor = Color.Yellow;
            gvDepartamentos.Rows[rowIndex].Cells[1].BackColor = Color.Yellow;
            gvDepartamentos.Rows[rowIndex].Cells[2].BackColor = Color.Yellow;

            lblRowIndexDpto.Text = rowIndex.ToString();
        }

        protected void btnBorrarDpto_Click(object sender, EventArgs e)
        {
            pAlertaModal.Visible = false;
            txtPD.Text = "";

            lblTabla.Text = "departamento";
            btnCloseModal.Text = "Cancelar";
            btnAceptarModal.Visible = true;
            lblHeader.Text = "<i class=\"fa-solid fa-triangle-exclamation\"></i> Advertencia";
            
            //Obtengo el index de la fila seleccionada 
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            
            //Si hay lista
            //Guardo el nombre del departamento en un hiddenField
            NombreDP.Value = gvDepartamentos.Rows[rowIndex].Cells[1].Text;

            //Genero el objeto con el id del departamento seleccionado
            Departamentos = new MetodosDepartamentos("", gvDepartamentos.Rows[rowIndex].Cells[0].Text);

            //Lleno la lista con los empleados del departamento
            _AuxEMpleados = Departamentos.PrevencionDepartamento();
            if(_AuxEMpleados.Count > 0)
            {
                lblDocDel.Text = "<p>Este departamente cuenta con los siguientes empleados:</p>";
                for (int i = 0; i < _AuxEMpleados.Count; i++)
                {
                    lblDocDel.Text += "<p>" + _AuxEMpleados[i].NoEmpleado+". "+ _AuxEMpleados[i].NombreEmpleado+" - "+ _AuxEMpleados[i].Puesto+"</p>"; 
                }
                lblDocDel.Text += "Si continua, el departamento asignado cambiara a uno general.</br> Desea continuar?";
            }
            else
            {
                lblDocDel.Text = "Esta por eliminar el siguiente departamento:";
                lblDptoPuesto.Text = gvDepartamentos.Rows[rowIndex].Cells[1].Text;
                lblTipo.Text = lblTabla.Text;
                pAlertaModal.Visible = true;
                btnAceptarModal.Visible = false;
                btnBorrarModal.Visible = true;
            }
            lblData.Text = gvDepartamentos.Rows[rowIndex].Cells[0].Text;
            ModalPopupExtender1.Show();
            
        }

        protected void BindDataDpto(string valor)
        {
            Departamentos = new MetodosDepartamentos();
            DataTable dt = Departamentos.ObtenerDepartamentos(valor);
            gvDepartamentos.DataSource = dt;
            gvDepartamentos.DataBind();

            lblTotalDpto.Text = "Total de registros: " + dt.Rows.Count;
        }
        protected void BindDataPuesto(string valor)
        {
            Puestos = new MetodosPuestos();
            DataTable dtP = Puestos.ObtenerPuestos(valor);
            gvPuestos.DataSource = dtP;
            gvPuestos.DataBind();
            lblTotalPuesto.Text = "Total de registros: "+dtP.Rows.Count;
        }

        protected void btnRegistrarDpto_Click(object sender, EventArgs e)
        {
            //Ejecuto el constructor para ejecutar el metodo de registro
            Departamentos = new MetodosDepartamentos(txtDpto.Text,txtIDdpto.Text);
            PAlerta.Visible = true;

            lblResult.Text = Departamentos.RegistrarDepartamento();
            
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
            
            Departamentos = new MetodosDepartamentos(txtDpto.Text, txtIDdpto.Text);
            lblResult.Text = Departamentos.EditarDepartamento();
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
            Departamentos = new MetodosDepartamentos();
            DataTable dt = Departamentos.ObtenerDepartamentos("");
            cbDepartamento.DataSource = dt;
            cbDepartamento.DataTextField = "Nombre";
            cbDepartamento.DataValueField = "ID_Departamento";
            cbDepartamento.DataBind();
        }

        protected void btnRegistrarPuesto_Click(object sender, EventArgs e)
        {
            Puestos = new MetodosPuestos(txtPuestosID.Text, txtPuestosDescripcion.Text, cbDepartamento.SelectedValue);
            PAlertaPuesto.Visible = true;
            lblPuestoAlert.Text = Puestos.RegistrarPuesto();

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
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            Puestos = new MetodosPuestos(gvPuestos.Rows[rowIndex].Cells[0].Text, "","");
            
            pAlertaModal.Visible = false;
            txtPD.Text = "";
            lblTabla.Text = "puesto";
            btnCloseModal.Text = "Cancelar";
            btnAceptarModal.Visible = true;
            lblHeader.Text = "<i class=\"fa-solid fa-triangle-exclamation\"></i> Advertencia";

            lblTipo.Text = "puesto";
            lblData.Text = gvPuestos.Rows[rowIndex].Cells[0].Text;
            NombreDP.Value = gvPuestos.Rows[rowIndex].Cells[1].Text;

            List<ListaEmpleados> prevencion = Puestos.PrevencionPuesto();
            if (prevencion.Count > 0)
            {               
                lblDocDel.Text = "Los siguientes empleado cuentan tienen el puesto de <strong>"+ gvPuestos.Rows[rowIndex].Cells[1].Text + "</strong> que formata parte del " +
                    "<br/> ";
                for (int i = 0; i < prevencion.Count; i++)
                {
                    lblDocDel.Text += prevencion[i].NoEmpleado + "-" + prevencion[i].NombreEmpleado+"<br/>";
                }
                lblDocDel.Text += "<br/> El puesto asignado cambiara a uno general. Desea continuar?";
            }
            else
            {
                lblDocDel.Text = "Esta por eliminar el siguiente puesto:";
                lblDptoPuesto.Text = gvPuestos.Rows[rowIndex].Cells[1].Text;

                pAlertaModal.Visible = true;


                btnAceptarModal.Visible = false;
                btnBorrarModal.Visible = true;
            }
            ModalPopupExtender1.Show();
            
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
            Puestos = new MetodosPuestos(txtPuestosID.Text, txtPuestosDescripcion.Text, cbDepartamento.SelectedValue);
            lblPuestoAlert.Text = Puestos.EditarPuesto();
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
            DataView sortedView = new DataView(clsHerramientas.ProcedimientoAlmacenado("Master_Division", parametros))
            {
                Sort = e.SortExpression + " " + sortingDirection
            };
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
            
            btnAceptarModal.Visible = false;

                pAlertaModal.Visible = false;

                if (lblTabla.Text == "departamento")
                {
                    lblDocDel.Text = "Esta por eliminar el siguiente departamento:";
                    lblDptoPuesto.Text = NombreDP.Value;
                    lblTipo.Text = lblTabla.Text;
                    btnBorrarModal.Visible = true;
                    pAlertaModal.Visible = true;
                    /*
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
                        
                        
                        lblHeader.Text = "<i class=\"fa-solid fa-circle-info\"></i> Informacion";
                        lblDocDel.Text = tupla.Item2;
                        btnCloseModal.Text = "Ok";
                        btnAceptarModal.Visible = false;

                        BindDataDpto("");
                        BindDataPuesto("");
                        llenarCombo();

                    }
                    */
                }
                //================ Acciones con la tabla de puesto===============================================
                else if (lblTabla.Text == "puesto")
                {
                /*
                    //=====================Pregunto si tiene este puesto esta relacionado con un empleado ====================
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
                        // =============Eliminacion del puesto si no tiene empleados ===========================================
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
                    */
                lblDocDel.Text = "Esta por eliminar el siguiente puesto:";
                lblDptoPuesto.Text = NombreDP.Value;
                lblTipo.Text = lblTabla.Text;
                btnBorrarModal.Visible = true;
                pAlertaModal.Visible = true;
                } 
        }

        protected void btnBorrarModal_Click(object sender, EventArgs e)
        {
            string ResultadoAccion;

            if(lblDptoPuesto.Text == txtPD.Text) {
                pAlertaModal.Visible = false;
                if (lblTabla.Text == "departamento") { 
                Departamentos = new MetodosDepartamentos("",lblData.Text);

                //Lleno la lista con los empleados del departamento
                _AuxEMpleados = Departamentos.PrevencionDepartamento();
                
                if (_AuxEMpleados.Count > 0)
                {
                    ResultadoAccion = Departamentos.CambiarGenerico(_AuxEMpleados);
                    if (!ResultadoAccion.Contains("Error"))
                    {
                        lblHeader.Text = "<i class=\"fa-solid fa-check\"></i> Exito";
                    }
                    else
                    {
                        lblHeader.Text = "<i class=\"fa-solid fa-x\"></i> Error";
                    }
                    lblDocDel.Text = ResultadoAccion+"</br>";
                }
                else {
                    lblDocDel.Text = Departamentos.EliminarDepartamento(lblData.Text);
                }
                }
                else
                {

                    Puestos = new MetodosPuestos(lblData.Text,"","");
                    _AuxEMpleados = Puestos.PrevencionPuesto();
                    if (_AuxEMpleados.Count > 0)
                    {
                        ResultadoAccion = Puestos.CambiarGenerico(_AuxEMpleados);
                        if (!ResultadoAccion.Contains("Error"))
                        {
                            lblHeader.Text = "<i class=\"fa-solid fa-check\"></i> Exito";
                        }
                        else
                        {
                            lblHeader.Text = "<i class=\"fa-solid fa-x\"></i> Error";
                        }
                        lblDocDel.Text = ResultadoAccion + "</br>";
                    }
                    else
                    {
                        //borrar si no hay lista
                        lblDocDel.Text = Puestos.EliminarPuesto(lblData.Text);
                    }
                    //ResultadoAccion = Puestos.CambiarGenerico()
                }
                //Limpiar modal
                btnBorrarModal.Visible = false;
                btnCloseModal.Text = "Ok";
                

            }
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            BindDataDpto("");
            BindDataPuesto("");
        }
    }
}