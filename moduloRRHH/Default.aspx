<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="moduloRRHH._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="row pt-3 mt-2" style="background: #E1E2EC;border-radius: 13px;color: #373b3e;">
            <div class="col">
                <h3>Documentos faltantes <i class="fa-solid fa-person-circle-exclamation text-secondary"></i></h3>
                <asp:GridView ID="gvDocumentosFaltantes" CssClass="table table-hover table-hover table-sm align-middle text-center" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="No_empleado" HeaderText="No empleado"></asp:BoundField>
                        <asp:BoundField DataField="Empleado" HeaderText="Empleado"></asp:BoundField>
                        <asp:BoundField DataField="Archivo" HtmlEncode="false" HeaderText="Archivo faltante"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPerfil" ToolTip="Ir al perfil" OnClick="btnPerfil_Click" CssClass="btn btn-sm btn-warning text-white" runat="server"><i class="fa-solid fa-folder-closed"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col">
                <h3>Documentos vencidos <i class="fa-solid fa-triangle-exclamation text-warning"></i></h3>
                <asp:GridView ID="gvDocumentosVencidos" AutoGenerateColumns="false"  CssClass="table table-hover table-hover table-sm align-middle text-center" ShowHeaderWhenEmpty="true" runat="server">
                    <Columns>
                        <asp:BoundField DataField="No_empleado" HeaderText="No empleado"></asp:BoundField>
                        <asp:BoundField DataField="Empleado" HeaderText="Empleado"></asp:BoundField>
                        <asp:BoundField DataField="Archivo" HtmlEncode="false" HeaderText="Archivos vencidos"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPerfilVencido" ToolTip="Ir al perfil" OnClick="btnPerfilVencido_Click" CssClass="btn btn-sm btn-warning text-white" runat="server"><i class="fa-solid fa-folder-closed"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div>No hay documentacion vencida <br /></div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </main>
    
</asp:Content>
