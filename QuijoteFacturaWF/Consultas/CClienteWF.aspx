<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CClienteWF.aspx.cs" Inherits="QuijoteFacturaWF.Consultas.CClienteWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="card card-register mx-auto mt-5">
        <div class="card-header text-uppercase text-center">Consultar Clientes</div>
        <div class="card-body">
            <div class="form-row justify-content-center">
                <%--Filtro--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem>Todo</asp:ListItem>
                        <asp:ListItem>Todo por Fecha</asp:ListItem>
                        <asp:ListItem>Id del Cliente</asp:ListItem>
                        <asp:ListItem>Nombre</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--Criterio--%>
                <div class="form-group col-md-3">
                    <asp:Label ID="Label1" runat="server">Criterio</asp:Label>
                    <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="buscarLinkButton" CssClass="btn btn-dark mt-4" runat="server" OnClick="buscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
                    </asp:LinkButton>
                </div>
            </div>
            <%--Rango fecha--%>
            <div class="form-row justify-content-center">
                <div class="form-group col-md-2">
                    <asp:Label Text="Desde" runat="server" />
                    <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Label Text="Hasta" runat="server" />
                    <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <asp:Label ID="criterioLabel" runat="server" Text="" Font-Bold="True" ValidateRequestMode="Inherit" Font-Size="Large"></asp:Label>
                    <div class="form-row justify-content-center">
                        <asp:GridView ID="ClienteGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="LightSkyBlue" />
                            <Columns>
                                <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="Nombres" HeaderText="Nombre" />
                                <asp:BoundField DataField="NoTelefono" HeaderText="NoTelefono" />
                                <asp:BoundField DataField="NoCedula" HeaderText="NoCedula" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                <asp:BoundField DataField="Deuda" HeaderText="Deuda" />
                            </Columns>
                            <HeaderStyle BackColor="LightGreen" Font-Bold="True" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <%--Imprimir--%>
            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <button type="button" class="btn btn-warning mt-4" data-toggle="modal" data-target=".bd-example-modal-lg">Imprimir</button>
                    </div>
                </div>
            </div>
            <!-- Modal para mi Reporte.// -->
            <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" style="max-width: 600px!important; min-width: 300px!important">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">REPORTE CLIENTES</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <%--Viewer--%>
                            <rsweb:ReportViewer ID="MyClientesReportViewer" runat="server" ProcessingMode="Remote" Height="400px" Width="500px">
                                <ServerReport ReportPath="" ReportServerUrl="" />
                            </rsweb:ReportViewer>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
