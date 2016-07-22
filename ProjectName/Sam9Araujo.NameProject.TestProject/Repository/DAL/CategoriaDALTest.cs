﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sam9araujo.NameProject.Repository.DAL;
using Sam9araujo.NameProject.Domain;
using System.Data;

namespace Sam9araujo.NameProject.TestProject.Repository.DAL
{
    /// <summary>
    ///This is a test class for ParceiroDALTest and is intended
    ///to contain all ParceiroDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CategoriaDALTest
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

        [TestMethod()]
        public void ListarTodosCategoriasTest()
        {
            CategoriaDAL target = new CategoriaDAL();
            IList<Categoria> actual = null;
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void ObterCategoriaTest()
        {
            CategoriaDAL target = new CategoriaDAL();
            Categoria actual = null;
            actual = target.Obter("idCategoria = 1");
            Assert.IsNotNull(actual);
        }

        //[TestMethod()]
        public void CategoriaFactoryTest()
        {
            CategoriaDAL dal = new CategoriaDAL();
            //dal.
            IDataReader DataReader = null;
            Categoria expected = null; // TODO: Initialize to an appropriate value
            Categoria actual;
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
            CategoriaDAL target = new CategoriaDAL();
            Categoria categoria = new Categoria();

            categoria.IdCategoria = 4;
            categoria.IdParceiro = 1;
            categoria.Descricao = "Categoria Test";
            categoria.DataCadastro = DateTime.Now;
            categoria.Mostra = true;
            categoria.IdPaiCategoria = 1;

            target.Insert(categoria);
            Categoria categoriaTest = target.Obter("IdParceiro = " + categoria.IdParceiro + " AND IdCategoria = " + categoria.IdCategoria);

            Assert.AreEqual(categoria.IdCategoria       ,categoriaTest.IdCategoria);
            Assert.AreEqual(categoria.IdParceiro        ,categoriaTest.IdParceiro);
            Assert.AreEqual(categoria.Descricao         ,categoriaTest.Descricao);
            Assert.AreEqual(categoria.DataCadastro      ,categoriaTest.DataCadastro);
            Assert.AreEqual(categoria.Mostra            ,categoriaTest.Mostra);
            Assert.AreEqual(categoria.IdPaiCategoria    , categoriaTest.IdPaiCategoria);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        //[TestMethod()]
        public void UpdateTest()
        {
            CategoriaDAL target = new CategoriaDAL();
            Categoria categoria = new Categoria();

            categoria.IdCategoria = 4;
            categoria.IdParceiro = 1;
            categoria.Descricao = "Categoria Patrícia";
            categoria.DataCadastro = DateTime.Now;
            categoria.Mostra = true;
            categoria.IdPaiCategoria = 4;

            target.Update(categoria);
            Categoria categoriaTest = target.Obter("IdParceiro = " + categoria.IdParceiro + " AND IdCategoria = " + categoria.IdCategoria);

            Assert.AreEqual(categoria.IdCategoria, categoriaTest.IdCategoria);
            Assert.AreEqual(categoria.IdParceiro, categoriaTest.IdParceiro);
            Assert.AreEqual(categoria.Descricao, categoriaTest.Descricao);
            Assert.AreEqual(categoria.DataCadastro, categoriaTest.DataCadastro);
            Assert.AreEqual(categoria.Mostra, categoriaTest.Mostra);
            Assert.AreEqual(categoria.IdPaiCategoria, categoriaTest.IdPaiCategoria);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            CategoriaDAL target = new CategoriaDAL();
            Categoria categoria = new Categoria();

            categoria.IdCategoria = 4;
            categoria.IdParceiro = 1;
            categoria.IdPaiCategoria = 1;

            target.Delete(categoria);

            //Assert.(ambiente, target.Obter("IdAmbiente = 101"));
        }
    }
}