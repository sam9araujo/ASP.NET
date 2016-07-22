using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Principal;
using System.Threading;
using Laboris.Cosan.UI.ViewWeb.Common;

namespace Laboris.Cosan.UI.ViewWeb.Controls
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.AppRelativeTemplateSourceDirectory = "";
            this.UpdateLoginPanel(Request.IsAuthenticated);
        }

        protected void UpdateLoginPanel(bool IsAuthenticated)
        {
            if (!IsAuthenticated)
            {
                PanelNotLoged.Visible = true;
                PanelLoged.Visible = false;
            }
            else
            {
                if (UsuarioOmnionLogado != null)
                {
                    msgLogin.InnerHtml = "Bem Vindo, " + UsuarioOmnionLogado.OmnionLogin.Nome + ", <br>" +
                                         "Você tem " + UsuarioOmnionLogado.OmnionLogin.Saldo + " pontos.";

                    PanelNotLoged.Visible = false;
                    PanelLoged.Visible = true;
                }
                else
                {
                    PanelNotLoged.Visible = true;
                    PanelLoged.Visible = false;                
                }
            }
        }

        protected void btLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (EfetuarLogin(txtCpf.Text, txtSenha.Text))
            {
                UpdateLoginPanel(true);
                Session["logado"] = Request.IsAuthenticated;

            }
            else
            {

            }
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            this.EfetuarLogout();
            UpdateLoginPanel(false);
        }

        public bool EfetuarLogin(string cpf, string senha)
        {
            bool validUsername = !string.IsNullOrEmpty(cpf);
            bool validPassword = !string.IsNullOrEmpty(senha); ;

            if (validUsername && validPassword)
            {
                senha = Service.Cryptography.HasherMD5(senha);                
                Laboris.Cosan.Service.Omnion.Login usuarioOmnion = Laboris.Cosan.Service.Omnion.OmnionLoginEngine.Instance.Get(cpf, senha);

                if (usuarioOmnion != null)
                {
                    if (usuarioOmnion.CodigoErro == 0)
                    {
                        this.RegistrarLogin(cpf, usuarioOmnion, senha);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public void EfetuarLogout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Remove("UsuarioOmnion");
        }

        public void RegistrarLogin(string cpf, Laboris.Cosan.Service.Omnion.Login usuarioOmnion, string senha)
        {
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(cpf, false);

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, usuarioOmnion.Nome);

            authCookie.Value = FormsAuthentication.Encrypt(newTicket);
            authCookie.Path = FormsAuthentication.FormsCookiePath;

            Response.Cookies.Add(authCookie);

            IPrincipal p = new GenericPrincipal(new FormsIdentity(newTicket), null);

            // Attach the CustomPrincipal to HttpContext.User and Thread.CurrentPrincipal
            UsuarioLogado usuarioLogado = new UsuarioLogado(usuarioOmnion, senha);
            HttpContext.Current.Session["UsuarioOmnion"] = usuarioLogado;
            HttpContext.Current.User = p;
            Thread.CurrentPrincipal = p;

            //string redirUrl = FormsAuthentication.GetRedirectUrl(txtCpf.Text, false);
            /*
            IPrincipal usr = HttpContext.Current.User;

            FormsIdentity fIdent = usr.Identity as FormsIdentity;
            */
        }

        public string UsuarioNome
        {
            get
            {
                return Utilidade.GetUsuarioLogado();
            }
        }

        public string UsuarioCpf
        {
            get
            {
                return Page.User.Identity.Name;
            }
        }

        public UsuarioLogado UsuarioOmnionLogado
        {
            get
            {
                return HttpContext.Current.Session["UsuarioOmnion"] as UsuarioLogado;
            }
        }

    }
}
