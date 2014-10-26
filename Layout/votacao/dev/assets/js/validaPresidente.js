/***************************************************
	Js para validar se o presidente existe
****************************************************/

var presidente       = document.getElementById('presidente'),
	validaPresidente = document.getElementById('validaPresidente');


/*
	Função de click do valida deputado estadual
*/ 

validaDeputadoEstadual.onclick = function() {
	$.ajax({ 
		type: 'POST',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/valida/validaCandidato.php",
		data: {
			numero: presidente.value
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