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
    public class MainSectorRepository : BaseRepository<MainSector>, IMainSector
    {
        public MainSectorRepository() : base()
        {

        }

        public MainSectorRepository(DbContext context) : base(context)
	    {
            
	    }

        public IEnumerable<MainSector> GetLawyersByMainSectorText(string searchText)
        {
            return this._dbContext.MainSectors.Include("LawSectors").Include("Lawyers").Where(x => x.Text.ToUpper()==searchText.ToUpper()).AsQueryable();
        }

        public IEnumerable<MainSector> GetLawSectorsByMainSectorText(string searchText)
        {
            return this._dbContext.MainSectors.Include("LawSectors").Where(x => x.Text.ToUpper() == searchText.ToUpper()).AsQueryable();
        }

        public IEnumerable<MainSector> GetKeywordsByMainSectorText(string searchText)
        {
            return this._dbContext.MainSectors.Include("LawSectors").Include("Keywords").Where(x => x.Text.ToUpper() == searchText.ToUpper()).AsQueryable();
        }
    }
}
