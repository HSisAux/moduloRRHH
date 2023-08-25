<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="moduloRRHH.documentos.crud" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
         function hideModal() {
            $find('<%= ModalPopupExtender1.ClientID %>').hide();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div style="background: #335CA8; color: #ffff; border-top-left-radius: 4px; border-top-right-radius: 4px;" class=" p-2">
                <asp:Label ID="lblSubPuesto" runat="server" Text="Registrando documento"></asp:Label>
            </div>
            <section style="color: #001A43; background: #DFE0FF; border-radius: 4px; padding: 12px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblRowIndex" runat="server" Text="" Visible="false"></asp:Label>
                                <label for="txtRfc" class="form-label">ID:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtDocID" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label for="txtRfc" class="form-label">Nombre:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label for="txtRfc" class="form-label">Tipo de expiracion:</label>
                                <asp:DropDownList ID="ddVencimiento" CssClass="form-select" runat="server">
                                    <asp:ListItem Text="cada 6 meses" Value="2" />
                                    <asp:ListItem Text="cada 3 meses" Value="3" />
                                    <asp:ListItem Text="cada 1 año" Value="4" />
                                    <asp:ListItem Text="por fecha" Value="1" />
                                    <asp:ListItem Text="No expira" Value="0" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col">
                                <div class="chbox">
                                    <label>
                                        <asp:CheckBox ID="chRequerido" runat="server" />
                                        Requerido
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col d-flex align-content-center">
                                <asp:Button ID="btnRegistrarDoc" CssClass="btn btn-sm btn-success" runat="server" Text="Registrar" OnClick="btnRegistrarDoc_Click" />
                                <asp:LinkButton ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-sm btn-success" Visible="false" runat="server"><i class="fa-solid fa-check"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-sm btn-danger ms-1" Visible="false" Style="width: 30.25px;" runat="server"><i class="fa-solid fa-x"></i></asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Panel ID="PAlerta" runat="server" Visible="false" CssClass="alert alert-info alert-dismissible fade show" role="alert">
                                <asp:Label ID="lblResult" runat="server" Text="asdfg"></asp:Label>
                                <asp:Button ID="btnCloseAlert" OnClick="btnCloseAlert_Click" runat="server" Text="" CssClass="btn-close" data-bs-dismiss="alert" aria-label="Close" />
                                <%--<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>--%>
                            </asp:Panel>
                            
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>
        <div class="col-md-9">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row row d-flex mb-3" style="background: #335CA8; padding: 10px; margin: 0;">
                            <div class="col">
                                <div class="containerH" style="height: 48px;">
                                    <label>Mostrar</label>
                                    <asp:DropDownList ID="ddCantidad" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddCantidad_SelectedIndexChanged">
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
                            <div class="col-auto">
                                <div class="containerH">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscar" runat="server" OnTextChanged="txtBuscar_TextChanged" CssClass="form-control" Placeholder="Buscar..."></asp:TextBox>
                                        <asp:LinkButton ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn text-center btn-secondary" data-accion="buscar" runat="server"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>

                                    </div>
                                     <asp:LinkButton ID="btnRefresh" OnClick="btnRefresh_Click" CssClass="btn btn-secondary" runat="server"><i class="fa-solid fa-arrows-rotate"></i></asp:LinkButton>
                                </div>
                               
                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">
                <div class="col">
                    <asp:UpdatePanel ID="UPTable" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" AllowSorting="True" OnRowDataBound="gvDocumentos_RowDataBound"
                                ShowHeaderWhenEmpty="True" Width="100%" CssClass="text-center table table-hover"
                                OnPageIndexChanging="gvDocumentos_PageIndexChanging" PagerStyle-CssClass="pagination-ys"
                                PageSize="6">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID"></asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre"></asp:BoundField>
                                    <asp:BoundField DataField="expiracion" HeaderText="Expiracion" SortExpression="expiracion"></asp:BoundField>
                                    <asp:BoundField DataField="requerido" HeaderText="Requerido" SortExpression="requerido"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Accion">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click" CssClass="btn btn-sm btn-warning text-white"><i class="fa-solid fa-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="btnBorrar" runat="server" OnClick="btnBorrar_Click" CssClass="btn btn-sm btn-danger"><i class="fa-solid fa-trash"></i></asp:LinkButton>
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
                                        <asp:Literal ID="Literal2" runat="server" Text="No hay documentos registrados"></asp:Literal>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btnShowModal" runat="server" Text="mostrar modal" hidden />
    <asp:Panel ID="pnlModal" CssClass="modalPopup" Style="display: none; color: black;" runat="server">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                            <asp:Label ID="lblData" hidden runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblDocDel" runat="server" Text="Label"></asp:Label>                
                            
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAceptarModal" OnClick="btnAceptarModal_Click" CssClass="btn btn-sm btn-primary" runat="server" Text="Si" />
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
