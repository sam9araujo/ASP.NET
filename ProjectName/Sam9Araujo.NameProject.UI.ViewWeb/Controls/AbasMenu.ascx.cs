using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboris.Cosan.UI.ViewWeb.Controls
{
    public partial class AbasMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Path = this.Page.AppRelativeVirtualPath;
            String Link = Path.Substring(Path.IndexOf("/") + 1, (Path.Length - Path.IndexOf("/")) - 1).ToLower();

            switch (Link)
            {
                case "ofertas.aspx":
                    mnuAbaOfertas.Attributes.Add("class", "hover");
                    break;
                case "busca.aspx":
                    mnuAbaBusca.Attributes.Add("class", "hover");
                    break;
                default:
                    mnuAbaCategoria.Attributes.Add("class", "hover");
                    break;
            }

        }
       
    }
}
