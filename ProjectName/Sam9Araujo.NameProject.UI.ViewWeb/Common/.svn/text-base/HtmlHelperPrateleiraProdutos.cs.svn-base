using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboris.Cosan.Domain;
using Laboris.Cosan.Repository;

namespace Laboris.Cosan.UI.ViewWeb.Common
{
    public sealed class HtmlHelperPrateleiraProdutos
    {
        public static string getHtml(IList<Produto> produtos)
        {
            string htmlPaginas = "";
            int p = 0;

            while (p < produtos.Count)
            {
                htmlPaginas += GetHtmlPagina(produtos, ref p);
            }

            return htmlPaginas;
        }

        private static string GetHtmlPagina(IList<Produto> produtos, ref int p)
        {
            string htmlPrateleiras = "";

            for (int i = 0; i < 2 && p < produtos.Count; i++)
            {
                htmlPrateleiras += GetHtmlPrateleira(produtos, ref p);
            }

            return "<div class=\"li\">" + htmlPrateleiras + "</div>";
        }

        private static string GetHtmlPrateleira(IList<Produto> produtos, ref int p)
        {
            string htmlProdutos = "";

            for (int i = 0; i < 3 && p < produtos.Count; i++, p++)
            {
                htmlProdutos += GetHtmlProduto(produtos[p]);
            }

            return "<div class=\"prateleira\">" + htmlProdutos + "</div>";
        }

        private static string GetHtmlProduto(Produto produto)
        {
            Utils.listarParceiro(produto);
            string htmlProduto =
                "<div class=\"produto\">" +
                "	<img src=\"" + produto.ImagemThumbnail + "\" alt=\"\" />" +
                //"	<div>" + produto.Frete +
                "	<div>" + Utilidade.RetornaFreteImagem(produto.Frete) +
                "		<h1>" + produto.Nome + "</h1>" +
                "		<p>" + produto.Preco.ToString("c") + " + " + produto.Pontos + " pontos</p>" +
                "		 <img src=" + produto.Parceiro.Imagem + ">" +
                "		<ul>" +
                "			<li><a href=\"#\" class=\"espiando\">espiar</a></li>" +
                "			<li><a href=\"" + Utilidade.ReplaceLink(produto.Link) + "\">comprar</a></li>" +
                //"			<li><a href=\"" + produto.Link + produto.IdProduto + "\">comprar</a></li>" +
                "		</ul>" +
                "		<div class=\"espiar\">" +
                "			<img src=\"img/close.png\" alt=\"\" class=\"imgBtFecharEspiar\" />" +
                "			<h2>" + produto.Titulo + " <span>Cód. do Produto: " + produto.IdProduto + " </span></h2>" +
                "			<div>" +
                "				<img src=\"" + produto.ImagemThumbnail + "\" alt=\"\" />" +
                "				<img src=" + produto.Parceiro.Imagem + ">" +
                "			</div>" +
                "			<div>" +
                "				<p><strong>Sinopse:<br />" + produto.Nome + "</strong></p>" +
                "				<span>" +
                "					De: " + produto.PrecoCheio.ToString("c") + "<br />" +
                "					Por: " + produto.Preco.ToString("c") + " + " + produto.Pontos + " + pontos" +
                "				</span>" +
                "               <br/>" +
                "               <br/>" +
                "               <br/>" +
                "               <br/>" +
                "               <p class='comprar'><img class='imgComprar' src='/img/loja/comprar.png'/><a class='linkComprar' href=\"" + Utilidade.ReplaceLink(produto.Link) + "\">comprar</a></p>" +
                "			</div>" +
                "		</div>" +
                "	</div>" +
                "</div>";

            return htmlProduto;
        }

    }
}