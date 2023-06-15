<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="detalles.aspx.cs" Inherits="moduloRRHH.detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="infoEmpleado" class="row">
        <section class="col-md-3 d-flex flex-column align-items-center p-3 m-3" style="background: #D8E2FF; border-radius: 13px;">
            <asp:Image ID="imgEmpresa" runat="server" AlternateText="hungaros" ImageUrl="~/Assets/img/hungaros.png" Width="184px" />
            <asp:Image ID="imgEmpleado" runat="server" AlternateText="foto del empleado" ImageUrl="~/Assets/img/tomholland.jpg" CssClass="foto-empleado" />
            <asp:Label ID="lblNombres" runat="server" Text="Peter Benjamin" Font-Bold="true" Font-Size="18px" CssClass="mt-2"></asp:Label>
            <asp:Label ID="lblApellido" runat="server" Text="Parker" Font-Bold="true" Font-Size="16px"></asp:Label>
            <asp:Label Text="Novio de Melissa" ID="lblPuesto" Font-Size="16px" runat="server" CssClass="mt-2" />
            <asp:Label Text="activo" CssClass="estado mt-4" runat="server" />
        </section>
        <section class="col-md-8 p-4 m-3" style="background: #D8E2FF; border-radius: 13px;">
            <div class="row" id="Puestoinfo">
                <div class="col">
                    <asp:Label ID="lblNoEmp" runat="server" Text="No. de empleado" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNoEmpleado" CssClass="form-control" TextMode="Password" />
                </div>
                <div class="col">
                    <asp:Label ID="lblFechaIngreso" runat="server" Text="Fecha de ingreso" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtFechaIngeso" CssClass="form-control" />
                </div>

                <div class="col">
                    <asp:Label ID="lblSalario" runat="server" Text="Salario" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtSalario" TextMode="Password" CssClass="form-control" />
                </div>
            </div>
            <hr />
            <div class="row">
                <section class="col-md-6">
                    <asp:Label ID="lblRFC" runat="server" Text="RFC" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="RFC" CssClass="form-control" />
                </section>
                <section class="col-md-6">
                    <asp:Label ID="lblFechaNac" runat="server" Text="Fecha de nacimiento" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtFechaNac" CssClass="form-control" />
                </section>
            </div>
            <div class="row">
                <section class="col-md-6">
                    <asp:Label ID="lblFracc" runat="server" Text="Fraccionamiento" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtFracc" CssClass="form-control" />
                </section>
                <section class="col-md-6">
                    <asp:Label ID="lblCalle" runat="server" Text="Calle" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCalle" CssClass="form-control" />
                </section>
            </div>
            <div class="row">
                <section class="col-md-4">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEstado" CssClass="form-control" />
                </section>
                <section class="col-md-4">
                    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" />
                </section>
                <section class="col-md-4">
                    <asp:Label ID="lblCP" runat="server" Text="Codigo postal" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" />
                </section>
            </div>
            <div class="row">
                <section class="col-md-4">
                    <asp:Label ID="lblTel" runat="server" Text="Telefono" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
                </section>
                <section class="col-md-4">
                    <asp:Label ID="lblTelEmergencia" runat="server" Text="Telefono de emergencia" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtTelEmergencia" CssClass="form-control" />
                </section>
                <section class="col-md-4">
                    <asp:Label ID="lblCorreo" runat="server" Text="Correo" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control" />
                </section>
            </div>
            <hr  />
            <div class="d-flex justify-content-end gap-2">
                <asp:HyperLink ID="btnEditar" runat="server" CssClass="btn btn-sm btn-warning text-white">Editar <i class="fa-solid fa-pencil ms-1"></i></asp:HyperLink>
                <asp:HyperLink ID="btnBajaTemporal" runat="server" CssClass="btn btn-sm btn-outline-secondary">Baja temporal <i class="fa-solid fa-ban ms-1"></i></asp:HyperLink>
            </div>
        </section>
    </div>

    <div class="row my-2" id="Documentos">
        <div class="col-12">
            <table class="table table-responsive table-striped table-hover text-center">
                <thead style="color:white; background:#1D3B71; font-size:11px; font-weight:bold; line-height:4;">
                    <th>Documento</th>
                    <th>Fecha de subida</th>
                    <th>Vencimiento</th>
                    <th>Status</th>
                    <th>Accion</th>
                </thead>
                <tbody>
                    <tr>
                        <td>Documento 1</td>
                        <td>29/10/2011</td>
                        <td> --/--/----</td>
                        <td>
                            <label class="estado">entregado</label>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlUpload" CssClass="btn btn-sm btn-warning text-white" runat="server"><i class="fa-solid fa-arrow-up-from-bracket"></i></asp:HyperLink>
                            <asp:HyperLink ID="hlView" runat="server" CssClass="btn btn-sm btn-secondary"><i class="fa-solid fa-eye"></i></asp:HyperLink>
                            <asp:HyperLink ID="hlHistorial" runat="server" CssClass="btn btn-sm btn-historial text-white" ><i class="fa-solid fa-clock-rotate-left"></i></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>Documento 2</td>
                        <td>29/10/2011</td>
                        <td> --/--/----</td>
                        <td>
                            <label class="estado">entregado</label>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-sm btn-warning text-white" runat="server"><i class="fa-solid fa-arrow-up-from-bracket"></i></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-sm btn-secondary"><i class="fa-solid fa-eye"></i></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm text-white" BackColor="#7D5D2B"><i class="fa-solid fa-clock-rotate-left"></i></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>Documento 3</td>
                        <td>29/10/2011</td>
                        <td> --/--/----</td>
                        <td>
                            <label class="estado">entregado</label>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink4" CssClass="btn btn-sm btn-warning text-white" runat="server"><i class="fa-solid fa-arrow-up-from-bracket"></i></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="btn btn-sm btn-secondary"><i class="fa-solid fa-eye"></i></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink6" runat="server" CssClass="btn btn-sm text-white" BackColor="#7D5D2B"><i class="fa-solid fa-clock-rotate-left"></i></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>Documento 4</td>
                        <td>29/10/2011</td>
                        <td> --/--/----</td>
                        <td>
                            <label class="estado">entregado</label>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink7" CssClass="btn btn-sm btn-warning text-white" runat="server"><i class="fa-solid fa-arrow-up-from-bracket"></i></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink8" runat="server" CssClass="btn btn-sm btn-secondary"><i class="fa-solid fa-eye"></i></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink9" runat="server" CssClass="btn btn-sm text-white" BackColor="#7D5D2B"><i class="fa-solid fa-clock-rotate-left"></i></asp:HyperLink>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    
    <footer class="d-flex position-fixed bottom-0 ">
        <asp:HyperLink ID="btnBack" CssClass="btn btn-secondary" NavigateUrl="~/empleados/lista.aspx" runat="server">Regresar<i class="fa-solid fa-angle-left ms-3"></i></asp:HyperLink>
    </footer>
</asp:Content>
