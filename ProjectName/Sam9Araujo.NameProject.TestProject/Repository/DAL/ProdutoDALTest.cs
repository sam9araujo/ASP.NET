﻿using Sam9araujo.NameProject.Repository.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sam9araujo.NameProject.DataAccessLayer;
using Sam9araujo.NameProject.Domain;
using System.Collections.Generic;
using System.Data;

namespace Sam9araujo.NameProject.TestProject
{
    /// <summary>
    ///This is a test class for ProdutoDALTest and is intended
    ///to contain all ProdutoDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProdutoDALTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }



        /// <summary>
        ///A test for Listar
        ///</summary>
        [TestMethod()]
        public void ListarTest()
        {
            ProdutoDAL target = new ProdutoDAL();
            IList<Produto> actual = null;
            target.CategoriaDAL.Include();
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for Listar(string where)
        ///</summary>
        [TestMethod()]
        public void ListarWhereTest()
        {
            ProdutoDAL target = new ProdutoDAL();
            IList<Produto> actual = null;
            actual = target.Listar("idParceiro = 1");
            Assert.IsNotNull(actual);
        }
        /*
                /// <summary>
                ///A test for ObterParceiro
                ///</summary>
                [TestMethod()]
                public void ObterParceiroTest()
                {
                    ParceiroDAL target = new ParceiroDAL();
                    Parceiro actual = null;
                    actual = target.ObterParceiro("id = 1");
                    Assert.IsNotNull(actual);
                }
                */
        /// <summary>
        ///A test for ProdutoFactory
        ///</summary>
        //[TestMethod()]
        public void ProdutoFactoryTest()
        {
            ProdutoDAL dal = new ProdutoDAL();
            //dal.
            IDataReader DataReader = null;
            Produto expected = null; // TODO: Initialize to an appropriate value
            Produto actual;
            actual = dal.Factory(DataReader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        //[TestMethod()]
        public void InsertTest()
        {
            ProdutoDAL target = new ProdutoDAL();
            Produto produto = new Produto();

            produto.IdProduto = "999";
            produto.IdParceiro = 1;
            produto.Link = "linkteste";
            produto.PrecoCheio = 100;
            produto.Preco = 100;
            produto.ImagemThumbnail = "imagem.jpg";
            produto.Pontos = 35;
            produto.IsDisponivel = true;
            produto.IsAtivo = true;
            produto.DataCadastro = DateTime.Now;
            produto.DataAlteracao = DateTime.Now;
            produto.Usuario = "Sam9araujo";
            produto.Nome = "Produto";
            produto.Nivel = 1;
            produto.OrdemDestaque = 1;
            produto.Titulo = "Titulo teste";
            produto.Descricao = "Desc teste";
            produto.Observacao = "OBS teste";
            produto.Frete = 50;
            produto.IdCategoria = 1;

            target.Insert(produto);

            Produto produtoTest = target.Obter("IdProduto = " + produto.IdProduto + " AND IdParceiro = " + produto.IdParceiro);

            Assert.AreEqual(produto.IdProduto       ,produtoTest.IdProduto);
            Assert.AreEqual(produto.IdParceiro      ,produtoTest.IdParceiro);
            Assert.AreEqual(produto.Link            ,produtoTest.Link);
            Assert.AreEqual(produto.PrecoCheio      ,produtoTest.PrecoCheio);
            Assert.AreEqual(produto.Preco           ,produtoTest.Preco);
            Assert.AreEqual(produto.ImagemThumbnail ,produtoTest.ImagemThumbnail);
            Assert.AreEqual(produto.Pontos          ,produtoTest.Pontos);
            Assert.AreEqual(produto.IsDisponivel    ,produtoTest.IsDisponivel);
            Assert.AreEqual(produto.IsAtivo         ,produtoTest.IsAtivo);
            Assert.AreEqual(produto.DataCadastro    ,produtoTest.DataCadastro);
            Assert.AreEqual(produto.DataAlteracao   ,produtoTest.DataAlteracao);
            Assert.AreEqual(produto.Usuario         ,produtoTest.Usuario);
            Assert.AreEqual(produto.Nome            ,produtoTest.Nome);
            Assert.AreEqual(produto.Nivel           ,produtoTest.Nivel);
            Assert.AreEqual(produto.OrdemDestaque   ,produtoTest.OrdemDestaque);
            Assert.AreEqual(produto.Titulo          ,produtoTest.Titulo);
            Assert.AreEqual(produto.Descricao       ,produtoTest.Descricao);
            Assert.AreEqual(produto.Observacao      ,produtoTest.Observacao);
            Assert.AreEqual(produto.Frete           ,produtoTest.Frete);
            Assert.AreEqual(produto.IdCategoria     ,produtoTest.IdCategoria);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            ProdutoDAL target = new ProdutoDAL();
            Produto produto = new Produto();

            produto.IdProduto = "999";
            produto.IdParceiro = 1;
            produto.Link = "linkteste2";
            produto.PrecoCheio = 100;
            produto.Preco = 100;
            produto.ImagemThumbnail = "imagem2.jpg";
            produto.Pontos = 35;
            produto.IsDisponivel = true;
            produto.IsAtivo = true;
            produto.DataCadastro = DateTime.Now;
            produto.DataAlteracao = DateTime.Now;
            produto.Usuario = "Sam9araujo2";
            produto.Nome = "Produto2";
            produto.Nivel = 1;
            produto.OrdemDestaque = 1;
            produto.Titulo = "Titulo teste";
            produto.Descricao = "Desc teste";
            produto.Observacao = "OBS teste";
            produto.Frete = 50;
            produto.IdCategoria = 1;
            target.Update(produto);

            Produto produtoTest = target.Obter("IdProduto = " + produto.IdProduto + " AND IdParceiro = " + produto.IdParceiro);

            Assert.AreEqual(produto.IdProduto, produtoTest.IdProduto);
            Assert.AreEqual(produto.IdParceiro, produtoTest.IdParceiro);
            Assert.AreEqual(produto.Link, produtoTest.Link);
            Assert.AreEqual(produto.PrecoCheio, produtoTest.PrecoCheio);
            Assert.AreEqual(produto.Preco, produtoTest.Preco);
            Assert.AreEqual(produto.ImagemThumbnail, produtoTest.ImagemThumbnail);
            Assert.AreEqual(produto.Pontos, produtoTest.Pontos);
            Assert.AreEqual(produto.IsDisponivel, produtoTest.IsDisponivel);
            Assert.AreEqual(produto.IsAtivo, produtoTest.IsAtivo);
            Assert.AreEqual(produto.DataCadastro, produtoTest.DataCadastro);
            Assert.AreEqual(produto.DataAlteracao, produtoTest.DataAlteracao);
            Assert.AreEqual(produto.Usuario, produtoTest.Usuario);
            Assert.AreEqual(produto.Nome, produtoTest.Nome);
            Assert.AreEqual(produto.Nivel, produtoTest.Nivel);
            Assert.AreEqual(produto.OrdemDestaque, produtoTest.OrdemDestaque);
            Assert.AreEqual(produto.Titulo, produtoTest.Titulo);
            Assert.AreEqual(produto.Descricao, produtoTest.Descricao);
            Assert.AreEqual(produto.Observacao, produtoTest.Observacao);
            Assert.AreEqual(produto.Frete, produtoTest.Frete);
            Assert.AreEqual(produto.IdCategoria, produtoTest.IdCategoria);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            ProdutoDAL target = new ProdutoDAL();
            Produto produto = new Produto();

            produto.IdProduto = "999";
            produto.IdParceiro = 1;

            target.Delete(produto);

            //Assert.(ambiente, target.Obter("IdAmbiente = 101"));
        }
    }
}