using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.Repositories;
using MyLawyerApp.Repositories.Interfaces;
using MyLawyerApp.Repositories.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLawyer.UnitTest
{
    [TestClass]
    public class UnitTest1
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
    }
}
