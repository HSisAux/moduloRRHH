<%@ Page Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="moduloRRHH.empleados.crud" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row p-4 mt-2" style="background: #E1E2EC; color: #001A43; border-radius: 14px;">
        <section class="col-md-3 mt-2">
            <div class="d-flex flex-column align-items-center">
                <label id="lblfoto" class="form-label">Seleccionar foto</label>
                <asp:Panel ID="imgEmpl" runat="server" BackImageUrl="~/Assets/img/default-user.png" Width="134px" Height="134px" CssClass="foto-empleado edicion mb-3"></asp:Panel>
                <asp:FileUpload ID="FUfoto" onchange="ShowPreview(this);" accept=".png, .jpg, .jpeg" CssClass="form-control" runat="server" />
                <asp:LinkButton ID="btnSubirImagen" Visible="false" CssClass="btn btn-primary btn-sm" runat="server" CausesValidation="false" OnClick="btnSubirImagen_Click">Cambiar foto <i class="fa-solid fa-upload"></i></asp:LinkButton>
            </div>
        </section>


        <section class="col-md-9">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="d-flex flex-row align-items-center justify-content-center align-content-center">
                        <hr style="width: 35%;" />
                        <p class="fw-bold m-2">Datos personales</p>
                        <hr style="width: 35%;" />
                    </div>
                    <div class="row">
                        <div class="col-md">
                            <label for="txtNombre" class="form-label">*Nombre(s):</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" MaxLength="30" />
                            <asp:RequiredFieldValidator ID="rvNombre" ControlToValidate="txtNombre" Display="Dynamic" runat="server" ForeColor="#cc0000" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Ingrese nombre(s) del empleado"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <section class="col-md">
                            <label for="txtApellidoP" class="form-label">*Apellido paterno:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoP" MaxLength="20" />
                            <asp:RequiredFieldValidator ID="rvApellidoP" ControlToValidate="txtApellidoP" runat="server" ForeColor="#cc0000" Display="Dynamic" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i>Ingrese un apellido paterno"></asp:RequiredFieldValidator>

                        </section>
                        <section class="col-md">
                            <label for="txtApellidoM" class="form-label">*Apellido materno:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoM" MaxLength="20" />
                            <asp:RequiredFieldValidator ID="rvApellidoM" ControlToValidate="txtApellidoM" runat="server" ForeColor="#cc0000" Display="Dynamic" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Ingrese un apellido materno"></asp:RequiredFieldValidator>
                        </section>
                    </div>
                    <div class="row">
                        <section class="col-md">
                            <label for="txtFechaNac" class="form-label">*Fecha de nacimiento:</label>
                            <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtFechaNac" />
                            <asp:RequiredFieldValidator ID="rvFechaNac" ControlToValidate="txtFechaNac" runat="server" Display="Dynamic" ForeColor="#cc0000" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Seleccione una fecha"></asp:RequiredFieldValidator>

                        </section>
                        <section class="col-md">
                            <label for="txtRfc" class="form-label">*RFC:</label>
                            <asp:TextBox runat="server" CssClass="form-control text-uppercase" ID="txtRfc" />
                            <asp:RequiredFieldValidator ID="rvRFC" ControlToValidate="txtRfc" runat="server" ForeColor="#cc0000" Display="Dynamic" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Ingrese el RFC"></asp:RequiredFieldValidator>
                        </section>
                        <section class="col-md">
                            <label for="txtCP" class="form-label">*NSS:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNSS" />
                            <asp:RequiredFieldValidator ID="rvNSS" Display="Dynamic" ControlToValidate="txtNSS" runat="server" ForeColor="#cc0000" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Ingrese el NSS"></asp:RequiredFieldValidator>
                        </section>
                    </div>
                    <div class="row">
                        <section class="col-md">
                            <label for="txtcolonia" class="form-label">Fraccionamiento:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtcolonia" />
                        </section>
                        <section class="col-md">
                            <label for="txtCalle" class="form-label">Calle:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCalle" />
                        </section>
                    </div>
                    <div class="row">
                        <section class="col-md">
                            <label for="txtCiudad" class="form-label">Ciudad:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCiudad" />
                        </section>
                        <section class="col-md">
                            <label for="txtEstado" class="form-label">Estado:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEstado" />
                        </section>
                        <section class="col-md">
                            <label for="txtCP" class="form-label">CP:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCP" />
                        </section>
                    </div>
                    <div class="row">
                        <section class="col-md">
                            <label for="txtTelefono" class="form-label">*Telefono:</label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Phone" ID="txtTelefono" />
                            <asp:RequiredFieldValidator ID="rvTel" ControlToValidate="txtTelefono" Display="Dynamic" ForeColor="#cc0000" runat="server" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Ingrese un numero de telefono"></asp:RequiredFieldValidator>
                        </section>

                        <section class="col-md">
                            <label for="txtCorreo" class="form-label">Correo:</label>
                            <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="txtCorreo" />
                        </section>
                    </div>
                    <div class="row mt-1">
                        <section class="col-md">
                            <label for="txtContactoEmergencia" class="form-label">En caso de emergencia llamar a:</label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Phone" ID="txtContactoEmergencia" />
                        </section>
                        <section class="col-md">
                            <label for="txtTelEmergencia" class="form-label">Telefono de contacto de emergencia:</label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="Phone" ID="txtTelEmergencia" />
                        </section>
                    </div>

                    <div class="d-flex flex-row align-items-center justify-content-center mt-3">
                        <hr style="width: 38%;" />
                        <p class="m-2 fw-bold">Datos del empleado</p>
                        <hr style="width: 38%;" />
                    </div>
                    <div class="row">
                        <section class="col-md">
                            <asp:Label ID="lblEmpresa" runat="server" Text="Empresa" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddEmpresa" CssClass="form-select" Width="30%" runat="server">
                                <asp:ListItem Text="4 Matildes" Value="3" />
                                <asp:ListItem Text="Hungaros" Value="1" />
                                <asp:ListItem Text="Jamamadi" Value="2" />
                            </asp:DropDownList>
                        </section>
                        <section class="row">
                            <section class="col-md">
                                <label for="txtNoEmpleado" class="form-label">*Numero de empleado:</label>
                                <asp:TextBox runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtNoEmpleado_TextChanged" ID="txtNoEmpleado" />
                                <asp:Label ID="lblYaexiste" runat="server" CssClass="text-danger" Visible="false" Text=""></asp:Label>
                                <asp:RequiredFieldValidator ID="rvNoEmpleado" ControlToValidate="txtNoEmpleado" Display="Dynamic" runat="server" ForeColor="#cc0000" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Asigne el numero de empleado"></asp:RequiredFieldValidator>
                            </section>
                            <section class="col-md">
                                <label for="txtFehcaIngreso" class="form-label">*Fecha de ingreso:</label>
                                <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" ID="txtFechaIngreso" />
                                <asp:RequiredFieldValidator ID="rvFechaIngreso" Display="Dynamic" runat="server" ControlToValidate="txtFechaIngreso" ForeColor="#cc0000" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Seleccione la fecha de ingreso"></asp:RequiredFieldValidator>
                            </section>
                        </section>
                        <section class="row">
                            <section class="col-md">
                                <label for="txtDpto" class="form-label">*Departamento:</label>
                                <asp:DropDownList ID="ddDepartamento" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddDepartamento_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Text="--Seleccionar departamento" Value="0" />
                                </asp:DropDownList>
                                <asp:Label ID="lblNoHayPuestos" runat="server" ForeColor="#cc0000" Visible="false" Text="<i class='fa-solid fa-circle-xmark'></i> Este departamento no tiene puestos regstrados"></asp:Label>
                                <asp:RequiredFieldValidator ID="rvDepto" ForeColor="#cc0000" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddDepartamento" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Seleccione un departamento"></asp:RequiredFieldValidator>

                            </section>
                            <section class="col-md">
                                <label for="txtPuesto" class="form-label">*Puesto:</label>
                                <asp:DropDownList ID="ddPuesto" CssClass="form-select" runat="server">
                                    <asp:ListItem Text="--Seleccionar puesto" Value="0" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rvPuesto" ForeColor="#cc0000" InitialValue="0" Display="Dynamic" runat="server" ControlToValidate="ddPuesto" ErrorMessage="<i class='fa-solid fa-triangle-exclamation'></i> Seleccione un puesto"></asp:RequiredFieldValidator>

                            </section>

                        </section>
                        <section class="row">
                            <label for="txtSalario" class="form-label"><i class="fa-solid fa-circle-info me-1" title="Puede registrar el salario del trabajador o hacerlo mas tarde en la pagina de salarios"></i>Salario:</label>
                            <div class="input-group mb-3 w-50">
                                <asp:LinkButton ID="btnShowModalAJAX" OnClick="btnShowModalAJAX_Click" CssClass="btn btn-outline-success" ToolTip="Editar salario" runat="server"><i class="fa-solid fa-dollar-sign"></i></asp:LinkButton>
                                <%--<asp:Button runat="server" CausesValidation="false" Text=":D" />--%>
                                <%--<button class="btn btn-outline-success" title="editar salario" type="button" data-bs-toggle="modal" data-bs-target="#SalarioModal" id="btnSalario"><i class="fa-solid fa-dollar-sign"></i></button>--%>
                                <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" TextMode="Password" ID="txtSalario" />


                            </div>
                        </section>
                        <section class="row mt">
                            <div class="col-md">
                                <label class="form-label">Status:</label>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                    <ContentTemplate>
                                        <label class="switch">
                                            <asp:CheckBox ID="chkEstatus" runat="server" AutoPostBack="true" Checked="true" OnCheckedChanged="chkOnOff_CheckedChanged" />
                                            <span class="slider round"></span>
                                        </label>
                                        <asp:Label ID="lblStatus" CssClass="ms-2 estado" Width="128px" runat="server" Text="activo"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </section>
                        <section class="row">
                            <span class="text-danger text-end" style="font-size: 14px;">*Campos obligatorios</span>
                        </section>
                    </div>
                    <hr />
                    <section class="d-flex flex-row gap-3 align-content-end justify-content-end">
                        <asp:Button ID="btnCancelar" CausesValidation="false" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click" />
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar cambios" />
                    </section>

                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnGuardar" />
                </Triggers>
            </asp:UpdatePanel>
        </section>

    </div>

    <!-- modal ajax -->
    <asp:Button ID="btnTargetAjax" runat="server" CssClass="visually-hidden" Text="show" />

    <asp:Panel ID="PnlModal" CssClass="modalPopup" Style="display: none; color: black" runat="server">
        <asp:UpdatePanel ID="upModal" runat="server">
            <ContentTemplate>
                <div class="modalContent">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Salario</h5>
                            <button type="button" class="btn-close" onclick="return hideModal();"></button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-auto d-flex mt-1">Salario actual</div>
                                <div class="col-auto">
                                    <div class="input-group mb-3">
                                        <span class="input-group-text bg-primary text-white" id="spanSalario"><i class="fa-solid fa-dollar-sign"></i></span>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtSalarioActual" ReadOnly="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-auto mt-1">Salario nuevo</div>
                                <div class="col-auto">
                                    <div class="input-group mb-3">
                                        <span class="input-group-text bg-success text-white" id="spanSalarioN"><i class="fa-solid fa-dollar-sign"></i></span>
                                        <asp:TextBox runat="server" CssClass="form-control" pattern="^[0-9]+\.[0-9]{2}$" ID="txtSalarioNuevo" ValidationGroup="salario" placeholder="Ingrese un monto" />
                                        <asp:RequiredFieldValidator ID="rfvSalario" Display="Dynamic" runat="server" ControlToValidate="txtSalarioNuevo" ValidationGroup="salario" ForeColor="#cc0000" ErrorMessage="*Ingrese una cantidad"></asp:RequiredFieldValidator>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Label ID="lblRes" ForeColor="#008800" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAceptarModal" ClientIDMode="Static" ValidationGroup="salario" CssClass="btn btn-sm btn-success" OnClick="btnAceptarModal_Click" runat="server" Text="Registrar" />
                            <asp:Button ID="btnCloseModal" class="btn btn-sm btn-secondary" OnClientClick="return hideModal();" runat="server" Text="Cancelar" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PnlModal" TargetControlID="btnTargetAjax"></cc1:ModalPopupExtender>
    <!-- Modal -->
    <div class="modal fade" id="SalarioModal" tabindex="-1" aria-labelledby="SalarioModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background: #335CA8; color: #ffff;">
                    <h1 class="modal-title fs-6" id="SalarioModalLabel">Modificando salario</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <%--     <div class="row">
                        <div class="col-auto d-flex mt-1">Salario actual</div>
                        <div class="col-auto">
                            <div class="input-group mb-3">
                                <span class="input-group-text bg-primary text-white" id="spanSalario"><i class="fa-solid fa-dollar-sign"></i></span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtSalarioActual" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-auto mt-1">Salario nuevo</div>
                        <div class="col-auto">
                            <div class="input-group mb-3">
                                <span class="input-group-text bg-success text-white" id="spanSalarioN"><i class="fa-solid fa-dollar-sign"></i></span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtSalarioNuevo" TextMode="Number" />
                            </div>
                        </div>
                    </div> --%>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success btn-sm">Guardar cambios</button>
                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">  
        function ShowPreview(input) {
            if (input.files && input.files[0]) {
                var ImageDir = new FileReader();
                ImageDir.onload = function (e) {
                    //$('#MainContent_imgEmpleado').attr('src', e.target.result);
                    /*$("selector").css({"background-image": "url(" + img + ")"});*/
                    $('#MainContent_imgEmpl').css({ "background-image": "url(" + e.target.result + ")" });

                }
                ImageDir.readAsDataURL(input.files[0]);
            }
        }

        function hideModal() {
            $find('<%= ModalPopupExtender1.ClientID %>').hide();
            return false;
        }
    </script>

</asp:Content>
