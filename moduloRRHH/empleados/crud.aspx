<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="moduloRRHH.empleados.crud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row p-4 mt-2" style="background: #E1E2EC; color:#001A43; border-radius: 14px;">
        <section class="col-md-3 mt-2">
            <div class="d-flex flex-column align-items-center">
                <label id="lblfoto" class="form-label">Seleccionar foto</label>
                <asp:Panel ID="imgEmpl" runat="server" BackImageUrl="~/Assets/img/default-user.png" Width="134px" Height="134px" CssClass="foto-empleado edicion mb-3"></asp:Panel>
                <asp:Image ID="imgEmpleado" Visible="false" runat="server" AlternateText="foto del empleado" ImageUrl="~/Assets/img/default-user.png" CssClass="foto-empleado edicion" />
                <asp:FileUpload ID="FUfoto"  CssClass="form-control" onchange="ShowPreview(this)"  runat="server" />
            </div>
        </section>
        <section class="col-md-9">
            <div class="d-flex flex-row align-items-center justify-content-center align-content-center">
                <hr style="width: 35%;" />
                <p class="fw-bold m-2">Información personal</p>
                <hr style="width: 35%;" />
            </div>
            <div class="row">
                <div class="col-md">
                    <label for="txtNombre" class="form-label">Nombre(s):</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
            </div>
            <div class="row">
                <section class="col-md">
                    <label for="txtApellidoP" class="form-label">Apellido paterno:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoP" />
                </section>
                <section class="col-md">
                    <label for="txtApellidoM" class="form-label">Apellido materno:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoM" />
                </section>
            </div>
            <div class="row">
                <section class="col-md">
                    <label for="txtFechaNac" class="form-label">Fecha de nacimiento:</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtFechaNac" />
                </section>
                <section class="col-md">
                    <label for="txtRfc" class="form-label">RFC:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtRfc" />
                </section>
            </div>
            <div class="row">
                <section class="col-md">
                    <label for="txtcolonia" class="form-label">colonia:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtcolonia" />
                </section>
                <section class="col-md">
                    <label for="txtCalle" class="form-label">Calle:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCalle" />
                </section>
            </div>
            <div class="row">
                <section class="col-md">
                    <label for="txtEstado" class="form-label">Estado:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEstado" />
                </section>
                <section class="col-md">
                    <label for="txtCiudad" class="form-label">Ciudad:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCiudad" />
                </section>
                <section class="col-md">
                    <label for="txtCP" class="form-label">CP:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCP" />
                </section>
            </div>
            <div class="row">
                <section class="col-md">
                    <label for="txtTelefono" class="form-label">Telefono:</label>
                    <asp:TextBox runat="server" CssClass="form-control" TextMode="Phone" ID="txtTelefono" />
                </section>
                <section class="col-md">
                    <label for="txtTelEmergencia" class="form-label">Telefono de emergencia:</label>
                    <asp:TextBox runat="server" CssClass="form-control" TextMode="Phone" ID="txtTelEmergencia" />
                </section>
                <section class="col-md">
                    <label for="txtCorreo" class="form-label">Correo:</label>
                    <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="txtCorreo" />
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
                    <asp:DropDownList ID="ddEmpresa" CssClass="form-select" Width="30%"  runat="server">
                        <asp:ListItem Text="4 Matildes" />
                        <asp:ListItem Text="Hungaros" />
                        <asp:ListItem Text="Jamamadi" />
                    </asp:DropDownList>
                </section>
                <section class="row">
                    <section class="col-md">
                        <label for="txtNoEmpleado" class="form-label">Numero de empleado:</label>
                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Number" ID="txtNoEmpleado" />
                    </section>
                    <section class="col-md">
                        <label for="txtFehcaIngreso" class="form-label">Fecha de ingreso:</label>
                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" ID="txtFechaIngreso" />
                    </section>
                </section>
                <section class="row">
                    <section class="col-md">
                        <label for="txtPuesto" class="form-label">Puesto:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPuesto" />
                    </section>
                    <section class="col-md">
                        <label for="txtSalario" class="form-label">Salario:</label>
                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="txtSalario" />
                    </section>
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
            </div>
            <hr />
            <section class="d-flex flex-row gap-3 align-content-end justify-content-end">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar cambios" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click" />
            </section>
        </section>
    </div>

    <script type="text/javascript">  
        function ShowPreview(input) {  
            if (input.files && input.files[0]) {  
                var ImageDir = new FileReader();  
                ImageDir.onload = function(e) {  
                    $('#MainContent_imgEmpleado').attr('src', e.target.result);  
                    /*$("selector").css({"background-image": "url(" + img + ")"});*/
                    $('#MainContent_imgEmpl').css({ "background-image": "url(" + e.target.result + ")" });
                }  
                ImageDir.readAsDataURL(input.files[0]);  
            }  
        }  
    </script>

</asp:Content>
