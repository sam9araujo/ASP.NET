var gUrlAjaxPrateleiraProdutos = "Controls/wsPrateleiraProdutos.asmx/GetPrateleiraProdutosBusca";
var parameters = new Object();
parameters.isSeted = false;

function sendData() {

    if (!parameters.isSeted) {
        
        parameters.Texto = $(".TextBoxBusca")[0].value;

        if ($(".TextBoxPontoIn").length > 0)
            parameters.PontosInicial = $(".TextBoxPontoIn")[0].value;
        else
            parameters.PontosInicial = 0;

        if ($(".TextBoxPontoFin").length > 0)
            parameters.PontosFinal = $(".TextBoxPontoFin")[0].value;
        else
            parameters.PontosFinal = 0;

        if ($(".TextBoxprecoInicial").length > 0)
            parameters.ValorInicial = $(".TextBoxprecoInicial")[0].value;
        else
            parameters.ValorInicial = 0;

        if ($(".TextBoxPrecoFinal").length > 0)
            parameters.ValorFinal = $(".TextBoxPrecoFinal")[0].value;
        else
            parameters.ValorFinal = 0;

        parameters.BuscarPorOfertas = $("#Content_CheckBoxofertas")[0].checked;

        parameters.isSeted = true;
    }

    return JSON.stringify(parameters);
}
