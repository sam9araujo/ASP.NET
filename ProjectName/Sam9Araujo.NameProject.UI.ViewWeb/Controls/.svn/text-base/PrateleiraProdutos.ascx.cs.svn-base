using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.Domain;
//using Laboris.Cosan.Repository;
using Laboris.Cosan.UI.ViewWeb.Common;

namespace Laboris.Cosan.UI.ViewWeb.Controls
{
    public partial class PrateleiraProdutos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AppRelativeTemplateSourceDirectory = "";
        }

        public void ListarProdutos(IList<Produto> produtos)
        {
            divContainerListaProdutos.InnerHtml = HtmlHelperPrateleiraProdutos.getHtml(produtos);
        }
/*
        private string GetHtmlPagina(IList<Produto> produtos, ref int p)
        {
            string htmlPrateleiras = "";

            for (int i = 0; i < 2 && p < produtos.Count; i++)
            {
                htmlPrateleiras += GetHtmlPrateleira(produtos, ref p);
            }

            return "<div class=\"li\">" + htmlPrateleiras + "</div>";
        }

        private string GetHtmlPrateleira(IList<Produto> produtos, ref int p)
        {
            string htmlProdutos = "";

            for (int i = 0; i < 3 && p < produtos.Count; i++, p++)
            {
                htmlProdutos += GetHtmlProduto(produtos[p]);
            }

            return "<div class=\"prateleira\">" + htmlProdutos + "</div>";
        }

        private string GetHtmlProduto(Produto produto)
        {
            Utils.listarParceiro(produto);
            string htmlProduto =
                "<div class=\"produto\">" +
                "	<img src=\"" + produto.ImagemThumbnail + "\" alt=\"\" />" +
                "	<div>" + Utilidade.RetornaFreteImagem(produto.Frete) +
                "		<h1>" + produto.Nome + "</h1>" +
                "		<p>" + produto.Preco.ToString("c") + " + " + produto.Pontos + " pontos</p>" +
                "		 <img src=" + produto.Parceiro.Imagem + ">" +
                "		<ul>" +
                "			<li><a href=\"#\" class=\"espiando\">espiar</a></li>" +
                "			<li><a href=\""+ Utilidade.ReplaceLink(produto.Link) + produto.IdProduto +"\">comprar</a></li>" +
                "		</ul>" +
                "		<div class=\"espiar\">" +
                "			<img src=\"img/close.png\" alt=\"\" />" +
                "			<h2>" + produto.Titulo + " <span>Cód. do Produto: " + produto.IdProduto + " </span></h2>" +
                "			<div>" +
                "				<img src=\"" + produto.ImagemThumbnail + "\" alt=\"\" />" +
                "				<img src=" + produto.Parceiro.Imagem + ">" +
                "			</div>" +
                "			<div>" +
                "				<p><strong>Sinopse:<br />" + produto.Titulo + "</strong></p>" +
                "				<span>" +
                "					De: " + produto.PrecoCheio.ToString("c") + "<br />" +
                "					Por: " + produto.Preco.ToString("c") + " + " + produto.Pontos + " + pontos" +
                "				</span>" +
                "			</div>" +
                "		</div>" +
                "	</div>" +
                "</div>";

            return htmlProduto;
        }
 */
    }
}



