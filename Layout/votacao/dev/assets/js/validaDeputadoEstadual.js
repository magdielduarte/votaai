/***************************************************
	Js para validar se o deputado estadual existe
****************************************************/

var deputadoEstadual       = document.getElementById('deputadoEstadual'),
	validaDeputadoEstadual = document.getElementById('validaDeputadoEstadual');


/*
	Função de click do valida deputado estadual
*/ 

validaDeputadoEstadual.onclick = function() {
	$.ajax({ 
		type: 'POST',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/valida/validaCandidato.php",
		data: {
			numero: deputadoEstadual.value
		},
		success: function(dados) {
			//salva os itens necessário na seção para montar o perfil do candidato


			//redireciona para a proxima página
		},
		error:function(dados){
			//enviar mensagem avisando que o numero não existe e se deseja anular o voto.
		}
	});
};