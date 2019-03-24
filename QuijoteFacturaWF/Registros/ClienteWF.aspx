<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteWF.aspx.cs" Inherits="QuijoteFacturaWF.Registros.ClienteWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-6">
            <div class="card">
                <div class="card-header text-uppercase text-center text-primary">Cliente</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" />
                                    <asp:TextBox class="form-control" ID="clienteIdTextBox" Text="0" type="number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:Image ID="UsuarioImage" runat="server" Height="285px" ImageUrl="~/Resources/comprador.jpg" runat="server" Width="211px" AlternateText="Imagen no disponible" ImageAlign="right" />
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
                                    <asp:TextBox class="form-control" ID="nombreTextBox" placeholder="Nombre" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="Número de Teléfono"></asp:Label>
                                    <asp:TextBox class="form-control" ID="noTelefonoTextBox" placeholder="000-000-0000" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" Text="Número de Cédula"></asp:Label>
                                    <asp:TextBox class="form-control" ID="emailTextBox" placeholder="000-0000000-0" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Direccion"></asp:Label>
                                    <asp:TextBox class="form-control" ID="direccionTextBox" type="password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Deuda"></asp:Label>
                                    <asp:TextBox class="form-control" ID="deudaTextBox" placeholder="0" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button class="btn btn-primary btn-sm" ID="nuevoButton" runat="server" Text="Nuevo" />
                                    <asp:Button class="btn btn-success btn-sm" ID="guardarButton" runat="server" Text="Guardar" />
                                    <asp:Button class="btn btn-danger btn-sm" ID="eliminarutton" runat="server" Text="Eliminar" />
                                </div>
                            </div>
                        </div>

                    </form>
                </article>
            </div>
            <!-- card.// -->
    </div>
    <br>
</asp:Content>
