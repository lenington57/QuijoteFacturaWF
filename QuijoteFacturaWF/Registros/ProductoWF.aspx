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
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-3">
                                <asp:Label ID="Label5" runat="server" Text="Id"></asp:Label>
                                <asp:TextBox class="form-control" ID="productoIdTextBox" Text="0" type="number" runat="server" Width="110px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="productoIdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="productoIdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>

                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                                <span class="fas fa-search"></span>Buscar
                                </asp:LinkButton>
                            </div>
                        </div>
                        <asp:Image ID="UsuarioImage" runat="server" Height="231px" ImageUrl="~/Resources/new-product-seal_23-2147503128.jpg" runat="server" Width="222px" AlternateText="Imagen no disponible" ImageAlign="right" />
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
                                    <asp:RequiredFieldValidator ID="NombreRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="descripcionTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="descripcionTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>
                        <div class="form-row justify-content-center">
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label3" runat="server" Text="Costo"></asp:Label>
                                <asp:TextBox class="form-control" ID="costoTextBox" runat="server" Width="80px" OnTextChanged="costoTextBox_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="costoTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="costoTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>

                            </div>
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label6" runat="server" Text="Precio"></asp:Label>
                                <asp:TextBox class="form-control" ID="precioTextBox" runat="server" Width="80px" AutoPostBack="true" OnTextChanged="precioTextBox_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="precioTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="precioTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>

                            </div>
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label11" runat="server" Text="Ganancia"></asp:Label>
                                <asp:TextBox class="form-control" ID="porGanTextBox" runat="server" ReadOnly="true" Width="80px"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-2">
                                <asp:Label ID="Label12" runat="server" Text="Cantidad"></asp:Label>
                                <asp:TextBox class="form-control" ID="canInvTextBox" Text="0" runat="server" ReadOnly="true" Width="80px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button class="btn btn-primary btn-sm" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" />
                                    <asp:Button class="btn btn-success btn-sm" ID="guardarButton" runat="server" Text="Guardar" OnClick="guardarButton_Click" ValidationGroup="Guardar" />
                                    <asp:Button class="btn btn-danger btn-sm" ID="eliminarutton" runat="server" Text="Eliminar" OnClick="eliminarutton_Click" />
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
