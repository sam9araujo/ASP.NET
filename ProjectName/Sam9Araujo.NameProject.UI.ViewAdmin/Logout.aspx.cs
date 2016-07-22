#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - Cosan
 * http://www.cosan.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 18/03/2011
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

namespace Laboris.Cosan.UI.ViewAdmin
{
    public partial class Logout : System.Web.UI.Page
    {
        #region Page__Load
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["Usuario"] = null;
            System.Web.Security.FormsAuthentication.SignOut();
            this.Response.Redirect("~/Login.aspx");
        }
        #endregion
    }
}