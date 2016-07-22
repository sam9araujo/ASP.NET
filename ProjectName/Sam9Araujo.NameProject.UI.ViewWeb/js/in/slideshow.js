$.fn.slideshow = function (options) {

	// Variaveis Default
	var s = $.extend({
		'local': 'depois',
		'play': 'auto',
		'nome': 'dizain',
		'tempo': 2000
	}, options);


	var tempo = s.tempo;
	if (s.play != 'auto') {
		var tempo = parseInt(s.play);
	}

	// Montagem do HTML
	$(this).find(' > div').addClass('' + s.nome + 'slidehide');
	var quantidade = $(this).find('div:last').index();
	if (s.local == 'depois') {
		$(this).append('<div class="' + s.nome + 'menu" />');
	} else {
		$(this).prepend('<div class="' + s.nome + 'menu" />');
	}

	// Começou a escrever o menu
	var menu = '<ul>\n';
	for (i = 0; i <= quantidade; i++) {
		var divid = $(this).find('div').eq(quantidade).attr('id');
		var menu = menu + '<li>' + (i + 1) + '</li>\n';
	}
	var menu = menu + '</ul>';
	$('.' + s.nome + 'menu').html(menu);
	// Acabou de escrever o menu
	
		// Inicio das Funcionalidades
	$('.' + s.nome + 'slidehide').not(':first').hide();
	$('.' + s.nome + 'menu ul li:first').addClass('' + s.nome + 'ativo');
	$('.' + s.nome + 'menu ul li').click(function () {
		var indice = $(this).index();
		$('.' + s.nome + 'slidehide').hide().eq(indice).fadeIn();
		$('.' + s.nome + 'ativo').removeClass();
		$(this).addClass('' + s.nome + 'ativo');
		$('.' + s.nome + 'slidehide:visible').addClass('' + s.nome + 'espera');
	});

	if (s.play != 'nao') {

		function proximo() {
			$('.' + s.nome + 'slidehide:visible').hide().addClass('' + s.nome + 'visivel');
			var item = ($('div.' + s.nome + 'slidehide.' + s.nome + 'visivel').index() + 1);
			if ((item - 1) == quantidade) {
				$('.' + s.nome + 'slidehide').hide().removeClass('' + s.nome + 'visivel');
				$('.' + s.nome + 'slidehide:first').fadeIn();
				$('.' + s.nome + 'menu ul li').removeClass('' + s.nome + 'ativo')
				$('.' + s.nome + 'menu ul li:first').addClass('' + s.nome + 'ativo');
			} else {
				$('.' + s.nome + 'menu ul li').removeClass('' + s.nome + 'ativo').eq(item).addClass('' + s.nome + 'ativo');
				$('.' + s.nome + 'visivel').removeClass('' + s.nome + 'visivel').next('.' + s.nome + 'slidehide').fadeIn();
			}
		}

		function verifica() {

			// Ver quanto tempo leva
			var classe = $('.' + s.nome + 'slidehide:visible').attr('class');
			var exp = RegExp(/slidetime-\d+/);
			var expdois = RegExp(/\d+/);
			var classe = exp.exec(classe);
			var tempo = parseFloat(expdois.exec(classe));

			if ($('.' + s.nome + 'slidehide:visible').is('.' + s.nome + 'espera')) {
				$('.' + s.nome + 'slidehide:visible').removeClass('' + s.nome + 'espera');
				clearInterval();
			} else {
				proximo();
			}
		}

		setInterval(verifica, tempo);
	}
};
