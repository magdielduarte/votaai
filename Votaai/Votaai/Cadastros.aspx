<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastros.aspx.cs" Inherits="Votaai.Cadastros" %>
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

<div class="navbar navbar-fixed-top">
  <div class="navbar-inner">
    <div class="container"> <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                    class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span> </a><a class="brand" href="Index.aspx">Vota Aí - Dashboard </a>
      <div class="nav-collapse">
        <ul class="nav pull-right">
          <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i
                            class="icon-cog"></i> Configurações<b class="caret"></b></a>
            <ul class="dropdown-menu">
              <li><a href="javascript:;">Sobre</a></li>
            </ul>
          </li>
          <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i
                            class="icon-user"></i> tulio de paula<b class="caret"></b></a>
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
        <li><a href="Index.aspx"><i class="icon-dashboard"></i><span>Dashboard</span> </a> </li>
        <li class="active"><a href="cadastros.html"><i class="icon-list-alt"></i><span>Cadastros</span> </a> </li>
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
	  				</div> <!-- /widget-header -->
					
					<div class="widget-content">
						
						
						
						<div class="tabbable">
							<ul class="nav nav-tabs">
							  <li class="active">
							    <a href="#Formpartido" data-toggle="tab">Cadastrar Partido</a>
							  </li>
							  <li ><a href="#Formcandidato" data-toggle="tab">Cadastrar Candidato</a></li>
							  <li ><a href="#Formusuario" data-toggle="tab">Cadastrar Usuário</a></li>
							</ul>
						
							<br>
						
							<div class="tab-content">
								<div class="tab-pane active" id="Formpartido">
									<form id="edit-profile" class="form-horizontal">
										<fieldset>
											
											<div class="control-group">											
												<label class="control-label" for="username">CNPJ</label>
												<div class="controls">
													<input type="text" class="span4" id="cpnj" name="cnpj" placeholder="99.999.999/9999-99">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->
											
											
											<div class="control-group">											
												<label class="control-label" for="firstname">Nome</label>
												<div class="controls">
													<input type="text" class="span4" id="nome" name="nome" placeholder="digite o nome completo do partido">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->
											
											
											<div class="control-group">											
												<label class="control-label" for="lastname">Sigla</label>
												<div class="controls">
													<input type="text" class="span4" id="sigla" placeholder="Digite a sigla do partido">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->
											
											
											<div class="control-group">											
												<label class="control-label" for="email">Prefixo</label>
												<div class="controls">
													<input type="number" class="span4" id="prefixo" placeholder="digite o prefixo do partid. Ex: 13">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->

											<div class="form-actions">
												<button type="submit" class="btn btn-success">Cadastrar</button> 
												<button class="btn">Cancelar</button>
											</div> <!-- /form-actions -->
										</fieldset>
									</form>
								</div>
								
								<div class="tab-pane" id="Formcandidato">
									<form id="edit-profile" class="form-horizontal">
										<fieldset>

											<div class="control-group">											
												<label class="control-label" for="username">Nome</label>
												<div class="controls">
													<input type="text" class="span4" id="nomecandidato" name="nome" placeholder="Digite o nome do candidato">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->										
										
											<div class="control-group">											
												<label class="control-label" for="email">Número</label>
												<div class="controls">
													<input type="number" class="span4" id="numero" placeholder="Digite o numero do candidato">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->	

											<div class="control-group">											
												<label class="control-label" for="email">Cargo</label>
												<div class="controls">
													<input type="text" class="span4" id="cargo" placeholder="Digite o cargo do candidato">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->	 

											<div class="control-group">											
												<label class="control-label" for="email">Foto</label>
												<div class="controls">
													<input type="file" class="span4" id="img">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->                                           
  											
											<div class="control-group">											
												<label class="control-label" for="email">Partido</label>
												<div class="controls">
													<select name="" id="" class="span4">
														<option value="">PSDB</option>
														<option value="">PT</option>
													</select>
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->

  											<div class="form-actions">
												<button type="submit" class="btn btn-success">Cadastrar</button> 
												<button class="btn">Cancelar</button>
											</div> <!-- /form-actions -->                                          
    
										</fieldset>
									</form>
								</div>

								<div class="tab-pane" id="Formusuario">
									<form id="edit-profile" class="form-horizontal">
										<fieldset>

											<div class="control-group">											
												<label class="control-label" for="username">Login</label>
												<div class="controls">
													<input type="text" class="span4" id="login" name="login" placeholder="Login">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->										
										
											<div class="control-group">											
												<label class="control-label" for="email">Senha</label>
												<div class="controls">
													<input type="password" class="span4" id="senha" placeholder="Senha">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->	

											<div class="control-group">											
												<label class="control-label" for="email">Repita a senha</label>
												<div class="controls">
													<input type="password" class="span4" id="senharepitida" name ="senharepitida" placeholder="Repita a senha">
												</div> <!-- /controls -->				
											</div> <!-- /control-group -->	 

  											<div class="form-actions">
												<button type="submit" class="btn btn-success">Cadastrar</button> 
												<button class="btn">Cancelar</button>
											</div> <!-- /form-actions -->                                          
    
										</fieldset>
									</form>
								</div>
								
							</div>
						  
						  
						</div>
						
						
						
						
						
					</div> <!-- /widget-content -->
						
				</div> <!-- /widget -->
		    </div> <!-- /span8 -->
	      	
	      	
	      </div> <!-- /row -->
	
	    </div> <!-- /container -->
	    
	</div> <!-- /main-inner -->
    
</div> <!-- /main -->
    
    


	<script src="js/jquery-1.7.2.min.js"></script>
		
	<script src="js/bootstrap.js"></script>
	<script src="js/base.js"></script>


  </body>

</html>
