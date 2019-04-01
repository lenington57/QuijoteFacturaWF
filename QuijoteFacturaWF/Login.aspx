<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuijoteFacturaWF.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="Content/Login/images/icons/favicon.ico" />
    <link href="Content/Login/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/animate/animate.css" rel="stylesheet" />
    <link href="Content/Login/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="Content/Login/css/main.css" rel="stylesheet" />
    <link href="Content/Login/css/util.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100">
                    <div class="login100-pic js-tilt" data-tilt>
                        <img src="Content/Login/images/Quixote03.jpg" alt="IMG" />
                        <%--<img src="Content/Login/images/img-01.png" alt="IMG"/>--%>
                    </div>

                    <div class="login100-form validate-form">
                        <span class="login100-form-title">Quijote Factura.do
                        </span>

                        <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">
                            <asp:TextBox ID="emailTextBox" class="input100" placeholder="Email" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-envelope" aria-hidden="true"></i>
                            </span>
                        </div>

                        <div class="wrap-input100 validate-input" data-validate="Password is required">
                            <asp:TextBox ID="passwordTextBox" class="input100" placeholder="Contraseña" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-lock" aria-hidden="true"></i>
                            </span>
                        </div>

                        <div class="container-login100-form-btn">
                            <asp:Button ID="LoginButton" class="login100-form-btn" runat="server" Text="Iniciar Sesión" OnClick="LoginButton_Click" />
                        </div>

                        <div class="text-center p-t-12">
                            <span class="txt1">Olvidó
                            </span>
                            <a class="txt2" href="#">Username / Password?
                            </a>
                        </div>

                        <div class="text-center p-t-136">
                            <a class="txt2" href="#">Crea tu cuenta
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>    <!--===============================================================================================-->
</form>
</body>
</html>
