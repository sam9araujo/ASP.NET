#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - Cosan
 * http://www.cosan.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 25/08/2010
 * Laboris Consultoria Ltda.
 * http://www.laboris.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
#endregion

namespace Laboris.Cosan.Service.Omnion
{
    public class SaldoWrapper
    {
        #region Fields
        private HttpWebRequest _httpWebRequest;
        private HttpWebResponse _httpWebResponse;
        #endregion

        //id=13&pontos=2&valor=40&cpf=9245686868

        #region Automatic Properties
        /// <summary>
        /// Grava e recupera o CPF
        /// </summary>
        public string CPF { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Construtor padrão
        /// ; Inicializa o objeto HttpWebRequest com o URL do webservice de 'Login' do Omnion
        /// ; Inicializa o método de request como 'POST'
        /// ; Inicializa o tipo de conteúdo como 'application/x-www-form-urlencoded'
        /// </summary>
        public SaldoWrapper()
        {
            this._httpWebRequest = WebRequest.Create(AppSettingsObject.Instance[AppSettingsObjectOption.OmnionSaldoURL]) as HttpWebRequest;
            this._httpWebRequest.Method = "POST";
            this._httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Recupera o XML do webservice
        /// </summary>
        /// <returns>XmlReader com o stream do HttpWebResponse</returns>
        public XmlReader GetResponse()
        {
            string queryString = "cpf=" + this.CPF;
            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            byte[] data = asciiEncoding.GetBytes(queryString);
            this._httpWebRequest.ContentLength = data.Length;
            Stream stream = this._httpWebRequest.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            this._httpWebResponse = this._httpWebRequest.GetResponse() as HttpWebResponse;
            return XmlTextReader.Create(this._httpWebResponse.GetResponseStream());
        }
        #endregion
    }
}
