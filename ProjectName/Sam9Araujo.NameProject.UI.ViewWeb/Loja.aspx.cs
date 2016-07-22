using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.Domain;
using Laboris.Cosan.UI.ViewWeb;

namespace ShoppingPontos
{
    public partial class Loja : BaseView<LojaController>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ambiente"]))
            {
                Controller.CarregarAmbiente(int.Parse(Request.QueryString["ambiente"]));
                LiteralDescricao.Text = Controller.View.AmbienteAtual.Descricao.ToString();
            }

        }
    }
}