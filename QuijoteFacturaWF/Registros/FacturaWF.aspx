<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FacturaWF.aspx.cs" Inherits="QuijoteFacturaWF.Registros.FacturaWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-row justify-content-center">
        <aside class="col-sm-8">
            <div class="card">
                <div class="card-header text-uppercase text-center text-primary">Factura</div>
                <article class="card-body">
                    <form>
                         <div class="form-row">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label4" runat="server" Text="Id"></asp:Label>
                                <asp:TextBox class="form-control" ID="facturaIdTextBox" type="number" runat="server" Width="100px"></asp:TextBox>
                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-info mt-4" runat="server">
                                <span class="fas fa-search"></span>Buscar
                                </asp:LinkButton>
                            </div>
                        </div>
                        <asp:Image ID="FacturaImage" runat="server" Height="260px" ImageUrl="~/Resources/mejores-herramientas-factuacion-electronica-810x607.jpg" runat="server" Width="265px" AlternateText="Imagen no disponible" ImageAlign="right" />
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="fechaTextBox" type="date" Width="170px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Cliente"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="clienteDropDownList" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="Producto"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="productoDropDownList" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-row justify-content-center">
                            <div class="form-group col-md-3">
                                <asp:Label ID="Label1" runat="server" Text="Cantidad"></asp:Label>
                                <asp:TextBox class="form-control" ID="cantidadTextBox" runat="server" Width="100px"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-3">
                                <asp:Label ID="Label2" runat="server" Text="Precio"></asp:Label>
                                <asp:TextBox class="form-control" ID="precioTextBox" runat="server" ReadOnly="true" Width="100px"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-3">
                                <asp:Label ID="Label8" runat="server" Text="Importe"></asp:Label>
                                <asp:TextBox class="form-control" ID="importeTextBox" runat="server" ReadOnly="true" Width="100px"></asp:TextBox>
                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="agregarLinkButton" CssClass="btn btn-dark mt-4" runat="server">
                                <span class="fas fa-search"></span>Agregar
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-body">
                                <asp:Label ID="criterioLabel" runat="server" Text="Detalle" Font-Bold="True" ValidateRequestMode="Inherit" Font-Size="Large"></asp:Label>
                                <div class="form-row justify-content-center">
                                    <asp:GridView ID="prestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="None" BackColor="White">
                                        <AlternatingRowStyle BackColor="#999999" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="ProductoId" HeaderText="ProductoId" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                                        </Columns>
                                        <HeaderStyle BackColor="#999999" Font-Bold="True" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label9" runat="server" Text="ITBIS"></asp:Label>
                                     <asp:TextBox class="form-control" ID="itbisTextBox" Text="0" runat="server" ReadOnly="true" Width="120px"></asp:TextBox>
                                    <asp:Label ID="Label6" runat="server" Text="Sub Total"></asp:Label>
                                     <asp:TextBox class="form-control" ID="subtotalTextBox" Text="0" runat="server" ReadOnly="true" Width="120px"></asp:TextBox>
                                    <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
                                     <asp:TextBox class="form-control" ID="totalTextBox" Text="0" runat="server" ReadOnly="true" Width="120px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br>
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
    </div>
    </div>
    </div>
    </div>
</asp:Content>
