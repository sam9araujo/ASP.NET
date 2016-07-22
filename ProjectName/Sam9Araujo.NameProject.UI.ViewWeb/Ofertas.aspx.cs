using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.Domain;

namespace Laboris.Cosan.UI.ViewWeb
{
	public partial class Ofertas : BaseView<OfertasController>
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            OrdenacaoProdutos1.Changed += new ViewWeb.Controls.ChangedEventHandler(ddlChanged);

            if (!IsPostBack)
            {
                OrdenacaoProdutos1.Popular();
                ListarOfertas();
            }
		}

        protected void ddlChanged(object sender, EventArgs e)
        {
            Response.Redirect("ofertas.aspx?ord=" + OrdenacaoProdutos1.ddlOrdem.SelectedIndex);
        }

        protected void ListarOfertas()
        {
            int total = 0;
            int ordemIndex;
            int.TryParse(Request.QueryString["ord"], out ordemIndex);
            OrdenacaoProdutos1.ddlOrdem.SelectedIndex = ordemIndex;

            Controller.CarregarProdutosOfertas(OrdenacaoProdutos1.Ordem, 1, 12, ref total);

            //Pager1.TotalRegistros = total;

            if (total > 0)
                OrdenacaoProdutos1.Visible = true;
            else
                OrdenacaoProdutos1.Visible = false;

            //Busca1.ListarProdutos(Controller.View.Produtos);
            PrateleiraProdutos1.ListarProdutos(Controller.View.Produtos);
        }
	}
}
