using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.Repositories;
using MyLawyer.Repositories.Interfaces;
using MyLawyer.Repositories.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLawyer.UnitTests
{
    [TestClass]
    public class RepositoriyTests
    {
        LawBarRepository lawBarRep = new LawBarRepository();
        LawyerRepository lawyerRep = new LawyerRepository();
        LawSectorRepository lawSectorRep = new LawSectorRepository();
        KeywordRepository keywordRep = new KeywordRepository();

        /*
        * Test KeywordRepository
        **/
        [TestMethod]
        public void TestKeywordRepositoryGetLawSectorsByKeywordText()
        {
            var results = this.keywordRep.GetLawSectorsByKeywordText("Διαζύγιο");


            foreach (Keyword result in results)
            {
                Assert.IsTrue(result.LawSectors.Count() == 2);
            }

        }
        [TestMethod]
        public void TestKeywordRepositoryGetLawyersByKeywordText()
        {
            var results = this.keywordRep.GetLawyersByKeywordText("Διαζύγιο");

            Assert.IsTrue(results.Count() > 0);
        }
        [TestMethod]
        public void TestKeywordRepositoryCountAll()
        {
            var results = this.keywordRep.CountAll();

            Assert.IsTrue(results == 10);
        }

        /*
         * Test LawBarRepository
         **/
        [TestMethod]
        public void TestCount()
        {
            var results = this.lawBarRep.CountAll();

            Assert.IsTrue(results == 65);
        }

        [TestMethod]
        public void TestLawBarRepositoryGetLawyersByLawBarText()
        {
            IEnumerable<LawBar> results = this.lawBarRep.GetLawyersByLawBarText("ΑΓΡΙΝΙΟΥ");
            Assert.IsTrue(results.First().Lawyers.Count() == 4);

        }

        /*
         * Test LawyerRepository
         **/
        [TestMethod]
        public void TestLawyerRepositoryGetLawSectorsByLawyerName()
        {
            var results = this.lawyerRep.GetLawSectorsByLawyerName("Παπα");

            Assert.IsTrue(results.Count() == 4);
        }
        [TestMethod]
        public void TestLawyerRepositoryGetKeywordsByLawyerName()
        {
            var results = this.lawyerRep.GetKeywordsByLawyerName("Παπα");

            Assert.IsTrue(results.First().Keywords.Count() == 4);
        }
        [TestMethod]
        public void TestLawyerCountAll()
        {
            var results = this.lawyerRep.Fetch();

            Assert.IsTrue(results.Count() == 6);
        }

        /*
         * Test LawSectorRepository
         **/
        [TestMethod]
        public void TestLawSectorRepositoryGetKeywordsByLawSectorText()
        {
            IEnumerable<LawSector> results = lawSectorRep.GetKeywordsByLawSectorText("ΠΤΩΧΕΥΤΙΚΟ ΔΙΚΑΙΟ");

            Assert.IsTrue(results.First().Keywords.Count().Equals(5));
        }
        [TestMethod]
        public void TestLawSectorRepositoryGetLawyersByLawSectorText()
        {
            var results = lawSectorRep.GetLawyersByLawSectorText("ΕΜΠΡΑΓΜΑΤΟ ΔΙΚΑΙΟ");

            Assert.IsTrue(results.Count() > 0);
        }
    }
}
