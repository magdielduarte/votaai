/***************************************************
	Js para validar se o deputado estadual existe
****************************************************/

var deputadoEstadual       = document.getElementById('deputadoEstadual'),
	validaDeputadoEstadual = document.getElementById('validaDeputadoEstadual');


/*
	Função de click do valida deputado estadual
*/ 
    
validaDeputadoEstadual.onclick = function() {
	var eleitor = JSON.parse(sessionStorage.getItem('eleitor'));
	$.ajax({ 
		type: 'post',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/validacandidato.php",
		data: {
			numero: deputadoEstadual.value,
			estadocandidato: eleitor.estadoeleitor,
			cargo: 5
		},  
		success: function(dados) {
			
			if(dados.status) {
				//Salvo na sessão o id do cargo para montar a query de retorno
				sessionStorage.setItem('cargoID', 5);

				//se o candidato existir os dados para montar o seu perfil
				retornaCandidato(deputadoEstadual.value);
			}
			else {
				alert('candidato não existe, deseja anular seu voto?');
				return false;
			}
		},
		error:function(dados){
			alert('Não foi possível validar o candidato, tente novamente !');
		}
	});
};


function retornaCandidato(numero) {
	var eleitor = JSON.parse(sessionStorage.getItem('eleitor'));
	
	$.ajax({ 
		type: 'post',
		dataType: 'jsonp',  
		url: "http://apivotaai.azurewebsites.net/retornacandidato.php",
		data: {
			numero: numero,
			uf: eleitor.estadoeleitor,
			cargo: sessionStorage.getItem('cargoID')
		},  
		success: function(dados) {
				console.log(dados.candidatoid);
				$('.imgperfil').attr('src', dados.foto);
				$('.nomePerfil').text(dados.nome);
				$('.numeroPerfil').text(' - ' + dados.numero);
				$('.partidoPerfil').text('Partido: ' + dados.sigla);  
				$('.correto').attr('data-candidatoid', dados.candidatoid);
				$('.correto').attr('data-cargo', sessionStorage.getItem('cargoID'));


				$.fn.fullpage.moveSlideRight();	  
		},
		error:function(dados){
			alert('Não foi possível montar o perfil do candidato, tente novamente !');
		}
	});
}