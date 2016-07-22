using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Configuration;
using System.IO;

namespace Sam9araujo.NameProject.Service.Omnion.WebService
{
    internal class Logger
    {
        internal static void Log(string arquivo, string mensagem, bool cabecalho, bool rodape)
        {
            if (cabecalho)
            {
                File.AppendAllText(arquivo, DateTime.Now + Environment.NewLine);
            }

            File.AppendAllText(arquivo, mensagem + Environment.NewLine);

            if (rodape)
            {
                File.AppendAllText(arquivo, "--------------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        internal static void WriteLogError(string page, Exception exception)
        {
            try
            {
                string message = MessageGenerateByException(exception);

                string path = ConfigurationManager.AppSettings["LogPath"].Replace("[data]", DateTime.Now.ToShortDateString().Replace("/", ""));
                File.AppendAllText(path, message);
            }
            catch { }
        }
        private static string MessageGenerateByException(Exception exception)
        {
            Exception ex = exception;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine("Message:");
            sb.AppendLine(ex.Message);
            sb.AppendLine("");
            sb.AppendLine("Source:");
            sb.AppendLine(ex.Source);
            sb.AppendLine("");
            sb.AppendLine("StackTrace:");
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine("");

            ex = ex.InnerException;

            while (ex != null)
            {
                sb.AppendLine("InnerException:");
                sb.AppendLine(ex.ToString());
                sb.AppendLine("");

                ex = ex.InnerException;
            }

            return sb.ToString();
        } 
    }
}