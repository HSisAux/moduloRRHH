<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="lista.aspx.cs" Inherits="moduloRRHH.lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .dropdown-item:hover, .dropdown-item:focus {
            color: #211B00 !important;
            background-color: #FFE24D !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background: #E1E2EC; border-radius: 13px;" class="row p-4 mt-2">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="row row-cols-auto d-flex justify-content-around" style="background: #335CA8; padding: 10px;">
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
                                            <a class="dropdown-item" href="#">4 Matildes</a>
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#">Hungaros</a>
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#">Jamamadi</a>
                                        </li>
                                    </ul>
                                </li>
                                <li class="dropend">
                                    <a href="#" class="dropdown-item dropdown-toggle" data-bs-toggle="dropdown">Status </a>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <a class="dropdown-item" href="#">Activo</a>
                                        </li>
                                        <li>
                                            <a class="dropdown-item" href="#">Inactivo</a>
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

        <div class="mt-3 overflow-auto p-0">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="ID_compania">
                        <AlternatingItemTemplate>
                            <tr style="background-color: #D1D1D1; font-size: 12px;">
                                <td>
                                    <asp:Label Text='<%# Eval("ID_compania") %>' runat="server" ID="ID_companiaLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Nombre_comp") %>' runat="server" ID="Nombre_compLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Nombre_comercial") %>' runat="server" ID="Nombre_comercialLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Tipo_persona") %>' runat="server" ID="Tipo_personaLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("RFC") %>' runat="server" ID="RFCLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("CURP") %>' runat="server" ID="CURPLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("tiempo_negocio") %>' runat="server" ID="tiempo_negocioLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Direccion") %>' runat="server" ID="DireccionLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("codigo_postal") %>' runat="server" ID="codigo_postalLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Pais") %>' runat="server" ID="PaisLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Estado") %>' runat="server" ID="EstadoLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Ciudad") %>' runat="server" ID="CiudadLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Fecha_registro") %>' runat="server" ID="Fecha_registroLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Estatus") %>' runat="server" ID="EstatusLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("ID_user") %>' runat="server" ID="ID_userLabel" /></td>
                            </tr>
                        </AlternatingItemTemplate>

                        <EmptyDataTemplate>
                            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                <tr>
                                    <td>No se han devuelto datos.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <tr style="background-color: #FFFFFF; color: #000000; font-size: 12px;">
                                <td>
                                    <asp:Label Text='<%# Eval("ID_compania") %>' runat="server" ID="ID_companiaLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Nombre_comp") %>' runat="server" ID="Nombre_compLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Nombre_comercial") %>' runat="server" ID="Nombre_comercialLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Tipo_persona") %>' runat="server" ID="Tipo_personaLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("RFC") %>' runat="server" ID="RFCLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("CURP") %>' runat="server" ID="CURPLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("tiempo_negocio") %>' runat="server" ID="tiempo_negocioLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Direccion") %>' runat="server" ID="DireccionLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("codigo_postal") %>' runat="server" ID="codigo_postalLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Pais") %>' runat="server" ID="PaisLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Estado") %>' runat="server" ID="EstadoLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Ciudad") %>' runat="server" ID="CiudadLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Fecha_registro") %>' runat="server" ID="Fecha_registroLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("Estatus") %>' runat="server" ID="EstatusLabel" /></td>
                                <td>
                                    <asp:Label Text='<%# Eval("ID_user") %>' runat="server" ID="ID_userLabel" /></td>
                            </tr>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table runat="server" style="text-align: center">
                                <tr runat="server">
                                    <td runat="server">
                                        <table runat="server" cellspacing="5" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                            <tr runat="server" style="background-color: #335CA8; color: #FFFFFF; height: 60px; font-size: 11px;">
                                                <th runat="server">ID_compania</th>
                                                <th runat="server">Nombre_comp</th>
                                                <th runat="server">Nombre_comercial</th>
                                                <th runat="server">Tipo_persona</th>
                                                <th runat="server">RFC</th>
                                                <th runat="server">CURP</th>
                                                <th runat="server">tiempo_negocio</th>
                                                <th runat="server">Direccion</th>
                                                <th runat="server">codigo_postal</th>
                                                <th runat="server">Pais</th>
                                                <th runat="server">Estado</th>
                                                <th runat="server">Ciudad</th>
                                                <th runat="server">Fecha_registro</th>
                                                <th runat="server">Estatus</th>
                                                <th runat="server">ID_user</th>
                                            </tr>
                                            <tr runat="server" id="itemPlaceholder"></tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" style="text-align: center; color: #000000;">
                                        <section class="m-3">
                                            <asp:DataPager runat="server" PageSize="6" ID="DataPager1" PagedControlID="ListView1">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonCssClass="btn btn-sm btn-primary primario" PreviousPageText="&lt;i class=&quot;fa-solid fa-chevron-left&quot;&gt;&lt;/i&gt;" NextPageText="&lt;i class=&quot;fa-solid fa-chevron-right&quot;&gt;&lt;/i&gt;" />
                                                    <asp:NumericPagerField ButtonType="Link" NumericButtonCssClass="btn btn-sm btn-primary primario" CurrentPageLabelCssClass="btn btn-sm btn-warning sobre-secundario" NextPreviousButtonCssClass="btn btn-sm btn-primary primario" NextPageText="&lt;i class=&quot;fa-solid fa-angles-right&quot;&gt;&lt;/i&gt;" PreviousPageText="&lt;i class=&quot;fa-solid fa-angles-left&quot;&gt;&lt;/i&gt;"></asp:NumericPagerField>
                                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-sm btn-primary primario" ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" NextPageText="&lt;i class=&quot;fa-solid fa-chevron-right&quot;&gt;&lt;/i&gt;" PreviousPageText="&lt;i class=&quot;fa-solid fa-chevron-left&quot;&gt;&lt;/i&gt;" />

                                                </Fields>
                                            </asp:DataPager>
                                        </section>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:clientes_hungarosConnectionString %>' ProviderName='<%$ ConnectionStrings:clientes_hungarosConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [Table_compania]"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

    <script>
        $('#btnEmpleados').addClass('seleccionado');

    </script>
</asp:Content>
