using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.DAL;

namespace MyLawyer.Repositories.Interfaces
{
    public interface IKeywordRepository
    {
        IEnumerable<Keyword> GetLawSectorsByKeywordText(string searchText);

        IEnumerable<Keyword> GetLawyersByKeywordText(string searchText);
    }
}
