/***************************************************
	Js para validar se o presidente existe
****************************************************/

var presidente       = document.getElementById('presidente'),
	validaPresidente = document.getElementById('validaPresidente');


/*
	Função de click do valida deputado estadual
*/ 

validaPresidente.onclick = function() {
	var eleitor = JSON.parse(sessionStorage.getItem('eleitor'));  
	$.ajax({ 
		type: 'post',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/validacandidato.php",
		data: {
			numero: presidente.value,
			estadocandidato: eleitor.estadoeleitor,
			cargo: 1
		},  
		success: function(dados) {
			
			if(dados.status) {
				//Salvo na sessão o id do cargo para montar a query de retorno
				sessionStorage.setItem('cargoID', 1);

				//se o candidato existir pego os dados para montar o seu perfil
				retornaCandidato(presidente.value);
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