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
				validaVotou();
			} 
			else{
				$('#alert').text('Título não está cadastrado ou não existe, tente novamente !');
				$('#alert').trigger('openModal');
			}
			
		},
		error: function(dados){
			$('#alert').text('Não foi possível validar seu título, tente novamente!');
			$('#alert').trigger('openModal');
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
			console.log(dados);

			var eleitor  = {
				eleitorid: dados.eleitorid,
				estadoeleitor: dados.estado,
				idadeeleitor: dados.idade,
				sexoeleitor: dados.sexo,
				zonaeleitor: dados.zonaeleitoral,
				secaoeleitor: dados.secao
			} 

			sessionStorage.setItem('eleitor', JSON.stringify(eleitor));

			//redireciona para o começo da votação
			$.fn.fullpage.moveSlideRight();	

		},
		error: function(dados){
			$('#alert').text('Não foi possível validar seu título, tente novamente!');
			$('#alert').trigger('openModal');
		}
	});	
}

function validaVotou() {
	$.ajax({ 
		type: 'POST',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/validavoto.php",
		data: {
			titulo: titulo.value
		},
		success: function(dados) {  

			if(!dados.status)
				retornaEleitor();
			else{
				$('#alert').text('O título informado já realizou a votação.');
				$('#alert').trigger('openModal');
			}

		},
		error: function(dados){
			$('#alert').text('Não foi possível validar seu título, tente novamente!');
			$('#alert').trigger('openModal');
		}
	});	
}

