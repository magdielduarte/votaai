/***********************************************
	Js para manipulação do cadastro de eleitor
************************************************/

var nextCadastro     	  = document.getElementById('nextCadastro'),
	finalizaCadastro 	  = document.getElementById('finalizaCadastro'),
	nome  		 		  = document.getElementById('nomeEleitor'),
	idade 		 		  = document.getElementById('idadeEleitor'),
	sexo         		  = document.getElementById('sexoEleitor'),
	estado       		  = document.getElementById('estadoEleitor'),
	tituloEleitorCadastro = document.getElementById('tituloEleitorCadastro'),
	zona		 	 	  = document.getElementById('zonaEleitor'),
	secao		 	 	  = document.getElementById('secaoEleitor');


/*
	Evento clique do botão nextCadastro
*/

nextCadastro.onclick = function() {
	//lembrar de chamar a funcao de validação

	sessionStorage.setItem('nome', nome.value);
	sessionStorage.setItem('idade', idade.value);
	sessionStorage.setItem('sexo', sexo.value);
	sessionStorage.setItem('estado', estado.value);

	$.fn.fullpage.moveSlideRight();
};



/*
	Evento clique do botao finalizaCadastro
*/

finalizaCadastro.onclick = function() {
	//lembrar de chamar a funcao de validação

	sessionStorage.setItem('titulo', tituloEleitorCadastro.value);
	sessionStorage.setItem('zona', zona.value);
	sessionStorage.setItem('secao', secao.value);  

	validaTituloExiste();
	
};

/*
	Função que valida se o titulo já foi cadastrado
*/

function validaTituloExiste() {
	titulo = sessionStorage.getItem('titulo');   
     
	$.ajax({            
		type: 'post',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/validatitulo.php",
		data: {
			titulo: titulo
		},
		success: function(dados) {
			if(dados.status){
				$('#alert').text('Título já cadastrado, tente novamente!');
				$('#alert').trigger('openModal');
				return false;
			} 
			else
				cadastraEleitor();


		},
		error:function(dados){
			//enviar mensagem de erro
			$('#alert').text('Não foi possível validar se o título existe, tente novamente !');
			$('#alert').trigger('openModal');  
		}
	});


}

/*
	Função cadastra eleitor
*/  

function cadastraEleitor() {
	nome   = sessionStorage.getItem('nome'),
	idade  = sessionStorage.getItem('idade'),
	sexo   = sessionStorage.getItem('sexo'),
	estado = sessionStorage.getItem('estado'),
	titulo = sessionStorage.getItem('titulo'),
	zona   = sessionStorage.getItem('zona'),
	secao  = sessionStorage.getItem('secao');  

	$.ajax({ 
		type: 'post',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/insereeleitor.php",
		data: {
			nome: nome,
			titulo: titulo,
			idade: idade,
			sexo: sexo,
			uf: estado, 
			zona: zona,
			secao: secao
		},
		success: function(dados) {
			//redireciona para a página de sucesso
			if(dados.status){

				$.fn.fullpage.moveSlideRight();	
				//remove os itens da sessão
				sessionStorage.removeItem('nome');
				sessionStorage.removeItem('idade');
				sessionStorage.removeItem('sexo');
				sessionStorage.removeItem('estado');
				sessionStorage.removeItem('titulo');
				sessionStorage.removeItem('zona');
				sessionStorage.removeItem('secao'); 
			}
			else
				alert(dados.mensagem);
		},
		error:function(dados){
			//enviar mensagem de erro
			$('#alert').text('não foi possível cadastrar, tente novamente !');
			$('#alert').trigger('openModal');
		}
	});

}