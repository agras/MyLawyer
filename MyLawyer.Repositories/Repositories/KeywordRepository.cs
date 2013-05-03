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
    public class KeywordRepository : BaseRepository<Keyword>, IKeywordRepository
    {
        public KeywordRepository() : base()
        {

        }

        public KeywordRepository(DbContext context)
            : base(context)
	    {
            
	    }

        public IEnumerable<Keyword> GetLawSectorsByKeywordText(string searchText)
        {
            return (this._dbContext.Keywords.Include("LawSectors").Where(x => x.Text.ToUpper() == searchText.ToUpper()).AsQueryable());
        }

        public IEnumerable<Keyword> GetLawyersByKeywordText(string searchText)
        {
            return this._dbContext.Keywords.Include("Lawyers").Where(x => x.Text.ToUpper() == searchText.ToUpper()).AsQueryable();
        }
    }
}
