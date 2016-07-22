using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.Domain;
using System.Web.Services;

namespace Laboris.Cosan.UI.ViewWeb
{
    public partial class AmbienteAspx : BaseView<AmbienteController>
    {
        public string conteudo;
        protected void Page_Load(object sender, EventArgs e)
        {
            int idAmbiente;
            
            if (Request["id"] != null)
            {
                idAmbiente = int.Parse(Request["id"]);

                //RegisterStartupScript("globalAmbiente", "debugger; var globalIdAmbiente = " + idAmbiente);
                string script = "var globalIdAmbiente = " + idAmbiente + ";";
                ClientScript.RegisterStartupScript(this.GetType(), "jsGlobalVariables", script, true);

                Controller.CarregarListaProdutosOfertas(idAmbiente);
                Controller.CarregarAmbiente(idAmbiente);

                lblAmbienteAtual.InnerText = Controller.View.Ambiente.Descricao;

                ListarProdutoOfertas();
                RetornarImagemAmbiente(idAmbiente);
            }
        }

        private void ListarProdutoOfertas()
        {
            PrateleiraProdutos1.ListarProdutos(Controller.View.Produtos);
        }

        public void RetornarImagemAmbiente(int idAmbiente)
        {
            string img = "";
            string cor = "";

            switch (idAmbiente)
            {
                case 1:
                    img = "ImagensAmbientes/esportes.jpg";
                    cor = "#008A1B";
                    break;
                case 2:
                    img = "ImagensAmbientes/diversao.jpg";
                    cor = "#b4390b";
                    break;
                case 3:
                    img = "ImagensAmbientes/eletro.jpg";
                    cor = "#3B9FF4";
                    break;
                case 4:
                    img = "ImagensAmbientes/informatica.jpg";
                    cor = "#014B8A";
                    break;
                case 5:
                    img = "ImagensAmbientes/gastronomia.jpg";
                    cor = "#E7C42C";
                    break;
                case 6:
                    img = "ImagensAmbientes/telefonia.jpg";
                    cor = "#E65E2E";
                    break;
                default:
                    img = "ImagensAmbientes/telefonia.jpg";
                    break;
            }

           styleDinamicoBannerAmbiente.InnerHtml = "#slide.loja {background:" + cor + " url('img/slide/bgloja.png') repeat-x left bottom;}#slide.loja .in {min-height:167px; width:1154px; background: url('" + img + "') no-repeat left top;}";
           
        }

        [WebMethod]
        public static string wm()//int id, int page)
        {
            return "teste";
        }
    }
}
