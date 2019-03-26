<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuijoteFacturaWF.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Login</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width" />
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="Content/Login/images/icons/favicon.ico"/>
    <link href="Content/Login/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/animate/animate.css" rel="stylesheet" />
    <link href="Content/Login/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="Content/Login/css/main.css" rel="stylesheet" />
    <link href="Content/Login/css/util.css" rel="stylesheet" />
</head>
<body>
       <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-pic js-tilt" data-tilt>
                    <img src="Content/Login/images/Quixote03.jpg" alt="IMG"/>
					<%--<img src="Content/Login/images/img-01.png" alt="IMG"/>--%>
				</div>

				<form class="login100-form validate-form">
					<span class="login100-form-title">
						Quijote Factura.do
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
						<input class="input100" type="text" name="email" placeholder="Email">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-envelope" aria-hidden="true"></i>
						</span>
					</div>

					<div class="wrap-input100 validate-input" data-validate = "Password is required">
						<input class="input100" type="password" name="pass" placeholder="Contraseña">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-lock" aria-hidden="true"></i>
						</span>
					</div>
					
					<div class="container-login100-form-btn">
						<button class="login100-form-btn">
							Login
						</button>
					</div>

					<div class="text-center p-t-12">
						<span class="txt1">
							Olvidó
						</span>
						<a class="txt2" href="#">
							Username / Password?
						</a>
					</div>

					<div class="text-center p-t-136">
						<a class="txt2" href="#">
							Crea tu cuenta
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
						</a>
					</div>
				</form>
			</div>
		</div>
	</div>
<!--===============================================================================================-->	
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="vendor/select2/select2.min.js"></script>
	<script src="vendor/tilt/tilt.jquery.min.js"></script>
	<script >
		$('.js-tilt').tilt({
			scale: 1.1
		})
	</script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>
<!--===============================================================================================--> 
</body>
</html>
