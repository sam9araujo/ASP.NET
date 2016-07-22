var goSlidePagingPrateleiraProdutos = new SlidePaging();

$(function () {
    
    registerActionEspiar();

    //Inicializa total de páginas da prateleira de produtos - retornadas inicialmente direto do aspx.
    var totalPaginasPrateleiraProdutos = $('#loja div.ul div.li').length;

    //Inicializa página atual da prateleira de produtos
    if (totalPaginasPrateleiraProdutos)
        var paginaAtualPrateleiraProdutos = 1;
    else
        var paginaAtualPrateleiraProdutos = 0;

    goSlidePagingPrateleiraProdutos.url = gUrlAjaxPrateleiraProdutos;
    goSlidePagingPrateleiraProdutos.htmlContainer = $('#loja div.ul')[0];
    goSlidePagingPrateleiraProdutos.delegateDataReceived = registerActionEspiar;
    goSlidePagingPrateleiraProdutos.delegateGetJsonSendData = sendData;
    goSlidePagingPrateleiraProdutos.stringSearchForValidationDataReceived = "<div class=\"li\">";
    goSlidePagingPrateleiraProdutos.nextButton = $('#loja .next');
    goSlidePagingPrateleiraProdutos.previousButton = $('#loja .prev');
    goSlidePagingPrateleiraProdutos.delegateSlideToNextPage = slideToNextPagePrateleiraProdutos;
    goSlidePagingPrateleiraProdutos.delegateSlideToPreviousPage = slideToPreviousPagePrateleiraProdutos;

    goSlidePagingPrateleiraProdutos.start(paginaAtualPrateleiraProdutos, totalPaginasPrateleiraProdutos);
});

function slideToNextPagePrateleiraProdutos() {
    goSlidePagingPrateleiraProdutos.lockPageChange();
    $('#loja div.ul').addClass('ativo');
    $('#loja div.ul').css('width', (parseFloat($('#loja div.ul').css('width').replace('px', '')) + 646) + 'px');
    $('#loja div.ul').animate({ left: "-=646px" }, 400, function () { $('#loja div.ul').removeClass('ativo'); goSlidePagingPrateleiraProdutos.unlockPageChange(); });
}

function slideToPreviousPagePrateleiraProdutos() {
    var lefts = parseFloat($('#loja div.ul').css('left').replace('px', ''));

    if (!$('#loja div.ul').hasClass('ativo')) {
        if (lefts < 0) {
            goSlidePagingPrateleiraProdutos.lockPageChange();
            $('#loja div.ul').addClass('ativo');
            $('#loja div.ul').animate({ left: '+=646px' }, 400, function () { $('#loja div.ul').removeClass('ativo'); goSlidePagingPrateleiraProdutos.unlockPageChange(); });
        } else {
            $('#loja div.ul').css('left', '0px');
        }
    }
}

function registerActionEspiar() {
    $(".espiando").die("click", exibirEspiar);
    $(".espiando").live("click", exibirEspiar);

    $(".imgBtFecharEspiar").die("click", ocultarEspiar);
    $(".imgBtFecharEspiar").live("click", ocultarEspiar);
}

function exibirEspiar() {
    if (!$(".espiar").is(":visible")) {
        var divEspiarProduto = $(this).parent().parent().next(".espiar");
        var left;
        var pageLeft;

        if (divEspiarProduto.attr("leftIsSetted") != "true") {
            left = parseFloat(divEspiarProduto.css('left').replace('px', ''));
            pageLeft = parseFloat($('#loja div.ul').css('left').replace('px', '')) * -1;
            //pageLeft = divEspiarProduto.parent().parent().parent()[0].offsetLeft;

            divEspiarProduto[0].style.left = pageLeft + left + 'px';
            divEspiarProduto.attr("leftIsSetted", "true");
        }
        goSlidePagingPrateleiraProdutos.lockPageChange();
        divEspiarProduto.fadeIn();
    }
    return false;
}

function ocultarEspiar() {
    $(this).parent().fadeOut();
    goSlidePagingPrateleiraProdutos.unlockPageChange();
}
