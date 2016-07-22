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
    [TestClass]
    public class NewsletterDALTest
    {
        private TestContext testContextInstance;

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
        public void ListarTodosNewslettersTest()
        {
            NewsletterDAL target = new NewsletterDAL();
            IList<Newsletter> actual = null;
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void ObterNewsletterTest()
        {
            NewsletterDAL target = new NewsletterDAL();
            Newsletter actual = null;
            actual = target.Obter("idNewsletter=1");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for NewsletterFactory
        ///</summary>
        //[TestMethod()]
        public void NewsletterFactoryTest()
        {
            NewsletterDAL dal = new NewsletterDAL();
            //dal.
            IDataReader DataReader = null;
            Newsletter expected = null; // TODO: Initialize to an appropriate value
            Newsletter actual;
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
            NewsletterDAL target = new NewsletterDAL();
            Newsletter newsletter = new Newsletter();

            newsletter.IdNewsletter = 1;
            newsletter.Email = "teste@Sam9araujo.com";
            newsletter.Data = DateTime.Now;
            

            target.Insert(newsletter);
            Newsletter newsletterTest = target.Obter("IdNewsletter = " + newsletter.IdNewsletter);

            Assert.AreEqual(newsletter.IdNewsletter,newsletterTest.IdNewsletter);
            Assert.AreEqual(newsletter.Email, newsletterTest.Email);
            Assert.AreEqual(newsletter.Data, newsletterTest.Data);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        //[TestMethod()]
        public void UpdateTest()
        {
            NewsletterDAL target = new NewsletterDAL();
            Newsletter newsletter = new Newsletter();

            newsletter.IdNewsletter = 1;
            newsletter.Email = "scosta@Sam9araujo.com.br";
            newsletter.Data = DateTime.Now;
            

            target.Update(newsletter);
            Newsletter newsletterTest = target.Obter("IdNewsletter = " + newsletter.IdNewsletter);

            Assert.AreEqual(newsletter.IdNewsletter, newsletterTest.IdNewsletter);
            Assert.AreEqual(newsletter.Email, newsletterTest.Email);
            Assert.AreEqual(newsletter.Data, newsletterTest.Data);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            NewsletterDAL target = new NewsletterDAL();
            Newsletter newsletter = new Newsletter();

            newsletter.IdNewsletter = 1;

            target.Delete(newsletter);
        }
      
    }
}
