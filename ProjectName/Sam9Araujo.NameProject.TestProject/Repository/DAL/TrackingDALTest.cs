using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sam9araujo.NameProject.Repository.DAL;
using Sam9araujo.NameProject.Domain;
using System.Data;

namespace Sam9araujo.NameProject.TestProject.Repository.DAL
{
    [TestClass()]
    public class TrackingDALTest
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
            TrackingDAL target = new TrackingDAL();
            IList<Tracking> actual = null;
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for Listar(string where)
        ///</summary>
        [TestMethod()]
        public void ListarWhereTest()
        {
            TrackingDAL target = new TrackingDAL();
            IList<Tracking> actual = null;
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
        public void TrackingFactoryTest()
        {
            TrackingDAL dal = new TrackingDAL();
            //dal.
            IDataReader DataReader = null;
            Tracking expected = null; // TODO: Initialize to an appropriate value
            Tracking actual;
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
            TrackingDAL target = new TrackingDAL();
            Tracking tracking = new Tracking();

            tracking.IdPedido = 1;
            tracking.IdParceiro = 1;
            tracking.IdTracking = 1;
            tracking.Status = "Aguardando";
            tracking.Data = DateTime.Now;

            target.Insert(tracking);

            var trackingTest = target.Obter("IdPedido = 1 AND IdParceiro = 1 AND IdTracking = 1");

            Assert.AreEqual(target.Obter("IdPedido = 1 AND IdParceiro = 1 AND IdTracking = 1"), tracking);
            
        }
       //[TestMethod()]
        public void UpdateTest()
        {
            TrackingDAL target = new TrackingDAL();
            Tracking tracking = new Tracking();

            tracking.IdPedido = 1;
            tracking.IdParceiro = 1;
            tracking.IdTracking = 2;
            tracking.Status = "TESTE";
            tracking.Data = DateTime.Now;

            target.Update(tracking);

            Tracking trackingTest = target.Obter("IdPedido = 1 AND IdParceiro = 1 AND IdTracking = 2");

            Assert.AreEqual(tracking.IdPedido, trackingTest.IdPedido);
            Assert.AreEqual(tracking.IdParceiro, trackingTest.IdParceiro);
            Assert.AreNotEqual(tracking.IdTracking, trackingTest.IdTracking);
            Assert.AreEqual(tracking.Status, trackingTest.Status);
            Assert.AreEqual(tracking.Data, trackingTest.Data);

        }
        //[TestMethod()]
        public void DeleteTest()
        {
            TrackingDAL target = new TrackingDAL();
            Tracking tracking = new Tracking();

            tracking.IdPedido = 1;
            tracking.IdParceiro = 1;
            tracking.IdTracking = 1;
            tracking.Status = "TESTE";
            tracking.Data = DateTime.Now;

            target.Delete(tracking);

            //Tracking trackingTest = target.Obter("IdPedido = 1 AND IdParceiro = 1 AND IdTracking = 2");

            //Assert.AreEqual(tracking.IdPedido, trackingTest.IdPedido);
            //Assert.AreEqual(tracking.IdParceiro, trackingTest.IdParceiro);
            //Assert.AreNotEqual(tracking.IdTracking, trackingTest.IdTracking);
            //Assert.AreEqual(tracking.Status, trackingTest.Status);
            //Assert.AreEqual(tracking.Data, trackingTest.Data);


        }
    }
}
