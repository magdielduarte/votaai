
/*
	Apaga as setas do fullpage js, pois o mesmo não existe opção default para tal
*/
setTimeout(function(){
	var arrowsfb = document.getElementsByClassName('fp-controlArrow');
	for (var i = 0; i < arrowsfb.length; i++) {
		arrowsfb[i].style.display = 'none';
	}
},10);


/*
	link para começar a votação
*/
 
var linkVotar = document.getElementById('linkVotar');
linkVotar.onclick = function() {
	$.fn.fullpage.moveTo(2);
};


/*
	link para cadastro do eleitor
*/

var linkCadastrar = document.getElementById('linkCadastrar');
linkCadastrar.onclick = function() {
	$.fn.fullpage.moveTo(3);
};


/*
	Link para voltar ao início
*/
$('.linkInicio').on('click', function(){
	$.fn.fullpage.moveTo(1);
});


/*
	link para cancelar escolha de candidato
*/

$('.cancela').on('click', function(){
	$.fn.fullpage.moveSlideLeft();	  
});


/*
	link para confirmar voto
*/

$('.correto').on('click', function(){
	var candidato = $(this).attr('data-candidatoid'),
		cargo     = $(this).attr('data-cargo');


	switch(cargo) {
		case '1':
			var candidato1 = candidato;
			sessionStorage.setItem('candidato1', candidato);
			alert('passou aqui');
			validaVoto();
			break;
		case '2':
			var candidato2 = candidato;
			sessionStorage.setItem('candidato2', candidato);
			$.fn.fullpage.moveSlideRight();
			break;
		case '3':  
			var candidato3 = candidato;
			sessionStorage.setItem('candidato3', candidato); 
			$.fn.fullpage.moveSlideRight();
			break;
		case '4':   
			var candidato4 = candidato;
			sessionStorage.setItem('candidato4', candidato);
			$.fn.fullpage.moveSlideRight();
			break;
		case '5':  
			var candidato5 = candidato;
			sessionStorage.setItem('candidato5', candidato);
			$.fn.fullpage.moveSlideRight();
			break;  
	}

		
});



/*
	Função valida voto
*/

function validaVoto() {
	//monto um objeto com os candidatos escolhidos pelo eleitor
	var candidato = {
		candidato1: sessionStorage.getItem('candidato1'),
		candidato2: sessionStorage.getItem('candidato2'),
		candidato3: sessionStorage.getItem('candidato3'),
		candidato4: sessionStorage.getItem('candidato4'),
		candidato5: sessionStorage.getItem('candidato5')
	}

	//transforma a session eleitor em objeto para poder manipulalo
	var eleitorsession = JSON.parse(sessionStorage.getItem('eleitor')),
		eleitor;

	eleitor = {
		eleitorid: eleitorsession.eleitorid,
		estadoeleitor: eleitorsession.estadoeleitor,
		idadeeleitor: eleitorsession.idadeeleitor,
		sexoeleitor: eleitorsession.sexoeleitor,
		zonaeleitor: eleitorsession.zonaeleitor,
		secaoeleitor: eleitorsession.secaoeleitor
	}


    $.ajax({ 
		type: 'post',
		dataType: 'jsonp',
		url: "http://apivotaai.azurewebsites.net/inserevoto.php",
		data: {
			eleitor: eleitor,
			candidatos: candidato
		},
		success: function(dados) {
			console.log(dados);
			$.fn.fullpage.moveSlideRight();
		},
		error: function(dados){
			console.log(dados);
			alert('Não foi possível cadastrar  seu voto, tente novamente!');
		}
	});	
}



