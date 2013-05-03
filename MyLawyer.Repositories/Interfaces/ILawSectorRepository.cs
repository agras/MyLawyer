using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.DAL;

namespace MyLawyer.Repositories.Interfaces
{
    public interface ILawSectorRepository
    {
        IEnumerable<LawSector> GetKeywordsByLawSectorText(string searchText);

        IEnumerable<LawSector> GetLawyersByLawSectorText(string searchText);
    }
}
    