using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Repository.DAL;
using Sam9araujo.NameProject.Domain;

namespace Sam9araujo.NameProject.Repository
{
    public class ProdutoRepository : BaseRepository<Produto, ProdutoDAL, ProdutoRepository>, IRepositoryBase
    {
        private static AtributoProdutoDAL AtributoProdutoDAL
        {

            get { return Singleton<AtributoProdutoDAL>.Instance; }

        }

        private static ImagemProdutoDAL ImagemProdutoDAL
        {

            get { return Singleton<ImagemProdutoDAL>.Instance; }

        }

        public Produto Obter(string where, bool includeAtributo = false, bool includeImagem = false)
        {
            Produto produto = base.Obter(where);

            this.ExecuteIncludesFromProduto(produto, includeAtributo, includeImagem);

            return produto;
        }

        public IList<Produto> Listar(bool includeAtributoProduto = false, bool includeImagem = false)
        {
            return this.Listar("", includeAtributoProduto, includeImagem);
        }

        public IList<Produto> Listar(string where, bool includeAtributoProduto = false, bool includeImagem = false)
        {
            IList<Produto> produtos = base.Listar(where);

            this.ExecuteIncludesFromListProduto(produtos, includeAtributoProduto, includeImagem);

            return produtos;
        }

        private void ExecuteIncludesFromListProduto(IList<Produto> produtos, bool includeAtributoProduto = false, bool includeImagem = false)
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                this.ExecuteIncludesFromProduto(produtos[i], includeAtributoProduto, includeImagem);
            }
        }

        private void ExecuteIncludesFromProduto(Produto produto, bool includeAtributoProduto = false, bool includeImagem = false)
        {
            if (includeAtributoProduto)
                produto.Atributos = AtributoProdutoDAL.Listar("idProduto = " + produto.IdProduto + " AND idParceiro = " + produto.IdParceiro);
            if (includeImagem)
                produto.Imagens = ImagemProdutoDAL.Listar("idProduto = " + produto.IdProduto + " AND idParceiro = " + produto.IdParceiro);
        }

        public IList<Produto> ListarOfertasPorAmbiente(int idAmbiente, int start, int size, bool includeAtributoProduto = false, bool includeImagem = false)
        {
            string sql = DAL.SqlSELECT + " INNER JOIN CATEGORIA ON CATEGORIA.idCategoria = PRODUTO.idCategoria AND CATEGORIA.idParceiro = PRODUTO.idParceiro "
                                       + " INNER JOIN AMBIENTE_CATEGORIA ON CATEGORIA.idCategoria = AMBIENTE_CATEGORIA.idCategoria AND CATEGORIA.idParceiro = AMBIENTE_CATEGORIA.idParceiro "
                                       + " WHERE idAmbiente = " + idAmbiente
                                       + "   AND isAtivo = 1"
                                       + "   AND nivel = 1";
                                       //+ " ORDER BY ordemDestaque";

            int total = 0;
            IList<Produto> produtos = this.ListarPagina(sql, "ordemDestaque", start, size, ref total);

            this.ExecuteIncludesFromListProduto(produtos);

            return produtos;
        }

        public IList<Produto> ListarOfertas(string ordem, int start, int size, ref int total, bool includeAtributoProduto = false, bool includeImagem = false)
        {
            string sql = DAL.SqlSELECT + " WHERE isAtivo = 1"
                                       + "   AND nivel = 1";

            IList<Produto> produtos = this.ListarPagina(sql, ordem, start, size, ref total);

            this.ExecuteIncludesFromListProduto(produtos);

            return produtos;
        }

        public IList<Produto> Buscar(string busca, int pontoIn, int pontoFi, decimal valorIn, decimal valorFi,bool ofertas,int start, int size, ref int totalRecords, bool includeAtributoProduto = false, bool includeImagem = false)
        {
            string sql = DAL.SqlSELECT;
            string conector = " WHERE ";

            if (!string.IsNullOrEmpty(busca))
            {
                sql += conector + "(Nome like '%" + busca + "%')";
                               //+ " OR Descricao like '%" + busca + "%'"
                               //+ " OR Observacao like '%" + busca + "%'"
                conector = " AND ";
            }
            if (pontoIn > 0 || pontoFi > 0)
            {
                sql += conector + " (pontos BETWEEN " + pontoIn + " AND " + pontoFi + ")";

                conector = " AND ";
            }
            if(valorIn > 0 || valorFi > 0)
            {
                /*
                sql += conector + " (preco BETWEEN " + valorIn.ToString().Replace(",", ".") + " AND " + valorFi.ToString().Replace(",", ".") + ""
                                + " OR precoCheio BETWEEN " + valorIn.ToString().Replace(",", ".") + " AND " + valorFi.ToString().Replace(",", ".") + ")";
                */
                sql += conector + " (preco BETWEEN " + valorIn.ToString().Replace(",", ".") + " AND " + valorFi.ToString().Replace(",", ".") + ")";
                conector = " AND ";
            }
            if (ofertas)
            {
                sql += conector + " (nivel=1)";
                //conector = " OR ";
            }

            IList<Produto> produtos = this.ListarPagina(sql, "Nome", start, size, ref totalRecords);

            this.ExecuteIncludesFromListProduto(produtos);

            return produtos;
        }
        public override int Update(Produto produto)
        {
            int ret = base.Update(produto);

            if (produto.Atributos != null)
            {

                AtributoProdutoDAL.Delete("idProduto = " + produto.IdProduto + " AND idParceiro = " + produto.IdParceiro);

                for (int i = 0; i < produto.Atributos.Count; i++)
                {
                    AtributoProdutoDAL.Insert(produto.Atributos[i]);
                }
            }
            if (produto.Imagens != null)
            {

                ImagemProdutoDAL.Delete("idProduto = " + produto.IdProduto + " AND idParceiro = " + produto.IdParceiro);

                for (int i = 0; i < produto.Imagens.Count; i++)
                {
                    ImagemProdutoDAL.Insert(produto.Imagens[i]);
                }
            }
            return ret;
        }

        public override int Delete(Produto produto)
        {

            AtributoProdutoDAL.Delete("idProduto = " + produto.IdProduto + " AND idParceiro = " + produto.IdParceiro);
            ImagemProdutoDAL.Delete("idProduto = " + produto.IdProduto + " AND idParceiro = " + produto.IdParceiro);

            return base.Delete(produto);
        }

        public override int Insert(Produto produto)
        {
            int ret = base.Insert(produto);

            if (produto.Atributos != null)
            {
                for (int i = 0; i < produto.Atributos.Count; i++)
                {
                    AtributoProdutoDAL.Insert(produto.Atributos[i]);
                }
            }

            if (produto.Imagens != null)
            {
                if (produto.Imagens != null)
                {
                    for (int i = 0; i < produto.Imagem.Count; i++)
                    {
                        ImagemProdutoDAL.Insert(produto.Imagens[i]);
                    }
                }
            }
            return ret;
        }

        public sealed class Ordem
        {
            public const string Nome = "nome";
            public const string Pontos = "pontos";
            public const string Preco = "preco";
        }
    }
}
