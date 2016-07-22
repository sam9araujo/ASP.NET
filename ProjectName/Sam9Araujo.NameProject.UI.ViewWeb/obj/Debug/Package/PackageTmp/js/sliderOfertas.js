var gUrlAjaxPrateleiraProdutos = "Controls/wsPrateleiraProdutos.asmx/GetPrateleiraProdutosOfertas";

function sendData() {
    var parameters = new Object();
    
    parameters.ordem = $(".ordemCombo")[0].value;

    return JSON.stringify(parameters);
}
