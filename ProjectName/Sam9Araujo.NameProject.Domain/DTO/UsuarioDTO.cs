#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - NameProject
 * http://www.NameProject.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 02/04/2011
 * Sam9araujo Consultoria Ltda.
 * http://www.Sam9araujo.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Sam9araujo.NameProject.Domain.DTO
{
    public class UsuarioDTO : BaseDTO
    {
        #region Fields
        private Usuario _usuario;
        private IList<Usuario> _usuarios;
        #endregion

        #region Properties

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public IList<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }
       
        #endregion
    }
}
