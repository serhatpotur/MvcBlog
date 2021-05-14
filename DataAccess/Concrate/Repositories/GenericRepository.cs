using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        //ctor
        public GenericRepository()
        {
            _object = context.Set<T>();
        }
        public void Delete(T p)
        {
            var deleted = context.Entry(p);
            deleted.State = EntityState.Deleted;
            //_object.Remove(p);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var added = context.Entry(p);
            added.State = EntityState.Added;
            //_object.Add(p);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updated = context.Entry(p);
            updated.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
