using MyLawyer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.DAL;

namespace MyLawyer.Repositories.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected MyLawyerPublicEntities _dbContext;
        protected DbSet<T> dbTable;
 
        /// <summary>
        /// Constructor #1
        /// </summary>
        public BaseRepository()
        {
            this._dbContext = new MyLawyerPublicEntities();
            this.dbTable = _dbContext.Set<T>();
        }

        /// <summary>
        /// Constructor #2
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(DbContext context)
        {
            this._dbContext = (MyLawyerPublicEntities)context;
            this.dbTable = _dbContext.Set<T>();
        }


        /// <summary>
        /// Count all entities
        /// </summary>
        /// <returns></returns>
        public int CountAll()
        {
            return this.dbTable.Count();
        }
        /// <summary>
        /// Count entities based on a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return this.dbTable.Where(predicate).Count();
        }


        /// <summary>
        /// Returns true if there are more than one entities in the dbTable satisfying this predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            if (this.dbTable.Where(predicate).Count() > 0)
                return true;
            else
                return false;
        }


  
        /// <summary>
        /// Add a new entity in the dbcontext
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            if(entity != null)
                this.dbTable.Add(entity);
            else
                throw new ArgumentNullException("Entity null during insert operation");
        }



        /// <summary>
        /// Delete entity with/without a predicate
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (entity != null)
                this.dbTable.Remove(entity);
            else
                throw new ArgumentNullException("Entity null during delete operation");
        }
        /// <summary>
        /// Delete a collection of entities
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(ICollection<T> entities)
        {
            foreach(T entity in entities)
            {
                this.Delete(entity);
            }
        }


        /// <summary>
        /// Returns the whole data table of the entity type T
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Fetch()
        {
            return this.dbTable;
        }
        /// <summary>
        /// Return the whole data table of the entity type T in as a List
        /// </summary>
        /// <returns></returns>
        public List<T> FetchToList()
        {
            return this.dbTable.ToList();
        }
        /**
         * Returns the entities T matching the provided predicate
         * */
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return this.dbTable.Where(predicate);
        }
        /**
         * Returns the entities T list matching the provided predicate
         * */
        public List<T> SearchForToList(Expression<Func<T, bool>> predicate)
        {
            return this.dbTable.Where(predicate).ToList();
        }
        /// <summary>
        /// Returns a single entity that matches the argument predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Single(Expression<Func<T, bool>> predicate)
        {
            if( this.Exists(predicate) && this.Count(predicate) == 1 )
                return this.dbTable.Where(predicate).SingleOrDefault();
            else
                return this.First(predicate);
        }
        /// <summary>
        /// Returns the first occurence based on the spesified predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Returns null if ...</returns>
        public T First(Expression<Func<T, bool>> predicate)
        {

            var results = this.dbTable.Where(predicate);
            if (results.Any())
                return results.First();
            else
                return null;
        }



        /**
         * Fetch entity by id. Returns null if no entity is found
         **/
        public T GetById(int id)
        {
            return this.dbTable.Find(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Attach(T entity)
        {
            this.dbTable.Attach(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void AttachModified(T entity)
        {
            this.Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            this.AttachModified(entity);   
        }



        public void SaveChanges()
        {
            try
            {
                this._dbContext.SaveChanges();
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new Exception("Concurrency Issue. Please reload!");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._dbContext != null)
                {
                    this._dbContext.Dispose();
                    this._dbContext = null;
                }
            }
        }
    }//class
}//namespace
