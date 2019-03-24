<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoWF.aspx.cs" Inherits="QuijoteFacturaWF.Registros.ProductoWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-6">
            <div class="card">
                <div class="card-header text-uppercase text-center text-primary">Producto</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" />
                                    <asp:TextBox class="form-control" ID="productoIdTextBox" Text="0" type="number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:Image ID="UsuarioImage" runat="server" Height="260px" ImageUrl="~/Resources/new-product-seal_23-2147503128.jpg" runat="server" Width="265px" AlternateText="Imagen no disponible" ImageAlign="right" />
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha de Vencimiento"></asp:Label>
                                    <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Departamento"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="departamentoDropDownList" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label>
                                    <asp:TextBox class="form-control" ID="descripcionTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <asp:Label ID="Label1" runat="server" Text="Costo"></asp:Label>
                                <asp:TextBox class="form-control" ID="costoTextBox" runat="server" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="Precio"></asp:Label>
                                <asp:TextBox class="form-control" ID="precioTextBox" runat="server" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label8" runat="server" Text="Porciento Ganado"></asp:Label>
                                <asp:TextBox class="form-control" ID="porGanTextBox" runat="server" ReadOnly="true" Width="160px"></asp:TextBox>
                                <asp:Label ID="Label9" runat="server" Text="Cantidad en Invetario"></asp:Label>
                                <asp:TextBox class="form-control" ID="canInvTextBox" runat="server" ReadOnly="true" Width="160px"></asp:TextBox>
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
