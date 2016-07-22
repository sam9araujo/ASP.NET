using Sam9araujo.NameProject.Repository.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sam9araujo.NameProject.DataAccessLayer;
using Sam9araujo.NameProject.Domain;
using System.Collections.Generic;
using System.Data;

namespace Sam9araujo.NameProject.TestProject
{
    /// <summary>
    ///This is a test class for ParceiroDALTest and is intended
    ///to contain all ParceiroDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParceiroDALTest
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
            ParceiroDAL target = new ParceiroDAL();
            IList<Parceiro> actual = null;
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ObterParceiro
        ///</summary>
        [TestMethod()]
        public void ObterParceiroTest()
        {
            ParceiroDAL target = new ParceiroDAL();
            Parceiro actual = null;
            actual = target.Obter("idParceiro = 1");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ParceiroFactory
        ///</summary>
        //[TestMethod()]
        public void ParceiroFactoryTest()
        {
            ParceiroDAL dal = new ParceiroDAL();
            //dal.
            IDataReader DataReader = null;
            Parceiro expected = null; // TODO: Initialize to an appropriate value
            Parceiro actual;
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
            ParceiroDAL target = new ParceiroDAL();
            Parceiro parceiro = new Parceiro();

            parceiro.IdParceiro = 999;
            parceiro.Nome = "Parceiro Test";
            parceiro.DataCadastro = DateTime.Now;
            parceiro.PercentualPreco = 11;
            parceiro.PercentualPontos = 22;

            target.Insert(parceiro);
            Parceiro parceiroTest = target.Obter("IdParceiro = " + parceiro.IdParceiro);

            Assert.AreEqual(parceiro.IdParceiro, parceiroTest.IdParceiro);
            Assert.AreEqual(parceiro.Nome, parceiroTest.Nome);
            Assert.AreNotEqual(parceiro.DataCadastro, parceiroTest.DataCadastro);
            Assert.AreEqual(parceiro.PercentualPreco, parceiroTest.PercentualPreco);
            Assert.AreEqual(parceiro.PercentualPontos, parceiroTest.PercentualPontos);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            ParceiroDAL target = new ParceiroDAL();
            Parceiro parceiro = new Parceiro();

            parceiro.IdParceiro = 999;
            parceiro.Nome = "Parceiro Test";
            parceiro.DataCadastro = DateTime.Now;
            parceiro.PercentualPreco = 11;
            parceiro.PercentualPontos = 22;

            target.Update(parceiro);
            Parceiro parceiroTest = target.Obter("IdParceiro = " + parceiro.IdParceiro);

            Assert.AreEqual(parceiro.IdParceiro, parceiroTest.IdParceiro);
            Assert.AreEqual(parceiro.Nome, parceiroTest.Nome);
            Assert.AreNotEqual(parceiro.DataCadastro, parceiroTest.DataCadastro);
            Assert.AreEqual(parceiro.PercentualPreco, parceiroTest.PercentualPreco);
            Assert.AreEqual(parceiro.PercentualPontos, parceiroTest.PercentualPontos);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            ParceiroDAL target = new ParceiroDAL();
            Parceiro parceiro = new Parceiro();

            parceiro.IdParceiro = 999;

            target.Delete(parceiro);

            //Assert.(ambiente, target.Obter("IdAmbiente = 101"));
        }
    }
}