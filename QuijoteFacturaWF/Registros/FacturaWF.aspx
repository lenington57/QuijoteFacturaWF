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
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-1">
                                <asp:Label ID="Label6" runat="server" Text="Fecha"></asp:Label>
                            </div>
                            <div class="col-lg-1 p-0">
                                <asp:TextBox class="form-control" ID="fechaTextBox" ReadOnly="true" type="date" Width="171px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label4" runat="server" Text="Id"></asp:Label>
                                <asp:TextBox class="form-control" ID="facturaIdTextBox" type="number" Text="0" runat="server" Width="100px"></asp:TextBox>
                            </div>
                            <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-info mt-4" runat="server">
                                <span class="fas fa-search"></span>Buscar
                                </asp:LinkButton>
                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="col-lg-1 p-0">
                                <button type="button" class="btn btn-warning mt-4" data-toggle="modal" data-target=".bd-example-modal-lg">Imprimir</button>
                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <div class="form-group col-md-1">
                                 <asp:Label ID="Label3" runat="server" Text="User"></asp:Label>
                             </div>
                            <div class="col-lg-1 p-0">
                                <asp:TextBox class="form-control" ID="usuarioTextBox1" Placeholder="Usuario" runat="server" ReadOnly="true" Width="170px"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Image ID="FacturaImage" runat="server" Height="208px" ImageUrl="~/Resources/mejores-herramientas-factuacion-electronica-810x607.jpg" runat="server" Width="167px" AlternateText="Imagen no disponible" ImageAlign="right" />
                        <br>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label7" runat="server" Text="Cliente"></asp:Label>
                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:DropDownList class="form-control" ID="clienteDropDownList" Width="180px" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label5" runat="server" Text="Producto"></asp:Label>
                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:DropDownList class="form-control" ID="productoDropDownList" Width="180px" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <br>
                        <br>
                        <br>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label1" runat="server" Text="Cantidad"></asp:Label>
                                <asp:TextBox class="form-control" ID="cantidadTextBox" runat="server" Width="80px"></asp:TextBox>
                            </div>
                            &nbsp;&nbsp;
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label2" runat="server" Text="Precio"></asp:Label>
                                <asp:TextBox class="form-control" ID="precioTextBox" runat="server" ReadOnly="true" Width="100px"></asp:TextBox>
                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label8" runat="server" Text="Importe"></asp:Label>
                                <asp:TextBox class="form-control" ID="importeTextBox" runat="server" ReadOnly="true" Width="100px"></asp:TextBox>
                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="agregarLinkButton" CssClass="btn btn-dark mt-4" runat="server">
                                <span class="fas fa-search"></span>Agregar
                                </asp:LinkButton>
                            </div>
                            &nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="removerLinkButton" CssClass="btn btn-danger mt-4" runat="server">
                                <span class="fas fa-search"></span>Remover
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <div class="card">
                                        <div class="card-body">
                                            <asp:Label ID="criterioLabel" runat="server" Text="Detalle" Font-Bold="True" ValidateRequestMode="Inherit" Font-Size="Large"></asp:Label>
                                            <div class="form-row justify-content-center">
                                                <asp:GridView ID="prestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="None" BackColor="White">
                                                    <AlternatingRowStyle BackColor="#999999" />
                                                    <Columns>
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
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-1">
                                <asp:Label ID="Label11" runat="server" Text="ITBIS"></asp:Label>
                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:TextBox class="form-control" ID="itbisTextBox" Text="0" ReadOnly="true" runat="server" Width="150px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-1">
                                <asp:Label ID="Label12" runat="server" Text="SubT"></asp:Label>
                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:TextBox class="form-control" ID="subtotalTextBox" Text="0" runat="server" ReadOnly="true" Width="150px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-1">
                                <asp:Label ID="Label13" runat="server" Text="Total"></asp:Label>
                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:TextBox class="form-control" ID="totalTextBox" Text="0" runat="server" ReadOnly="true" Width="150px"></asp:TextBox>
                            </div>
                        </div>
                        <br>
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button class="btn btn-primary" ID="nuevoButton" runat="server" Text="Nuevo" />
                                    <asp:Button class="btn btn-success" ID="guardarButton" runat="server" Text="Guardar" />
                                    <asp:Button class="btn btn-danger" ID="eliminarutton" runat="server" Text="Eliminar" />
                                </div>
                            </div>
                        </div>
                        <!-- Modal para mi Factura Rápida.// -->
                        <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Vista Rápida de Facturas</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div id="div1">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                    </div>
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
