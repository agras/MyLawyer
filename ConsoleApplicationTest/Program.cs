using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.Repositories;
using MyLawyer.Repositories.Interfaces;
using MyLawyer.Repositories.Repositories;

namespace ConsoleApplicationTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            LawBarRepository lawBarRep = new LawBarRepository();
            LawyerRepository lawyerRep = new LawyerRepository();
            LawSectorRepository lawSectorRep = new LawSectorRepository();
            KeywordRepository keywordRep = new KeywordRepository();


            var results = keywordRep.CountAll();
            Console.Write(results);
            Console.ReadLine();

            IEnumerable<Keyword> resultsKeywords = keywordRep.GetLawSectorsByKeywordText("Διαζύγιο");

            foreach (Keyword result in resultsKeywords)
            {
               Console.Write(result.LawSectors.Count());
               Console.ReadLine();
            }

            resultsKeywords = keywordRep.GetLawyersByKeywordText("Διαζύγιο");

            foreach (Keyword result in resultsKeywords)
            {
                Console.Write(result.LawSectors.Count());
                Console.ReadLine();
            }
            
        //    var l = new MyLawyer.Entities.LawBars();
        //    using(MyLawyerDAL.MyLawyerPublicEntities ctx = new MyLawyerDAL.MyLawyerPublicEntities())
        //    {

        //        l.Text = "μαλακας";
        //        ctx.LawBars.Add(l);
        //        ctx.SaveChanges();
            
        //    }

        //    Console.Write(l.Id.ToString());
        //    Console.ReadLine();
        }
    }
}
