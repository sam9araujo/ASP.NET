using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboris.Cosan.UI.ViewWeb.Controls
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public partial class OrdenacaoProdutos : System.Web.UI.UserControl
    {
        public event ChangedEventHandler Changed;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Popular()
        {
            ddlOrdem.Items.Add(new ListItem("Nome A-Z", "nome ASC", true));
            ddlOrdem.Items.Add(new ListItem("Nome Z-A", "nome DESC", true));
            ddlOrdem.Items.Add(new ListItem("Mais Pontos", "pontos DESC", true));
            ddlOrdem.Items.Add(new ListItem("Menos Pontos", "pontos ASC", true));
            ddlOrdem.Items.Add(new ListItem("Maior Preço", "preco DESC", true));
            ddlOrdem.Items.Add(new ListItem("Menor Preço", "preco ASC", true));
        }

        public string Ordem
        {
            get
            {
                if (ddlOrdem.SelectedIndex > 0)
                    return ddlOrdem.SelectedValue;
                else
                    return "nome";
            }
        }

        protected void ddlOrdem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Changed(sender, e);
        }

    }
}
