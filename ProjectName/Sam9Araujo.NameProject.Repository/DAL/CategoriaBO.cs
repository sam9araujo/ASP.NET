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
    public class CategoriaBO : DataAccess
    {
        private readonly string strSELECT = "SELECT id, descricao, dataCadastro, codigo, parceiro, parent FROM [categoria] ";
        private string strSQL = string.Empty;

        public CategoriaBO()
        {

        }

        public List<Categoria> ListarTodasCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            Categoria categoria = null;

            //base.OpenSqlConnection();
            {
                base.OpenDataReader(strSELECT, CommandBehavior.CloseConnection);
                {
                    while (base.DataReader.Read())
                    {
                        categoria = CategoriaFactory();
                        categorias.Add(categoria);
                    }
                }
                //base.CloseDataReader();
            }
            base.CloseSqlConnection();

            return categorias;
        }
        public Categoria ObterCategoria(string where)
        {
            string sql = strSELECT + where;

            Categoria categoria = null;

            //base.OpenSqlConnection();
            {

                base.OpenDataReader(sql, CommandBehavior.SingleRow);
                {
                    if (base.DataReader.Read())
                    {
                        categoria = CategoriaFactory();
                    }
                }
                base.CloseDataReader();
            }
            //base.CloseSqlConnection();

            return categoria;
        }

        public bool Update(Categoria categoria)
        {
            bool isOK = false;

            try
            {
                strSQL = @"UPDATE [categoria]
                            SET codigo = " + categoria.Codigo + @"
                                ,descricao = '" + categoria.Descricao + @"'
                                ,parceiro = " + categoria.ParceiroID + @"
                                ,parent = " + categoria.Parent + @"
                            WHERE 
                                id = " + categoria.Id;


                base.ChangeDatabase(strSQL, null);

                isOK = true;
            }
            catch(Exception ex)
            {
                isOK = false;
            }

            return isOK;
        }
        
        public bool Insert(Categoria categoria)
        {
            bool isOK = false;

            strSQL = @"INSERT INTO [categoria] ([codigo],[descricao],[dataCadastro],[parceiro],[parent])
                        VALUES
                       (@Codigo, @Descricao, @DataCadastro, @Parceiro, @Parent)";

            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("Codigo", categoria.Codigo);
            sqlParameters[0].SqlDbType = SqlDbType.Int;

            sqlParameters[1] = new SqlParameter("Descricao", categoria.Descricao);
            sqlParameters[1].SqlDbType = SqlDbType.NVarChar;

            sqlParameters[2] = new SqlParameter("DataCadastro", DateTime.Now);
            sqlParameters[2].SqlDbType = SqlDbType.DateTime;

            sqlParameters[3] = new SqlParameter("Parceiro", categoria.ParceiroID);
            sqlParameters[3].SqlDbType = SqlDbType.Int;

            sqlParameters[4] = new SqlParameter("Parent", categoria.Parent);
            sqlParameters[4].SqlDbType = SqlDbType.Int;


            base.ChangeDatabase(strSQL, sqlParameters);

            isOK = true;

            return isOK;
        }

        private Categoria CategoriaFactory()
        {
            Categoria categoria = new Categoria();
            {
                categoria.Id = int.Parse(base.DataReader["id"].ToString());
                categoria.Codigo = int.Parse(base.DataReader["codigo"].ToString());
                categoria.DataCadastro = DateTime.Parse(base.DataReader["dataCadastro"].ToString());
                categoria.Descricao = base.DataReader["descricao"].ToString();
                categoria.Parent = int.Parse(base.DataReader["parent"].ToString());
                categoria.ParceiroID = int.Parse(base.DataReader["parceiro"].ToString());
            }
            return categoria;
        }
    }
}

