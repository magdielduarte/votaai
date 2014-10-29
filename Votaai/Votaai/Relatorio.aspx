<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="Votaai.Relatorio" %>

<%@ Register TagPrefix="ajx" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">

    </script>
    <title>Votaaí - Relatórios</title>
    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/base.js"></script>


</head>

<body>
    <form id="Form1" runat="server">
        <%--<asp:ScriptManager runat="server"></asp:ScriptManager>--%>
        <ajx:ToolkitScriptManager runat="server"></ajx:ToolkitScriptManager>
        <div class="navbar navbar-fixed-top">
            <div class="navbar-inner">
                <div class="container">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                        class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></a>
                    <a class="brand" href="Index.aspx">Votaaí - Relatórios</a>

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
                        <li><a href="Cadastros.aspx"><i class="icon-list-alt"></i><span>Cadastros</span> </a></li>
                        <li class="active"><a href="#"><i class="icon-download"></i><span>Relatórios</span></a></li>

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

                                <div class="widget-content" >

                                    <div class="tabbable" id="filtroSexo" runat="server" style="display: none">

                                        <div class="control-group" runat="server" id="sexo">
                                             <label class="control-label" for="cargo">Sexo: </label>
                                            <div class="controls">
                                                <asp:DropDownList runat="server" ID="selectsexo" Width="250">
                                                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                    <asp:ListItem Value="F">Feminino</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="tabbable" id="filtroZona" runat="server" style="display: none">

                                        <div class="control-group" runat="server" id="zona">
                                             <label class="control-label" for="cargo">Zona Eleitoral: </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtZona" runat="server" Width="250" MaxLength="3" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="tabbable" id="filtroSecao" runat="server" style="display: none">

                                        <div class="control-group" runat="server" id="secao">
                                             <label class="control-label" for="cargo">Seção Eleitoral: </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtSecao" runat="server" Width="250" MaxLength="4" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="tabbable" id="filtroEstado" runat="server" style="display: none">

                                        <div class="control-group" runat="server" id="estado">
                                            <label class="control-label" for="cargo">Estado: </label>
                                            <div class="controls">
                                                <asp:DropDownList runat="server" ID="selectestado" Width="250">
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
                                            <!-- /controls -->
                                        </div>

                                    </div>

                                    <div class="tabbable" id="filtroErro" runat="server" style="display: none">

                                        <div class="control-group" runat="server" id="erro">
                                             <label class="control-label" for="cargo">Filtro não encontrado! Tente novamente.</label>
                                        </div>

                                    </div>

                                     <div class="tabbable" id="vazio" runat="server" style="display: none">

                                        <div class="control-group" runat="server" id="nada">
                                             <label class="control-label" for="cargo">Dados não encontrados.</label>
                                        </div>

                                    </div>


                                    <div class="tabbable" id="resposta" runat="server" style="display: none">

                                        <div class="control-group" runat="server" id="busca">
                                            <b>Presidentes:</b>
                                            <br />
                                            <br />
                                            <asp:Label Text="" runat="server" ID="presidente" />
                                            <br />
                                            <b>Governadores:</b>
                                            <br />
                                            <br />
                                            <asp:Label Text="" runat="server" ID="governador" />
                                            <br />
                                            <b>Senadores:</b>
                                            <br />
                                            <br />
                                            <asp:Label Text="" runat="server" ID="senador" />
                                            <br />
                                            <b>Deputados Federais:</b>
                                            <br />
                                            <br />
                                            <asp:Label Text="" runat="server" ID="federal" />
                                            <br />
                                            <b>Deputados Estaduais:</b>
                                            <br />
                                            <br />
                                            <asp:Label Text="" runat="server" ID="estadual" />
                                            <br />
                                            <br />
                                            <asp:Label Text="" runat="server" ID="vencedor" />
                                        </div>

                                    </div>

                                    <div class="col-sm-3" id="confirma" runat="server">
                                        <asp:Button Text="Gerar Relatório" ID="BtnGerarRelatorio" CssClass="btn btn-success" runat="server" OnClick="BtnGerarRelatorio_Click"></asp:Button>
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
