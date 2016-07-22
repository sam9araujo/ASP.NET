using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboris.Cosan.UI.ViewWeb
{
    public class UsuarioLogado
    {
        public UsuarioLogado(Laboris.Cosan.Service.Omnion.Login omnionLogin, string senha)
        {
            _omnionLogin = omnionLogin;
            _senha = senha;
        }

        private Laboris.Cosan.Service.Omnion.Login _omnionLogin;
        public Laboris.Cosan.Service.Omnion.Login OmnionLogin
        {
            get { return _omnionLogin; }
            //set { _omnionLogin = value; }
        }

        private string _senha;

        public string SenhaMD5
        {
            get { return _senha; }
            //set { _senha = value; }
        }
    }
}