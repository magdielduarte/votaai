<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastros.aspx.cs" Inherits="Votaai.Cadastros" %>

<%@ Register Src="~/UserControl/Candidato.ascx" TagPrefix="uc1" TagName="Candidato" %>
<%@ Register Src="~/UserControl/Partido.ascx" TagPrefix="uc1" TagName="Partido" %>
<%@ Register Src="~/UserControl/Usuario.ascx" TagPrefix="uc1" TagName="Usuario" %>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>Account - Bootstrap Admin Template</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet">

    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet">
    <link href="css/font-awesome.css" rel="stylesheet">

    <link href="css/style.css" rel="stylesheet">

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

</head>

<body>
    <form runat="server">
        <div class="navbar navbar-fixed-top">
            <div class="navbar-inner">
                <div class="container">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                        class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></a><a class="brand" href="Index.aspx">Vota Aí - Dashboard </a>
                    <div class="nav-collapse">
                        <ul class="nav pull-right">
                            <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i
                                class="icon-cog"></i>Configurações<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="javascript:;">Sobre</a></li>
                                </ul>
                            </li>
                            <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i
                                class="icon-user"></i>tulio de paula<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="javascript:;">Logout</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
                <!-- /container -->
            </div>
            <!-- /navbar-inner -->
        </div>
        <!-- /navbar -->
        <div class="subnavbar">
            <div class="subnavbar-inner">
                <div class="container">
                    <ul class="mainnav">
                        <li><a href="Index.aspx"><i class="icon-dashboard"></i><span>Dashboard</span> </a></li>
                        <li class="active"><a href="cadastros.html"><i class="icon-list-alt"></i><span>Cadastros</span> </a></li>
                    </ul>
                </div>
                <!-- /container -->
            </div>
            <!-- /subnavbar-inner -->
        </div>

        <div class="main">

            <div class="main-inner">

                <div class="container">

                    <div class="row">

                        <div class="span12">

                            <div class="widget ">

                                <div class="widget-header">
                                    <i class="icon-plus-sign"></i>
                                    <h3>Cadastros Gerais</h3>
                                </div>
                                <!-- /widget-header -->

                                <div class="widget-content">



                                    <div class="tabbable">
                                        <ul class="nav nav-tabs">
                                            <li class="active">
                                                <a href="#Formpartido" data-toggle="tab">Cadastrar Partido</a>
                                            </li>
                                            <li><a href="#Formcandidato" data-toggle="tab">Cadastrar Candidato</a></li>
                                            <li><a href="#Formusuario" data-toggle="tab">Cadastrar Usuário</a></li>
                                        </ul>

                                        <br>

                                        <div class="tab-content">
                                            <uc1:Candidato runat="server" ID="Candidato" />
                                            <uc1:Partido runat="server" ID="Partido" />
                                            <uc1:Usuario runat="server" ID="Usuario" />
                                        </div>

                                    </div>

                                </div>
                                <!-- /widget-content -->

                            </div>
                            <!-- /widget -->
                        </div>
                        <!-- /span8 -->


                    </div>
                    <!-- /row -->

                </div>
                <!-- /container -->

            </div>
            <!-- /main-inner -->

        </div>
        <!-- /main -->
    </form>
    <script src="js/jquery-1.7.2.min.js"></script>

    <script src="js/bootstrap.js"></script>
    <script src="js/base.js"></script>

    <script>
        var select = document.getElementById('selectcargo'),
             vice = document.getElementById('vice'),
             suplente = document.getElementById('suplente');

        function none() {
            vice.style.display = 'none';
            suplente.style.display = 'none';
        }

        none();

        select.onchange = function () {
            if (select.value == '1' || select.value == '3') {
                none();
                vice.style.display = 'block';
            }
            else {
                none();
                suplente.style.display = 'block';
            }
        };
    </script>
</body>

</html>
