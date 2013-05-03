using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Repositories.Interfaces;
using MyLawyer.Entities;
using MyLawyer.DAL;
using System.Data.Entity;
using MyLawyer.Repositories.Helpers;


namespace MyLawyer.Repositories.Repositories
{
    public class LawyerRepository : BaseRepository<Lawyer>, ILawyerRepository
    {
        

        public IEnumerable<Lawyer> GetLawSectorsByLawyerName(string name)
        {
            return this._dbContext.Lawyers.Include("LawSectors").Where(x => x.Name.ToUpper().Contains(name.ToUpper())).AsQueryable();
        }
        public IEnumerable<Lawyer> GetKeywordsByLawyerName(string name)
        {
            return this._dbContext.Lawyers.Include("Keywords").Where(x => x.Name.ToUpper().Contains(name.ToUpper())).AsQueryable();
        }


        public List<Lawyer> SearchLawyerByCriteria(LawyerCriteria criteria)
        {
            if (criteria.IsEmpty)
                return null;

            // We add a 0 value in the array containing the LawSectors to avoid null pointer exception due to the primitive type array.
            // "Unable to create a null constant value of type 'System.Int32[]'. Only entity types, enumeration types or primitive types are supported in this context."
            if (criteria.LawSectors == null)
            {
                criteria.LawSectors = new int[1];
                criteria.LawSectors[0] = 0;
            }

            var query = from l in this._dbContext.Lawyers
                        from ls in l.LawSectors
                        where ( ( (criteria.Name == null) || (l.Name.ToUpper().Contains(criteria.Name.ToUpper())) )
                        && ( (criteria.LawSectors.Contains(0)) || (criteria.LawSectors.Contains(ls.Id)) )
                        && ( (criteria.LawBar == 0) || (l.LawBarId == criteria.LawBar) ) )
                        select l.Id;

            var results = from lawyer in _dbContext.Lawyers.Include("LawSectors").Include("LawBar") where query.Contains(lawyer.Id) select lawyer;

            return results.ToList();
        }

        public void RegisterStudies(Lawyer entity, int studiesId)
        {
            BaseRepository<Study> sdRep = new BaseRepository<Study>(this._dbContext);
            entity.Study = sdRep.GetById(studiesId);
            entity.StudiesId = studiesId;
        }

        public void RegisterLawBar(Lawyer entity, int lawBarId)
        {
            var lbRep = new LawBarRepository(this._dbContext);
            entity.LawBar = lbRep.Fetch().Where(x => lawBarId.Equals(x.Id)).First();
            entity.LawBarId = lawBarId;
        }

        public void RegisterLawSectors(Lawyer entity, List<int> lawSectorIds)
        {
            var rep = new LawSectorRepository(this._dbContext);
            var cols = rep.Fetch().Where(x => lawSectorIds.Contains(x.Id));
            foreach (var item in cols)
            {
                entity.LawSectors.Add(item);
            }
        }

        public void RegisterKeywords(Lawyer entity, List<int> KeywordIds)
        {
            var rep = new KeywordRepository(this._dbContext);
            var cols = rep.Fetch().Where(x => KeywordIds.Contains(x.Id));
            foreach (var item in cols)
            {
                entity.Keywords.Add(item);
            }
        }

        public void Register(Lawyer entity, List<int> lawSectorIds, int lawBarId, int studiesId, List<int> keywordIds)
        {
            this.RegisterLawBar(entity, lawBarId);

            if( lawSectorIds != null )
                this.RegisterLawSectors(entity, lawSectorIds);

            if( studiesId != null && studiesId != 0  )
                this.RegisterStudies(entity, studiesId);

            if (keywordIds != null)
                this.RegisterKeywords(entity, keywordIds);
        }


        public List<Lawyer> SearchLawyerByCriteria(string name)
        {
            return this._dbContext.Lawyers.Include("LawSectors").Include("LawBar").Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList();
        }
    }
}
