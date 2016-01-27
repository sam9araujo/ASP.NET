using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OpenPop.Pop3;
using OpenPop.Mime;



namespace sam9araujo.WEB
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pop3Client pop = new Pop3Client();
            pop.Connect("email-ssl.com.br", 995,true);
            pop.Authenticate("your-email@email.com", "yourpassword");
            if (pop.Connected)
            {
                Int32 tot = pop.GetMessageCount();
                lblTotMessage.Text = "Conexão feito. Total Mensagem: " + tot.ToString();
               
                DataTable datatb = new DataTable();
                datatb.Columns.Add("MessageNumber");
                datatb.Columns.Add("From");
                datatb.Columns.Add("Subject");
                datatb.Columns.Add("DateSent");
                int counter = 0;
                for (int i = 1; i < tot; i++)
                {

                    Message message = pop.GetMessage(i);
                    datatb.Rows.Add();
                    datatb.Rows[datatb.Rows.Count - 1]["MessageNumber"] = i;
                    datatb.Rows[datatb.Rows.Count - 1]["Subject"] = message.Headers.Subject;
                    datatb.Rows[datatb.Rows.Count - 1]["DateSent"] = message.Headers.DateSent;
                    counter++;
                    if (counter > 20)
                    {
                        break;
                    }
                }
                
                gvTicket.DataSource = datatb;
                gvTicket.DataBind();
                 
            }

         
        }
    }
}