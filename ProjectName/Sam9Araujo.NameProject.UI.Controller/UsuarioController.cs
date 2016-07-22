#region Document Header

/******************************************************************************
 * e-Commerce - Versão 2
 * Copyright (C)2011 - NameProject
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
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;
#endregion

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class UsuarioController : BaseController<UsuarioDTO>
    {
        public UsuarioController()
        {

        }

        public void LogarUsuario(string login, string senha)
        {
            View.Usuario = UsuarioRepository.Instance.ConsultarUsuario(login, senha);
        }

        public void CarregaUsuario(int idUsuario)
        {
            View.Usuario = UsuarioRepository.Instance.ConsultarUsuario(idUsuario);
        }

        public void CarregarListaUsuarios()
        {
            View.Usuarios = UsuarioRepository.Instance.Listar();
        }

        public int Incluir(Usuario usuario)
        {
            return UsuarioRepository.Instance.Insert(usuario);
        }

        public int Atualizar(Usuario usuario)
        {
            return UsuarioRepository.Instance.Update(usuario);
        }

        public void Listar(string where)
        {
            View.Usuarios = UsuarioRepository.Instance.Listar(where);
        }
    }
}
