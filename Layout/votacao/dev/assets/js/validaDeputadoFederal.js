/***************************************************
	Js para validar se o deputado federal existe
****************************************************/

var deputadoFederal       = document.getElementById('deputadoFederal'),
	validaDeputadoFederal = document.getElementById('validaDeputadoFederal');


/*
	Função de click do valida deputado estadual
*/  
    
validaDeputadoFederal.onclick = function() {
	var eleitor = JSON.parse(sessionStorage.getItem('eleitor'));  
	$.ajax({ 
		type: 'post',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/validacandidato.php",
		data: {
			numero: deputadoFederal.value,
			estadocandidato: eleitor.estadoeleitor,
			cargo: 4
		},  
		success: function(dados) {
			
			if(dados.status) {
				//Salvo na sessão o id do cargo para montar a query de retorno
				sessionStorage.setItem('cargoID', 4);

				//se o candidato existir os dados para montar o seu perfil
				retornaCandidato(deputadoFederal.value);
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