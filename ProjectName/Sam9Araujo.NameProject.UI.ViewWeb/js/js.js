
$(function () {

    // DEVE SER EXECUTADO PRIMEIRO - Máscaras dos controles de entrada de dados

    $("#login .cpf").mask("999.999.999-99", { placeholder: "_" });

    //$("input.datainicial").inputmask("d/m/y");
    $("input.datainicial").mask("99/99/9999", { placeholder: "_" });
    $("input.datafinal").mask("99/99/9999", { placeholder: "_" }); //

    var text = 'Digite o número do pedido';
    $("input.numero")
    .val(text)
    .focus(function () {
        $(this).inputmask({ "mask": "9", "repeat": 9, "greedy": false });
    })
    .blur(function () {
        //$(this).unmask();
        if ($(this).val() == '') {
            $(this)[0].value = text;
        }
    });

    var text1 = 'Digite a data inicial';
    $('input.datainicial').val(text1).focus(function () {
        if ($(this).val() == text1) { $(this).val(''); }
    }).blur(function () {
        if ($(this).val() == '') { $(this).val(text1); }
    });

    var text2 = 'Digite a data final';
    $('input.datafinal').val(text2).focus(function () {
        if ($(this).val() == text2) { $(this).val(''); }
    }).blur(function () {
        if ($(this).val() == '') { $(this).val(text2); }
    });

    var text3 = 'CPF';
    $('#login .cpf').val(text3).focus(function () {
        if ($(this).val() == text3) { $(this).val(''); }
    }).blur(function () {
        if ($(this).val() == '') { $(this).val(text3); }
    });

    var text4 = 'Senha';
    $('#login .senha').val(text4).focus(function () {
        if ($(this).val() == text4) { $(this).val(''); }
    }).blur(function () {
        if ($(this).val() == '') { $(this).val(text4); }
    });


    $(".home .hid + div").addClass("aberto");
    $(".home .hid + div").find("span").html("fechar");
    $(".hid + div").click(function () {
        $(".hid").slideToggle(function () {
            $(".hid + div").removeClass();
            if ($(".hid").is(":visible")) {
                $(".hid + div").addClass("aberto");
                $(".hid + div").find("span").html("fechar");
            } else {
                $(".hid + div").addClass("fechado");
                $(".hid + div").find("span").html("abrir");
            }
        });
    });

    $("#dois").slideshow({ 'nome': 'dizaindois' });
    $("#tres").slideshow();

    $("#topo ul li").hover(
		function () { $(this).find("> div").show(); },
		function () { $(this).find("> div").hide(); });

    var pAccept;

    //if (document.getElementById("divFavItensAmbiente")) {
    pAccept = ".ambiente > a";
    //} else if (document.getElementById("divFavItensProduto")) {
    //    pAccept = ".produto";
    //}

    var $gallery = $(pAccept), $trash = $("#fav div");

    $gallery.draggable({
        cancel: "a.ui-icon",
        revert: "invalid",
        activeClass: "custom-state-active",
        cursorAt: { top: -12, left: -20 },
        helper: function (event) {
            return $("<div class='ui-widget-header'>" + $(this).html() + "</div>");
        }

    });

    $trash.droppable({
        accept: pAccept,
        activeClass: "ui-state-highlight",
        drop: function (event, ui) {
            var antes = $(this).html();
            if (antes == "0 Itens") { var antes = ""; }
            var error = false;
            $(this).find("p").each(function () {
                if ($(this).text() == ui.draggable.html()) {
                    error = true;
                }
            });
            //if (error) { var html = "" } else { var html = "<p><a href='#'>" + ui.draggable.html() + "</a><span>[x]</span></p>" }
            //$(this).html(antes + html);
            if (!error)
                setFavItem(ui.draggable.html(), ui.draggable[0].href);
        }
    });

    $("#temas .next, #temas .prev").hover(
		function () {
		    var text = $(this).find("img").attr("alt");
		    $("body").prepend("<div class='tooltip'>" + text + "</div>");
		    $(".tooltip").css({
		        'position': 'absolute',
		        'float': 'left',
		        'width': '100px',
		        'height': '36px',
		        'z-index': '99999',
		        'background': 'url("img/loja/balao.png") no-repeat left top',
		        'color': '#000',
		        'text-align': 'center',
		        'font': 'bold 10px/14px Arial, sans-serif',
		        'padding': '2px 8px 6px 8px'
		    });
		    $("html").mousemove(function (mouse) {
		        mousex = mouse.pageX;
		        mousey = mouse.pageY;
		        $(".tooltip").css({ 'left': (mousex - 56) + 'px', 'top': (mousey - 54) + 'px' });
		    });
		},
		function () {
		    $(".tooltip").remove();
		}
	);

    $('#temas .next').click(slideToNextCategoria);
    $('#temas .prev').click(slideToPreviousCategoria);

    var slideCategoriaInterval;

    $("#temas .next").hover(
		function () {
		    slideCategoriaInterval = setInterval(slideToNextCategoria, 500);
		},
		function () {
		    clearInterval(slideCategoriaInterval);
		}
	);
    $("#temas .prev").hover(
		function () {
		    slideCategoriaInterval = setInterval(slideToPreviousCategoria, 500);
		},
		function () {
		    clearInterval(slideCategoriaInterval);
		}
	);

});

// SLIDE SHOW DO BANNER DE PARCEIROS

function slideSwitch() {
    var $activeA = $('.slideshow a.active');
    var $activeIMG = $activeA.children('img');

    $activeA.addClass('last-active');

    // verifica se existe um próximo objeto na div #slideshow, caso ele nao exista, retorna para o primeiro
    var $nextA = $activeA.next('a').length ? $activeA.next('a') : $('.slideshow a:first');
    var $nextIMG = $nextA.children('img');

    // Codigo que define as transicoes entre as imagens
    $nextIMG.css({ opacity: 0.0 });
    $nextA.addClass('active');
    $nextIMG.animate({ opacity: 1.0 }, 1000, function () {
            $activeA.removeClass('active last-active');
        });
}

$(function () {
    //Executa a função a cada 5 segundos
    setInterval("slideSwitch()", 5000);
});

function slideToNextCategoria() {
    var last = $('#temas ul li:last').index();
    var last = ((last - 8) * 209);
    var lefts = parseFloat($('#temas ul').css('left').replace('px', ''));
    if (isNaN(lefts)) { var lefts = 0; }
    if (!$('#temas ul').hasClass('ativo')) {
        if (lefts > last) {
            $('#temas ul').addClass('ativo');
            $('#temas ul').animate({ left: '-=209px' }, 200, function () { $('#temas ul').removeClass('ativo'); });
        } else {
            $('#temas ul').css('left', '' + last + 'px');
        }
    }
    return false;
}

function slideToPreviousCategoria() {
    var lefts = parseFloat($('#temas ul').css('left').replace('px', ''));
    if (!$('#temas ul').hasClass('ativo')) {
        if (lefts < 0) {
            $('#temas ul').addClass('ativo');
            $('#temas ul').animate({ left: '+=209px' }, 200, function () { $('#temas ul').removeClass('ativo'); });
        } else {
            $('#temas ul').css('left', '0px');
        }
    }
    return false;
}
