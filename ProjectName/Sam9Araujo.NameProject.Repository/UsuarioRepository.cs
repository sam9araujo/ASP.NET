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
using Sam9araujo.NameProject.Repository.DAL;
using Sam9araujo.NameProject.Domain;
#endregion

namespace Sam9araujo.NameProject.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario, UsuarioDAL, UsuarioRepository>, IRepositoryBase
    {
        private static UsuarioDAL UsuarioDAL
        {
            get { return Singleton<UsuarioDAL>.Instance; }
        }

        public Usuario ConsultarUsuario(int idUsuario)
        {
            string where = "idUsuario = " + idUsuario.ToString();
            return this.Obter(where, true);
        }

        public Usuario ConsultarUsuario(string login, string senha)
        {
            string where = "login = " + "'" +login + "' AND senha = " + "'" + senha + "'";
            return this.Obter(where, true);
        }

        public IList<Usuario> ConsultarUsuarioData(DateTime dataIni, DateTime dataFin)
        {
            string where = "data BETWEEN '" + dataIni.ToString("yyyy/MM/dd") + "' AND '" + dataFin.ToString("yyyy/MM/dd") + "'";
            return this.Listar(where, true);
        }

        public Usuario Obter(string where, bool includeItensUsuario = false)
        {
            Usuario usuario = base.Obter(where);

            return usuario;
        }

        public IList<Usuario> Listar(bool includeItensUsuario = false)
        {
            return this.Listar("", includeItensUsuario);
        }

        public IList<Usuario> Listar(string where, bool includeItensUsuario = false)
        {
            IList<Usuario> usuario = base.Listar(where);

            return usuario;
        }

        public override int Update(Usuario usuario)
        {
            int ret = base.Update(usuario);

            return ret;
        }

        public override int Delete(Usuario usuario)
        {
            return base.Delete(usuario);
        }

        public override int Insert(Usuario usuario)
        {
            int ret = base.Insert(usuario);

            return ret;
        }
    }
}
