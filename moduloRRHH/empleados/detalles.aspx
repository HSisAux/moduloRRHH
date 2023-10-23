<%@ Page Title="Empleado" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="detalles.aspx.cs" Inherits="moduloRRHH.detalles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/dropzone.css" rel="stylesheet" />
    <script>

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="infoEmpleado" class="row">
        <section class="col-auto d-flex flex-column align-items-center p-3 m-3" style="background: #E1E2EC; border-radius: 13px;">
            <asp:Image ID="imgEmpresa" runat="server" ClientIDMode="Static" AlternateText="Hungaros" ImageUrl="~/Assets/img/hungaros.png" Width="184px" />
            <asp:Image ID="imgEmpleado" runat="server" AlternateText="foto del empleado" ImageUrl="~/Assets/img/tomholland.jpg" CssClass="foto-empleado" />

            <asp:Label Text="Nombre" ForeColor="#8f9099" CssClass="align-self-start mt-1" Font-Size="14px" runat="server" />
            <asp:Label ID="lblNombres" ClientIDMode="Static" runat="server" Text="Peter Benjamin" Font-Bold="true" Font-Size="18px" CssClass="mt-2"></asp:Label>
            <asp:Label ID="lblApellido" ClientIDMode="Static" runat="server" Text="Parker" Font-Bold="true" Font-Size="16px"></asp:Label>
            <asp:Label Text="Puesto" ForeColor="#8f9099" CssClass="align-self-start mt-1" Font-Size="14px" runat="server" />
            <asp:Label ID="lblPuesto" Text="Novio de Melissa" Font-Size="16px" runat="server" />
            <asp:Label Text="Estado" ForeColor="#8f9099" CssClass="align-self-start mt-1" Font-Size="14px" runat="server" />
            <asp:Label ID="lblStatus" Text="activo" CssClass="estado" runat="server" />
        </section>
        <section class="col-auto p-4 m-3" style="background: #E1E2EC; border-radius: 13px;">
            <div class="row" id="Puestoinfo">
                <div class="col-md">
                    <asp:Label ID="lblNoEmp" runat="server" Text="No. de empleado" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ClientIDMode="Static" ReadOnly="true" ID="txtNoEmpleado" CssClass="form-control" />
                </div>
                <div class="col-md">
                    <asp:Label ID="lblFechaIngreso" runat="server" Text="Fecha de ingreso" CssClass="form-label"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="txtFechaIngeso" TextMode="Date" CssClass="form-control" />
                </div>

                <div class="col-md">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblSalario" runat="server" Text="Salario" CssClass="form-label"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="true" ID="txtSalario" TextMode="Password" CssClass="form-control" />
                            <asp:CheckBox ID="chSHowHide" Text="Mostrar" AutoPostBack="true" OnCheckedChanged="chSHowHide_CheckedChanged" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:HiddenField ID="hfExpiracion" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hfDocumento" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hfAccion" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hfDocumentacionID" ClientIDMode="Static" runat="server" />
                    </div>
                    <!--=================== TEST ===================================================== -->
                    <asp:GridView ID="gvTest" runat="server" AllowPaging="true"
                        PagerStyle-CssClass="pagination-ys" PageSize="4"
                        CssClass="table table-responsive table-striped table-hover text-center"
                        OnRowDataBound="gvTest_RowDataBound" AutoGenerateColumns="false" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Documento" HeaderText="Documento" SortExpression="Documento"></asp:BoundField>
                            <asp:CheckBoxField DataField="requerido" HeaderText="Requerido" ReadOnly="True"></asp:CheckBoxField>
                            <asp:BoundField DataField="fecha_registro" HeaderText="Fecha de registro"></asp:BoundField>
                            <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento"></asp:BoundField>
                            <asp:BoundField DataField="detalles" HeaderText="Estado"></asp:BoundField>
                            <asp:BoundField DataField="docid" HeaderText="docid">
                                <HeaderStyle CssClass="visually-hidden" />
                                <ItemStyle CssClass="visually-hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="expiracion" HeaderText="expiracion">
                                 <HeaderStyle CssClass="visually-hidden" />
                                <ItemStyle CssClass="visually-hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ID_Documentacion" HeaderText="documentoid">
                                <HeaderStyle CssClass="visually-hidden" />
                                <ItemStyle CssClass="visually-hidden" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <div class="d-flex gap-1 ">
                                        <div>
                                            <asp:LinkButton ID="btnSubir" data-accion="subir" ToolTip="Subir archivo" OnClick="SubirEditar_Click" CssClass="btn btn-success btn-sm" runat="server"><i class="fa-solid fa-upload"></i></asp:LinkButton>
                                        </div>
                                        <asp:Panel ID="PanelOpciones" runat="server" CssClass="dropdown">

                                            <button class="btn btn-sm btn-light" type="button" data-bs-toggle="dropdown" title="Más acciones" aria-expanded="false">
                                                <i class="fa-solid fa-ellipsis-vertical"></i>
                                            </button>
                                            <ul class="dropdown-menu dropdown-menu-sm-start">
                                                <li>
                                                    <asp:LinkButton ID="btnPrint" OnClick="LinkButton2_Click" CssClass="dropdown-item" runat="server"><i class="fa-solid fa-print"></i> Imprimir</asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="btnHistorial" OnClick="btnHistorial_Click" CssClass="dropdown-item" runat="server"><i class="fa-solid fa-clock-rotate-left"></i> Ver historial</asp:LinkButton>
                                                <li>
                                                    <asp:LinkButton ID="btnVer" CssClass="dropdown-item" runat="server"><i class="fa-solid fa-eye"></i> Abrir</asp:LinkButton>
                                                </li>
                                                <li id="btnAccioones" class="bg-primary">
                                                    <asp:LinkButton ID="btnAceptar" CssClass="dropdown-item text-white" data-action="aceptar" OnClick="btnAceptar_Click" runat="server"><i class="fa-solid fa-check me-1"></i>Aceptar</asp:LinkButton>
                                                </li>
                                            </ul>
                                        </asp:Panel>
                                    </div>
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
                                <asp:Literal ID="Literal2" runat="server" Text="No se encontraron cambios"></asp:Literal>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>


    </div>

    <!-- Modal -->
    <asp:SqlDataSource runat="server" ID="SqlDataSource1"></asp:SqlDataSource>
    <div class="modal fade" id="exampleModal" tabindex="-1" data-bs-backdrop="static" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
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
    <!--===================================== Modal ajax ============================================-->
    <asp:Button ID="btnShowModal" runat="server" Text="mostrar modal" CssClass="visually-hidden" />
    <asp:Panel ID="pnlModal" CssClass="modalPopup" Style="display: none; color: black; overflow: auto;" runat="server">

        <div class="modal-content" style="margin: auto; width: 40%; min-width: 400px;">
            <div class="modal-header">
                <h3 class="modal-title fs-5" id="exampleModalLabel">Subir archivo</h3>
                <button type="button" class="btn-close" onclick="return hideModal();" <%--data-bs-dismiss="modal" aria-label="Close"--%>></button>
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
                            <input type="file" class="file-selector-input" name="name" value="" accept=".pdf" id="fileup" />

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
                        <%-- <section class="list-title">Archivo cargado</section>
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
                        </div>--%>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="panelFecha" runat="server">
                                <div>
                                    <br />
                                    <asp:Label ID="lblFecha" runat="server" Text="El documento que se esta pidiendo tiene fecha de vencimiento. Seleccionala a continuacion:"></asp:Label>
                                    <input type="date" id="dateFecha" class="form-control m-auto" />
                                    <%--<asp:TextBox ID="dateFecha" ClientIDMode="Static" Width="50%"  CssClass="form-control m-auto" runat="server" TextMode="Date"></asp:TextBox>--%>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
            <div class="modal-footer">
                <button type="button" onclick="return hideModal();" class="btn btn-secondary btn-sm" <%-- data-bs-dismiss="modal"--%>>Cerrar</button>
                <button type="button" class="btn btn-primary btn-sm" style="display: none;" id="btnUpload">Subir archivo</button>
            </div>
        </div>

    </asp:Panel>

    <cc1:ModalPopupExtender ID="ModalPopupExtender1" ClientIDMode="Static" BackgroundCssClass="modalBackground" PopupControlID="pnlModal" runat="server" TargetControlID="btnShowModal">
    </cc1:ModalPopupExtender>
    <!--===================================== Modal ajax ============================================-->
    <!-- ======================= MODAL historial =========================== -->
    <asp:Button ID="btnShowHistorial" runat="server" Text="mostrar modal" CssClass="btn visually-hidden" />
    <asp:Panel ID="pnlModalHistory" CssClass="modalPopup" Style="display: none; color: black; overflow: auto;" runat="server">

        <div class="modal-content" style="margin: auto; width: 40%; min-width: 400px;">
            <div class="modal-header">
                <h3 class="modal-title fs-5" id="ModalLabel">Historial</h3>
                <button type="button" class="btn-close" onclick="return OcultarModal();"></button>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDocHistorial" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:GridView ID="gvHistory" CssClass="table table-responsive table-striped table-hover text-center" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:BoundField DataField="Fecha_cambio" HeaderText="Fecha de cambio"></asp:BoundField>
                                <asp:BoundField DataField="accion" HeaderText="Cambio"></asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="modificado por"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div class="modal-footer">
                <button type="button" onclick="return OcultarModal();" class="btn btn-secondary btn-sm" <%-- data-bs-dismiss="modal"--%>>Cerrar</button>
                <%--<button type="button" class="btn btn-primary btn-sm" style="display: none;" id="btnUpload">Subir archivo</button>--%>
            </div>
        </div>

    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalHistorial" ClientIDMode="Static" BackgroundCssClass="modalBackground" PopupControlID="pnlModalHistory" runat="server" TargetControlID="btnShowHistorial"></cc1:ModalPopupExtender>
    <!-- ======================= MODAL historial =========================== -->


    <script src="assets/dropzone.js"></script>
    <script src="assets/JSDetalles.js"></script>
    <footer class="d-flex position-fixed bottom-0 ">
        <asp:HyperLink ID="btnBack" CssClass="btn btn-secondary" NavigateUrl="~/empleados/lista.aspx" runat="server">Regresar<i class="fa-solid fa-angle-left ms-3"></i></asp:HyperLink>
    </footer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentScript" runat="server">
    <script>
        function Imprimir(link) {
            printJS(link);
        }
    </script>
</asp:Content>

