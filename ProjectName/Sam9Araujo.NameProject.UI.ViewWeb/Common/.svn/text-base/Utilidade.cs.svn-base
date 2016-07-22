using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboris.Cosan.Domain;
using System.Security.Principal;
using System.Web.Security;

namespace Laboris.Cosan.UI.ViewWeb.Common
{
    public class Utilidade
    {
        public static string RetornaFreteImagem(float frete)
        {
            string imagem = string.Empty;
            string link = HttpContext.Current.Request.Url.AbsolutePath;
            if (frete == 0)
            {
                if (link != "/Ambiente.aspx")
                {
                    imagem = "<img src='img/frete.png' alt=\"Frete Grátis\" />";
                }
                else
                {
                    imagem = "<img src='img/loja/frete.png' alt=\"Frete Grátis\" />";
                }
            }
            return imagem;
        }

        public static string GetUsuarioLogado()
        {
            string userData = "";
            
            // Get User Data from FormsAuthenticationTicket and show it in WelcomeBackMessage
            FormsIdentity ident = HttpContext.Current.User.Identity as FormsIdentity;            

            if (ident != null)
            {
                FormsAuthenticationTicket ticket = ident.Ticket;
                userData = ticket.UserData;
            }
            return userData;
        }

        //[Obsolete("Remover esse código, o link de produto deve estar no banco de dados")]
        //public static string GetProdutoLink1(int parceiro, int prodID)
        //{
        //    //TODO: o link de produto deve estar no banco de dados

        //    string link = "#";

        //    if (parceiro == 1)
        //        link = (@"http://www.submarino.com.br/CommonIncentiveProgram/default.aspx?Login=generico&token=f78be9eb051a8a009121dd79c16b655&partnerID=295810&RequestUrl=ProductDetail.aspx?ProdID=" + prodID);
        //    return link;

        //}

        public static string ReplaceLink(string link)
        {
            Laboris.Cosan.UI.ViewWeb.UsuarioLogado UsuarioLogado = HttpContext.Current.Session["UsuarioOmnion"] as Laboris.Cosan.UI.ViewWeb.UsuarioLogado;

            if (UsuarioLogado != null)
            {
                link = link.ToString().Replace("generico", UsuarioLogado.OmnionLogin.CPF);
                link = link.ToString().Replace("f78be9eb051a8a009121dd79c16b655e", UsuarioLogado.SenhaMD5);
            }


            return link.ToString();
        }


    }
}