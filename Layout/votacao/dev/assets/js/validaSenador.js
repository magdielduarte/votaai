/***************************************************
	Js para validar se o senador existe
****************************************************/

var senador       = document.getElementById('senador'),
	validaSenador = document.getElementById('validaSenador');


/*
	Função de click do valida deputado estadual
*/ 

validaSenador.onclick = function() {
	var eleitor = JSON.parse(sessionStorage.getItem('eleitor'));  
	$.ajax({ 
		type: 'post',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/validacandidato.php",
		data: {
			numero: senador.value,
			estadocandidato: eleitor.estadoeleitor,
			cargo: 2
		},  
		success: function(dados) {
			
			if(dados.status) {
				//Salvo na sessão o id do cargo para montar a query de retorno
				sessionStorage.setItem('cargoID', 2);

				//se o candidato existir os dados para montar o seu perfil
				retornaCandidato(senador.value);
			}
			else {
				$('#alert').text('candidato não existe, deseja anular seu voto?');
				$('#alert').trigger('openModal');
				return false;
			}
		},
		error:function(dados){
			$('#alert').text('Não foi possível validar o candidato, tente novamente !');
			$('#alert').trigger('openModal');
		}
	});
};