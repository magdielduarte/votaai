<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" MaintainScrollPositionOnPostback="true" %>

<%@ Register TagPrefix="ajx" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>Votaaí - Relatórios</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet">
    <link href="css/font-awesome.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/base.js"></script>


    <script type="text/javascript">

    </script>

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

</head>

<body>
    <form id="Form1" runat="server">
        <%--<asp:ScriptManager runat="server"></asp:ScriptManager>--%>
        <ajx:ToolkitScriptManager runat="server"></ajx:ToolkitScriptManager>
        <div class="navbar navbar-fixed-top">
            <div class="navbar-inner">
                <div class="container">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                        class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></a><a class="brand" href="Index.aspx">Votaaí - Dashboard</a>
                    <div class="nav-collapse">
                        <ul class="nav pull-right">
                            <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i
                                class="icon-cog"></i>Configurações<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="javascript:;">Sobre</a></li>
                                </ul>
                            </li>
                            <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <i id="IdUsuLogado" runat="server" class="icon-user"></i><b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="Login.aspx">Logout</a></li>
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
                        <li class="active"><a href="Cadastros.aspx"><i class="icon-list-alt"></i><span>Cadastros</span> </a></li>
                    </ul>
                </div>
                <!-- /container -->
            </div>
            <!-- /subnavbar-inner -->
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="le-alert" style="display: none; z-index: 999; width: 500px; margin: 0 auto; position: fixed" class="alert alert-danger alert-block fade alertVotaai">
                    <button href="#" type="button" onclick="desativadiv('le-alert')" class="close">&times;</button>
                    <h4>Alerta!</h4>
                    <asp:Label runat="server" ID="lbldanger" CssClass="p" Text=""></asp:Label>
                </div>

                <div id="le-sucess" style="display: none; z-index: 999; width: 500px; margin: 0 auto; position: fixed" class="alert alert-sucess alert-block fade alertVotaai">
                    <button href="#" type="button" onclick="desativadiv('le-sucess')" class="close">&times;</button>
                    <h4>Mensagem!</h4>
                    <asp:Label runat="server" ID="LblSucess" CssClass="p" Text=""></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="main">

            <div class="main-inner">

                <div class="container">

                    <div class="row">

                        <div class="span12">

                            <div class="widget ">

                                <div class="widget-header">
                                    <i class="icon-plus-sign"></i>
                                    <h3>Relatório</h3>
                                </div>
                                <!-- /widget-header -->

                                <div class="widget-content">

                                    <div class="tabbable">
                                        teste

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

</body>

</html>
