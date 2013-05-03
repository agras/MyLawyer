using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Repositories.Interfaces;
using MyLawyer.Entities;
using MyLawyer.DAL;
using System.Data.Entity;

namespace MyLawyer.Repositories.Repositories
{
    public class LawBarRepository : BaseRepository<LawBar>, ILawBarRepository
    {

        public LawBarRepository()
            : base()
        {

        }

        public LawBarRepository(DbContext context)
            : base(context)
	    {
            
	    }

        public IEnumerable<LawBar> GetLawyersByLawBarText(string searchText)
        {
            return this._dbContext.LawBars.Include("Lawyers").Where(x => (x.Text.ToUpper()) == searchText.ToUpper()).AsQueryable();
        }
    }
}
