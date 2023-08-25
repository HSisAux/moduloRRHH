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
            <table class="table table-hover text-center">
                <thead class="table-header" style="color:white; background:#1D3B71;">
                <tr>
                    <th>Fecha de cambio</th>
                    <th>Tipo de cambio</th>
                    <th>Cambiado por</th>
                </tr>
                    </thead>
                <tbody>
                    <tr>
                        <td>08/07/2023</td>
                        <td>Creado</td>
                        <td>Usuario</td>
                    </tr> 
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
