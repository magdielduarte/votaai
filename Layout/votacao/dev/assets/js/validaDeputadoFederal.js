/***************************************************
	Js para validar se o deputado federal existe
****************************************************/

var deputadoFederal       = document.getElementById('deputadoFederal'),
	validaDeputadoFederal = document.getElementById('validaDeputadoFederal');


/*
	Função de click do valida deputado estadual
*/ 

validaDeputadoEstadual.onclick = function() {
	$.ajax({ 
		type: 'POST',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/valida/validaCandidato.php",
		data: {
			numero: deputadoFederal.value
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