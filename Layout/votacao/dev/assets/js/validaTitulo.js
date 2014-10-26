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

	$.ajax({ 
		type: 'POST',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/valida/validaTitulo.php",
		data: {
			tituloeleitor: titulo.value
		},
		success: function(dados) {
			//salva os itens necessário na seção para inserir o voto


			//redireciona para a proxima página
		},
		error:function(dados){
			//enviar mensagem de erro
		}
	});
};

