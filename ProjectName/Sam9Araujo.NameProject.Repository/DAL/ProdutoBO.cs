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
    public class ProdutoBO : DataAccess
    {
        private readonly string strSELECT = "SELECT id, codigo, link, precoCheio, preco, imagem, pontos, isDisponivel, IsAtivo, dataCadastro, dataAlteracao, usuario, nome, nivel, categoria, ordemDestaque FROM [produto] ";
        private string strSQL = string.Empty;

        public ProdutoBO()
        {

        }

        public List<Produto> ListarTodosProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            Produto produto = null;

            //base.OpenSqlConnection();
            {
                base.OpenDataReader(strSELECT, CommandBehavior.SingleResult);
                {
                    while (base.DataReader.Read())
                    {
                        produto = ProdutoFactory();
                        produtos.Add(produto);
                    }
                }
                base.CloseDataReader();
            }
            //base.CloseSqlConnection();

            return produtos;
        }
        public Produto ObterProduto(string where)
        {
            string sql = strSELECT + where;

            Produto produto = null;

            //base.OpenSqlConnection();
            {

                base.OpenDataReader(sql, CommandBehavior.SingleRow);
                {
                    if (base.DataReader.Read())
                    {
                        produto = ProdutoFactory();
                    }
                }
                base.CloseDataReader();
            }
            //base.CloseSqlConnection();

            return produto;
        }

        public void DesativarTodosProdutos()
        {
            strSQL = @"UPDATE [produto] SET IsAtivo = 0";
            base.ChangeDatabase(strSQL, null);
        }

        public void Update(Produto produto)
        {
            strSQL = @"UPDATE [produto]
                            SET codigo = @Codigo 
                                ,link = @Link
                                ,precoCheio = @PrecoCheio
                                ,preco = @Preco
                                ,imagem = @Imagem
                                ,pontos = @Pontos
                                ,isDisponivel = @IsDisponivel
                                ,IsAtivo = @IsAtivo
                                ,dataCadastro = @Codigo
                                ,dataAlteracao = @Codigo
                                ,usuario = @Usuario
                                ,nome = @Nome
                                ,nivel = @Nivel
                                ,categoria = @CategoriaID
                                ,ordemDestaque = @OrdemDestaque
                            WHERE 
                                id = " + produto.Id;

            SqlParameter[] parameters = AddParameters(produto);

            base.ChangeDatabase(strSQL, parameters);
        }
        
        public void Insert(Produto produto)
        {
            strSQL = @"INSERT INTO [produto] (codigo,
                                            link,
                                            precoCheio,
                                            preco,
                                            pontos,
                                            isDisponivel,
                                            IsAtivo,
                                            dataCadastro,
                                            dataAlteracao,
                                            usuario,
                                            nome,
                                            nivel,
                                            categoria,
                                            ordemDestaque,
                                            descricao,
                                            parceiro,
                                            frete,
                                            imagem
                                            )
                        VALUES
                                           (@Codigo
                                           , @Link
                                           , @PrecoCheio
                                           , @Preco
                                           , @Pontos
                                           , @IsDisponivel
                                           , @IsAtivo
                                           , @DataCadastro
                                           , @DataAlteracao
                                           , @Usuario
                                           , @Nome
                                           , @Nivel
                                           , @CategoriaID
                                           , @OrdemDestaque
                                           , @Descricao
                                           , @Parceiro
                                           , @Frete
                                           , @Imagem
                                    )";

            SqlParameter[] sqlParameters = AddParameters(produto);

            base.ChangeDatabase(strSQL, sqlParameters);
        }

        private static SqlParameter[] AddParameters(Produto produto)
        {
            SqlParameter[] sqlParameters = new SqlParameter[18];
            sqlParameters[0] = new SqlParameter("Codigo", produto.Codigo);
            sqlParameters[0].SqlDbType = SqlDbType.Int;

            sqlParameters[1] = new SqlParameter("Link", produto.Link);
            sqlParameters[1].SqlDbType = SqlDbType.NVarChar;

            sqlParameters[2] = new SqlParameter("PrecoCheio", produto.PrecoCheio);
            sqlParameters[2].SqlDbType = SqlDbType.Float;

            sqlParameters[3] = new SqlParameter("Preco", produto.Preco);
            sqlParameters[3].SqlDbType = SqlDbType.Float;

            sqlParameters[4] = new SqlParameter("Pontos", produto.Pontos);
            sqlParameters[4].SqlDbType = SqlDbType.Int;

            sqlParameters[5] = new SqlParameter("IsDisponivel", Convert.ToInt32(produto.IsDisponivel));
            sqlParameters[5].SqlDbType = SqlDbType.Bit;

            sqlParameters[6] = new SqlParameter("IsAtivo", Convert.ToInt32(produto.IsAtivo));
            sqlParameters[6].SqlDbType = SqlDbType.Bit;

            sqlParameters[7] = new SqlParameter("DataCadastro", produto.DataCadastro);
            sqlParameters[7].SqlDbType = SqlDbType.DateTime;

            sqlParameters[8] = new SqlParameter("DataAlteracao", produto.DataAlteracao);
            sqlParameters[8].SqlDbType = SqlDbType.DateTime;

            sqlParameters[9] = new SqlParameter("Usuario", produto.Usuario);
            sqlParameters[9].SqlDbType = SqlDbType.NVarChar;

            sqlParameters[10] = new SqlParameter("Nome", produto.Nome);
            sqlParameters[10].SqlDbType = SqlDbType.NVarChar;

            sqlParameters[11] = new SqlParameter("Nivel", produto.Nivel);
            sqlParameters[11].SqlDbType = SqlDbType.Int;

            sqlParameters[12] = new SqlParameter("CategoriaID", produto.CategoriaID);
            sqlParameters[12].SqlDbType = SqlDbType.Int;

            sqlParameters[13] = new SqlParameter("OrdemDestaque", produto.OrdemDestaque);
            sqlParameters[13].SqlDbType = SqlDbType.Int;

            sqlParameters[14] = new SqlParameter("Descricao", produto.Descricao);
            sqlParameters[14].SqlDbType = SqlDbType.Text;

            sqlParameters[15] = new SqlParameter("Parceiro", produto.Parceiro);
            sqlParameters[15].SqlDbType = SqlDbType.Int;

            sqlParameters[16] = new SqlParameter("Frete", produto.Frete);
            sqlParameters[16].SqlDbType = SqlDbType.Float;

            sqlParameters[17] = new SqlParameter("Imagem", produto.ImagemThumbnail);
            sqlParameters[17].SqlDbType = SqlDbType.VarChar;

            return sqlParameters;
        }

        private Produto ProdutoFactory()
        {
            Produto produto = new Produto();
            {
                produto.Id = int.Parse(base.DataReader["id"].ToString());
                produto.CategoriaID = int.Parse(base.DataReader["categoria"].ToString());
                produto.Codigo = int.Parse(base.DataReader["codigo"].ToString());
                produto.DataAlteracao = DateTime.Parse(base.DataReader["dataAlteracao"].ToString());
                produto.DataCadastro = DateTime.Parse(base.DataReader["dataCadastro"].ToString());
                produto.ImagemThumbnail = base.DataReader["imagem"].ToString();
                produto.IsAtivo = bool.Parse(base.DataReader["isAtivo"].ToString());
                produto.IsDisponivel = bool.Parse(base.DataReader["isDisponivel"].ToString());
                produto.Link = base.DataReader["link"].ToString();
                produto.Nivel = int.Parse(base.DataReader["nivel"].ToString());
                produto.Nome = base.DataReader["nome"].ToString();
                produto.OrdemDestaque = int.Parse(base.DataReader["ordemDestaque"].ToString());
                produto.Pontos = float.Parse(base.DataReader["pontos"].ToString());
                produto.Preco = float.Parse(base.DataReader["preco"].ToString());
                produto.PrecoCheio = float.Parse(base.DataReader["precoCheio"].ToString());
                produto.Usuario = base.DataReader["usuario"].ToString();
            }
            return produto;
        }
    }
}
