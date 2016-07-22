using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.Domain;
using Laboris.Cosan.Repository;
using Laboris.Cosan.UI.ViewWeb.Common;

namespace Laboris.Cosan.UI.ViewWeb.Controls
{
    public partial class Busca : System.Web.UI.UserControl
    {
        public string conteudo;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AppRelativeTemplateSourceDirectory = "";
        }

        public void ListarProdutos(IList<Produto> produtos)
        {
            //TODO: porque existe classe utils em repository?
            //TODO: o link de produto deve estar no banco de dados

            for (int i = 0; i < produtos.Count(); i++)
            {
                Utils.listarParceiro(produtos[i]);
                /*
                conteudo += "<div><a href=" + Utilidade.GetProdutoLink(produtos[i].Parceiro.IdParceiro, produtos[i].IdProduto) + "><img src=" + produtos[i].ImagemThumbnail + " alt=" + produtos[i].Nome + " />" +
                            "<img src=" + produtos[i].Parceiro.Imagem + ">" +
                            Utilidade.RetornaFreteImagem(produtos[i].Frete) +
                            "<p>" + produtos[i].Nome + "</p>" +
                            "<span>Por: " + produtos[i].Preco.ToString("c") + " + " + produtos[i].Pontos + " pontos</span><img src='img/detalhes.png' alt='' /></a></div>";
                 */
                conteudo += "<div class='textLeft'><a href=" + produtos[i].Link + "><img src=" + produtos[i].ImagemThumbnail + " alt=" + produtos[i].Nome + " />" +
                            "<img src=" + produtos[i].Parceiro.Imagem + ">" +
                            Utilidade.RetornaFreteImagem(produtos[i].Frete) +
                            "<p class='textLeft'>" + produtos[i].Nome + "</p>" +
                            "<span class='textLeft'>Por: " + produtos[i].Preco.ToString("c") + " + " + produtos[i].Pontos + " pontos</span><img src='img/detalhes.png' alt='' /></a></div>";

            }
        }

    }
}