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
    public class AmbienteDALTest
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
        public void ListarTest()
        {
            AmbienteDAL target = new AmbienteDAL();
            IList<Ambiente> actual = null;
            target.CategoriaDAL.Include();
            target.ParceiroDAL.Include();
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void ObterAmbienteTest()
        {
            AmbienteDAL target = new AmbienteDAL();
            Ambiente actual = null;
            actual = target.Obter("idAmbiente = 1");
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void AmbienteFactoryTest()
        {
            AmbienteDAL dal = new AmbienteDAL();
            //dal.
            IDataReader DataReader = null;
            Ambiente expected = null; // TODO: Initialize to an appropriate value
            Ambiente actual;
            actual = dal.Factory(DataReader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            AmbienteDAL target = new AmbienteDAL();
            Ambiente ambiente = new Ambiente();

            ambiente.IdAmbiente = 999;
            ambiente.Descricao = "Ambiente Teste";
            ambiente.DataCadastro = DateTime.Now;
            ambiente.Mostra = true;

            target.Insert(ambiente);
            Ambiente ambienteTest = target.Obter("IdAmbiente = " + ambiente.IdAmbiente);

            Assert.AreEqual(ambiente.IdAmbiente, ambienteTest.IdAmbiente);
            Assert.AreEqual(ambiente.Descricao, ambienteTest.Descricao);
            Assert.AreNotEqual(ambiente.DataCadastro, ambienteTest.DataCadastro);
            Assert.AreEqual(ambiente.Mostra, ambienteTest.Mostra);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            AmbienteDAL target = new AmbienteDAL();
            Ambiente ambiente = new Ambiente();

            ambiente.IdAmbiente = 999;
            ambiente.Descricao = "Ambiente Teste Unitário - UPDATED";
            ambiente.DataCadastro = DateTime.Now;
            ambiente.Mostra = false;

            target.Update(ambiente);

            Ambiente ambienteTest = target.Obter("IdAmbiente = " + ambiente.IdAmbiente);

            Assert.AreEqual(ambiente.IdAmbiente, ambienteTest.IdAmbiente);
            Assert.AreEqual(ambiente.Descricao, ambienteTest.Descricao);
            Assert.AreNotEqual(ambiente.DataCadastro, ambienteTest.DataCadastro);
            Assert.AreEqual(ambiente.Mostra, ambienteTest.Mostra);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            AmbienteDAL target = new AmbienteDAL();
            Ambiente ambiente = new Ambiente();

            ambiente.IdAmbiente = 999;

            target.Delete(ambiente);

            //Assert.(ambiente, target.Obter("IdAmbiente = 101"));
        }
    }
 }