<%@ Page Title="" Language="C#" MasterPageFile="~/template.Master" AutoEventWireup="true" CodeBehind="visor.aspx.cs" Inherits="moduloRRHH.empleados.visor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col">
            <iframe src="prueba.pdf" runat="server" frameborder="0" id="ifile" style="width: 100%; height: 550px;"></iframe>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col">            
            <asp:GridView ID="gvHistory" CssClass="table table-responsive table-striped table-hover text-center" AutoGenerateColumns="false" runat="server" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField DataField="Fecha_cambio" HeaderText="Fecha de cambio"></asp:BoundField>
                    <asp:BoundField DataField="accion" HeaderText="Cambio"></asp:BoundField>
                    <asp:BoundField DataField="Nombre" HeaderText="modificado por"></asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="d-flex justify-content-center">
                        <asp:Literal ID="Literal2" runat="server" Text="No se encontraron empleados"></asp:Literal>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="d-flex justify-content-center">
            <asp:LinkButton ID="btnPaTras" runat="server"  OnClick="btnPaTras_Click" CssClass="btn btn-secondary"><i class="fa-solid fa-chevron-left"></i> Regresar</asp:LinkButton>
        </div>
    </div>
</asp:Content>
