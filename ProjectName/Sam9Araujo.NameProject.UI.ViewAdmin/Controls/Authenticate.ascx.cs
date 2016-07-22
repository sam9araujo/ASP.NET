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
#endregion

namespace Laboris.Cosan.UI.ViewAdmin.Controls
{
    public partial class Authenticate : System.Web.UI.UserControl
    {
        #region Page__Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioLogado usuario = System.Web.HttpContext.Current.Session["Usuario"] as UsuarioLogado;
                if (usuario == null)
                {
                    this.Response.Redirect("~/AccessDenied.aspx");
                }
            }
        }
        #endregion
    }
}