using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboris.Cosan.UI.ViewWeb.Common;
using System.Threading;
using System.Security.Principal;
using System.Web.Security;

namespace Laboris.Cosan.UI.ViewWeb
{
    public class LoginManager
    {
        public static bool Logar(string cpf, string senha, HttpResponse Response)
        {
            bool isLogado = false;
            
            Laboris.Cosan.Service.Omnion.Login usuarioOmnion = null;

            bool validUsername = !string.IsNullOrEmpty(cpf);
            bool validPassword = !string.IsNullOrEmpty(senha);

            if (validUsername && validPassword)
            {
                senha = Service.Cryptography.HasherMD5(senha);
                usuarioOmnion = Laboris.Cosan.Service.Omnion.OmnionLoginEngine.Instance.Get(cpf, senha);

                if (usuarioOmnion != null)
                {
                    isLogado = true;

                    RegistrarLogin(cpf, usuarioOmnion, senha, Response);
                }
            }

            return isLogado;
        }

        public static void RegistrarLogin(string cpf, Laboris.Cosan.Service.Omnion.Login usuarioOmnion, string senha, HttpResponse Response)
        {
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(cpf, false);

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, usuarioOmnion.Nome);

            authCookie.Value = FormsAuthentication.Encrypt(newTicket);
            authCookie.Path = FormsAuthentication.FormsCookiePath;

            Response.Cookies.Add(authCookie);

            IPrincipal p = new GenericPrincipal(new FormsIdentity(newTicket), null);

            UsuarioLogado usuarioLogado = new UsuarioLogado(usuarioOmnion, senha);
            HttpContext.Current.Session["UsuarioOmnion"] = usuarioLogado;
            HttpContext.Current.User = p;
            Thread.CurrentPrincipal = p;
        }

        public static void Deslogar()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Remove("UsuarioOmnion");
        }


    }

}