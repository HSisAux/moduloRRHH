<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="detalles.aspx.cs" Inherits="moduloRRHH.detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/dropzone.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="infoEmpleado" class="row">
        <section class="col-auto d-flex flex-column align-items-center p-3 m-3" style="background: #E1E2EC; border-radius: 13px;">
            <asp:Image ID="imgEmpresa" runat="server" AlternateText="hungaros" ImageUrl="~/Assets/img/hungaros.png" Width="184px" />
            <asp:Image ID="imgEmpleado" runat="server" AlternateText="foto del empleado" ImageUrl="~/Assets/img/tomholland.jpg" CssClass="foto-empleado" />

            <asp:Label Text="Nombre" ForeColor="#8f9099" CssClass="align-self-start mt-1" Font-Size="14px" runat="server" />
            <asp:Label ID="lblNombres" runat="server" Text="Peter Benjamin" Font-Bold="true" Font-Size="18px" CssClass="mt-2"></asp:Label>
            <asp:Label ID="lblApellido" runat="server" Text="Parker" Font-Bold="true" Font-Size="16px"></asp:Label>
            <asp:Label Text="Puesto" ForeColor="#8f9099" CssClass="align-self-start mt-1" Font-Size="14px" runat="server" />
            <asp:Label ID="lblPuesto" Text="Novio de Melissa" Font-Size="16px" runat="server" />
            <asp:Label Text="Estado" ForeColor="#8f9099" CssClass="align-self-start mt-1" Font-Size="14px" runat="server" />
            <asp:Label ID="lblStatus" Text="activo" CssClass="estado" runat="server" />
        </section>
        <section class="col-auto p-4 m-3" style="background: #E1E2EC; border-radius: 13px;">
            <div class="row" id="Puestoinfo">
                <div class="col-md">
                    <asp:Label ID="lblNoEmp" runat="server" Text="No. de empleado" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtNoEmpleado" CssClass="form-control" />
                </div>
                <div class="col-md">
                    <asp:Label ID="lblFechaIngreso" runat="server" Text="Fecha de ingreso" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtFechaIngeso" TextMode="Date" CssClass="form-control" />
                </div>

                <div class="col-md">
                    <asp:Label ID="lblSalario" runat="server" Text="Salario" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtSalario" TextMode="Password" CssClass="form-control" />
                </div>
            </div>
            <hr />
            <div class="row">
                <section class="col-md-4">
                    <asp:Label ID="lblRFC" runat="server" Text="RFC" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtRFC" CssClass="form-control" />
                </section>
                <section class="col-md-4">
                    <asp:Label ID="lblNSS" runat="server" Text="NSS" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtNSS" CssClass="form-control" />
                </section>
                <section class="col-md-4">
                    <asp:Label ID="lblFechaNac" runat="server" Text="Fecha de nacimiento" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtFechaNac" TextMode="Date" CssClass="form-control" />
                </section>
            </div>
            <div class="row">
                <section class="col-md-6">
                    <asp:Label ID="lblFracc" runat="server" Text="Fraccionamiento" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtFracc" CssClass="form-control" />
                </section>
                <section class="col-md-6">
                    <asp:Label ID="lblCalle" runat="server" Text="Calle y numero" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtCalle" CssClass="form-control" />
                </section>
            </div>
            <div class="row">
                <section class="col-md-4">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtEstado" CssClass="form-control" />
                </section>
                <section class="col-md-4">
                    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtCiudad" CssClass="form-control" />
                </section>
                <section class="col-md-4">
                    <asp:Label ID="lblCP" runat="server" Text="Codigo postal" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtCP" CssClass="form-control" />
                </section>
            </div>
            <div class="row">
                <section class="col-md-6">
                    <asp:Label ID="lblTel" runat="server" Text="Telefono" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtTelefono" CssClass="form-control" />
                </section>
                <section class="col-md-6">
                    <asp:Label ID="lblCorreo" runat="server" Text="Correo" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtCorreo" CssClass="form-control" />
                </section>
            </div>
            <div class="row">
                <section class="col-md-6">
                    <asp:Label ID="lblNombreEmergencia" runat="server" Text="En caso de emergencia a llamar a" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtContactoEmrgecia" CssClass="form-control" />
                </section>
                <section class="col-md-6">
                    <asp:Label ID="lblTelEmergencia" runat="server" Text="Telefono de emergencia" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtTelEmergencia" CssClass="form-control" />
                </section>

            </div>
            <hr />
            <div class="d-flex justify-content-end gap-2">
                <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-sm btn-warning text-white" OnClick="btnEditar_Click">Editar<i class="fa-solid fa-pencil ms-1"></i></asp:LinkButton>
                <asp:LinkButton ID="btnCambioEstado" OnClick="btnCambioEstado_Click" runat="server" CssClass="btn btn-sm btn-outline-danger">Baja temporal <i class="fa-solid fa-ban ms-1"></i></asp:LinkButton>
            </div>
        </section>
    </div>

    <div class="row my-2" id="Documentos">
        <div class="col-12">
            <!--=================== TEST ===================================================== -->
            <asp:GridView ID="gvTest" runat="server"
                CssClass="table table-responsive table-striped table-hover text-center"
                OnRowDataBound="gvTest_RowDataBound" AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Documento" HeaderText="Documento" SortExpression="Documento"></asp:BoundField>
                    <asp:CheckBoxField DataField="requerido" HeaderText="Requerido" ReadOnly="True" ></asp:CheckBoxField>
                    <asp:BoundField DataField="fecha_registro" HeaderText="Fecha de registro"></asp:BoundField>
                    <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento"></asp:BoundField>
                    <asp:BoundField DataField="detalles" HeaderText="Estado"></asp:BoundField>
                    <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                            <asp:HyperLink ID="subir" CssClass="btn btn-sm btn-warning text-white" data-bs-toggle="modal" data-bs-target="#exampleModal" runat="server"><i class="fa-solid fa-arrow-up-from-bracket"></i></asp:HyperLink>
                            <asp:HyperLink ID="ver" runat="server" CssClass="btn btn-sm btn-secondary"><i class="fa-solid fa-eye"></i></asp:HyperLink>
                            <asp:HyperLink ID="historial" data-bs-toggle="modal" data-bs-target="#HistorialModal" data-bs-document="Documento 4" runat="server" CssClass="btn btn-sm text-white" BackColor="#7D5D2B"><i class="fa-solid fa-clock-rotate-left"></i></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


    </div>

    <!-- Modal -->
    <asp:SqlDataSource runat="server" ID="SqlDataSource1"></asp:SqlDataSource>
    <div class="modal fade" id="exampleModal" tabindex="-1" data-bs-backdrop="static" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title fs-5" id="exampleModalLabel">Subir archivo</h3>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="contenedor-zone">
                        <div class="header-section">
                            <p>Solo se admiten archivos PDF</p>
                        </div>
                        <div class="drop-section">
                            <div class="col">
                                <div class="icono">
                                    <i class="fa-solid fa-cloud-arrow-up nube"></i>
                                </div>
                                <span>Arrastra y suelta un archivo</span>
                                <span>o</span>
                                <button type="button" class="file-selector shadow btn btn-primary btn-sm">Selecciona un archivo</button>
                                <input type="file" class="file-selector-input" name="name" value="" id="fileup" />

                            </div>
                            <div class="col dropped">
                                <div class="drop-here">Suelta aqui</div>
                            </div>
                            <div class="col preview ">
                                <iframe id="ifile" class="holds-the-iframe" width="100%" style="height: 255px;"></iframe>
                                <br />

                            </div>
                        </div>
                        <div id="archivoDetalle" class="d-flex align-content-between mt-3" style="gap: 5px;">
                            <div class="info align-content-end">
                                <i class="fa-solid fa-file-pdf" style="transform: translateY(6px);"></i>
                                <i class="fa-solid fa-minus" style="transform: translateY(6px);"></i>
                                <section class="masinfo">
                                    <label id="lblNombre" style="transform: translateY(-4px);">Sin archivo seleccionado</label>
                                </section>

                            </div>
                            <button class="btn btn-secondary btn-sm" type="button" id="btnCancelar" style="display: none;" title="Cancelar">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                        <div id="pgrs" style="display: none;" class="mt-1">
                            <div class="progress" role="progressbar" style="height: 24px;" aria-label="Warning example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                                <div class="progress-bar text-bg-success" id="barrita" style="width: 0%"></div>
                            </div>
                        </div>
                        <div class="list-section">
                            <section class="list-title">Archivo cargado</section>
                            <div class="list">
                                <ul style="text-decoration: none;">

                                    <li class="in-prog" hidden>
                                        <div class="col">
                                            <img src="assets/Pdf-2127829.png" width="100%" />
                                        </div>
                                        <div class="col">
                                            <div class="file-name">
                                                <div class="name">FileName</div>
                                                <span>50%</span>
                                            </div>
                                            <div class="file-progress">
                                                <span></span>
                                            </div>
                                            <div class="file-size">2.2 MB</div>
                                        </div>
                                        <div class="col">
                                            <svg xmlns="http://www.w3.org/2000/svg" class="cross" height="20" width="20">
                                                <path d="m5.979 14.917-.854-.896 4-4.021-4-4.062.854-.896 4.042 4.062 4-4.062.854.896-4 4.062 4 4.021-.854.896-4-4.063Z" />
                                            </svg>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="tick" height="20" width="20">
                                                <path d="m8.229 14.438-3.896-3.917 1.438-1.438 2.458 2.459 6-6L15.667 7Z"></path>
                                            </svg>

                                        </div>

                                    </li>
                                </ul>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary btn-sm" style="display: none;" id="btnUpload">Subir archivo</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Model de historial -->
    <div class="modal fade" id="HistorialModal" tabindex="-1" aria-labelledby="HistorialModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="HistorialModalLabel">New message</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="recipient-name" class="col-form-label">Recipient:</label>
                        <input type="text" class="form-control" id="recipient-name">
                    </div>
                    <div class="mb-3">
                        <label for="message-text" class="col-form-label">Message:</label>
                        <textarea class="form-control" id="message-text"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Send message</button>
                </div>
            </div>
        </div>
    </div>


    <script src="assets/dropzone.js"></script>
    <script src="assets/JSDetalles.js"></script>
    <footer class="d-flex position-fixed bottom-0 ">
        <asp:HyperLink ID="btnBack" CssClass="btn btn-secondary" NavigateUrl="~/empleados/lista.aspx" runat="server">Regresar<i class="fa-solid fa-angle-left ms-3"></i></asp:HyperLink>
    </footer>
</asp:Content>
