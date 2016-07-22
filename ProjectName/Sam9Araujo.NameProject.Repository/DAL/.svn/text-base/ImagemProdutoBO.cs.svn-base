using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosan.WF.Import.Core;
using Cosan.WF.Import.Model;
using System.Data;
using System.Data.SqlClient;

namespace Cosan.WF.Import.Business
{
    public class ImagemProdutoBO : DataAccess
    {
        private readonly string strSELECT = "SELECT [id],[produto],[imagem],[dataCadastro],[parceiro] FROM [imagemProduto] ";
        private string strSQL = string.Empty;

        public ImagemProdutoBO()
        {

        }

        public bool Insert(ImagemProduto imagemProduto)
        {
            bool isOK = false;

            strSQL = @"INSERT INTO [imagemProduto] ([produto],[imagem],[dataCadastro],[parceiro])
                        VALUES
                       (@Produto, @Imagem, @DataCadastro, @Parceiro)";

            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("Produto", imagemProduto.Produto.Codigo);
            sqlParameters[0].SqlDbType = SqlDbType.Int;

            sqlParameters[1] = new SqlParameter("Imagem", imagemProduto.Imagem);
            sqlParameters[1].SqlDbType = SqlDbType.VarChar;

            sqlParameters[2] = new SqlParameter("DataCadastro", DateTime.Now);
            sqlParameters[2].SqlDbType = SqlDbType.DateTime;

            sqlParameters[3] = new SqlParameter("Parceiro", imagemProduto.Parceiro.Id);
            sqlParameters[3].SqlDbType = SqlDbType.Int;

            base.OpenSqlConnection();
            {
                base.ChangeDatabase(strSQL, sqlParameters);
            }
            base.CloseSqlConnection();

            isOK = true;

            return isOK;
        }
    }
}

