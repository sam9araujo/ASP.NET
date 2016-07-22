var gUrlAjaxPrateleiraProdutos = "Controls/wsPrateleiraProdutos.asmx/GetPrateleiraProdutosAmbiente";

function sendData() {
    var parameters = new Object();

    parameters.idAmbiente = globalIdAmbiente;

    return JSON.stringify(parameters);
}
