<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Votaai.Login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>Vota Aí - Login</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <!-- IMPORT CSS FILES-->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/pages/signin.css" rel="stylesheet" type="text/css">

    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/signin.js"></script>



    <script type="text/javascript">
        function ativadiv(id) {

            $('#' + id).removeAttr('style').fadeIn(20000).addClass('in').delay(1000) // shows alert with Bootstrap CSS3 implem
        }
    </script>


</head>

<body>

    <div class="navbar navbar-fixed-top">

        <div class="navbar-inner">

            <div class="container">

                <a class="brand" href="Index.aspx">Vota Aí - Login
                </a>

            </div>
            <!-- /container -->

        </div>
        <!-- /navbar-inner -->

    </div>
    <!-- /navbar -->

    <form runat="server">

        <div id="le-alert" style="display: none; z-index: 999; width: 500px; margin: 0 auto; position: fixed" class="alert alert-danger alert-block fade alertVotaai">
            <button href="#" type="button" onclick="desativadiv('le-alert')" class="close">&times;</button>
            <h4>Alerta!</h4>
            <asp:Label runat="server" ID="lbldanger" CssClass="p" Text=""></asp:Label>
        </div>

        <div class="account-container">

            <div class="content clearfix">

                <h1>Login</h1>

                <div class="login-fields">

                    <p>Por favor, digite seu login e senha</p>

                    <div class="field">
                        <label for="username">Login</label>
                        <input type="text" runat="server" id="username" name="Login" value="" placeholder="Login" class="login username-field" />
                    </div>
                    <!-- /field -->

                    <div class="field">
                        <label for="password">Password:</label>
                        <input type="password" id="password" runat="server" name="senha" value="" placeholder="Senha" class="login password-field" />
                    </div>
                    <!-- /password -->

                </div>
                <!-- /login-fields -->

                <div class="login-actions">

                    <%--				<button class="button btn btn-large">login</button>--%>
                    <asp:Button runat="server" ID="BtnLogin" OnClick="BtnLogin_Click" CssClass="button btn btn-large" Text="Login" />
                </div>
                <!-- .actions -->
            </div>
        </div>
    </form>


    <!-- /content -->


    <!-- /account-container -->
</body>

</html>
