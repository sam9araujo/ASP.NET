﻿using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Sam9araujo.NameProject.Service.Omnion
{
    public class LoginWrapper
    {
        #region Fields
        private HttpWebRequest _httpWebRequest;
        private HttpWebResponse _httpWebResponse;
        #endregion

        #region Automatic Properties
        /// <summary>
        /// Grava e recupera o CPF
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Grava e recupera a senha
        /// </summary>
        public string Senha { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Construtor padrão
        /// ; Inicializa o objeto HttpWebRequest com o URL do webservice de 'Login' do Omnion
        /// ; Inicializa o método de request como 'POST'
        /// ; Inicializa o tipo de conteúdo como 'application/x-www-form-urlencoded'
        /// </summary>
        public LoginWrapper()
        {
            this._httpWebRequest = WebRequest.Create(AppSettingsObject.Instance[AppSettingsObjectOption.OmnionLoginURL]) as HttpWebRequest;
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
            string queryString = "cpf=" + this.CPF + "&senha=" + this.Senha;
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

    public class OmnionLoginEngine
    {
        #region Singleton
        private static readonly OmnionLoginEngine _instance = new OmnionLoginEngine();

        /// <summary>
        /// Instância do objeto singleton
        /// </summary>
        public static OmnionLoginEngine Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Construtor privado do Singleton
        /// </summary>
        private OmnionLoginEngine() { }
        #endregion

        #region Public Methods
        public Login Get(string cpf, string senha)
        {
            LoginWrapper loginWrapper = new LoginWrapper { CPF = cpf, Senha = senha };
            return XmlToObject<Login>.Convert(loginWrapper.GetResponse());
        }
        #endregion
    }

}