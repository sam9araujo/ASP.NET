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

namespace Laboris.Cosan.UI.ViewWeb
{
    public partial class Portal : System.Web.UI.MasterPage
    {

        private string pagina = "Default.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            pagina = Request.Url.ToString();

            VerificarLoginExterno();

            VerificarMeusPedidos();

            this.UpdateLoginPanel(Request.IsAuthenticated);

            InitMasterPage();
        }

        private void VerificarLoginExterno()
        {
            try
            {
                if (Request.QueryString["login"] != null && Request.QueryString["senha"] != null)
                {

                    string senha = Request.QueryString["senha"].ToString();
                    string login = Request.QueryString["login"].ToString();

                    if (EfetuarLogin(login, senha))
                    {
                        RedirectParceiro(UsuarioOmnionLogado);
                        Response.Redirect(pagina);
                    }

                    //Response.Write("<script>alert('Bem vindo ao Shopping do Programa Pontos, para ter acesso as ofertas, é necessário completar seu cadastro no site www.programapontos.com.br, acessando no menu o item \"Atualizar Cadastro\".');location.href='http://www.programapontos.com.br/atualizar_cadastro.asp';</script>");
                }


            }
            catch //(Exception ex)
            {
                Response.Redirect(pagina, false);
            }
        }

        private void InitMasterPage()
        {
            String Path = this.Page.AppRelativeVirtualPath;
            String Link = Path.Substring(Path.IndexOf("/") + 1, (Path.Length - Path.IndexOf("/")) - 1).ToLower();
            switch (Link)
            {
                case "default.aspx":
                    slide.Attributes["class"] = "home";
                    LITSaudacao.Visible = true;
                    break;
                case "categoria.aspx":
                    LITSaudacao.Visible = false;
                    slide.Attributes["class"] = "loja";
                    break;
                default:
                    LITSaudacao.Visible = false;
                    slide.Attributes["class"] = "";
                    break;
            }
        }

        private void VerificarMeusPedidos()
        {
            if (UsuarioOmnionLogado != null)
            {
                menuMeusPedidos.Visible = true;
            }
            else
            {
                menuMeusPedidos.Visible = false;
            }
        }
        protected void UpdateLoginPanel(bool IsAuthenticated)
        {
            if (!IsAuthenticated)
            {
                PanelNotLoged.Visible = true;
                PanelLoged.Visible = false;
                linkLogout.Visible = false;
            }
            else
            {
                if (UsuarioOmnionLogado != null)
                {
                    msgLogin.InnerHtml = "Bem Vindo, " + UsuarioOmnionLogado.OmnionLogin.Nome + ", <br>" +
                                         "Você tem " + UsuarioOmnionLogado.OmnionLogin.Saldo + " pontos.";

                    PanelNotLoged.Visible = false;
                    PanelLoged.Visible = true;
                    linkLogout.Visible = true;
                }
                else
                {
                    PanelNotLoged.Visible = true;
                    PanelLoged.Visible = false;
                    linkLogout.Visible = false;
                }
            }
        }

        protected void btLogin_Click(object sender, ImageClickEventArgs e)
        {
            string cpf = txtCpf.Text.Replace(".", "").Replace("-", "");
            string senha = txtSenha.Text;

            if (EfetuarLogin(cpf, senha))
            {
                UpdateLoginPanel(true);
                RedirectParceiro(UsuarioOmnionLogado);
                Response.Redirect(pagina);
            }
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            this.EfetuarLogout();
            UpdateLoginPanel(false);
        }

        public bool EfetuarLogin(string cpf, string senha)
        {
            bool isLogado = LoginManager.Logar(cpf, senha, Response);
            menuMeusPedidos.Visible = isLogado;
            return isLogado;
        }

        public void EfetuarLogout()
        {
            LoginManager.Deslogar();

            menuMeusPedidos.Visible = false;
            Response.Redirect("Default.aspx");
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

        private string RedirectParceiro(UsuarioLogado usuario)
        {
            if (Request.QueryString["ProdID"] != null)
            {
                pagina = @"http://www.submarino.com.br/CommonIncentiveProgram/default.aspx?Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5 + "&partnerID=295810&RequestUrl=ProductDetail.aspx?ProdID=" + Request.QueryString["ProdID"].ToString();

                if (Request.QueryString["Parceiro"] != null)
                {
                    if (Request.QueryString["Parceiro"].ToString() == "2")
                    {
                        pagina = "redirectCupom.aspx?ProdID=" + Request.QueryString["ProdID"].ToString() + "&Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5;
                    }
                    else if (Request.QueryString["Parceiro"].ToString() == "4")
                    {
                        pagina = @"http://loja.autoguiagps.com.br/esso.aspx?Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5 + "&IdProductSale=" + Request.QueryString["IdProductSale"];
                    }
                    else if (Request.QueryString["Parceiro"].ToString() == "5")
                    {
                        pagina = @"https://fielo-cosan.secure.force.com/Login?Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5 + "&prodId=" + Request.QueryString["prodId"];
                    }

                    else if (Request.QueryString["Parceiro"].ToString() == "6")
                    {
                        pagina = @"http://www.maniavirtual.com.br/pontosprocessa.aspx?Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5 + "&prodId=" + Request.QueryString["prodId"];
                    }

                    else if (Request.QueryString["Parceiro"].ToString() == "7")
                    {
                        pagina = @"http://www.maniavirtual.com.br/pontosprocessa.aspx?Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5 + "&prodId=" + Request.QueryString["prodId"];
                    }

                }
            }
            else
            {
                if (Request.QueryString["Parceiro"] != null)
                {
                    if (Request.QueryString["Parceiro"].ToString() == "3")
                    {
                        pagina = @"http://www.imperdivel.com.br/programapontos/callback/?origem=cosan&Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5;
                    }
                    else if (Request.QueryString["Parceiro"].ToString() == "4")
                    {
                        pagina = @"http://loja.autoguiagps.com.br/esso.aspx?Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5 + "&IdProductSale=" + Request.QueryString["IdProductSale"];
                    }
                    else if (Request.QueryString["Parceiro"].ToString() == "5")
                    {
                        pagina = @"https://fielo-cosan.secure.force.com/Login?Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5;
                    }

                    else if (Request.QueryString["Parceiro"].ToString() == "6")
                    {
                        pagina = @"http://www.maniavirtual.com.br/pontosprocessa.aspx?Login=" + usuario.OmnionLogin.CPF + "&token=" + usuario.SenhaMD5;
                    }
                }
            }

            return pagina;
        }
    }
}