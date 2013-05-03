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
    public class LawSectorRepository : BaseRepository<LawSector>, ILawSectorRepository
    {
        public LawSectorRepository() : base()
        {

        }

        public LawSectorRepository(DbContext context): base(context)
	    {
            
	    }

        public IEnumerable<LawSector> GetKeywordsByLawSectorText(string searchText)
        {
            return this._dbContext.LawSectors.Include("Keywords").Where(x => x.Text.ToUpper() == searchText.ToUpper()).AsQueryable();
        }

        public IEnumerable<LawSector> GetLawyersByLawSectorText(string searchText)
        {
            return this._dbContext.LawSectors.Include("Lawyers").Where(x => x.Text.ToUpper() == searchText.ToUpper()).AsQueryable();
        }
    }
}
