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
using System.Data;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.DataAccessLayer;
using System.Configuration;
#endregion

namespace Sam9araujo.NameProject.Repository.DAL
{

    public class UsuarioDAL : BaseDAL<Usuario>
    {
        #region Properties
        public override string SqlSELECT
        {
            get { return QuerysSQL.selectUsuario; }
        }

        public override string SqlINSERT
        {
            get { return QuerysSQL.insertUsuario; }
        }

        public override string SqlUPDATE
        {
            get { return QuerysSQL.updateUsuario; }
        }

        public override string SqlDELETE
        {
            get { return QuerysSQL.deleteUsuario; }
        }

        public override string SqlWhereKey
        {
            get { return QuerysSQL.whereKeyUsuario; }
        }
        #endregion

        #region Override Methods
        internal override IDbDataParameter[] PrepareParametersFactory(Usuario usuario, bool includeKeys = false)
        {
            IDbDataParameter[] dataParameters;

            if (includeKeys)
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 7);
            else
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 6);

            dataParameters[0].ParameterName = "nome";
            dataParameters[0].DbType = DbType.String;
            dataParameters[0].Value = usuario.Nome;

            dataParameters[1].ParameterName = "email";
            dataParameters[1].DbType = DbType.String;
            dataParameters[1].Value = usuario.Email;

            dataParameters[2].ParameterName = "login";
            dataParameters[2].DbType = DbType.String;
            dataParameters[2].Value = usuario.Login;

            dataParameters[3].ParameterName = "senha";
            dataParameters[3].DbType = DbType.String;
            dataParameters[3].Value = usuario.Senha;

            dataParameters[4].ParameterName = "isAtivo";
            dataParameters[4].DbType = DbType.Boolean;
            dataParameters[4].Value = usuario.IsAtivo;

            dataParameters[5].ParameterName = "dataCadastro";
            dataParameters[5].DbType = DbType.DateTime;
            dataParameters[5].Value = usuario.DataCadastro;

            if (includeKeys)
            {
                int i = 6;
                keyMethod(usuario, dataParameters, i);
            }

            return dataParameters;
        }

        internal override IDbDataParameter[] PrepareParametersKeyFactory(Usuario usuario)
        {
            IDbDataParameter[] dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 1);

            keyMethod(usuario, dataParameters, 0);

            return dataParameters;
        }

        public UsuarioDAL()
        {

        }

        public override Usuario Factory(IDataReader DataReader)
        {
            Usuario usuario = new Usuario();
            {
                usuario.IdUsuario = int.Parse(DataReader["idUsuario"].ToString());
                usuario.Nome = DataReader["nome"].ToString();
                usuario.Email = DataReader["email"].ToString();
                usuario.Login = DataReader["login"].ToString();
                usuario.Senha = DataReader["senha"].ToString();
                usuario.IsAtivo = bool.Parse(DataReader["isAtivo"].ToString());
                usuario.DataCadastro = DateTime.Parse(DataReader["dataCadastro"].ToString());
            }
            return usuario;
        }

        internal override void ExecuteIncludes(List<Usuario> usuarios)
        {

        }
        #endregion

        #region Static Methods
        private static void keyMethod(Usuario usuario, IDbDataParameter[] dataParameters, int i)
        {
            dataParameters[i].ParameterName = "idUsuarioKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = usuario.IdUsuario;

            i++;
        }
        #endregion
    }
}