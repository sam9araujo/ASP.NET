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
using Laboris.Cosan.UI.Controller;
#endregion

namespace Laboris.Cosan.UI.ViewAdmin
{
    public partial class UsuarioDetalhe : BaseView<UsuarioController>
    {
        #region Page__Load
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;

            if (int.TryParse(this.Request.QueryString["u"], out id))
            {
                Controller.CarregaUsuario(id);
                this.CarregaCampos();
            }
        }
        #endregion

        #region Events
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int result;
            bool isInsert;

            Domain.Usuario usuario = new Domain.Usuario();
            usuario.Nome = this.txtNome.Text;
            usuario.Email = this.txtEmail.Text;
            usuario.Login = this.txtLogin.Text;
            usuario.Senha = this.txtSenha.Text;
            usuario.IsAtivo = this.chkAtivo.Checked;
            usuario.DataCadastro = DateTime.Now;

            if (Controller.View.Usuario != null)
            {
                isInsert = false;
                result = Controller.Atualizar(usuario);
            }
            else
            {
                isInsert = true;
                result = Controller.Incluir(usuario);
            }

            if (result.Equals(1))
            {
                this.pnlCadastro.Visible = false;
                this.pnlResultado.Visible = true;
                this.lblResultadoInsercacao.Text = "Registro atualizado com sucesso!";
            }
            else
            {
                this.pnlCadastro.Visible = false;
                this.pnlResultado.Visible = true;
                this.lblResultadoInsercacao.Text = string.Format("Falha ao {0} o registro", isInsert ? "inserir" : "atualizar");
            }

        }
        #endregion

        #region Private Methods
        private void CarregaCampos()
        {
            Domain.Usuario usuario = Controller.View.Usuario;

            this.txtNome.Text = usuario.Nome;
            this.txtEmail.Text = usuario.Email;
            this.txtLogin.Text = usuario.Login;
            this.txtSenha.Text = usuario.Senha;
            this.chkAtivo.Checked = usuario.IsAtivo;
        }
        #endregion
    }
}