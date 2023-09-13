<%@ Page Title="salarios" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="salario.aspx.cs" Inherits="moduloRRHH.salario.salario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pAlert" Visible="false" CssClass="alert alert-primary alert-dismissible fade show" runat="server">
                        <asp:Literal ID="lMensaje" runat="server" Text="Holis :D"></asp:Literal>
                        <asp:Button ID="btnDismiss" runat="server" Text="" CssClass="btn-close m-3" OnClick="btnDismiss_Click" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div style="background: #335CA8; color: #ffff; border-top-left-radius: 4px; border-top-right-radius: 4px;" class=" p-2">
                <asp:Label ID="lblsubtitulo" runat="server" Text="Registrando salario"></asp:Label>
            </div>
            <section style="color: #001A43; background: #DFE0FF; border-radius: 4px; padding: 12px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div class="row">
                            <div class="col">
                                <asp:HiddenField ID="hfNoEmpleado" runat="server" />

                                <asp:Label ID="lblNoEmpleado" CssClass="form-label" runat="server" Text="No.Empleado" for="txtNoEmpleadob"></asp:Label>
                                <asp:TextBox ID="txtNoEmpleado" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNoEmpleado_TextChanged" ClientIDMode="Static" runat="server"></asp:TextBox>
                                <asp:Label ID="lblNoexiste" runat="server" Text="No existe el empleado" Visible="false" CssClass="text-bg-danger"></asp:Label>

                                <label for="txtEmpleado" class="form-label">Empleado</label>
                                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" autocomplete="off" ID="txtEmpleado" />


                                <asp:TextBox ID="txtMLLV" runat="server" ClientIDMode="Static" list="dlNombres"></asp:TextBox>
                                <datalist id="dlNombres">
                                    <option value="Chocolate"></option>
                                </datalist>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label for="txtSalario" class="form-label">Salario:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtSalario" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    ValidationExpression="^\d{1,3}(,?\d{3})*(\.\d+)?$" Display="Dynamic" runat="server" ControlToValidate="txtSalario"
                                    ErrorMessage="*Solo se permiten numeros, comas y puntos " ForeColor="#cc0000"></asp:RegularExpressionValidator>
                                <asp:HiddenField ID="hfSalarioAnterior" runat="server" />
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col">
                                <asp:LinkButton ID="btnEditar" Visible="false" CssClass="btn btn-success btn-sm" OnClick="btnEditar_Click" runat="server" ToolTip="Editar"><i class="fa-solid fa-check"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnCancelar" Visible="false" CssClass="btn btn-danger btn-sm" OnClick="btnCancelar_Click" runat="server" ToolTip="Cancelar"><i class="fa-solid fa-x"></i></asp:LinkButton>
                                <asp:Button ID="btnRegistrarSalario" OnClick="btnRegistrarSalario_Click" CssClass="btn btn-sm btn-success" runat="server" Text="Registar" />
                            </div>
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
                                        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" Placeholder="Buscar empleado"></asp:TextBox>
                                        <asp:LinkButton ID="btnBusqueda" OnClick="btnBusqueda_Click" CssClass="btn text-center btn-secondary" data-accion="buscar" runat="server"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">
                <div class="col">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvSalarios" AutoGenerateColumns="false" Width="100%"
                                OnRowDataBound="gvSalarios_RowDataBound" AllowPaging="true" AllowSorting="true" OnSorting="gvSalarios_Sorting"
                                PageSize="12" OnPageIndexChanging="gvSalarios_PageIndexChanging" PagerStyle-CssClass="pagination-ys"
                                ShowHeaderWhenEmpty="true" CssClass="table table-hover table-hover table-sm align-middle text-center" runat="server" Caption="Registros">
                                <Columns>
                                    <asp:BoundField DataField="no_empleado" HeaderText="# Empleado" ReadOnly="True" SortExpression="no_empleado"></asp:BoundField>
                                    <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" SortExpression="NombreCompleto"></asp:BoundField>
                                    <asp:BoundField DataField="Empresa" HeaderText="Empresa/Nomina" SortExpression="Empresa"></asp:BoundField>
                                    <asp:BoundField DataField="salario_actual" HeaderText="Salario actual" SortExpression="salario_actual"></asp:BoundField>
                                    <asp:BoundField DataField="salario_anterior" HeaderText="Salario anterior" SortExpression="salario_anterior"></asp:BoundField>
                                    <asp:BoundField DataField="Fecha_cambio" HeaderText="Fecha de cambio" SortExpression="Fecha_cambio"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Accion">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditarPuesto" ToolTip="Editar" OnClick="btnEditarPuesto_Click" CausesValidation="false" runat="server" CssClass="btn btn-sm btn-warning text-white"><i class="fa-solid fa-pencil"></i></asp:LinkButton>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentScript" runat="server">
    <script src="SalarioJS.js"></script>
</asp:Content>
