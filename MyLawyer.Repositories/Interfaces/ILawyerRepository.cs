using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.DAL;

namespace MyLawyer.Repositories.Interfaces
{
    public interface ILawyerRepository
    {
        IEnumerable<Lawyer> GetLawSectorsByLawyerName(string name);
        IEnumerable<Lawyer> GetKeywordsByLawyerName(string name);
        List<Lawyer> SearchLawyerByCriteria(string name);
    }
}
