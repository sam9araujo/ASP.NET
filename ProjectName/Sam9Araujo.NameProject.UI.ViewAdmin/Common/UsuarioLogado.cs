#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - Cosan
 * http://www.cosan.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 03/04/2011
 * Laboris Consultoria Ltda.
 * http://www.laboris.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Laboris.Cosan.UI.ViewAdmin
{
    public class UsuarioLogado
    {
        #region Fields
        private Laboris.Cosan.Domain.Usuario _usuario;
        private string _senha;
        #endregion

        #region Properties
        public UsuarioLogado(Laboris.Cosan.Domain.Usuario usuario, string senha)
        {
            _usuario = usuario;
            _senha = senha;
        }

        public Laboris.Cosan.Domain.Usuario Usuario
        {
            get { return _usuario; }
        }

        public string Senha
        {
            get { return _senha; }
        }
        #endregion
    }
}