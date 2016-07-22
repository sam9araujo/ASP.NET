using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.Domain;
using Laboris.Cosan.Repository;
using Laboris.Cosan.UI.ViewWeb.Common;
using Laboris.Cosan.UI.Controller;

namespace Laboris.Cosan.UI.ViewWeb
{
    public partial class Redirect : BaseView<ParceiroController>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idParceiro;
            if (int.TryParse(Request.QueryString["idParceiro"], out idParceiro))
            {
                this.ImagemParceiro(int.Parse(Request.QueryString["idParceiro"]));
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.setTimeout(\"location.href='" + Controller.View.Parceiro.Link + "'\", 4000);</script>");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        private void ImagemParceiro(int idParceiro)
        {
            Controller.CarregarParceiro(idParceiro);
            Label1.Text = "<img runat='server' id='ImagemParceiro'  src='" + Controller.View.Parceiro.Imagem + "'/>";
        }
    }
}