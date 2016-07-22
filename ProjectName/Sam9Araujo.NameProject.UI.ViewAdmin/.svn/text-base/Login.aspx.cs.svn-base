#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - Cosan
 * http://www.cosan.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 03/04/2011
 * Laboris Consultoria Ltda.
 * http://www.laboris.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Threading;
using System.Security.Principal;
using Laboris.Cosan.UI.Controller;

#endregion
namespace Laboris.Cosan.UI.ViewAdmin
{
    public partial class Login : BaseView<UsuarioController>
    {
        #region Page__Load
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UpdateLoginPanel(Request.IsAuthenticated);
        }
        #endregion

        #region Events
        protected void UpdateLoginPanel(bool IsAuthenticated)
        {
            if (IsAuthenticated)
            {
                if (UsuarioLogado != null)
                {
                    //msgLogin.InnerHtml = "Bem Vindo, " + UsuarioLogado.OmnionLogin.Nome + ", <br>" +
                    FormsAuthentication.RedirectFromLoginPage(this.txtLogin.Text, false);
                    this.Response.Redirect("~/Default.aspx");
                }
            }
        }
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (EfetuarLogin(this.txtLogin.Text, this.txtSenha.Text))
            {
                UpdateLoginPanel(true);
                Session["logado"] = Request.IsAuthenticated;

            }
            else
            {
                this.lblResultado.Visible = true;
            }
        }
        #endregion

        #region Private Methods
        public bool EfetuarLogin(string login, string senha)
        {
            bool validUsername = !string.IsNullOrEmpty(login);
            bool validPassword = !string.IsNullOrEmpty(senha); ;

            if (validUsername && validPassword)
            {
                Controller.LogarUsuario(login, senha);
                Domain.Usuario usuario = Controller.View.Usuario;

                if (usuario != null)
                {
                        this.RegistrarLogin(login, usuario, senha);
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

        public void RegistrarLogin(string login, Domain.Usuario usuario ,string senha)
        {
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(login, false);

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, usuario.Nome);

            authCookie.Value = FormsAuthentication.Encrypt(newTicket);
            authCookie.Path = FormsAuthentication.FormsCookiePath;

            Response.Cookies.Add(authCookie);

            IPrincipal p = new GenericPrincipal(new FormsIdentity(newTicket), null);

            // Attach the CustomPrincipal to HttpContext.User and Thread.CurrentPrincipal
            UsuarioLogado usuarioLogado = new UsuarioLogado(usuario, senha);
            HttpContext.Current.Session["Usuario"] = usuarioLogado;
            HttpContext.Current.User = p;
            Thread.CurrentPrincipal = p;
        }
        
        #endregion

        #region Properties 
        public UsuarioLogado UsuarioLogado
        {
            get
            {
                return HttpContext.Current.Session["Usuario"] as UsuarioLogado;
            }
        }
        #endregion
    }
}