using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.Domain;
using Laboris.Cosan.UI.ViewWeb.Common;

namespace Laboris.Cosan.UI.ViewWeb.Controls
{
    /// <summary>
    /// Summary description for wsPrateleiraProdutos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class wsPrateleiraProdutos : BaseWebServiceView<PrateleiraProdutosController>
    {
        [WebMethod(Description = "Retorna prateleira de produtos para carregamento dinâmico via Ajax.", EnableSession = true)]
        public string GetPrateleiraProdutosAmbiente(Dictionary<string, string> parameters, int page)
        {
            int size = 0;
            int start = 0;
            SetParametersPage(page, ref start, ref size);

            Controller.CarregarProdutosPorAmbiente(int.Parse(parameters["idAmbiente"]), start, size);
            return HtmlHelperPrateleiraProdutos.getHtml(Controller.View.Produtos);
        }

        [WebMethod(Description = "Retorna prateleira de produtos para carregamento dinâmico via Ajax.", EnableSession = true)]
        public string GetPrateleiraProdutosBusca(Dictionary<string, string> parameters, int page)
        {
            int size = 0;
            int start = 0;
            SetParametersPage(page, ref start, ref size);

            Controller.CarregarProdutosPorBusca(parameters["Texto"], int.Parse(parameters["PontosInicial"]), int.Parse(parameters["PontosFinal"]), decimal.Parse(parameters["ValorInicial"]), decimal.Parse(parameters["ValorFinal"]), bool.Parse(parameters["BuscarPorOfertas"]), start, size);

            return HtmlHelperPrateleiraProdutos.getHtml(Controller.View.Produtos);
        }

        [WebMethod(Description = "Retorna prateleira de produtos para carregamento dinâmico via Ajax.", EnableSession = true)]
        public string GetPrateleiraProdutosOfertas(Dictionary<string, string> parameters, int page)
        {
            int size = 0;
            int start = 0;
            SetParametersPage(page, ref start, ref size);

            Controller.CarregarProdutosOfertas(parameters["ordem"] ,start, size);

            return HtmlHelperPrateleiraProdutos.getHtml(Controller.View.Produtos);
        }

        private void SetParametersPage(int page, ref int start, ref int size)
        {
            size = 6;
            start = ((page - 1) * size) + 1;
        }
    }
}
