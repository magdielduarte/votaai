
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
var linkInicio = document.getElementById('linkInicio');
linkInicio.onclick = function() {
	$.fn.fullpage.moveTo(1);
};


