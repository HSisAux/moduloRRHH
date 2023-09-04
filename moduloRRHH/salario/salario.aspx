<%@ Page Title="salarios" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="salario.aspx.cs" Inherits="moduloRRHH.salario.salario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div style="background:#335CA8; color:#ffff; border-top-left-radius:4px; border-top-right-radius:4px;" class=" p-2">
                    <asp:Label ID="lblsubtitulo" runat="server" Text="Registrando salario"></asp:Label>
                </div>
            <section style="color: #001A43; background: #DFE0FF; border-radius: 4px; padding: 12px;">
                
                <div class="row">
                    <div class="col">
                        <label for="txtEmpleado" class="form-label">Empleado</label>
                        <asp:HiddenField ID="hfNoEmpleado" runat="server" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmpleado" list="Empleados_list" />
                        <datalist id="Empleados_list">
                            <option value="0" >Melissa</option>
                            <option value="1">Hector</option>
                            <option value="2">Nancy</option>
                            <option value="3">Miguel</option>
                            <option value="4">Alan</option>
                            <option value="5">Cesar</option>
                            <option value="6">Paulina</option>
                            <option value="7">Marcela</option>
                            <option value="8">Jose Luis</option>
                        </datalist>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <label for="txtSalario" class="form-label">Salario:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtSalario" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            ValidationExpression="^\d{1,3}(,\d{3})*(\.\d+)?$" runat="server" ControlToValidate="txtSalario"
                            ErrorMessage="tas mal compa" BackColor="Red" ForeColor="White"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col">
                        <asp:Button ID="btnRegistrarSalario" CssClass="btn btn-sm btn-success" runat="server" Text="Registar" />
                    </div>
                </div>
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
                                        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" Placeholder="Buscar..."></asp:TextBox>
                                        <asp:LinkButton ID="btnBusqueda" CssClass="btn text-center btn-secondary" data-accion="buscar" runat="server"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>

                                    </div>
                                </div>
                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">
                <div class="col">
                    <table class="table text-center">
                        <thead class="table-header">
                            <tr>
                                <th># Empleado</th>
                                <th>Nombre</th>
                                <th>Empresa/nomina</th>
                                <th>Salario actual</th>
                                <th>Salario anterior</th>
                                <th>Fecha de cambio</th>
                                <th>Accion</th>
                            </tr>
                        </thead>
                        <tr>
                            <td>a</td>
                            <td>b</td>
                            <td>c</td>
                            <td>d</td>
                            <td>e</td>
                            <td>f</td>
                            <td>
                                <button type="button" class="btn btn-sm btn-warning text-white"><i class="fa-solid fa-pencil"></i></button>
                                <button type="button" class="btn btn-sm btn-danger"><i class="fa-solid fa-trash"></i></button>
                            </td>

                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
