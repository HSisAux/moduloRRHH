<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="lista.aspx.cs" Inherits="moduloRRHH.lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background: #E1E2EC; border-radius: 13px;" class="row pt-3 mt-2">
        <div class="col">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="row row-cols-auto d-flex " style="background: #335CA8; padding: 10px; margin: 0.6px;">
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
                    <div class="col">
                        <div class="dropdown containerH">
                            <button class="form-control dropdown-toggle" type="button" id="dropdownMenuButton"
                                data-bs-toggle="dropdown" data-bs-auto-close="outside" aria-expanded="false">
                                Filtrar por...
                            </button>
                            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                <li class="dropend">
                                    <a href="#" class="dropdown-item dropdown-toggle" data-bs-toggle="dropdown">Empresa </a>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton ID="btn4M" CssClass="dropdown-item" runat="server">4 Matildes</asp:LinkButton>

                                        </li>
                                        <li>
                                            <asp:LinkButton ID="btnHungaros" CssClass="dropdown-item" runat="server">Hungaros</asp:LinkButton>

                                        </li>
                                        <li>
                                            <asp:LinkButton ID="btnJamamadi" CssClass="dropdown-item" runat="server">Jamamadi</asp:LinkButton>

                                        </li>
                                    </ul>
                                </li>
                                <li class="dropend">
                                    <a href="#" class="dropdown-item dropdown-toggle" data-bs-toggle="dropdown">Status </a>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton ID="btnActivo" CssClass="dropdown-item" runat="server">Activo</asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="btnInactivo" CssClass="dropdown-item" runat="server">Inactivo</asp:LinkButton>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col">
                        <div class="containerH">
                            <div class="input-group">
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" Placeholder="Buscar..."></asp:TextBox>
                                <asp:LinkButton ID="btnBusqueda" CssClass="btn text-center btn-secondary" data-accion="buscar" runat="server"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>

                            </div>
                        </div>
                    </div>
                    <div class="col d-flex justify-content-center">
                        <section class="containerH" style="width: fit-content;">
                            <asp:LinkButton ID="lbNuevoRegistro" runat="server" CssClass="btn btn-secondary" PostBackUrl="~/empleados/crud.aspx"><i class="fa-solid fa-user-plus"></i></asp:LinkButton>
                        </section>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UPEmpleados" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvEmpleados" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                    AllowPaging="true" AllowSorting="true" 
                    Width="100%" CssClass="text-center table table-hover mt-2 align-middle" OnPageIndexChanging="gvEmpleados_PageIndexChanging" PagerStyle-CssClass="pagination-ys" runat="server">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="no_empleado" HeaderText="No. Empleado" SortExpression="no_empleado"></asp:BoundField>
                        <asp:TemplateField HeaderText="Foto">
                            <ItemTemplate>
                                <img src="<%# Eval("foto") %>" alt="fot de empleado" style="width:60px; height:60px; border-radius:50px;"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre(s)" SortExpression="Nombre"></asp:BoundField>
                        <asp:BoundField DataField="Apellido_P" HeaderText="A.P." SortExpression="Apellido_P"></asp:BoundField>
                        <asp:BoundField DataField="Apellido_M" HeaderText="A.M." SortExpression="Apellido_M"></asp:BoundField>
                        <asp:BoundField DataField="Fecha_ingreso" HeaderText="Fecha de ingreso" SortExpression="Fecha_ingreso"></asp:BoundField>
                        <asp:BoundField DataField="Puesto" HeaderText="Puesto"></asp:BoundField>
                        <asp:BoundField HeaderText="Empresa" DataField="Empresa" SortExpression="Empresa"></asp:BoundField>
                        <%--<asp:BoundField HeaderText="Estado" DataField="Status" SortExpression="Status"></asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Estatus" SortExpression="Status">
                            <ItemTemplate>
                            <label class="estado <%# Eval("Status").Equals(false)?"inactivo":"" %>" ><%# Eval("Status").Equals(true)?"Activo":"Inactivo" %></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Accion">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnMas" CssClass="btn btn-sm btn-primary" ToolTip="Ver detalles" OnClick="btnMas_Click" runat="server"><i class="fa-solid fa-magnifying-glass-plus"></i></asp:LinkButton>
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
                            <asp:Literal ID="Literal2" runat="server" Text="No se encontraron empleados"></asp:Literal>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
            </div>
    </div>
    <script>
        $('#btnEmpleados').addClass('seleccionado');

    </script>
</asp:Content>
