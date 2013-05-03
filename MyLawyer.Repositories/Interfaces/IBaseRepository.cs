using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyLawyer.Entities;
using MyLawyer.DAL;

namespace MyLawyer.Repositories.Interfaces
{
    public interface IBaseRepository<T>: IDisposable where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        void Delete(ICollection<T> entities);

        IQueryable<T> Fetch();
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        List<T> SearchForToList(Expression<Func<T, bool>> predicate);
        List<T> FetchToList();
        T Single(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T GetById(int id);

        int CountAll();
        int Count(Expression<Func<T, bool>> predicate);

        bool Exists(Expression<Func<T, bool>> predicate);

        void SaveChanges();
        void Attach(T entity);
        void AttachModified(T entity);

        void Update(T entity);
    }
}
