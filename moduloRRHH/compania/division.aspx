<%@ Page Title="division" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="division.aspx.cs" MetaDescription="Muestra la seccion de departamentos y de puestos" Inherits="moduloRRHH.compania.division" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
         function hideModal() {
            $find('<%= ModalPopupExtender1.ClientID %>').hide();
            return false;
        }
    </script>
    <style>
        tbody {
            background: white;
        }


        #MainContent_cbDepartamento_cbDepartamento_OptionList {
            top: 0 !important;
            left: 0 !important;
            position: relative !important;
            max-height: 100px !important;
            overflow: auto !important;
        }

        .ajax__combobox_textboxcontainer, .ajax__combobox_buttoncontainer {
            background: #DFE0FF;
            border: 1px transparent solid;
        }

        .ajax__combobox_inputcontainer .ajax__combobox_textboxcontainer input {
            display: block;
            width: 100%;
            padding: 0.375rem 0.75rem;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #dee2e6;
            appearance: none;
            border-radius: 0.375rem;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }

            .ajax__combobox_inputcontainer .ajax__combobox_textboxcontainer input:focus {
                color: #212529;
                background-color: #fff;
                border-color: #ffc107;
                outline: 0;
                box-shadow: 0 0 0 0.25rem rgba(255, 218, 29, 0.55);
            }

        .ajax__combobox_inputcontainer .ajax__combobox_buttoncontainer button {
            /*Secundario*/
            padding: 0.375rem 0.75rem;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            border: 1px #6c757d solid;
            border-radius: 0.375rem;
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.15), 0 1px 1px rgba(0, 0, 0, 0.075);
            opacity: 0.65;
            display: inline-block;
            color: #fff;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            cursor: pointer;
            user-select: none;
            background-color: #6c757d;
            transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }

            .ajax__combobox_inputcontainer .ajax__combobox_buttoncontainer button:hover {
                background-color: #5c636a;
                border-color: #565e64;
            }

        .hiddencol {
            display: none;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">

        <div class="col-md-3" style="height: 100vh;">
            <div style="background: #335CA8; color: #ffff; border-top-left-radius: 4px; border-top-right-radius: 4px;" class=" p-2">
                <asp:Label ID="lblsubtitulo" runat="server" Text="Registrando departamento"></asp:Label>
            </div>
            <section style="color: #001A43; background: #DFE0FF; border-radius: 4px; padding: 12px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblRowIndexDpto" runat="server" Text="" Visible="false"></asp:Label>
                                <label for="txtIDdpto" class="form-label">ID:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtIDdpto" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ForeColor="red" ValidationGroup="dpto" runat="server" ControlToValidate="txtIDdpto" ErrorMessage="*Ingrese un ID"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label for="txtDpto" class="form-label">Departamento:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtDpto" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ValidationGroup="dpto" ForeColor="Red" runat="server" ControlToValidate="txtIDdpto" ErrorMessage="*Ingrese el nombre del departamento."></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col">
                                <asp:Button ID="btnRegistrarDpto" ValidationGroup="dpto" CssClass="btn btn-sm btn-success" OnClick="btnRegistrarDpto_Click" runat="server" Text="Registar" />
                                <asp:LinkButton ID="btnAceptarDpto" OnClick="btnAceptarDpto_Click" CssClass="btn btn-sm btn-success" Visible="false" runat="server"><i class="fa-solid fa-check"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnCancelarDpto" OnClick="btnCancelarDpto_Click" CssClass="btn btn-sm btn-danger ms-1" Visible="false" Style="width: 30.25px;" runat="server"><i class="fa-solid fa-x"></i></asp:LinkButton>
                            </div>
                        </div>
                        <div class="row mt-1 p-1">
                            <asp:Panel ID="PAlerta" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissible fade show" role="alert">
                                <asp:Label ID="lblResult" runat="server" Text="asdfg"></asp:Label>
                                <asp:Button ID="btnCloseAlert" CausesValidation="false" OnClick="btnCloseAlert_Click"
                                    runat="server" Text="" CssClass="btn-close mt-1" data-bs-dismiss="alert" aria-label="Close" />
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>

        </div>
        <div class="col-md-9">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row row d-flex mb-3" style="background: #335CA8; padding: 10px; margin: 0;">
                            <div class="col">
                                <div class="containerH" style="height: 48px;">
                                    <label>Mostrar</label>
                                    <asp:DropDownList ID="ddRegistros" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddRegistros_SelectedIndexChanged">
                                        <asp:ListItem Text="6" Value="6" />
                                        <asp:ListItem Text="12" Value="12" />
                                        <asp:ListItem Text="24" Value="24" />
                                        <asp:ListItem Text="50" Value="50" />
                                        <asp:ListItem Text="100" Value="100" />
                                    </asp:DropDownList>
                                    <label>registros</label>
                                </div>
                            </div>
                            <div class="col"></div>
                            <div class="col">
                                <div class="containerH">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBusqueda" CausesValidation="false" runat="server" CssClass="form-control" Placeholder="Buscar..."></asp:TextBox>
                                        <asp:LinkButton ID="btnBusqueda" OnClick="btnBusqueda_Click" CausesValidation="false" CssClass="btn text-center btn-secondary" data-accion="buscar" runat="server"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>

                                    </div>
                                </div>
                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">
                <div class="col">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvDepartamentos" runat="server" AutoGenerateColumns="false"
                                AllowPaging="true" AllowSorting="true" OnSorting="gvDepartamentos_Sorting"
                                Width="100%" ShowHeaderWhenEmpty="true"
                                CssClass="text-center table table-hover" OnPageIndexChanging="gvDepartamentos_PageIndexChanging"
                                PagerStyle-CssClass="pagination-ys" PageSize="6">

                                <Columns>
                                    <asp:BoundField DataField="ID_Departamento" HeaderText="ID" ReadOnly="True" SortExpression="ID_Departamento"></asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Departamento" SortExpression="Nombre"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Accion">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditarDpto" CausesValidation="false" runat="server" OnClick="btnEditarDpto_Click" CssClass="btn btn-sm btn-warning text-white"><i class="fa-solid fa-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="btnBorrarDpto" CausesValidation="false" runat="server" OnClick="btnBorrarDpto_Click" CssClass="btn btn-sm btn-danger"><i class="fa-solid fa-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="3"
                                    FirstPageText='<i class="fa-solid fa-angles-left"></i>'
                                    LastPageText='<i class="fa-solid fa-angles-right"></i>'
                                    NextPageText='<i class="fa-solid fa-chevron-right"></i>'
                                    PreviousPageText='<i class="fa-solid fa-chevron-left"></i>' />
                                <EmptyDataTemplate>
                                    <div class="d-flex justify-content-center">
                                        <asp:Literal ID="Literal2" runat="server" Text="No se encontraron departamentos"></asp:Literal>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Label ID="lblTotalDpto" runat="server" Text=""></asp:Label>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!-- ///////////////////////////////////////////////  PUESTOS  //////////////////////////////////////// -->
    <div id="Puestos"></div>
    <div class="row mt-3">

        <div style="height: 35px; color: white; border-radius: 8px; background: #1D3B71; min-width: 222px;" class="ps-2 p-1 mb-2">
            <asp:Label ID="lblPaginaTitulo2" Text="Puestos" Style="font-weight: 500; font-size: 18px;" runat="server" />
        </div>
        <div class="col-md-3">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div style="background: #335CA8; color: #ffff; border-top-left-radius: 4px; border-top-right-radius: 4px;" class=" p-2">
                        <asp:Label ID="lblSubPuesto" runat="server" Text="Registrando puesto"></asp:Label>
                    </div>
                    <section style="color: #001A43; background: #DFE0FF; border-radius: 4px; padding: 12px;">

                        <div class="row">
                            <div class="col">
                                <label for="txtPuestosID" class="form-label">ID:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ValidationGroup="valPuesto" ID="txtPuestosID" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="txtPuestosID" ValidationGroup="valPuesto"  runat="server" ForeColor="Red" ErrorMessage="*Ingrese un ID"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div>
                                    <label for="cbDepartamento" class="form-label">Departamento:</label>
                                    <cc1:ComboBox ID="cbDepartamento" AutoPostBack="true" AutoCompleteMode="SuggestAppend" runat="server"></cc1:ComboBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="cbDepartamento" ErrorMessage="*Seleccione un deprtamento"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label for="txtPuestosDescripcion" class="form-label">Puesto:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ValidationGroup="valPuesto"  ID="txtPuestosDescripcion" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ControlToValidate="txtPuestosDescripcion" ValidationGroup="valPuesto"  ForeColor="Red" runat="server" ErrorMessage="*Ingrese el puesto"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="row mt-1 p-1">
                            <asp:Panel ID="PAlertaPuesto" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissible fade show" role="alert">
                                <asp:Label ID="lblPuestoAlert" runat="server" Text="asdfg"></asp:Label>
                                <asp:Button ID="btnPuestoAlert" CausesValidation="false" OnClick="btnPuestoAlert_Click"
                                    runat="server" Text="" CssClass="btn-close mt-1" data-bs-dismiss="alert" aria-label="Close" />
                            </asp:Panel>
                        </div>
                        <div class="row mt-3">
                            <div class="col d-flex align-content-center">
                                <asp:Button ID="btnRegistrarPuesto" OnClick="btnRegistrarPuesto_Click" ValidationGroup="valPuesto" CssClass="btn btn-sm btn-success" runat="server" Text="Registrar" />
                                <asp:LinkButton ID="btnAceptarPuesto" ToolTip="Guardar cambios" OnClick="btnAceptarPuesto_Click" CssClass="btn btn-sm btn-success" Visible="false" runat="server"><i class="fa-solid fa-check"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnCancelarPuesto" ToolTip="Cancelar cambios" OnClick="btnCancelarPuesto_Click" CssClass="btn btn-sm btn-danger ms-1" Visible="false" Style="width: 30.25px;" runat="server"><i class="fa-solid fa-x"></i></asp:LinkButton>
                            </div>
                        </div>

                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-9" style="height: 100vh;">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row row d-flex mb-3" style="background: #335CA8; padding: 10px; margin: 0;">
                            <div class="col">
                                <div class="containerH" style="height: 48px;">
                                    <label>Mostrar</label>
                                    <asp:DropDownList ID="ddPuestoCant" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddPuestoCant_SelectedIndexChanged">
                                        <asp:ListItem Text="6" Value="6" />
                                        <asp:ListItem Text="12" Value="12" />
                                        <asp:ListItem Text="24" Value="24" />
                                        <asp:ListItem Text="50" Value="50" />
                                        <asp:ListItem Text="100" Value="100" />
                                    </asp:DropDownList>
                                    <label>registros</label>
                                </div>
                            </div>
                            <div class="col"></div>
                            <div class="col">
                                <div class="containerH">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearchPuesto" runat="server" CssClass="form-control" Placeholder="Buscar..."></asp:TextBox>
                                        <asp:LinkButton ID="btnSearchPuesto" OnClick="btnSearchPuesto_Click" CssClass="btn text-center btn-secondary" CausesValidation="false" data-accion="buscar" runat="server"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="col">
                            <asp:GridView ID="gvPuestos" runat="server" AutoGenerateColumns="false"
                                AllowPaging="true" AllowSorting="true" OnSorting="gvPuestos_Sorting"
                                ShowHeaderWhenEmpty="true" Width="100%"
                                CssClass="text-center table table-hover" OnPageIndexChanging="gvPuestos_PageIndexChanging"
                                PagerStyle-CssClass="pagination-ys" PageSize="6">

                                <Columns>
                                    <asp:BoundField DataField="ID_puesto" HeaderText="ID" SortExpression="ID_puesto"></asp:BoundField>
                                    <asp:BoundField DataField="Puesto" HeaderText="Puesto" SortExpression="Puesto"></asp:BoundField>
                                    <asp:BoundField HeaderText="Departamento" DataField="Nombre" SortExpression="Nombre"></asp:BoundField>
                                    <asp:BoundField HeaderText="ID_Departamento" DataField="ID_Departamento" SortExpression="ID_Departamento">
                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Accion">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditarPuesto" ToolTip="Editar" CausesValidation="false" runat="server" OnClick="btnEditarPuesto_Click" CssClass="btn btn-sm btn-warning text-white"><i class="fa-solid fa-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="btnBorrarPuesto" ToolTip="Eliminar" CausesValidation="false" runat="server" OnClick="btnBorrarPuesto_Click" CssClass="btn btn-sm btn-danger"><i class="fa-solid fa-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="1"
                                    FirstPageText='<i class="fa-solid fa-angles-left"></i>'
                                    LastPageText='<i class="fa-solid fa-angles-right"></i>'
                                    NextPageText='<i class="fa-solid fa-chevron-right"></i>'
                                    PreviousPageText='<i class="fa-solid fa-chevron-left"></i>' />
                                <EmptyDataTemplate>
                                    <div class="d-flex justify-content-center">
                                        <asp:Literal ID="Literal2" runat="server" Text="No se encontraron puestos"></asp:Literal>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Label ID="lblTotalPuesto" runat="server" Text=""></asp:Label>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>


    </div>
    <!--///////////////////////////////////////////////// MODAL ///////////////////////////////////////////////// -->
     <asp:Button ID="btnShowModal" runat="server" Text="mostrar modal"  />
    <asp:Panel ID="pnlModal" CssClass="modalPopup" Style="display: none; color: black;" runat="server">
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
                <div class="modalContent">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">
                                <asp:Label ID="lblHeader" runat="server" Text="Modal header"></asp:Label>
                            </h5>
                            <button type="button" class="btn-close" onclick="return hideModal();"></button>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblTabla" hidden runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblData" hidden runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblDocDel" runat="server" Text="Label"></asp:Label>                
                            
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAceptarModal"  CssClass="btn btn-sm btn-primary" OnClick="btnAceptarModal_Click" runat="server" Text="Si" />
                            <asp:Button ID="btnCloseModal"  class="btn btn-sm btn-secondary" OnClientClick="return hideModal();" runat="server" Text="Cancelar" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="modalBackground" PopupControlID="pnlModal" runat="server" TargetControlID="btnShowModal">
       <%-- <Animations>              
                <OnShown><Fadein Duration="0.1" /></OnShown>
                <OnHiding><Fadeout Duration="0.1" /></OnHiding>
        </Animations>--%>
    </cc1:ModalPopupExtender>


</asp:Content>
