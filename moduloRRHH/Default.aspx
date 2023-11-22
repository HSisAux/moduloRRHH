<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="moduloRRHH._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Bienvenido! ヾ(￣▽￣)</h1>

    <main>
        <div class="row">
            <div class="col">
                <asp:GridView ID="gvDocumentosFaltantes" CssClass="table table-hover table-hover table-sm align-middle text-center" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="No_empleado" HeaderText="No empleado"></asp:BoundField>
                        <asp:BoundField DataField="Empleado" HeaderText="Empleado"></asp:BoundField>
                        <asp:BoundField DataField="Archivo_faltante" HeaderText="Archivo faltante"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPerfil" ToolTip="Ir al perfil" OnClick="btnPerfil_Click" CssClass="btn btn-sm btn-warning text-white" runat="server"><i class="fa-solid fa-folder-closed"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col">
                <asp:GridView ID="gvDocumentosVencidos" AutoGenerateColumns="false" CssClass="table table-hover table-hover table-sm align-middle text-center" ShowHeaderWhenEmpty="true" runat="server">
                    <Columns>
                        <asp:BoundField DataField="No_empleado" HeaderText="No empleado"></asp:BoundField>
                        <asp:BoundField DataField="Empleado" HeaderText="Empleado"></asp:BoundField>
                        <asp:BoundField DataField="Archivo_faltante" HtmlEncode="false" HeaderText="Archivo faltante"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPerfil" ToolTip="Ir al perfil" OnClick="btnPerfil_Click" CssClass="btn btn-sm btn-warning text-white" runat="server"><i class="fa-solid fa-folder-closed"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </main>
    <%--<main>

        <div style="background: #D8E2FF; border-radius: 13px;" class="p-5 mt-2">
            <section class="row" aria-labelledby="aspnetTitle">
                <h1 id="aspnetTitle">ASP.NET</h1>
                <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
                <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
            </section>

            <div class="row">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                    <h2 id="gettingStartedTitle">Getting started</h2>D
                    <p>
                        ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                    </p>
                    <p>
                        <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                    </p>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </section>
                <section class="col-md-4" aria-labelledby="librariesTitle">
                    <h2 id="librariesTitle">Get more libraries</h2>
                    <p>
                        NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
                    </p>
                    <p>
                        <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                    </p>
                </section>
                <section class="col-md-4" aria-labelledby="hostingTitle">
                    <h2 id="hostingTitle">Web Hosting</h2>
                    <p>
                        You can easily find a web hosting company that offers the right mix of features and price for your applications.
                    </p>
                    <p>
                        <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                    </p>
                </section>
            </div>
        </div>
    </main>

    <script>
        //var index = ['btnHome', 'btnDoc', 'btnDpto', 'btnEmpleados', 'btnPuestos', 'btnSalarios'];
        //for (var i = 0; i < index.length; i++) {
        //    $('#' + index[i]).removeClass('seleccionado');
        //}

        $('#btnHome').addClass('seleccionado');
    </script>--%>
</asp:Content>
