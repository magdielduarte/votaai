<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Votaai.Index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Dashboard - Votaaí</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <!-- IMPORT CSS FILES-->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet">
    <link href="css/font-awesome.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/pages/dashboard.css" rel="stylesheet">
    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/excanvas.min.js"></script>
    <script src="js/chart.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/full-calendar/fullcalendar.min.js"></script>
    <script src="js/base.js"></script>

    <script type="text/javascript">
        window.history.forward(1);
        function noBack() {
            window.history.forward();
        }
    </script>

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	 <![endif]-->
</head>
<body onload="noBack();" onpageshow="if (event.persisted) noBack();" onunload="">
    <div class="navbar navbar-fixed-top">
        <div class="navbar-inner">
            <div class="container">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                    class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></a><a class="brand" href="Index.aspx">Votaaí - Dashboard </a>
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
                    <li class="active"><a href="Index.aspx"><i class="icon-dashboard"></i><span>Dashboard</span> </a></li>
                    <li><a href="Cadastros.aspx"><i class="icon-list-alt"></i><span>Cadastros</span> </a></li>
                    <li><a href="#"><i class="icon-download"></i><span>Relatórios</span></a></li>
                </ul>
            </div>
            <!-- /container -->
        </div>
        <!-- /subnavbar-inner -->
    </div>
    <!-- /subnavbar -->
    <form runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
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
                                                        <%--<span id="lblqtdcadastro" class="value">851</span>--%>
                                                        <div id="qtd-cadastro" class="value"></div>
                                                </div>
                                                <!-- .stat -->

                                                <div class="stat">
                                                    <i class="icon-filter"></i>
                                                    <h6 class="bigstats">QUANTOS VOTARAM<h6>
                                                        <%--                                                    <span id="lblqtvotos" class="value">423</span>--%>
                                                        <div id="qtd-votos" class="value"></div>
                                                </div>
                                                <!-- .stat -->
                                                <div class="stat">
                                                    <i class="icon-certificate"></i>
                                                    <h6 class="bigstats">QUANTOS VOTARAM (%)<h6>
                                                        <%--                                                <span id="lblpercvoto" class="value">25%</span>--%>
                                                        <div id="qtd-percent" class="value"></div>
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
                                        <a href="Relatorio.aspx?filtro=estado" class="shortcut">
                                            <span class="shortcut-label">Votações por Estado</span>
                                        </a>
                                        <a href="Relatorio.aspx?filtro=sexo" class="shortcut">
                                            <span class="shortcut-label">Votações por sexo</span>
                                        </a>
                                        <a href="Relatorio.aspx?filtro=zona" class="shortcut">
                                            <span class="shortcut-label">Votações por Zona Eleitoral</span>
                                        </a>
                                        <a href="Relatorio.aspx?filtro=secao" class="shortcut">
                                            <span class="shortcut-label">Votação por Seção</span>
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
                                    <h3>Gráfico de Votações</h3>
                                </div>
                                <!-- /widget-header -->


                                <div class="widget-content">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <label class="control-label" for="email">Cargo</label>

                                            <asp:DropDownList runat="server" AutoPostBack="true" ID="selectcargo" CssClass="span4" OnSelectedIndexChanged="selectcargo_SelectedIndexChanged">
                                                <asp:ListItem Value="1" Text="Presidente"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Senador"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Governador"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Deputado Federal"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Deputado Estadual"></asp:ListItem>
                                            </asp:DropDownList>
                                            <div runat="server" style="width: 300px;" id="divestado">
                                                <label class="control-label">Estado</label>
                                                <asp:DropDownList runat="server" ID="selectestado" CssClass="span4">
                                                    <asp:ListItem Value="AC">Acre</asp:ListItem>
                                                    <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                                                    <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                                                    <asp:ListItem Value="AP">Amapá</asp:ListItem>
                                                    <asp:ListItem Value="BA">Bahia</asp:ListItem>
                                                    <asp:ListItem Value="CE">Ceará</asp:ListItem>
                                                    <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
                                                    <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
                                                    <asp:ListItem Value="GO">Goiás</asp:ListItem>
                                                    <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                                                    <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                                                    <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                                                    <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                                                    <asp:ListItem Value="PA">Pará</asp:ListItem>
                                                    <asp:ListItem Value="PB">Paraíba</asp:ListItem>
                                                    <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
                                                    <asp:ListItem Value="PI">Piauí</asp:ListItem>
                                                    <asp:ListItem Value="PR">Paraná</asp:ListItem>
                                                    <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                                                    <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                                                    <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                                                    <asp:ListItem Value="RR">Roraima</asp:ListItem>
                                                    <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                                                    <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                                                    <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                                                    <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                                                    <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <asp:Button Text="Atualizar Gráfico" runat="server" ID="BtnPesquisar" CssClass="btn-info" OnClick="BtnPesquisar_Click" />

                                            <canvas id="bar_chart" class="chart-holder" runat="server" width="538" height="250"></canvas>
                                            <!-- /bar-chart -->
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

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
    </form>
    <!-- Le javascript
================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

</body>
</html>
