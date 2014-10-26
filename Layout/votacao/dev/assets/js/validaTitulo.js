/***********************************************
	Js Validar se o título está cadastrado
************************************************/

var titulo 		 = document.getElementById('tituloEleitor'),
	validaTitulo = document.getElementById('validaTitulo');


/*
	Função de click do validaTitulo
*/

validaTitulo.onclick = function() {
	//lembrar de chamar função de validação
 	
 	//valido se o título está cadastrado na base
 	$.ajax({ 
		type: 'POST',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/validaTitulo.php",
		data: {
			titulo: titulo.value
		},
		success: function(dados) {
			//salva os itens necessário na seção para inserir o voto
			if(dados.status){
				retornaEleitor();
			} 
			else
				alert('Título não cadastrado, cadastre-se antes de votar =)');
			
		},
		error: function(dados){
			alert('Não foi possível validar seu título, tente novamente!');
		}
	});
};


function retornaEleitor() {
	$.ajax({ 
		type: 'POST',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/retornaeleitor.php",
		data: {
			titulo: titulo.value
		},
		success: function(dados) {
			//salva os itens necessário na seção para inserir o voto
			sessionStorage.setItem('estadoeleitor', dados.estado); 
			sessionStorage.setItem('idadeeleitor', dados.idade);
			sessionStorage.setItem('sexoeleitor', dados.sexo);
			sessionStorage.setItem('zonaeleitor', dados.zonaeleitoral);
			sessionStorage.setItem('secaoeleitor', dados.secao);

			//redireciona para o começo da votação
			$.fn.fullpage.moveSlideRight();	

		},
		error: function(dados){
			alert('Não foi possível validar seu título, tente novamente!');
		}
	});	
}

