<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Votaai.Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Dashboard - Bootstrap Admin Template</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <!-- IMPORT CSS FILES-->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600"
        rel="stylesheet">
    <link href="css/font-awesome.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/pages/dashboard.css" rel="stylesheet">
    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	 <![endif]-->
</head>
<body>
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
                    <li class="active"><a href="Index.aspx"><i class="icon-dashboard"></i><span>Dashboard</span> </a></li>
                    <li><a href="Cadastros.aspx"><i class="icon-list-alt"></i><span>Cadastros</span> </a></li>
                </ul>
            </div>
            <!-- /container -->
        </div>
        <!-- /subnavbar-inner -->
    </div>
    <!-- /subnavbar -->
    <div class="main">
        <div class="main-inner">
            <div class="container">
                <div class="row">
                    <div class="span6">
                        <div class="widget widget-nopad">
                            <div class="widget-header">
                                <i class="icon-list-alt"></i>
                                <h3>Status gerais</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="widget big-stats-container">
                                    <div class="widget-content">
                                        <h6 class="bigstats">Acompanhe abaixo as atualizações de status gerais da votação em tempo real</h6>
                                        <div id="big_stats" class="cf">
                                            <div class="stat">
                                                <i class="icon-group"></i>
                                                <h6 class="bigstats">CADASTROS<h6>
                                                    <span id="lblqtdcadastro" class="value">851</span>
                                            </div>
                                            <!-- .stat -->

                                            <div class="stat">
                                                <i class="icon-filter"></i>
                                                <h6 class="bigstats">QUANTOS VOTARAM<h6>
                                                    <span id="lblqtvotos" class="value">423</span>
                                            </div>
                                            <!-- .stat -->
                                            <div class="stat">
                                                <i class="icon-certificate"></i>
                                                <h6 class="bigstats">QUANTOS VOTARAM (%)<h6><span id="lblpercvoto" class="value">25%</span>
                                            </div>
                                            <!-- .stat -->
                                        </div>
                                    </div>
                                    <!-- /widget-content -->

                                </div>
                            </div>
                        </div>
                        <!-- /widget -->

                        <div class="widget">
                            <div class="widget-header">
                                <i class="icon-file"></i>
                                <h3>Notificações</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <ul class="messages_layout">
                                    <li class="from_user left"><a href="#" class="avatar">
                                        <img src="img/message_avatar1.png" /></a>
                                        <div class="message_wrap">
                                            <div class="text">Candidato X recebeu um voto as 14:20pm. </div>
                                        </div>
                                    </li>
                                    <li class="by_myself left"><a href="#" class="avatar">
                                        <img src="img/message_avatar2.png" /></a>
                                        <div class="message_wrap">
                                            <div class="text">Candidato Y recebeu um voto as 14:22pm.</div>
                                        </div>
                                    </li>
                                    <li class="from_user left"><a href="#" class="avatar">
                                        <img src="http://placehold.it/50x50" /></a>
                                        <div class="message_wrap">
                                            <div class="text">Novo eleitor cadastrado as 14:23pm.</div>
                                        </div>
                                    </li>
                                    <li class="from_user left"><a href="#" class="avatar">
                                        <img src="img/message_avatar1.png" /></a>
                                        <div class="message_wrap">
                                            <div class="text">Candidato X recebeu um voto as 14:20pm. </div>
                                        </div>
                                    </li>
                                    <li class="from_user left"><a href="#" class="avatar">
                                        <img src="img/message_avatar2.png" /></a>
                                        <div class="message_wrap">
                                            <div class="text">Candidato Y recebeu um voto as 14:22pm.</div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <!-- /widget-content -->
                        </div>
                        <!-- /widget -->
                    </div>
                    <!-- /span6 -->
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header">
                                <i class="icon-bookmark"></i>
                                <h3>Relatórios</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <div class="shortcuts">
                                    <a href="javascript:;" class="shortcut">
                                        <span class="shortcut-label">Relatório 1</span>
                                    </a>
                                    <a href="javascript:;" class="shortcut">
                                        <span class="shortcut-label">Relatório 2</span>
                                    </a>
                                    <a href="javascript:;" class="shortcut">
                                        <span class="shortcut-label">Relatório 3</span>
                                    </a>
                                    <a href="javascript:;" class="shortcut">
                                        <span class="shortcut-label">Relatório 4</span>
                                    </a>
                                    <a href="javascript:;" class="shortcut">
                                        <span class="shortcut-label">Relatório 5</span>
                                    </a>
                                    <a href="javascript:;" class="shortcut">
                                        <span class="shortcut-label">Relatório 6</span>
                                    </a>
                                    <a href="javascript:;" class="shortcut">
                                        <span class="shortcut-label">Relatório 7</span>
                                    </a>
                                    <a href="javascript:;" class="shortcut">
                                        <span class="shortcut-label">Relatório 8</span>
                                    </a>
                                </div>
                                <!-- /shortcuts -->
                            </div>
                            <!-- /widget-content -->
                        </div>
                        <!-- /widget -->
                        <div class="widget">
                            <div class="widget-header">
                                <i class="icon-bar-chart"></i>
                                <h3>Votação para presidência</h3>
                            </div>
                            <!-- /widget-header -->
                            <div class="widget-content">
                                <canvas id="bar-chart" class="chart-holder" width="538" height="250"></canvas>
                                <!-- /bar-chart -->
                            </div>
                            <!-- /widget-content -->
                        </div>
                        <!-- /widget -->
                    </div>
                    <!-- /span6 -->
                </div>
                <!-- /row -->
            </div>
            <!-- /container -->
        </div>
        <!-- /main-inner -->
    </div>
    <!-- /main -->

    <!-- Le javascript
================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/excanvas.min.js"></script>
    <script src="js/chart.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.js"></script>
    <script language="javascript" type="text/javascript" src="js/full-calendar/fullcalendar.min.js"></script>

    <script src="js/base.js"></script>
    <script>
        var barChartData = {
            labels: ["dilma", "aecio", "marina", "pastor", "tulio", "diel", "marcin"],
            datasets: [
        {
            fillColor: "rgba(151,187,205,0.5)",
            strokeColor: "rgba(151,187,205,1)",
            data: [28, 48, 40, 19, 96, 27, 100]
        }
            ]

        }

        var myLine = new Chart(document.getElementById("bar-chart").getContext("2d")).Bar(barChartData);
    </script>
    <script type="text/javascript">
        function IncrementLabel(cadastros, qtsvotaram, percentual) {
            for (var cad = 0; cad < length; cad++) {
            }
        }
    </script>
</body>
</html>
