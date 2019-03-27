<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioWF.aspx.cs" Inherits="QuijoteFacturaWF.Registros.UsuarioWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-6">
            <div class="card">
                <div class="card-header text-uppercase text-center text-primary">Usuario</div>
                <article class="card-body">
                    <form>
                        <div class="form-row">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="form-group col-md-3">
                                <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                                <asp:TextBox class="form-control" ID="usuarioIdTextBox" Text="0" type="number" runat="server" Width="110px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="usuarioIdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="usuarioIdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                            </div>

                            <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                                <span class="fas fa-search"></span>Buscar
                                </asp:LinkButton>
                            </div>
                        </div>
                        <asp:Image ID="UsuarioImage" runat="server" Height="285px" ImageUrl="~/Resources/Usuario.png" runat="server" Width="211px" AlternateText="Imagen no disponible" ImageAlign="right" />
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
                                    <asp:RequiredFieldValidator ID="NombreRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="nombreTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="nombreTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="Numero de Telefono"></asp:Label>
                                    <asp:TextBox class="form-control" ID="noTelefonoTextBox" placeholder="000-000-0000" runat="server" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="noTelefonoRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="noTelefonoTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="noTelefonoREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="noTelefonoTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
                                    <asp:TextBox class="form-control" type="email" ID="emailTextBox" placeholder="micorreo@gmail.com" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Contraseña"></asp:Label>
                                    <asp:TextBox class="form-control" ID="passwordTextBox" type="password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label8" runat="server" Text="Confirmar Contraseña"></asp:Label>
                                    <asp:TextBox class="form-control" ID="cpasswordTextBox" type="password" runat="server"></asp:TextBox>
                                </div>
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
</div>
    </div>
</asp:Content>
